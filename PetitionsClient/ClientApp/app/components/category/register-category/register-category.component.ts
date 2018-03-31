import { Component, OnInit, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { CreateCategory } from '../../models/category/create-category';

@Component({
  selector: 'app-register-category',
  templateUrl: './register-category.component.html',
  styleUrls: ['./register-category.component.css']
})
export class RegisterCategoryComponent implements OnInit {    
    category: CreateCategory = { name: '', description: '' };

    constructor(private authService: AuthService,
        @Inject('API_URL') private apiUrl: string,
        private location: Location) {
    }

    ngOnInit() {
    }

    public submit() {
        this.createCategory();
    }

    private createCategory() {
        console.log(this.category);
        this.authService.post(this.apiUrl + 'Category', this.category)
            .subscribe(result => { console.log("result"); console.log(result); }, error => console.error(error));
        this.location.back();
    }

}