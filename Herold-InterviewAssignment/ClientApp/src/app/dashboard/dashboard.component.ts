import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  logout(){
    this.userService.logout();
  }

  getEmployees() {
    this.userService.getEmployees()
      .pipe(first()).subscribe(result => {
        console.log(result);
      })
  }
}
