import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-app-navbar',
  templateUrl: './app-navbar.component.html',
  styleUrls: ['./app-navbar.component.css']
})
export class AppNavbarComponent implements OnInit {
  public employee: Employee[];
  constructor(
    private userService: UserService,
    private http: HttpClient,
    private router: Router
    ) { }

  ngOnInit() {
    this.userProfile();
  }

  userProfile(){
    return this.http.get<Employee[]>("http://staging.tangent.tngnt.co/api/user/me/", {
      headers: new HttpHeaders({'Authorization': 'Token ' + localStorage.getItem("currentUser")})
      
    }).subscribe(res => {
      this.employee = res;
    })

  }

  logout(): void {
    this.userService.logout();
  }

  gotoUserProfile(): void {
    this.router.navigate(['/userprofile']);
  }

  gotoEmployees(): void {
    this.router.navigate(['/employees']);
  }
}
