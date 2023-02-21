import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthenticationService } from '../services/AuthenticationService';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationGuard implements CanActivate {

  constructor (private auth: AuthenticationService, private router: Router){}

  canActivate() :boolean {
    if(this.auth.isLoggedIn()){
      return true;
    }
    else{
      this.router.navigate([""]).then(x => window.location.reload());
      return false;
    }
  }
}