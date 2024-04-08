import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { equipoUseCaseProviders } from '../../../intraestructure/delegate/delegate-equipo/delegateEquipo';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Router } from '@angular/router';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { EquipoGetAllDTO } from '../../../intraestructure/dto/get/EquipoGetAllDTO';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list-all',
  templateUrl: './list-all.component.html',
  styleUrl: './list-all.component.css'
})
export class ListAllComponent implements OnInit, AfterViewInit, OnDestroy {
  delegateCategoria = equipoUseCaseProviders;
  listEquipos!: EquipoDomainEntity[];
  mostrarComponente: boolean = false;
  //@Input() crearCategoria!: boolean;
  //sweet = new SweetAlert();
  private statusSubscription: Subscription | undefined;

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
        next: (value: ResponseDomainEntity<EquipoDomainEntity[]>) => {

            if (value.status === false) {
            console.log("Fallo, producir una alerta con el mesaje de error : msg");
          }

          this.listEquipos = value.value as EquipoDomainEntity[];
          console.log(this.listEquipos);
        },
      });
  }


  ngOnDestroy(): void {
    //¨Para cancelar la subscribe al irme a otro componente
    if (this.statusSubscription) {
      this.statusSubscription.unsubscribe();
    }
  }

}
