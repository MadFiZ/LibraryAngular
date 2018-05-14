import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Publication } from '../publication-list/publication';

@Injectable()
export class PublicationService {

  private url = "/api/publications";

  constructor(private http: HttpClient) {
  }

  getPublications(): Observable<Publication[]> {
    return this.http.get<Publication[]>(this.url);
  }
}
