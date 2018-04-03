import { Component, OnInit, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { RegisterPetition } from '../../models/petition/register-petition';
import { CategoryShort } from '../../models/category/category-short';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-register-petition',
  templateUrl: './register-petition.component.html',
  styleUrls: ['./register-petition.component.css']
})
export class RegisterPetitionComponent implements OnInit {
    petition: RegisterPetition = { categoryId: '', name: '', description: '', userName: '' };
    currCategory: string = 'Оберіть категорію ...';
    categories: any = [];

    constructor(private http: HttpClient,
        private authService: AuthService,
        @Inject('API_URL') private apiUrl: string,
        private location: Location) {
    }

    ngOnInit() {
        this.getCategories()
            .subscribe(result => {
                this.categories = result;
                console.log(this.categories);
            });
    }

    private getCategories(): Observable<CategoryShort[]> {
        return this.http.get<any>(this.apiUrl + 'category');
    }

    selectCatagory(category: any) {
        this.currCategory = category.name;
        this.petition.categoryId = category.id;
    }

    submit() {
        this.registerPetition();
    }

    private registerPetition() {
        console.log(this.petition);
        this.authService.post(this.apiUrl + 'petition', this.petition)
            .subscribe(result => {
                console.log(result);
                this.location.back();
            }, error => console.error(error));        
    }

}
