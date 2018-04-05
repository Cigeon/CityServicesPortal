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
    isAuthorized: boolean;
    modalRef: BsModalRef;
    petition: Petition;
    petitionLoaded: boolean = false;
    votesCount: number;

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
        this.isAuthorizedSubscription = this.authService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
            });
        console.log(this.petition);
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
    }

    getPetition(id: string): void {
        this.http.get<any>(this.apiUrl + 'petition/' + id)
            .subscribe(result => {  
                console.log(result);
                this.petitionLoaded = true;
                this.petition = result;
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
        this.router.navigate(['/register-petition']);
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
