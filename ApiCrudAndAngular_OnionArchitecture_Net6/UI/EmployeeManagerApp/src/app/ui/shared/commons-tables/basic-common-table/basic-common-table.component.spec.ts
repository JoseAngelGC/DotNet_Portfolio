import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicCommonTableComponent } from './basic-common-table.component';

describe('BasicCommonTableComponent', () => {
  let component: BasicCommonTableComponent;
  let fixture: ComponentFixture<BasicCommonTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasicCommonTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BasicCommonTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
