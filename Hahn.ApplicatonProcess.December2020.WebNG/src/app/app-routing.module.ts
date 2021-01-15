import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ApplicantComponent } from './applicant/applicant.component';

const routes: Routes = [
  {path:'applicant', component : ApplicantComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
