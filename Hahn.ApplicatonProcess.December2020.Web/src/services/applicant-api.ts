import { HttpClient } from '@aurelia/fetch-client'
import { inject } from 'aurelia';

@inject(HttpClient)

export class ApplicantApi{

    constructor(private http:HttpClient){

    }

    public async getApplicants() : Promise<IApplicantItem>{
        const req= await this.http.fetch(`https://localhost:5001/api/Applicants`);
        return req.json();
    }
}


interface IApplicantItem{
    Id: number;
    Name: string;
    FamilyName: string;
    Address: string;
    CountyOfOrigin : string;
    EmailAddress : string;
    Age : number;
    Hired:boolean;
}