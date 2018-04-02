import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllPetitionsComponent } from './all-petitions.component';

describe('AllPetitionsComponent', () => {
  let component: AllPetitionsComponent;
  let fixture: ComponentFixture<AllPetitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllPetitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllPetitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
