import { AfterViewInit, Component, OnInit } from '@angular/core';
import { equipoUseCaseProviders } from '../../../intraestructure/delegate/delegate-equipo/delegateEquipo';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-all',
  templateUrl: './list-all.component.html',
  styleUrl: './list-all.component.css'
})
export class ListAllComponent implements OnInit, AfterViewInit {
  delegateCategoria = equipoUseCaseProviders;
  equipos!: EquipoDomainEntity[];
  nombres!: string[];
  mostrarComponente: boolean = false;
  //@Input() crearCategoria!: boolean;
  //sweet = new SweetAlert();
  constructor(
    private equipoService: EquipoService,
    private router: Router,
  ) { }
  ngAfterViewInit(): void {
    window.scroll(0, 0)
  }
  finalizarCreacion() {
    this.mostrarComponente = false;
  }
  ngOnInit(): void {
    this.delegateCategoria.getAllEquipoUseCaseProvider
      .useFactory(this.equipoService)
      .execute();
    this.delegateCategoria.getAllEquipoUseCaseProvider
      .useFactory(this.equipoService)
      .statusEmmit.subscribe({
        next: (value: EquipoDomainEntity[]) => {
          
          this.equipos = value;
          console.log(this.equipos);
          console.log(value);

        },
      });
  }

}
