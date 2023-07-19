import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = []
  public eventosFiltratos: any = []

  exibirImagem = true;
  private _filterEvent: string = '';

  public get filterEvent(): string {
    return this._filterEvent;
  }
  public set filterEvent(value: string) {
    this._filterEvent = value;
    this.eventosFiltratos = this.filterEvent ? this.filterList(this.filterEvent) : this.eventos
  }

  filterList(filtro: string): any {
    filtro = filtro.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string, local: string }) => evento.tema.toLocaleLowerCase().indexOf(filtro) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtro) !== -1
    )
  }
  constructor(private http: HttpClient) { }

  showImage() {
    this.exibirImagem = !this.exibirImagem
  }

  ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response =>{ this.eventos = response
      this.eventosFiltratos = this.eventos
      },
      
      error => console.log(error)
    );
  }
}
