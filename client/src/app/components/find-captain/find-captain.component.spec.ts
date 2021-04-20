import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindCaptainComponent } from './find-captain.component';

describe('FindCaptainComponent', () => {
  let component: FindCaptainComponent;
  let fixture: ComponentFixture<FindCaptainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindCaptainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindCaptainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
