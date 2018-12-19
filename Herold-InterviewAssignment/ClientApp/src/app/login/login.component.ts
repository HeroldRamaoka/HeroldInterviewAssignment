import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from './user';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  constructor(
    private userService: UserService
  ) { }

  ngOnInit() {
    this.getEmployees();
  }

  login(){
    this.userService.login(this.user) 
      .pipe(first()).subscribe(result => {
        this.user = result.json();

        console.log(this.user.Password);

      })
  }

  getEmployees() {
    this.userService.getEmployees()
      .pipe(first()).subscribe(output => {
        var res = output.json();
        console.log(res);
      });
  }
}
