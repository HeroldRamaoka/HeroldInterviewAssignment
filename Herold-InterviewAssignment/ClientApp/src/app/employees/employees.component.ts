import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import { Employees } from '../models/employees';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public employees: Employees[];
  constructor(
    private employeesService: EmployeesService
  ) { }

  ngOnInit() {
    this.getAllEmployees();
  }

  getAllEmployees() {
    this.employeesService.getAllEmployees()
      .subscribe(output => {
        this.employees = output;
        console.log(this.employees);
      })
  }
}
