import { ApplicantApi } from './services/applicant-api';

export class MyApp {
  private applicant;

  constructor(private api: ApplicantApi) {
    this.Get();
  }

  async Get() {

    this.applicant = await this.api.getApplicants();
  }


}