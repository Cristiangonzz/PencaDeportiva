import { IEquipoDomain } from "../interfaces/IEquipoDomain";

export class EquipoDomainEntity implements IEquipoDomain {
  EquipoId?: string;
  Name?: string;
  Activo: boolean;


  constructor(
    EquipoId?: string,

    Name?: string,
    Activo?: boolean,
   
  ) {
    this.EquipoId = EquipoId as string;
    this.Name = Name as string;
    this.Activo = Activo as boolean;
  }
}
