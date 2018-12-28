import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AccountComponent } from './account.component';
import { UserService } from '../app/services/user.service';


@NgModule({
  declarations: [
    AccountComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path:  'account/login', component: LoginComponent },

      {path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    UserService
  ],
  bootstrap: [AccountComponent]
})
export class AccountModule { }
