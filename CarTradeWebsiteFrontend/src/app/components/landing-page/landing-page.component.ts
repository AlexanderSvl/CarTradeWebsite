import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/AuthenticationService';
import { Router } from "@angular/router";

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {
  constructor(private authenticationService: AuthenticationService, private router: Router){}

  ngOnInit(): void {
    if(this.authenticationService.isLoggedIn()){
      this.router.navigate(["home"]);
    }
  }
}
