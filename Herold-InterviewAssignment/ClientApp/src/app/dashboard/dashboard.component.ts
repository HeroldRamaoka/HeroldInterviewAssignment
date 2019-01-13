import { Component, OnInit, Output, ChangeDetectorRef } from '@angular/core';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';
import { EmployeesService } from '../services/employees.service';
import { Employees } from '../models/employees';
import { UserProfile } from '../models/userProfile';
import * as moment from 'moment';
import { UserProfileComponent } from '../user-profile/user-profile.component';
import { element } from 'protractor';
import { race } from 'rxjs/observable/race';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  currentUser: UserProfile;
  employees: UserProfile[];
  allemployees: Employees[];
  allRaces: UserProfile[];
  empReview: UserProfile[];
  numberOfReviews: any = 0;
  numberOfJobTitle: any = 0;
  numberOfemployees: any = 0;
  numberOfbirthdays: any = 0;
  numberOfLevels: any = 0;
  numberOfFemales: any = 0;
  numberOfMales: any = 0;
  numberOfRaces: any = 0;
  dataTable: any;
  numberOfColored: any = 0;
  numberOfBlack: any = 0;
  numberOfWhite: any = 0;
  numberOfIndians: any = 0;
  numberOfN: any = 0;

  constructor(
    private userService: UserService,
    private employeeService: EmployeesService,
    private chRef: ChangeDetectorRef,
    private router: Router

  ) { }

  ngOnInit() {
    this.getUserReviews();
    this.countEmployeesAndJobTitle();
    this.countBirthdays();
    this.countGender();
    this.countRaces();
  }

  logout() {
    this.userService.logout();
  }

  getUserReviews() {
    this.employeeService.userProfile()
      .subscribe((data: any) => {
        this.currentUser = data;

        this.numberOfReviews = this.currentUser.employee_review.length;

      })
  }

  countEmployeesAndJobTitle() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any[]) => {

        this.employees = data;

        // creating datatable for all users
        // this.chRef.detectChanges();
        // const table: any = $('#birthdateTable');
        // this.dataTable = table.DataTable();


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


  countGender() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any[]) => {
        this.employees = data;

        this.employees.forEach(element => {
          if (element.gender == "M") {
            this.numberOfMales += 1;
          } else {
            this.numberOfFemales += 1;
          }
        });
      })
  }

  countRaces() {
    this.employeeService.getAllEmployees()
      .subscribe((data: any) => {
        this.allRaces = data;

        var listofrace = new Array();

        this.allRaces.forEach(element => {
          if (element.race != null) {

            if (!listofrace.includes(element.race)) {
              listofrace.push(element.race);
            }

            if (element.race == "B") {
              this.numberOfBlack += 1;
            } else if (element.race == "W") {
              this.numberOfWhite += 1;
            } else if (element.race == "I") {
              this.numberOfIndians += 1;
            } else if (element.race == "N") {
              this.numberOfN += 1;
            } else if (element.race == "C") {
              this.numberOfColored += 1;
            }

          }
        });

        this.numberOfRaces = listofrace.length;
      })
  }

  gotoEmployees() {
    this.router.navigate(["/employees"]);
  }

}
