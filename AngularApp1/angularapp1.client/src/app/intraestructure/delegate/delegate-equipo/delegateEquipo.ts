import { GetAllEquipoUseCase } from "../../../application/use-case/get-all-equipo.use-case";
import { EquipoService } from "../../../domain/services/EquipoService";



const GetAllEquipoUseCaseFactory = (() => {
  let instance: GetAllEquipoUseCase;

  const factory = (service: EquipoService): GetAllEquipoUseCase => {
    if (!instance) {
      instance = new GetAllEquipoUseCase(service);
    }

    return instance;
  };

  return factory;
})();

export const equipoUseCaseProviders = {

  getAllEquipoUseCaseProvider: {
    provide: GetAllEquipoUseCase,
    useFactory: GetAllEquipoUseCaseFactory,
    deps: [EquipoService],
  },

};
