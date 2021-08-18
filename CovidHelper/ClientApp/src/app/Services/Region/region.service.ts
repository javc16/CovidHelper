import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegionDetailDTO } from 'src/app/Models/RegionDetailDTO';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private url:string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) 
  {
    this.url = baseUrl+ 'api/region';
  }

  getData(): Observable<RegionDetailDTO[]> {
    return this.http.get<RegionDetailDTO[]>(this.url);
  }
}



// constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//   http.get<RegionDetail[]>(baseUrl + 'api/region').subscribe(result => {
//     this.forecasts = result;
//     console.log(this.forecasts);
//   }, error => console.error(error));
// }