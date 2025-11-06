import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Edita } from './edita';

describe('Edita', () => {
  let component: Edita;
  let fixture: ComponentFixture<Edita>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Edita]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Edita);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
