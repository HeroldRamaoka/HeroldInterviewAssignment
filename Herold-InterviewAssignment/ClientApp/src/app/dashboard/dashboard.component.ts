import { Component, OnInit, Output } from '@angular/core';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private userService: UserService, private employeeService: EmployeesService) { }

  ngOnInit() {
  }

  logout(){
    this.userService.logout();
  }

  

}
