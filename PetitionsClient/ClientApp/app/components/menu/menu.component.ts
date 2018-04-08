import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { AuthService } from '../services/auth.service';
import { Constant } from '../models/constant';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit, OnDestroy {
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean = false;
    userDataSubscription: Subscription;
    isAdmin: boolean = false;

    constructor(public authService: AuthService) {
    }

    ngOnInit() {
        this.isAuthorizedSubscription = this.authService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;

                this.userDataSubscription =
                    this.authService.getUserData().subscribe(
                        (userData: any) => {
                            console.log('user data: ', userData);
                            if (userData) {
                                this.isAdmin = userData.user_rights >= Constant.ADMIN_RIGHTS;
                                console.log('isAdmin: ', this.isAdmin);
                            }                           
                        }, error => console.log(error));
            });        
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
        if (this.userDataSubscription) {
            this.userDataSubscription.unsubscribe();
        }        
    }

    public login() {
        this.authService.login();
    }

    public refreshSession() {
        this.authService.refreshSession();
    }

    public logout() {
        this.authService.logout();
    }

}
