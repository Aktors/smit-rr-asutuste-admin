import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsutusListComponent } from './asutus-list.component';

describe('AsutusListComponent', () => {
  let component: AsutusListComponent;
  let fixture: ComponentFixture<AsutusListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AsutusListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AsutusListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
