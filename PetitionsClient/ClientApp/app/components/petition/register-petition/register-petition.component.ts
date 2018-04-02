import { Component, OnInit, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { RegisterPetition } from '../../models/petition/register-petition';
import { CategoryShort } from '../../models/category/category-short';
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

    constructor(private authService: AuthService,
        @Inject('API_URL') private apiUrl: string,
        private location: Location) {
    }

    ngOnInit() {
        this.authService.get(this.apiUrl + 'category')
            .subscribe(result => {
                this.categories = result;
                console.log(this.categories);
            });
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
