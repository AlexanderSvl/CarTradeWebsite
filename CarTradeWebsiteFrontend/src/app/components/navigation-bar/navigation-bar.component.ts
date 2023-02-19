import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/AuthenticationService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  public static isAuthorized = false;

  constructor(private authenticationService: AuthenticationService, private router: Router){}

  ngOnInit(): void {
    NavigationBarComponent.isAuthorized = this.authenticationService.isLoggedIn();
  }

  get isAuthorized() {
    return NavigationBarComponent.isAuthorized;
  }

  logout() {
    this.authenticationService.logout();
    this.ngOnInit();
    this.router.navigate(['home'])
  }
}
