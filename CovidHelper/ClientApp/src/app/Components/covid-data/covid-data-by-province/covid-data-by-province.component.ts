import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegionDetailDTO } from 'src/app/Models/RegionDetailDTO';

@Component({
  selector: 'app-covid-data-by-province',
  templateUrl: './covid-data-by-province.component.html',
  styleUrls: ['./covid-data-by-province.component.css']
})
export class CovidDataByProvinceComponent implements OnInit {

  constructor(    activatedRoute:ActivatedRoute,
    private router: Router,
    ) 
  {
    console.log(this.router.getCurrentNavigation().extras.state);
    
   }

  ngOnInit() {
  }

  getCitizenById(id: RegionDetailDTO) {
    
  }

}
