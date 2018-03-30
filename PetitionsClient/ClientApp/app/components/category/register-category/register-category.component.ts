import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-category',
  templateUrl: './register-category.component.html',
  styleUrls: ['./register-category.component.css']
})
export class RegisterCategoryComponent implements OnInit {
    name: string = "";
    description: string = "";

    constructor() { }

    ngOnInit() {
    }

    public submit() {
        console.log(this.name + " " + this.description);
    }

}
