import { Component, OnInit } from '@angular/core';

// Cremaos un tipo base para el ejemplo
export type Producto = {
  nombre: string;
  precio: number;
  descripcion: string;
}


@Component({
  selector: 'app-lista-basica',
  templateUrl: './lista-basica.component.html',
  styleUrls: ['./lista-basica.component.css']
})
export class ListaBasicaComponent implements OnInit {

  listaElementos: string[] = ["Leche", "Carne", "Verdura", "Huevos"];
  
  listaProductos: Producto[] = [
    {
      nombre: 'Leche',
      precio: 10,
      descripcion: 'Leche entera'
    },
    {
      nombre: 'Carne Ternera',
      precio: 20,
      descripcion: 'carne de ternera de primera calidad'  
    }
  ];
  
  cargando: boolean = false;

  opcion: number = 0;
  
  constructor() { }

  ngOnInit(): void {

  }

  cambiarCargando(){
    this.cargando = !this.cargando; // El valor que este en cargando, cambialo al contrario, de false a true y de true a false.
  }

  escogerOpcion(opcionEscogida: number){
    this.opcion = opcionEscogida; // El valor cambia, implica un cambio en los elementos renderizados 
  }

}
