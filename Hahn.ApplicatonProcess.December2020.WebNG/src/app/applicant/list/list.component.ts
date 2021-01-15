import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private service: SharedService) { }

  ApplicantList:any=[];

  ModalTitle:string="";
  ActivateModifyComp:boolean=false;
  applicantData:any;


  ngOnInit(): void {
    this.refreshApplicantList();
  }

  addApplicantClick(){
    this.applicantData={
      id:0,
      name:"",
      familyName:"",
      address:"",
      countyOfOrigin:"",
      emailAddress:"",
      age:0,
      hired:false
    }

    this.ModalTitle = "Add New Applicant";
    this.ActivateModifyComp=true;
  }


  editApplicantClick(item){
    this.applicantData =item;
    this.ModalTitle = "Edit Applicant";
    this.ActivateModifyComp = true;
  }

  closeClick(){
    this.ActivateModifyComp=false;
    this.refreshApplicantList();
  }

  refreshApplicantList(){
    this.service.getApplicantList().subscribe(data=>{
      this.ApplicantList=data;
    })
  }

}
