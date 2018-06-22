import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';

import { Session } from '../shared/model';
import { DataService } from '../shared/data.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'session-detail',
  templateUrl: './session-detail.component.html'
})
export class SessionDetailComponent implements OnInit {
  session: Session;

  constructor(
    private sessionService: DataService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {

    this.route.paramMap
      // tslint:disable-next-line:no-non-null-assertion
      .switchMap((params: ParamMap) => this.sessionService.getSession(+params.get('id')!))
      .subscribe(session => this.session = session);
  }

  goBack() {
    this.location.back();
  }

}
