import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:5001/api";

  constructor(private _http : HttpClient) { }

  getApplicantList():Observable<any[]>{
    return this._http.get<any>(this.APIUrl+'/Applicants');

  }

  getApplicant(val:any){
    return this._http.get<any>(this.APIUrl+'/Applicants', val);

  }


  addApplicant(val:any){
    return this._http.post(this.APIUrl+'/Applicants', val);
  }

  updateApplicant(val:any){
    return this._http.put(this.APIUrl+'/Applicants', val);
  }

  deleteApplicant(val:any){
    return this._http.delete(this.APIUrl+'/Applicants', val);
  }


  
}
