import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindCrewComponent } from './find-crew.component';

describe('FindCrewComponent', () => {
  let component: FindCrewComponent;
  let fixture: ComponentFixture<FindCrewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindCrewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindCrewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
