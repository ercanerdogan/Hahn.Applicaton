import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-modify',
  templateUrl: './modify.component.html',
  styleUrls: ['./modify.component.css'],
})
export class ModifyComponent implements OnInit {
  constructor(private service: SharedService) {}

  @Input() applicantData: any;

  id: number | undefined;
  name: string | undefined;
  familyName: string | undefined;
  address: string | undefined;
  countyOfOrigin: string | undefined;
  emailAddress: string | undefined;
  age: number | undefined;
  hired: boolean=false;

  ngOnInit(): void {
    this.id = this.applicantData.id;
    this.name = this.applicantData.name;
    this.familyName = this.applicantData.familyName;
    this.address = this.applicantData.address;
    this.countyOfOrigin = this.applicantData.countyOfOrigin;
    this.emailAddress = this.applicantData.emailAddress;
    this.age = this.applicantData.age;
    this.hired = this.applicantData.hired;
  }

  addApplicant() {
    var val = {
      id: this.id,
      name: this.name,
      familyName: this.familyName,
      address: this.address,
      countyOfOrigin: this.countyOfOrigin,
      emailAddress: this.emailAddress,
      age: this.age,
      hired: this.hired
    };

    this.service.addApplicant(val).subscribe((res) => {
      alert(res.toString());
    });
  }

  updateApplicant() {
    var val = {
      id: this.id,
      name: this.name,
      familyName: this.familyName,
      address: this.address,
      countyOfOrigin: this.countyOfOrigin,
      emailAddress: this.emailAddress,
      age: this.age,
      hired: this.hired
    };

    this.service.updateApplicant(val).subscribe((res) => {
      alert(res.toString());
    });
  }
}
