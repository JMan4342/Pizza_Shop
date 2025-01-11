import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToppingsService {

  apiUrl='http://localhost:8000/'

  constructor(private http: HttpClient) { }

  getToppings(): Observable<any> {
    return this.http
      .get(
        this.apiUrl + "get_toppings"
      )
      .pipe(
        map((results) => {
          return results;
        })
      );
  }
}
