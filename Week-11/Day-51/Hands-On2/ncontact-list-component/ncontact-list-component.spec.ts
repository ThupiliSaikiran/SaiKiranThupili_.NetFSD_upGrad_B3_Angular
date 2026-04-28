import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NContactListComponent } from './ncontact-list-component';

describe('NContactListComponent', () => {
  let component: NContactListComponent;
  let fixture: ComponentFixture<NContactListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NContactListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NContactListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
