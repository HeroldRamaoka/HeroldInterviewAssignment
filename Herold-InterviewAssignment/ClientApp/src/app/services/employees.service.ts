import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeesService {

  constructor(
    private http: HttpClient
  ) { }

    getAllEmployees() {
      
    }

}
