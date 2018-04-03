import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Petition } from '../../models/petition/petition';
import { CategoryShort } from '../../models/category/category-short';
import { Constant } from '../../models/constant';
import { faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';


@Component({
  selector: 'app-all-petitions',
  templateUrl: './all-petitions.component.html',
  styleUrls: ['./all-petitions.component.css']
})
export class AllPetitionsComponent implements OnInit {
    faArrowAltCircleRight = faArrowAltCircleRight;
    allPetitions: Petition[] = [];
    petitions: Petition[] = [];
    categories: CategoryShort[] = []
    votesCount: number;
    sStatus: string = 'Всі';
    sCategory: string = 'Всі';

    constructor(private http: HttpClient,
        @Inject('API_URL') private apiUrl: string) {
        this.votesCount = Constant.VOTES_COUNT;
    }

    ngOnInit() {
        this.getPetitions()
            .subscribe(result => {
                this.allPetitions = result;
                this.petitions = result;
                console.log(result);
            }, error => console.log(error));
        this.getCategories()
            .subscribe(result => {
                this.categories = result;
                console.log(result);
            }, error => console.log(error));
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

    filterPetitions() {
        if (this.sCategory === 'Всі') {
            this.petitions = this.allPetitions;
        } else {
            this.petitions = this.allPetitions.filter(p => p.category.name === this.sCategory);
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

    getName(status: number) {
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
        }
    }

}
