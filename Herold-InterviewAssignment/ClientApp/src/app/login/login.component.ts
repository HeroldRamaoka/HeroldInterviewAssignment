import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from './user';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router'; 
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  loginError: boolean = false;
  constructor(
    private userService: UserService,
    private router: Router
  ) { }

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
      (err: HttpErrorResponse) => {
        this.loginError = true;
      })
  }

  getEmployees() {
    this.userService.getEmployees()
      .subscribe(output => {

      });
  }
}
