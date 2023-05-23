import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { DetailsComponent } from './components/details/details.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { AddListingComponent } from './components/add-listing/add-listing.component';
import { AuthenticationGuard } from './guards/authenticationGuard';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthenticationGuard]},
  { path: 'search', component: SearchComponent, canActivate: [AuthenticationGuard]},
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'posts/:ID', component: DetailsComponent, canActivate: [AuthenticationGuard]},
  { path: '', component: LandingPageComponent },
  { path: 'new-listing', component: AddListingComponent, canActivate: [AuthenticationGuard]},
  { path: 'searchResults', component: SearchResultsComponent, canActivate: [AuthenticationGuard]},
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
