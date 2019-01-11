import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import { Employees } from '../models/employees';
import * as $ from 'jquery';
import 'datatables.net';
import 'datatables.net-bs4';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {

 employees: Employees[] = [];
  dataTable: any;

  constructor(
    private employeesService: EmployeesService,
    private chRef: ChangeDetectorRef
  ) { }

  ngAfterViewInit() {
    this.getAllEmployees();
  }

  getAllEmployees() {
    this.employeesService.getAllEmployees()
      .subscribe((output: any[]) => {
        this.employees = output;
        console.log(this.employees);
        this.chRef.detectChanges();
        const table: any = $('table');
        this.dataTable = table.DataTable();
      })
  }
}
