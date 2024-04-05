import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Observable } from 'rxjs';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { CreateEquipoDto } from '../../dto/create/CreateEquipoDTO';
import { UpdateEquipoDto } from '../../dto/create/UpdateEquipoDTO';

@Injectable({
  providedIn: 'root'
})
export class EquipoImplentationService extends EquipoService {
 
  URL = 'http://localhost:5046';
  
  constructor(private http: HttpClient) {
    super();
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Methods': 'POST,GET,PUT,DELETE',
      'Access-Control-Allow-Origin': '*',
    }),
  };

  getAll(): Observable<EquipoDomainEntity[]> {
    return this.http.get<EquipoDomainEntity []>(
      `${this.URL}/Equipo`, this.httpOptions
    );
  }
  create(data: CreateEquipoDto): Observable<EquipoDomainEntity> {
    throw new Error('Method not implemented.');
  }
  update(id: string, entity: UpdateEquipoDto): Observable<EquipoDomainEntity> {
    throw new Error('Method not implemented.');
  }
  delete(id: string): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  get(id: string): Observable<EquipoDomainEntity> {
    throw new Error('Method not implemented.');
  }
  getByName(titulo: string): Observable<EquipoDomainEntity> {
    throw new Error('Method not implemented.');
  }


}
