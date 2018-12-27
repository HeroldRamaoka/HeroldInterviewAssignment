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
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserService } from './services/user.service';
import { HttpModule } from '@angular/http';
import { AuthGuard } from './guards/auth.guard';
import { JwtInterceptor } from './interceptor/jwt.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path:  'login', component: LoginComponent },
      { path: 'counter', component: CounterComponent, canActivate: [AuthGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
      {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},

      {path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    AuthGuard,
    UserService
    //{
      // provide: HTTP_INTERCEPTORS,
      // useClass: JwtInterceptor,
      // multi: true
    //}
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
