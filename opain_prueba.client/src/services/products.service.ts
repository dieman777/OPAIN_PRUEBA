import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

export interface IProductos {
  id: number;
  name: string;
  description: string;
  price: number;
  createdat: Date;
}

export interface IAddProducts {
  NAME: string;
  DESCRIPTION: string;
  PRICE: number; 
}



const urlApi = 'https://localhost:7277/';

@Injectable({
  providedIn : 'root'
})

export class ProductsService{


  constructor(private http: HttpClient){ }

  ObtenerProductos(): Observable<IProductos[]> {
    return this.http.get<IProductos[]>(`${urlApi}GetProduct`);
  }

  AgregarProductos(product: IAddProducts): Observable<any> {
    return this.http.post(`${urlApi}AddProducto`, product)
  }

  ObtenerProductoId(id: number) {
    return this.http.get<any>(`${urlApi}GetProduct/${id}`);
  }
  EditarProducto(id: number, product: IAddProducts) {
    return this.http.put<any>(`${urlApi}UpdateProduct/${id}`, product);
  }

  EliminarProducto(id: number) {
    return this.http.delete<any>(`${urlApi}Delete/${id}`);
  }
}
