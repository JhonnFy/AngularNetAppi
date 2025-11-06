import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Nota } from './nota';

describe('Nota', () => {
  let component: Nota;
  let fixture: ComponentFixture<Nota>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Nota]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Nota);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
