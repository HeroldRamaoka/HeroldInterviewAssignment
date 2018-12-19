import { Injectable } from '@angular/core';
import { Http } from '@angular/http'
import { User } from '../login/user';

@Injectable()
export class UserService {

  url = "http://staging.tangent.tngnt.co";

  constructor(private http: Http) {
   }

   login(user: User){
    return this.http.post(this.url + "/api-token-auth/", user);
   }

   getEmployees(){
     return this.http.get(this.url + "/api/employee/");
   }
}   
