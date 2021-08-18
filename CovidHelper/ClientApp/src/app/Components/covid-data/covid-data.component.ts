import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { RegionDetailDTO } from 'src/app/Models/RegionDetailDTO';
import { ExcelService } from 'src/app/Services/Excel/excel.service';
import { JsonService } from 'src/app/Services/Json/json.service';
import { RegionService } from 'src/app/Services/Region/region.service';

@Component({
  selector: 'app-covid-data',
  templateUrl: './covid-data.component.html',
  styleUrls: ['./covid-data.component.css']
})
export class CovidDataComponent implements OnInit {
  @Output('statusSlectedChange') statusSelectedChange: EventEmitter<any> = new EventEmitter(); 
  details!: RegionDetailDTO[];
  detailsByProvince!: RegionDetailDTO[];
  allValue!:RegionDetailDTO;
  displayedColumns: string[] = ['name','confirmed', 'deaths'];
  fileName:string = 'TOP 10 COVID-19 CASES'
  selectedValue:RegionDetailDTO = new RegionDetailDTO();
  validTable:boolean = true;
  constructor(private regionService: RegionService, private excelService: ExcelService, private jsonService: JsonService,private router: Router,) { }

  ngOnInit() {
    this.regionService.getData().subscribe((res: any[])=>{
      this.details= res;
      console.log(this.details)
      this.allValue = new RegionDetailDTO();
      this.allValue.iso="ALL";
      this.allValue.name="ALL"
      this.allValue.confirmed=-1; 
      
 
    
      console.log(this.allValue);    
    })
  
  }

  exportToExcel(table: any[])
  {
    this.excelService.exportJsonAsExcelFile(table,this.fileName);
  }

  exportToJson(table: any[])
  {
    this.jsonService.downloadJson(table,this.fileName);
  }

  getByProvince(region: RegionDetailDTO)
  {
    if(region.name==="ALL")
    {
      this.validTable=true;
      this.details.length = this.details.length - 1;
      return;
    }
    this.validTable=false;
    if(this.details.length<=10)
    {
      this.details.push(this.allValue);
    }
    this.regionService.getDataByProvince(region).subscribe((res: any[])=>{
      this.detailsByProvince= res;
      console.log(this.detailsByProvince)       
    })
  }

  
}
