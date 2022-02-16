import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductoRoutingModule } from './producto-routing.module';
import { ProductoComponent } from './components/producto/producto.component';
import { ProductoModalComponent } from './components/producto/producto-modal/producto-modal.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ProductoComponent, ProductoModalComponent],
  imports: [
    CommonModule,
    ProductoRoutingModule,
    ReactiveFormsModule
  ]
})
export class ProductoModule { }
