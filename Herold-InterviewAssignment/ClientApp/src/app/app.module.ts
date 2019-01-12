import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserService } from './services/user.service';
import { HttpModule } from '@angular/http';
import { AuthGuard } from './guards/auth.guard';
import { JwtInterceptor } from './interceptor/jwt.interceptor';
// import { LoginComponent } from '../account/login/login.component';
import { AccountComponent } from '../account/account.component';
import { LoginComponent } from './login/login.component';
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppNavbarComponent } from './app-navbar/app-navbar.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeesService } from './services/employees.service';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { Page404Component } from './page404/page404.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    DashboardComponent,
    AccountComponent,
    AppNavbarComponent,
    EmployeesComponent,
    UserProfileComponent,
    Page404Component
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    ToastModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      {path: 'appcomponent', component: AppComponent},
      { path: 'counter', component: CounterComponent, canActivate: [AuthGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
      {path: 'dashboard', component: DashboardComponent },
      {path: 'userprofile', component: UserProfileComponent, canActivate: [AuthGuard]},
      {path: 'employees', component: EmployeesComponent, canActivate: [AuthGuard]},
      {path: 'nav', component: AppNavbarComponent, canActivate: [AuthGuard]},

      {path: '**', component: Page404Component }
    ])
  ],
  providers: [
    AuthGuard,
    UserService,
    EmployeesService
    //{
      // provide: HTTP_INTERCEPTORS,
      // useClass: JwtInterceptor,
      // multi: true
    //}
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
