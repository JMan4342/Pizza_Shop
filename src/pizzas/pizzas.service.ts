import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Pizza } from '../shared/classes/pizza';

@Injectable({
  providedIn: 'root'
})
export class PizzasService {
  apiUrl='http://localhost:8000/'

  constructor(private http: HttpClient) { }

  getPizzas(): Observable<any> {
    return this.http
      .get(
        this.apiUrl + "get_pizzas"
      )
      .pipe(
        map((results) => {
          return results;
        })
      );
  }

  addNewPizza(pizzaName: string, toppings: string): Observable<any> {
    return this.http
    .post(
      this.apiUrl + "add_pizza/" + pizzaName + "/" + toppings, null
    )
    .pipe(
      map((result) => {
        return result
      })
    )
  }

  updatePizza(pizzaName: string, toppings: string, pizzaId: number): Observable<any> {
    return this.http
    .post(
      this.apiUrl + "update_pizza/" + pizzaName + "/" + toppings + "/" + pizzaId, null
    )
    .pipe(
      map((result) => {
        return result
      })
    )
  }
}
