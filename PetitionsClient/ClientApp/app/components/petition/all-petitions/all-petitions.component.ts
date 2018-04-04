import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { Petition } from '../../models/petition/petition';
import { CategoryShort } from '../../models/category/category-short';
import { Constant } from '../../models/constant';
import { faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';
import { faSearch } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-all-petitions',
  templateUrl: './all-petitions.component.html',
  styleUrls: ['./all-petitions.component.css']
})
export class AllPetitionsComponent implements OnInit {
    faArrowAltCircleRight = faArrowAltCircleRight;
    faSearch = faSearch;
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
        @Inject('API_URL') private apiUrl: string) {
        this.votesCount = Constant.VOTES_COUNT;
        this.statuses = Constant.PETITIONS_STATUS;
    }

    ngOnInit() {
        this.getPetitions()
            .subscribe(result => {                
                this.allPetitions = result;
                this.filteredPetitions = result;
                if (this.allPetitions.length < 10) {
                    this.showedItems = this.allPetitions.length;
                } else { this.showedItems = 10; }
                this.itemsPerPage = 10;
                this.shownPetitions = this.filteredPetitions.slice(0, this.itemsPerPage);
                console.log(this.shownPetitions);
            }, error => console.log(error));
        this.getCategories()
            .subscribe(result => {
                this.categories = result;
                console.log(result);
            }, error => console.log(error));      

        
    }

    setItemsPerPage(value: number) {
        this.itemsPerPage = value;
        this.filteredPetitions = this.allPetitions;
        this.shownPetitions = this.filteredPetitions.slice(0, this.itemsPerPage);
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
            this.getStatus(this.sStatus)
            this.filteredPetitions = this.filteredPetitions.filter(p => p.status === this.getStatus(this.sStatus));
        }
        // search
        if (this.searchQuery !== '') {
            this.filteredPetitions = this.filteredPetitions.filter(p =>
                p.name.toLowerCase().includes(this.searchQuery) ||
                p.category.name.toLowerCase().includes(this.searchQuery) ||
                p.created.toLowerCase().includes(this.searchQuery) ||
                p.user.lastName.toLowerCase().includes(this.searchQuery) ||
                this.getName(p.status).toLowerCase().includes(this.searchQuery));
        }
    }

    getColor(status: number) {
        switch (status) {
            case 0:
                return '#c1afb1';
            case 1:
                return '#1ba1e2';
            case 2:
                return '#ffb410';
            case 3:
                return '#028900';
            case 4:
                return '#ff0065';
        }
    }

    getName(status: number): string {
        switch (status) {
            case 0:
                return 'Перевірка';
            case 1:
                return 'Збір голосів';
            case 2:
                return 'Розглядається';
            case 3:
                return 'З відповіддю';
            case 4:
                return 'Не підтримано';
            default:
                return '';
        }
    }

    getStatus(name: string): number {
        switch (name) {
            case 'Перевірка':
                return 0;
            case 'Збір голосів':
                return 1;
            case 'Розглядається':
                return 2;
            case 'З відповіддю':
                return 3;
            case 'Не підтримано':
                return 4;
            default:
                return -1;
        }
    }

}
