import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { User } from './user';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router'; 
import { UserService } from '../services/user.service';
import { ToastModule } from 'ng2-toastr';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
// import { UserService } from '../../app/services/user.service';
import {BrowserModule} from '@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  constructor(
    private userService: UserService,
    private router: Router,
    public toastr: ToastsManager, vcr: ViewContainerRef
  ) {
    this.toastr.setRootViewContainerRef(vcr);
   }

  ngOnInit() {
    this.userService.logout();
  }

  login(){
    this.userService.login(this.user) 
      .pipe(first()).subscribe(result => {

        if(result && result.token){
          localStorage.setItem('currentUser', result.token);
          this.router.navigate(['/dashboard']);
        }
      },
      err => {
          this.failToLogIn();
      })
  }

  failToLogIn() {
    this.toastr.error('Please verify your login credentials', "Invalid credentials!");
  }
}
