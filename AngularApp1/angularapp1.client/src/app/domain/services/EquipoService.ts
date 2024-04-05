import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { EquipoDomainEntity } from '../entity/EquipoEntity';
import { CreateEquipoDto } from '../../intraestructure/dto/create/CreateEquipoDTO';
import { BaseService } from './BaseService';
import { UpdateEquipoDto } from '../../intraestructure/dto/create/UpdateEquipoDTO';

@Injectable({
  providedIn: 'root',
})
export abstract class EquipoService extends BaseService<EquipoDomainEntity> {
  abstract create(data: CreateEquipoDto): Observable<EquipoDomainEntity>;
  abstract update(id: string, entity: UpdateEquipoDto): Observable<EquipoDomainEntity>;
}
