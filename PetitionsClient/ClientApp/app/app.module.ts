import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AuthModule, OidcSecurityService } from 'angular-auth-oidc-client';
import { AuthService } from './components/services/auth.service';

import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { MenuComponent } from './components/menu/menu.component';
import { RegisterPetitionComponent } from './components/petition/register-petition/register-petition.component';
import { RegisterCategoryComponent } from './components/category/register-category/register-category.component';
import { AllPetitionsComponent } from './components/petition/all-petitions/all-petitions.component';
import { PetitionDetailComponent } from './components/petition/petition-detail/petition-detail.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';



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
        AllPetitionsComponent,
        PetitionDetailComponent,
        AdminDashboardComponent        
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
        ModalModule.forRoot(),
        AccordionModule.forRoot(),
        ProgressbarModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'petitions', component: AllPetitionsComponent },
            { path: 'petitions/:category', component: AllPetitionsComponent },
            { path: 'register-petition', component: RegisterPetitionComponent },
            { path: 'detail/:id', component: PetitionDetailComponent },
            { path: 'register-category', component: RegisterCategoryComponent },
            { path: 'admin', component: AdminDashboardComponent },
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

