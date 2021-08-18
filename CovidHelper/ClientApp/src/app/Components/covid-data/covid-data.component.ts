import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RegionDetail } from 'src/app/Models/RegionDetail';
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
  details!: RegionDetail[];
  displayedColumns: string[] = ['name','confirmed', 'deaths'];
  fileName:string = 'TOP 10 COVID-19 CASES'
  selectedValue!:string;
  constructor(private regionService: RegionService, private excelService: ExcelService, private jsonService: JsonService) { }

  ngOnInit() {
    this.regionService.getData().subscribe((res: any[])=>{
      this.details= res;
      console.log(this.details)  
    })  
  }

  exportToExcel()
  {
    this.excelService.exportJsonAsExcelFile(this.details,this.fileName);
  }

  exportToJson()
  {
    this.jsonService.downloadJson(this.details,this.fileName);
  }

  
}
