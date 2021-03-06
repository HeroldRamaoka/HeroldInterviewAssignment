import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { Employee } from '../models/employee';
import { User } from '../../account/login/user';

@Injectable()
export class UserService {

  constructor(private http: HttpClient,
    private router: Router
    ) {
   }

   login(user: User) {
     const payload = {
       'password': user.Password,
       'username': user.Username
     };

    return this.http.post<any>("https://localhost:44327/api/Account/token/", payload)

   }

   logout() {
     localStorage.removeItem('currentUser'); 
    this.http.get<any>("https://localhost:44327/api/Account/logout/")
    window.location.href = "/login";
   }

}   
