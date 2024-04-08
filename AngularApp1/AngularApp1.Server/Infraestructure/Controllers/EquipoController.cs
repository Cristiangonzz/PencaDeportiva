using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.infraestructure.db;
using AngularApp1.Server.Infraestructure.Dto;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipoController : ControllerBase
    {

        private readonly IEquipoRepository _equipoRepositorio;

        private readonly IMapper _mapper;

        public EquipoController(IEquipoRepository equipoRepositorio, IMapper mapper)
        {
            this._equipoRepositorio = equipoRepositorio;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Create([FromBody] EquipoDTO request)
        {

            ResponseDTO<EquipoDTO> _ResponseDTO = new ResponseDTO<EquipoDTO>();
            try
            {
                Equipo _producto = _mapper.Map<Equipo>(request);

                Equipo _productoCreado = await _equipoRepositorio.Create(_producto);

                if (_productoCreado.name != null)
                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = true, msg = "ok", value = _mapper.Map<EquipoDTO>(_productoCreado) };
                else
                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = "No se pudo crear el producto" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListGetAll()
        {

            ResponseDTO<List<EquipoDTO>> _ResponseDTO = new ResponseDTO<List<EquipoDTO>>();

            try
            {
                List<EquipoDTO> ListaEquipos = new List<EquipoDTO>();
                IQueryable<Equipo> query = await _equipoRepositorio.Consultar();
               // query = query.Include(r => r.IdCategoriaNavigation);

                ListaEquipos = _mapper.Map<List<EquipoDTO>>(query.ToList());

                if (ListaEquipos.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = true, msg = "ok", value = ListaEquipos };
                else
                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            //var ListEquipos = dbContext.Equipos.ToList();

            //return Ok(ListEquipos);

        }

        [HttpPut]
        [Route("Editar/{Id:Guid}")]
        public async Task<IActionResult> Editar([FromBody] EquipoDTO request, [FromRoute] Guid id)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Equipo _equipo = _mapper.Map<Equipo>(request);
                Equipo _equipoParaEditar = await _equipoRepositorio.Obtener(u => u.id == id);

                if (_equipoParaEditar != null)
                {

                    _equipoParaEditar.name = _equipo.name;
                    

                    bool respuesta = await _equipoRepositorio.Update(_equipoParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
                    else
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar el producto" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró el producto" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        //[HttpGet]
        //[Route("{Id:Guid}")]
        //public IActionResult GetEquipo([FromRoute] Guid Id)
        //{
        //    //var EquipoDomain = dbContext.Equipos.Find(Id);
        //    ///*
        //    // EL id es por defecto que lo busca, 
        //    //si se quiere buscar por algun otro argumento se tiene que usar
        //    //var students = dbContext.Students.FirstOrDefault(x => x.codigo == id)
        //    // */

        //    //return Ok(EquipoDomain);
        //}
    }
}
