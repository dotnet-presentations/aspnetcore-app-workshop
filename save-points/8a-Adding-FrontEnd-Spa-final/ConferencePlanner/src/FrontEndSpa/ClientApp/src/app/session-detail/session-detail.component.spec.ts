import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionDetailComponent } from './session-detail.component';

describe('SessionDetailComponent', () => {
  let component: SessionDetailComponent;
  let fixture: ComponentFixture<SessionDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SessionDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
