import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserRegisterModel } from 'src/app/models/userRegisterModel';
import { environment } from '../../constants/enviroment'
import { Validation } from '../../constants/validations'
import { LoginComponent } from '../login/login.component';
import { NavigationBarComponent } from '../navigation-bar/navigation-bar.component';
import { UserLoginModel } from 'src/app/models/userLoginModel';
import { AuthenticationService } from 'src/app/services/AuthenticationService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  ngOnInit(): void {
    
  }

  registerModel = new UserRegisterModel('', '', '', '', '', new Date);
  repeatedPassword = '';
  isInputValid = false;
  passwordMatch = false;
  errorMessage = "";

  constructor(private http: HttpClient, private router: Router, private authenticationService: AuthenticationService) {}

  onSubmit() {
    this.checkValidation();

    if(this.isInputValid){
      this.registerModel.dateOfCreation = new Date();
      this.register(this.registerModel);
    }
    else{
      alert(this.errorMessage)
    }
  }

  checkValidation(){
    let firstNameElement = document.getElementById('firstName') as HTMLElement;
    let lastNameElement = document.getElementById('lastName') as HTMLElement;
    let userNameElement = document.getElementById('userName') as HTMLElement;
    let emailElement = document.getElementById('email') as HTMLElement;
    let passwordElement = document.getElementById('password') as HTMLElement;
    let passwordRepeatElement = document.getElementById('password-repeat') as HTMLElement;

    let firstNameCheck = false;
    let lastNameCheck = false;
    let userNameCheck = false;
    let emailCheck = false;
    let passwordCheck = false;


    if(!Validation.userValidations.nameValidation.test(this.registerModel.firstName)) {
      firstNameCheck = false;
      firstNameElement.style.borderBottomColor = 'red';
      firstNameElement.style.borderBottom = '3px solid red'
      this.errorMessage = "Invalid first name!"
    }
    else {
      firstNameCheck = true;
      firstNameElement.style.borderBottomColor = 'green';
      firstNameElement.style.borderBottom = '3px solid green'
    }

    //////

    if(!Validation.userValidations.nameValidation.test(this.registerModel.lastName)) {
      lastNameCheck = false;
      lastNameElement.style.borderBottomColor = 'red';
      lastNameElement.style.borderBottom = '3px solid red'
      this.errorMessage = "Invalid last name!"
    }
    else {
      lastNameCheck = true;
      lastNameElement.style.borderBottomColor = 'green';
      lastNameElement.style.borderBottom = '3px solid green'
    }
    
    //////

    if(!Validation.userValidations.userNameValidation.test(this.registerModel.userName)){
      userNameCheck = false;
      userNameElement.style.borderBottomColor = 'red';
      userNameElement.style.borderBottom = '3px solid red'
      this.errorMessage = "Invalid user name!"
    }
    else {
      userNameCheck = true;
      userNameElement.style.borderBottomColor = 'green';
      userNameElement.style.borderBottom = '3px solid green'
    }

    //////

    if(!Validation.userValidations.emailValidation.test(this.registerModel.email)) {
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

    if(Validation.userValidations.passwordValidation.test(this.registerModel.password) && Validation.userValidations.passwordValidation.test(this.repeatedPassword) 
       && this.repeatedPassword == this.registerModel.password && this.repeatedPassword.length > 0) {
      passwordCheck = true;
      passwordElement.style.borderBottomColor = 'green';
      passwordElement.style.borderBottom = '3px solid green'
      passwordRepeatElement.style.borderBottomColor = 'green';
      passwordRepeatElement.style.borderBottom = '3px solid green';
    }
    else{
      passwordCheck = false;
      passwordElement.style.borderBottomColor = 'red';
      passwordElement.style.borderBottom = '3px solid red'
      passwordRepeatElement.style.borderBottomColor = 'red';
      passwordRepeatElement.style.borderBottom = '3px solid red';
      this.errorMessage = "Invalid password / passwords do not match!"
    }

    //////

    if(firstNameCheck && lastNameCheck && userNameCheck && emailCheck && passwordCheck) {
      this.isInputValid = true;
    }
    else {
      this.isInputValid = false;
    }
  }
  
  register(data: UserRegisterModel) {
    this.http.post(`${environment.baseUrl}/users/new`, 
    data, 
    {headers:{'Content-Type':'application/json'}})
    .subscribe((result: any) => {
      alert("Success!");
      let data = {
        email: this.registerModel.email,
        password: this.registerModel.password
      }
      this.authenticationService.login(data).subscribe(x => {
        this.authenticationService.storeToken(x.token);
        NavigationBarComponent.isAuthorized = true;
        console.log("here")
        this.router.navigate(['home'])
      }, err => {
        alert("Incorrect email or password.")
      }); 
    }, (error: any) => {
      if(error.statusCode == "400"){
        alert("Error: Bad request.")
      }
      else{
        alert("Error: Try again later.")
      }
    });

  }
}

