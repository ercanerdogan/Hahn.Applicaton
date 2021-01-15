import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApplicantComponent } from './applicant/applicant.component';
import { ListComponent } from './applicant/list/list.component';
import { ModifyComponent } from './applicant/modify/modify.component';
import { SharedService } from './shared.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    AppComponent,
    ApplicantComponent,
    ListComponent,
    ModifyComponent
  ],  
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
