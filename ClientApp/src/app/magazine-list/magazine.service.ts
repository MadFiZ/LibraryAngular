import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Magazine } from '../magazine-list/magazine';

@Injectable()
export class MagazineService {

  private url = "/api/magazines";

  constructor(private http: HttpClient) {
  }

  getMagazines(): Observable<Magazine[]> {
    return this.http.get<Magazine[]>(this.url);
  }

  createMagazine(magazine: Magazine) {
    return this.http.post(this.url, magazine);
  }
  updateMagazine(magazine: Magazine) {

    return this.http.put(this.url + '/' + magazine.id, magazine);
  }
  deleteMagazine(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
