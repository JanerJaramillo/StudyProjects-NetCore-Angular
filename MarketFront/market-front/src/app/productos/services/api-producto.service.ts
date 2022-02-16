import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { uri, headers } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Response } from 'src/app/utils/response';
import { Producto } from '../model/producto';
import { Marca } from 'src/app/marcas/model/marca';
import { Categoria } from 'src/app/categorias/model/categoria';

@Injectable({
  providedIn: 'root'
})
export class ProductoServicesService {

  constructor(
    private http: HttpClient
  ) { }

  public GetProducts(): Observable<Response<Producto[]>> {
    return this.http.get<Response<Producto[]>>(`${uri}/Producto`, { headers: headers })
  }

  public GetProductsForId(id: number): Observable<Response<Producto>> {
    return this.http.get<Response<Producto>>(`${uri}/Producto/getProductsForId?id=${id}`)
  }

  public GetMarcaList(): Observable<Response<Marca[]>> {
    return this.http.get<Response<Marca[]>>(`${uri}/Marca`, { headers: headers })
  }

  public GetCategoriaList(): Observable<Response<Categoria[]>> {
    return this.http.get<Response<Categoria[]>>(`${uri}/Categoria`, { headers: headers })
  }

  public InsertProduct(productos: Producto): Observable<Response<Producto>> {
    return this.http.post<Response<Producto>>(`${uri}/Producto/insertProduct`, productos, { headers: headers })
  }

  public UpdateProduct(producto: Producto): Observable<Response<Producto[]>> {
    return this.http.put<Response<Producto[]>>(`${uri}/Producto/updateProduct`, producto, { headers: headers })
  }

  public DeleteProduct(id: number): Observable<Response<Producto[]>> {
    return this.http.delete<Response<Producto[]>>(`${uri}/Producto/deleteProduct?id=${id}`, { headers: headers })
  }

}
