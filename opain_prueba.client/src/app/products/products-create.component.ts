import { Component, OnInit } from '@angular/core';
import { ProductsService, IProductos } from '@service/products.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-products-create',
  standalone: false,
  templateUrl: 'products-create.component.html'
})


export class ProductsCreateComponent implements OnInit {
  ifEdit: boolean = false;
  idProduct!: number;
  mensaje: string = '';
  formProducto = {
    NAME: '',
    DESCRIPTION: '',
    PRICE: 0
  };

  constructor(private productsService: ProductsService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.ifEdit = true;
      this.idProduct = +id;

      this.productsService.ObtenerProductoId(this.idProduct).subscribe({
        next: (product) => {
          this.formProducto = {
            NAME: product.name,
            DESCRIPTION: product.description,
            PRICE: product.price
          };
        }
      });
    }
  }

 

  RegistrarProduct(): void {

    if (this.idProduct) {
      this.productsService.EditarProducto(this.idProduct, this.formProducto).subscribe({
        next: (response) => {
          this.mensaje = response.mensaje;
        }
      });
    } else {
      this.productsService.AgregarProductos(this.formProducto).subscribe({
        next: (response) => {
          this.mensaje = response.mensaje;
          this.formProducto = { NAME: '', DESCRIPTION: '', PRICE: 0 };
        }
      });
    }
  }

  isPrecioValido(): boolean {
    return /^[0-9]+(\.[0-9]{1,2})?$/.test(this.formProducto.PRICE.toString());
  }
}
