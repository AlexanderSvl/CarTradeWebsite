import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { DetailsComponent } from './components/details/details.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'search', component: SearchComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'posts/:ID', component: DetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
