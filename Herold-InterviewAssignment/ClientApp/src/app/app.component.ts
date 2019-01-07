import { Component, OnInit } from '@angular/core';
import { UserProfile } from './models/userProfile';
import { Router } from '@angular/router';
import { EmployeesService } from './services/employees.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  public currentUser: string;

  constructor(){

  }

  ngOnInit(){
    this.currentUser = localStorage.getItem("currentUser");
  }

}
