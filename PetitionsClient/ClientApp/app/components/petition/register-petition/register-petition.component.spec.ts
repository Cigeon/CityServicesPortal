import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterPetitionComponent } from './register-petition.component';

describe('RegisterPetitionComponent', () => {
  let component: RegisterPetitionComponent;
  let fixture: ComponentFixture<RegisterPetitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterPetitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterPetitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
