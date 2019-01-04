import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import { UserProfile } from '../models/userProfile';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  public users: UserProfile[];
  
  data = [];
  constructor(
    private employeeService: EmployeesService
  ) { }

  ngOnInit() {
    this.getUserProfile();
  }

  getUserProfile() {
    this.employeeService.userProfile()
      .subscribe(output => {
        this.users = output;
      })
  }

}
