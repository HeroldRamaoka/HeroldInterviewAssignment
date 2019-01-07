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
  currentUser: string;

  constructor(
    private userService: UserService,
    private http: HttpClient,
    private router: Router
    ) { }

  ngOnInit() {
    this.getToken();
    this.userLoggedin();
  }

  userLoggedin(){
    return this.http.get<Employee[]>("https://localhost:44327/api/Employee/currentUser/").subscribe(res => {
      this.employee = res;
    })

  }

  logout(): void {
    this.userService.logout();
  }

  getToken(){
    this.currentUser = localStorage.getItem("currentUser");
  }

  gotoUserProfile(): void {
    this.router.navigate(['/userprofile']);
  }

  gotoEmployees(): void {
    this.router.navigate(['/employees']);
  }

  gotoDashboard(): void {
    this.router.navigate(['/dashboard']);
  }
}
