import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ButtonsModule } from 'ngx-bootstrap/buttons';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

import { AuthModule, OidcSecurityService } from 'angular-auth-oidc-client';
import { AuthService } from './components/services/auth.service';
import { MenuComponent } from './components/menu/menu.component';
import { NewPetitionComponent } from './components/new-petition/new-petition.component';
import { RegisterCategoryComponent } from './components/category/register-category/register-category.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        UnauthorizedComponent,
        MenuComponent,
        NewPetitionComponent,
        RegisterCategoryComponent
    ],
    imports: [
        AuthModule.forRoot(),
        CommonModule,
        HttpClientModule,
        FormsModule,
        ButtonsModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'create-petition', component: NewPetitionComponent },
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

