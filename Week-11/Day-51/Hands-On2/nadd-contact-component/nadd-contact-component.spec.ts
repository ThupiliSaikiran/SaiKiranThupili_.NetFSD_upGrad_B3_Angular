import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NAddContactComponent } from './nadd-contact-component';

describe('NAddContactComponent', () => {
  let component: NAddContactComponent;
  let fixture: ComponentFixture<NAddContactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NAddContactComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NAddContactComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
