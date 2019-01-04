import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employees } from '../models/employees';
import { UserProfile } from '../models/userProfile';

@Injectable()
export class EmployeesService {

  constructor(
    private http: HttpClient
  ) { }

    getAllEmployees(): Observable<Employees[]> {
      return this.http.get<Employees[]>("https://localhost:44327/api/Employee/employees/"
      );
    }

    userProfile(): Observable<UserProfile[]>{
      return this.http.get<UserProfile[]>("https://localhost:44327/api/Employee/userProfile/"
      );
 
    }

}
