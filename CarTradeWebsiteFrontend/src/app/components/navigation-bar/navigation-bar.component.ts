import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/AuthenticationService';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  public static isAuthorized = false;

  constructor(private authenticationService: AuthenticationService, private router: Router, private toast: NgToastService){}

  ngOnInit(): void {
    NavigationBarComponent.isAuthorized = this.authenticationService.isLoggedIn();
  }

  get isAuthorized() {
    return NavigationBarComponent.isAuthorized;
  }

  logout() {
    this.toast.warning({detail:"WARNING",summary:'Successfully logged out!',duration:4000, position: "tl"});
    this.authenticationService.logout();
    this.ngOnInit();
    this.router.navigate([''])
  }
}
