import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: RegionDetail[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RegionDetail[]>(baseUrl + 'api/region').subscribe(result => {
      this.forecasts = result;
      console.log(this.forecasts);
    }, error => console.error(error));
  }
}

interface RegionDetail {
  confirmed: number;
  deaths: number;
  region: Region
}


interface Region {
  name: string;
}
