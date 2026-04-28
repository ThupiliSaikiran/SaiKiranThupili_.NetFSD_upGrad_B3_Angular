import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NContactDetailsComponent } from './ncontact-details-component';

describe('NContactDetailsComponent', () => {
  let component: NContactDetailsComponent;
  let fixture: ComponentFixture<NContactDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NContactDetailsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NContactDetailsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
