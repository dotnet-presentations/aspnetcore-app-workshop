import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';

import { Session } from '../shared/model';
import { DataService } from '../shared/data.service';

@Component({
  selector: 'session-detail',
  templateUrl: './sessiondetail.component.html'
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
      .switchMap((params: ParamMap) => this.sessionService.getSession(+params.get('id')!))
      .subscribe(session => this.session = session);
  }

  goBack() {
    this.location.back();
  }

}
