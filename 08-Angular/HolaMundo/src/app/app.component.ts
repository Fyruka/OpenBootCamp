import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HolaMundo';
  usuario = '@Samu';

  /* Esta funcion se ejecutara cuando en el hijo ( saludo component) se pulse un boton */
  recibirMensajeDelHijo(evento: string){
    alert(evento);
  }
}
