import { Component, OnInit, Output } from '@angular/core';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';
import { EmployeesService } from '../services/employees.service';
import { Employees } from '../models/employees';
import { UserProfile } from '../models/userProfile';
import * as moment from 'moment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  currentUser: UserProfile[];
  allemployees: Employees[];
  empReview: UserProfile[];
  reviews: any[];
  numberOfJobTitle: any = 0;
  numberOfemployees: any = 0;
  numberOfbirthdays: any = 0;
  numberOfLevels: any = 0;

  constructor(private userService: UserService, private employeeService: EmployeesService) { }

  ngOnInit() {
    this.getsingleUser();
    this.countEmployeesAndJobTitle();
    this.countBirthdays();
    this.countLevel();
  }

  logout() {
    this.userService.logout();
  }

  getsingleUser() {
    this.employeeService.userProfile()
      .subscribe((data: any[]) => {
        this.currentUser = data;

      })
  }

  countEmployeesAndJobTitle() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any[]) => {
        this.allemployees = data;
        this.numberOfemployees = this.allemployees.length;

        var listoftitle = new Array();

        this.allemployees.forEach(element => {
          if (element.position != null) {

            if (!listoftitle.includes(element.position.name)) {
              listoftitle.push(element.position.name);
            }

          }
        });

        this.numberOfJobTitle = listoftitle.length;
      })
  }

  countBirthdays() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any[]) => {
        this.allemployees = data;

        this.allemployees.forEach(element => {
          var a = moment(new Date(element.birth_date), "DD/MM/YYYY");
          var b = moment(new Date(), "DD/MM/YYYY");

          if (a.format("M") == b.format("M")) {
            this.numberOfbirthdays += 1;
          }

        }
        );

      })
  }

  countLevel() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any[]) => {
        this.allemployees = data;
        this.numberOfemployees = this.allemployees.length;

        var listoftitle = new Array();

        this.allemployees.forEach(element => {
          if (element.position != null) {

            if (!listoftitle.includes(element.position.level)) {
              listoftitle.push(element.position.level);
            }

          }
        });

        this.numberOfLevels = listoftitle.length;
      })
  }

}
