import { Component, OnInit, OnDestroy, TemplateRef, Inject } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { CategoryShort } from '../models/category/category-short';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: [ './home.component.css' ]
})
export class HomeComponent implements OnInit, OnDestroy {
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean;
    modalRef: BsModalRef;
    categories: any = [];

    constructor(private http: HttpClient,
        @Inject('API_URL') private apiUrl: string,
        public authService: AuthService,
        public router: Router,
        private modalService: BsModalService) {
    }

    ngOnInit() {
        this.isAuthorizedSubscription = this.authService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
            });
        this.http.get<any>(this.apiUrl + 'category')
            .subscribe(result => {
                this.categories = result;
                console.log(this.categories);
            }, error => console.log(error));
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
    }

    showPetitions(name: string) {
        this.router.navigate(['/petitions']);   
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template, { class: 'modal-md' });
    }

    confirm(): void {
        this.authService.login();
        this.modalRef.hide();
    }

    cancel(): void {
        this.modalRef.hide();
    }

    public addPetition() {
        this.router.navigate(['/register-petition']);           
    }

}
