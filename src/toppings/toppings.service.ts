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

  addNewTopping(toppingName: string): Observable<any> {
    return this.http
      .post(
        this.apiUrl + "add_topping/" + toppingName, null
      )
      .pipe(
        map((results) => {
          return results;
        })
      );
  }

  updateTopping(toppingName: string, toppingId: number): Observable<any> {
    return this.http
      .post(
        this.apiUrl + "update_topping/" + toppingName + "/" + toppingId, null
      )
      .pipe(
        map((results) => {
          return results;
        })
      );
  }

  deleteTopping(toppingId: number): Observable<any> {
    return this.http
    .delete(
      this.apiUrl + "delete_topping/" + toppingId
    )
    .pipe(
      map((result) => {
        return result
      })
    )
  }

}
