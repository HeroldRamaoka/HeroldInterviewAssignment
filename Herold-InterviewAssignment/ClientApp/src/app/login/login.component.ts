import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router'; 
import { UserService } from '../services/user.service';
// import { UserService } from '../../app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
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

        console.log(result);
        if(result && result.token){

          localStorage.setItem('currentUser', result.token);
          this.router.navigate(['/dashboard']);

        }else{
          console.log("something went wrong");
        }
      })
  }

  getUserProfile() {
    this.userService.userProfile()
      .subscribe(output => {
          
      });
  }
}
