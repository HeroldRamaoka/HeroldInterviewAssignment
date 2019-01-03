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
      return this.http.get<Employees[]>("http://staging.tangent.tngnt.co/api/employee/",{
        headers: new HttpHeaders({'Authorization': 'Token ' + localStorage.getItem("currentUser")})
      })
    }

    userProfile(): Observable<UserProfile[]>{
      return this.http.get<UserProfile[]>("http://staging.tangent.tngnt.co/api/employee/me/", {
        headers: new HttpHeaders({'Authorization': 'Token ' + localStorage.getItem("currentUser")})
      });
 
    }

}
