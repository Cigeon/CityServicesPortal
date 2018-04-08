import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { Petition } from '../models/petition/petition';
import { CategoryShort } from '../models/category/category-short';
import { faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { Observable } from 'rxjs/Observable';
import { ActivatedRoute, Router } from '@angular/router';
import { Constant } from '../models/constant';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit, OnDestroy {
    faArrowAltCircleRight = faArrowAltCircleRight;
    faSearch = faSearch;
    getPetitionsSubscription: Subscription;
    refreshPetitionsSubscription: Subscription;
    getCategoriesSubscription: Subscription;
    allPetitions: Petition[] = [];
    filteredPetitions: Petition[] = [];
    shownPetitions: Petition[] = [];
    categories: CategoryShort[] = [];
    statuses: string[] = [];
    searchQuery: string = '';
    votesCount: number;
    sStatus: string = 'Всі';
    sCategory: string = 'Всі';
    itemsPerPage: number = 0;
    showedItems: number = 0;
    itemsPerPageList: number[] = [1, 2, 5, 10, 15, 20];
    currentPage: number = 0;

    constructor(private http: HttpClient,
        @Inject('API_URL') private apiUrl: string,
        private authService: AuthService,
        public router: Router,
        private route: ActivatedRoute) {
        this.votesCount = Constant.VOTES_COUNT;
        this.statuses = Constant.PETITIONS_STATUS;
        this.route.params.subscribe(params => {
            this.sCategory = params['category'];
            if (this.sCategory == null) { this.sCategory = 'Всі'; };
        });
    }

    ngOnInit() {
        this.getPetitionsSubscription =
            this.http.get<any>(this.apiUrl + 'petition')
                .subscribe(result => {
                    this.allPetitions = result;
                    this.filteredPetitions = result;
                    if (this.allPetitions.length < 10) {
                        this.showedItems = this.allPetitions.length;
                    } else { this.showedItems = 10; }
                    this.itemsPerPage = 10;
                    this.filterPetitions();
                    console.log(this.shownPetitions);
                }, error => console.log(error));
        this.getCategoriesSubscription =
            this.getCategories()
                .subscribe(result => {
                    this.categories = result;
                    console.log(result);
                }, error => console.log(error));


    }

    ngOnDestroy(): void {
        this.getPetitionsSubscription.unsubscribe();
        this.getCategoriesSubscription.unsubscribe();
        if (this.refreshPetitionsSubscription) {
            this.refreshPetitionsSubscription.unsubscribe();
        }
    }

    setItemsPerPage(value: number) {
        this.itemsPerPage = value;
        this.filterPetitions();
    }

    pageChanged(event: PageChangedEvent): void {
        const startItem = (event.page - 1) * event.itemsPerPage;
        const endItem = event.page * event.itemsPerPage;
        this.shownPetitions = this.filteredPetitions.slice(startItem, endItem);
        console.log(startItem, endItem);
    }

    showPetitions() {

    }

    private getPetitions(): Observable<Petition[]> {
        return this.http.get<any>(this.apiUrl + 'petition');
    }

    private getCategories(): Observable<CategoryShort[]> {
        return this.http.get<any>(this.apiUrl + 'category');
    }

    selectCatagory(category: string) {
        this.sCategory = category;
        this.filterPetitions();
    }

    selectStatus(status: string) {
        this.sStatus = status;
        this.filterPetitions();
    }

    search() {
        console.log(this.searchQuery);
        this.filterPetitions();
    }

    filterPetitions() {
        // filer by category
        if (this.sCategory === 'Всі') {
            this.filteredPetitions = this.allPetitions;
        } else {
            this.filteredPetitions = this.allPetitions.filter(p => p.category.name === this.sCategory);
        }
        // filer by status
        if (this.sStatus !== 'Всі') {
            console.log(this.sStatus);
            //this.getStatusValue(this.sStatus)
            this.filteredPetitions = this.filteredPetitions.filter(p => p.status === this.getStatusValue(this.sStatus));
        }
        // search
        if (this.searchQuery !== '') {
            this.filteredPetitions = this.filteredPetitions.filter(p =>
                p.name.toLowerCase().includes(this.searchQuery) ||
                p.category.name.toLowerCase().includes(this.searchQuery) ||
                p.created.toLowerCase().includes(this.searchQuery) ||
                p.user.lastName.toLowerCase().includes(this.searchQuery) ||
                this.getStatusName(p.status).toLowerCase().includes(this.searchQuery));
        }

        this.shownPetitions = this.filteredPetitions.slice(0, this.itemsPerPage);
    }

    showPetitionDetail(id: string) {
        this.router.navigate(['/detail/' + id]);
    }

    approvePetition(id: string) {
        this.authService.put(this.apiUrl + 'petition/status/' + id, this.getStatusValue('Збір голосів'))
            .subscribe(result => {
                console.log(result);

                this.allPetitions = [];
                this.refreshPetitionsSubscription =
                    this.http.get<any>(this.apiUrl + 'petition')
                        .subscribe(result => {
                            this.allPetitions = result;
                            this.filteredPetitions = result;
                            if (this.allPetitions.length < 10) {
                                this.showedItems = this.allPetitions.length;
                            } else { this.showedItems = 10; }
                            this.itemsPerPage = 10;
                            this.filterPetitions();
                            console.log(this.shownPetitions);
                        }, error => console.log(error));

            }, error => console.error(error));   
    }

    deletePetition(id: string) {
        this.authService.delete(this.apiUrl + 'petition/' + id)
            .subscribe(result => {
                console.log(result);

                this.allPetitions = [];
                this.refreshPetitionsSubscription =
                    this.http.get<any>(this.apiUrl + 'petition')
                        .subscribe(result => {
                            this.allPetitions = result;
                            this.filteredPetitions = result;
                            if (this.allPetitions.length < 10) {
                                this.showedItems = this.allPetitions.length;
                            } else { this.showedItems = 10; }
                            this.itemsPerPage = 10;
                            this.filterPetitions();
                            console.log(this.shownPetitions);
                        }, error => console.log(error));

            }, error => console.error(error));       
    }

    getStatusColor(status: number) {
        return Constant.STATUS_COLOR(status);
    }

    getStatusName(status: number): string {
        return Constant.STATUS_NAME(status);
    }

    getStatusValue(name: string): number {
        return Constant.STATUS_VALUE(name);
    }

}
