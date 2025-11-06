import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Elimina } from './elimina';

describe('Elimina', () => {
  let component: Elimina;
  let fixture: ComponentFixture<Elimina>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Elimina]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Elimina);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
