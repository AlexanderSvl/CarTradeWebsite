import { Component } from '@angular/core';
import { UserLoginModel } from 'src/app/models/userLoginModel';
import { HttpClient} from '@angular/common/http';
import { Router } from "@angular/router";
import { routePaths } from 'src/app/constants/routes';
import { Validation } from '../../constants/validations'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginModel = new UserLoginModel("", "");
  isInputValid = false;
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router){}

  onSubmit(){
    this.checkValidation();
    
    if(this.isInputValid){
      this.login(this.loginModel);
    }
    else{
      alert(this.errorMessage);
    }
  };

  checkValidation(){
    let emailElement = document.getElementById('email') as HTMLElement;
    let passwordElement = document.getElementById('password') as HTMLElement;

    let emailCheck = false;
    let passwordCheck = false;

    if(!Validation.emailValidation.test(this.loginModel.email)) {
      emailCheck = false;
      emailElement.style.borderBottomColor = 'red';
      emailElement.style.borderBottom = '3px solid red'
      this.errorMessage = "Invalid email!"
    }
    else {
      emailCheck = true;
      emailElement.style.borderBottomColor = 'green';
      emailElement.style.borderBottom = '3px solid green'
    }

    //////

    if(Validation.passwordValidation.test(this.loginModel.password)) {
      passwordCheck = true;
      passwordElement.style.borderBottomColor = 'green';
      passwordElement.style.borderBottom = '3px solid green'
    }
    else{
      passwordCheck = false;
      passwordElement.style.borderBottomColor = 'red';
      passwordElement.style.borderBottom = '3px solid red'
      this.errorMessage = "Invalid password / passwords do not match!"
    }

    if(emailCheck && passwordCheck) {
      this.isInputValid = true;
    }
    else {
      this.isInputValid = false;
    }
  }

  login(data:UserLoginModel){
    console.log(data);
  };
}
