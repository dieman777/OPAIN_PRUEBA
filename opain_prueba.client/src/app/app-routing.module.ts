import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductsListComponent } from './products/products-list.component';
import { ProductsCreateComponent } from './products/products-create.component';

const routes: Routes = [
  //Diego:Ruta principal adireccionar
  { path: '', redirectTo: 'products-list', pathMatch: 'full' }, 
  { path: 'products-list', component: ProductsListComponent },
  { path: 'products-create', component: ProductsCreateComponent },
  { path: 'producto-edit/:id', component: ProductsCreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
