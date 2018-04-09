import { Component, OnInit, Inject, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Petition } from '../../models/petition/petition';
import { Observable } from 'rxjs/Observable';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';
import { faCheckCircle } from '@fortawesome/free-regular-svg-icons';
import { Constant } from '../../models/constant';


@Component({
  selector: 'app-petition-detail',
  templateUrl: './petition-detail.component.html',
  styleUrls: ['./petition-detail.component.css']
})
export class PetitionDetailComponent implements OnInit {
    faCheckCircle = faCheckCircle;
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean = false;
    petitionId: string = '';
    petitionSubscription: Subscription;
    userDataSubscription: Subscription;
    voteSubscription: Subscription;
    reviewSubscription: Subscription;
    isVoted: boolean = false;
    isAuthor: boolean = false;
    modalRef: BsModalRef;
    petition: Petition;
    petitionLoaded: boolean = false;
    votesCount: number;
    isCollapsed: boolean = true;
    review: string = '';

    constructor(public authService: AuthService,
                public router: Router,
                private modalService: BsModalService,
                private http: HttpClient,
                @Inject('API_URL') private apiUrl: string,
                private route: ActivatedRoute) {
        this.route.params.subscribe(params => this.getPetition(params['id']));
        this.votesCount = Constant.VOTES_COUNT;
    }

    ngOnInit() {
        this.isAuthorizedSubscription =
                this.authService.getIsAuthorized().subscribe(
                (isAuthorized: boolean) => {
                    this.isAuthorized = isAuthorized;
                }, error => console.log(error));
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
        this.userDataSubscription.unsubscribe();
        if (this.reviewSubscription) {
            this.reviewSubscription.unsubscribe();
        }
        if (this.petitionSubscription) {
            this.petitionSubscription.unsubscribe();
        }
    }

    getPetition(id: string): void {
        this.petitionId = id;
        this.petitionSubscription =
            this.http.get<any>(this.apiUrl + 'petition/' + id)
            .subscribe(result => {  
                console.log('petition: ', result);
                this.petitionLoaded = true;
                this.petition = result;

                this.userDataSubscription =
                    this.authService.getUserData().subscribe(
                        (userData: any) => {
                            console.log('user data: ', userData);
                            this.isVoted = this.petition.voters.filter(v => v.userName === userData.email).length > 0
                            this.isAuthor = this.petition.user.userName === userData.email;
                            console.log('voted: ', this.isVoted);
                            console.log('author: ', this.isAuthor);
                        }, error => console.log(error));

            }, error => console.log(error));

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

    public votePetition() {
        this.voteSubscription =
            this.authService.put(this.apiUrl + 'petition/vote/' + this.petition.id, null)
                .subscribe(result => {
                    console.log(result);
                    this.getPetition(this.petitionId);
                }, error => console.error(error)); 
    }

    collapsed(event: any): void {
        console.log(event);
    }

    expanded(event: any): void {
        console.log(event);
    }

    saveReview(): void {
        this.isCollapsed = true;
        this.reviewSubscription =
            this.authService.post(this.apiUrl + 'petition/review/' + this.petition.id, this.review)
                .subscribe(result => {
                    console.log(result);
                    this.getPetition(this.petitionId);
                }, error => console.error(error));
    }

    cancelReview(): void {
        this.isCollapsed = true;
        this.review = '';
    }

    getName(status: number): string {
        console.log(status);
        return Constant.STATUS_NAME(status);
    }

    getStatus(name: string): number {
        return Constant.STATUS_VALUE(name);
    }

    getColor(status: number) {
        return Constant.STATUS_COLOR(status);
    }


}
