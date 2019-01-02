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
    this.success();
    this.failToLogIn();
  }

  login(){
    this.userService.login(this.user) 
      .pipe(first()).subscribe(result => {

        console.log(result);
        if(result && result.token){

          localStorage.setItem('currentUser', result.token);
          this.router.navigate(['/nav']);

        }else{
          // console.log("something went wrong");
          this.failToLogIn();
        }
      })
  }


  success() {
    this.toastr.success('Hello', "You are in");
  }

  failToLogIn() {
    this.toastr.error('Invalid Credentials', "Please verify your login credentials!");
  }
}
