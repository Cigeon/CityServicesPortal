import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { MenuComponent } from './components/menu/menu.component';
import { RegisterPetitionComponent } from './components/petition/register-petition/register-petition.component';
import { RegisterCategoryComponent } from './components/category/register-category/register-category.component';

import { AuthModule, OidcSecurityService } from 'angular-auth-oidc-client';
import { AuthService } from './components/services/auth.service';
import { AllPetitionsComponent } from './components/petition/all-petitions/all-petitions.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        UnauthorizedComponent,
        MenuComponent,
        RegisterPetitionComponent,
        RegisterCategoryComponent,
        AllPetitionsComponent        
    ],
    imports: [
        AuthModule.forRoot(),
        CommonModule,
        HttpClientModule,
        FormsModule,
        FontAwesomeModule,
        ButtonsModule.forRoot(),
        BsDropdownModule.forRoot(),
        PaginationModule.forRoot(),
        TooltipModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'petitions', component: AllPetitionsComponent },
            { path: 'register-petition', component: RegisterPetitionComponent },
            { path: 'register-category', component: RegisterCategoryComponent },
            { path: 'unauthorized', component: UnauthorizedComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        AuthService,
        OidcSecurityService
    ]
})
export class AppModuleShared {
}

