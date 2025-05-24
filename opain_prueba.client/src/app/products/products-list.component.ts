import { Component, OnInit } from '@angular/core';
import { ProductsService, IProductos } from '@service/products.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-products-list',
  standalone : false,
  templateUrl: 'products-list.component.html'
})

export class ProductsListComponent implements OnInit {
  constructor(private productsService: ProductsService, private router: Router) { }

  public datosTabla: IProductos[] = [];

    ngOnInit(): void {
      this.Actualizar();
    }


  EditProduct(id:number): void {
    this.router.navigate(['/producto-edit', id]);
  }

  DeleteProduct(id: number): void {
    if (confirm("Seguro va a eliminar este producto?")) {
      this.productsService.EliminarProducto(id).subscribe({
        next: (response) => {
          alert(response.mensaje);
          this.Actualizar();
        }
      });
    }
  }

  Actualizar(): void {
    this.productsService.ObtenerProductos().subscribe(datos => {
      console.log('Datos recibidos:', datos);
      this.datosTabla = datos;
    });
  }
}
