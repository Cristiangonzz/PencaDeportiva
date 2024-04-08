import { BehaviorSubject, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { EquipoDomainEntity } from '../../domain/entity/EquipoEntity';
import { EquipoService } from '../../domain/services/EquipoService';
import { ResponseDomainEntity } from '../../domain/entity/ResponseEntity';


@Injectable({
  providedIn: 'root',
})
export class GetAllEquipoUseCase {
  private status!: ResponseDomainEntity<EquipoDomainEntity[]>;
  private number: number = 0;
  public statusEmmit: BehaviorSubject<ResponseDomainEntity<EquipoDomainEntity[]>> = new BehaviorSubject<
    ResponseDomainEntity<EquipoDomainEntity[]>
  >(this.status);

  constructor(private equipoService: EquipoService) { }

  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.equipoService.getAll().subscribe({
        next: (value: ResponseDomainEntity<EquipoDomainEntity[]>) => {
          this.status = value;
        },
        complete: () => {
          this.statusEmmit.next(this.status);
          console.log("Emitiendo" + this.number++);
          asyncScheduler.schedule(this.execute, 10000);//Para por ejemplo las notificaciones
        },
      });
    } else {
      asyncScheduler.schedule(this.execute, 100);
    }
  };
}
