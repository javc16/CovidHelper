import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CovidDataByProvinceComponent } from './covid-data-by-province.component';

describe('CovidDataByProvinceComponent', () => {
  let component: CovidDataByProvinceComponent;
  let fixture: ComponentFixture<CovidDataByProvinceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CovidDataByProvinceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CovidDataByProvinceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
