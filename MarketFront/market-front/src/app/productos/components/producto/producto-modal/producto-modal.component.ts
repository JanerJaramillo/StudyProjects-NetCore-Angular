import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Categoria } from 'src/app/categorias/model/categoria';
import { Marca } from 'src/app/marcas/model/marca';
import { Producto } from 'src/app/productos/model/producto';
import { ProductoServicesService } from 'src/app/productos/services/api-producto.service';
import { StateCode } from 'src/app/utils/errorCode';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-producto-modal',
  templateUrl: './producto-modal.component.html',
  styleUrls: ['./producto-modal.component.scss']
})
export class ProductoModalComponent implements OnInit {

  insertProductoForm: FormGroup

  @Input() viewModal: boolean | undefined;
  @Input() productoId: number | undefined;

  @Output()
  closeInsertModal = new EventEmitter<boolean>();
  @Output()
  newProducto = new EventEmitter<Producto>();
  @Output()
  newListProducto = new EventEmitter<Producto[]>();

  marcaList: Marca[] = []
  categoriaList: Categoria[] = []

  productos: Producto = {} as any

  constructor(
    private formBuilder: FormBuilder,
    private productoServicesService: ProductoServicesService
  ) {
    this.insertProductoForm = this.formBuilder.group({
      nombre: [''],
      descripcion: [''],
      stock: [null],
      precio: [null],
      marca: [null],
      categoria: [null]
    })
  }

  ngOnInit(): void {
    if (this.productoId) {
      this.GetProductsForId(this.productoId);
    }
    this.GetMarcaList();
    this.GetCategoriaList();
  }

  GetProductsForId(id: number): void {
    this.productoServicesService.GetProductsForId(id)
      .subscribe((response) => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          console.log(data)
          this.insertProductoForm = this.formBuilder.group({
            nombre: [data.nombre],
            descripcion: [data.descripcion],
            stock: [data.stock],
            precio: [data.precio],
            marca: [data.marcaId],
            categoria: [data.categoriaId]
          })
        }
      })
  }

  GetMarcaList(): void {
    this.productoServicesService.GetMarcaList()
      .subscribe(response => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.marcaList = data
        }
      })
  }

  GetCategoriaList(): void {
    this.productoServicesService.GetCategoriaList()
      .subscribe(response => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.categoriaList = data
        }
      })
  }

  FormValue(): Producto {
    let producto: Producto = {} as any;
    producto.nombre = this.insertProductoForm.value.nombre;
    producto.descripcion = this.insertProductoForm.value.descripcion;
    producto.stock = this.insertProductoForm.value.stock;
    producto.precio = this.insertProductoForm.value.precio;
    producto.marcaId = this.insertProductoForm.value.marca;
    producto.categoriaId = this.insertProductoForm.value.categoria;
    return producto
  }

  InsertProduct(): void {
    this.productos = this.FormValue();
    this.productoServicesService.InsertProduct(this.productos)
      .subscribe(response => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.newProducto.emit(data)
          Swal.fire("Producto Registrado", "", "success")
        }
      })
  }

  UpdateProduct(): void {
    this.productos = this.FormValue();
    this.productos.id = this.productoId;
    this.productoServicesService.UpdateProduct(this.productos)
      .subscribe(response => {
        const { data, statusCode } = response
        if (statusCode === StateCode.OK) {
          this.newListProducto.emit(data)
          Swal.fire("Producto Actualizado", "", "success")
        }
      })
  }

  closeModal(): void {
    if (this.productoId) { this.productoId = undefined }
    this.viewModal = false;
    this.closeInsertModal.emit(this.viewModal);
  }

  getStringDateTime(date: Date) {
    return date.toISOString()
  }

  getStringDate(stringDate: string | Date) {
    const date = new Date(stringDate)
    return this.getStringDateTime(date).substr(0, 10)
  }

}
