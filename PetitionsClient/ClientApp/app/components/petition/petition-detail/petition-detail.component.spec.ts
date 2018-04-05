import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PetitionDetailComponent } from './petition-detail.component';

describe('PetitionDetailComponent', () => {
  let component: PetitionDetailComponent;
  let fixture: ComponentFixture<PetitionDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetitionDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetitionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
