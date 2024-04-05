import { BehaviorSubject, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { EquipoDomainEntity } from '../../domain/entity/EquipoEntity';
import { EquipoService } from '../../domain/services/EquipoService';


@Injectable({
  providedIn: 'root',
})
export class GetAllEquipoUseCase {
  private status: EquipoDomainEntity[] = [];

  public statusEmmit: BehaviorSubject<EquipoDomainEntity[]> = new BehaviorSubject<
    EquipoDomainEntity[]
  >(this.status);

  constructor(private equipoService: EquipoService) { }

  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.equipoService.getAll().subscribe({
        next: (value: EquipoDomainEntity[]) => {
          this.status = value;
        },
        complete: () => {
          this.statusEmmit.next(this.status);
        },
      });
    } else {
      asyncScheduler.schedule(this.execute, 1000);
    }
  };
}
