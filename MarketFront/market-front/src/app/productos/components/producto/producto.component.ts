import { Component, OnInit } from '@angular/core';
import { StateCode } from 'src/app/utils/errorCode';
import { Producto } from '../../model/producto';
import { ProductoServicesService } from '../../services/api-producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent implements OnInit {

  products: Producto[] = []

  viewModal = false

  productoId: number | undefined;

  constructor(
    private productoServicesService: ProductoServicesService
  ) { }

  ngOnInit(): void {
    this.GetProducts();
  }

  GetProducts(): void {
    this.productoServicesService.GetProducts()
      .subscribe((response) => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.products = data
        }
      })
  }

  DeleteProduct(id: number): void {
    this.productoServicesService.DeleteProduct(id)
      .subscribe(response => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.products = data
        }
      })
  }

  openModal(): void {
    this.viewModal = true;
  }

  openModalForUpdate(id: number): void {
    this.productoId = id;
    this.viewModal = true;
  }

  processCloseInsertModal(event: boolean): void {
    if (this.productoId) { this.productoId = undefined }
    this.viewModal = event;
  }

  processNewProducto(event: Producto): void {
    this.products.push(event);
  }

  processnewListProducto(event: Producto[]): void {
    this.products = event;
  }

}
