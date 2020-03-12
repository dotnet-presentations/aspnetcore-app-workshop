import { Injectable, Inject } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Session, Speaker } from './model';

@Injectable()
export class DataService {

  private headers = new Headers({ 'Content-Type': 'application/json' });
  private sessionUrl = 'api/sessions';
  private speakerUrl = 'api/speakers';
  /**
   * init with Http
   */
  constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

  getSessions(): Promise<Session[]> {
    return this.http.get(this.baseUrl + this.sessionUrl)
      .toPromise()
      .then(response => <Session[]>response.json())
      .catch(this.handleError);
  }

  getSession(id: number): Promise<Session> {
    const url = `${this.baseUrl + this.sessionUrl}/${id}`
    return this.http.get(url)
      .toPromise()
      .then(response => <Session>response.json())
      .catch(this.handleError);
  }

  getSpeaker(id: number): Promise<Speaker> {
    const url = `${this.baseUrl + this.speakerUrl}/${id}`
    return this.http.get(url)
      .toPromise()
      .then(response => <Speaker>response.json())
      .catch(this.handleError);
  }

  getSpeakers(): Promise<Speaker[]> {
    return this.http.get(this.baseUrl + this.speakerUrl)
      .toPromise()
      .then(response => <Speaker[]>response.json())
      .catch(this.handleError);
  }

  private getData(response: Response) { }
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
