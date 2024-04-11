using AngularApp1.Server.Domain.Entities;
using AngularApp1.Server.Domain.Interfaces;
using AngularApp1.Server.Infraestructure.Dto;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;

namespace AngularApp1.Server.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipoController : ControllerBase
    {

        private readonly IEquipoRepository _equipoRepositorio;

        private readonly IMapper _mapper;

        private readonly IHttpClientFactory _httpClientFactory;

        public EquipoController(IHttpClientFactory httpClientFactory, IEquipoRepository equipoRepositorio, IMapper mapper)
        {
            this._equipoRepositorio = equipoRepositorio;
            this._mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }



        [HttpGet]
        [Route("Matches")]
        public async Task<IActionResult> GetMatches()
        {

            ResponseDTO<MatchDTO> _ResponseDTO = new ResponseDTO<MatchDTO>();
            var client = _httpClientFactory.CreateClient();

            // Configura la URL de la API externa
            var url = "https://api.football-data.org/v4/matches";

            // Configura el token de autenticación si es necesario
            client.DefaultRequestHeaders.Add("X-Auth-Token", "5e5f4b403ed749dcb7065634af5e8dc4");

            try
            {
                // Realiza la solicitud HTTP GET a la API externa
                var response = await client.GetAsync(url);

                // Verifica si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                   
                    return StatusCode(StatusCodes.Status200OK, responseStream);
                }
                else
                {
                    // Si la solicitud no fue exitosa, devuelve el código de estado de la respuesta
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                // Si ocurre un error al realizar la solicitud, devuelve un código de estado 500 (Error interno del servidor)
                return StatusCode(500);
            }
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

        private List<MatchDTO> DeserializeMatches(string jsonString)
        {
            var matches = new List<MatchDTO>();

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                if (root.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement matchElement in root.EnumerateArray())
                    {
                        var match = new MatchDTO();
                        match.id = matchElement.GetProperty("id").GetString();
                        match.utcDate = matchElement.GetProperty("utcDate").GetString();
                        match.status = matchElement.GetProperty("status").GetString();
                        match.matchday = matchElement.GetProperty("matchday").GetInt32();
                        match.stage = matchElement.GetProperty("stage").GetString();
                        match.group = matchElement.GetProperty("group").GetString();
                        match.lastUpdated = matchElement.GetProperty("lastUpdated").GetString();
                        // Mapea las propiedades de los objetos complejos
                        match.area = DeserializeArea(matchElement.GetProperty("area"));
                        match.competition = DeserializeCompetition(matchElement.GetProperty("competition"));
                        match.season = DeserializeSeason(matchElement.GetProperty("season"));
                        match.homeTeam = DeserializeHomeTeam(matchElement.GetProperty("homeTeam"));
                        match.awayTeam = DeserializeAwayTeam(matchElement.GetProperty("awayTeam"));
                        match.score = DeserializeScore(matchElement.GetProperty("score"));
                        match.odds = DeserializeOdds(matchElement.GetProperty("odds"));
                        match.referees = DeserializeReferees(matchElement.GetProperty("referees"));

                        matches.Add(match);
                    }
                }
            }

            return matches;
        }

        private List<RefereesDTO> DeserializeReferees(JsonElement element)
        {
            var referees = new List<RefereesDTO>();

            foreach (JsonElement refereeElement in element.EnumerateArray())
            {
                var referee = new RefereesDTO
                {
                    id = refereeElement.GetProperty("id").GetInt32(),
                    name = refereeElement.GetProperty("name").GetString(),
                    type = refereeElement.GetProperty("type").GetString(),
                    nationality = refereeElement.GetProperty("nationality").GetString()
                };

                referees.Add(referee);
            }

            return referees;
        }


        private AwayTeamDTO DeserializeAwayTeam(JsonElement element)
        {
            return new AwayTeamDTO
            {
                id = element.GetProperty("id").GetInt32(),
                name = element.GetProperty("name").GetString(),
                shortName = element.GetProperty("shortName").GetString(),
                tla = element.GetProperty("tla").GetString(),
                crest = element.GetProperty("crest").GetString()
            };
        }


        private HomeTeamDTO DeserializeHomeTeam(JsonElement element)
        {
            return new HomeTeamDTO
            {
                id = element.GetProperty("id").GetInt32(),
                name = element.GetProperty("name").GetString(),
                shortName = element.GetProperty("shortName").GetString(),
                tla = element.GetProperty("tla").GetString(),
                crest = element.GetProperty("crest").GetString()
            };
        }



        private OddsDTO DeserializeOdds(JsonElement element)
        {
            return new OddsDTO
            {
                msg = element.GetProperty("msg").GetString()
            };
        }
        private AreaDTO DeserializeArea(JsonElement element)
        {
            return new AreaDTO
            {
                id = element.GetProperty("id").GetInt32(),
                name = element.GetProperty("name").GetString(),
                code = element.GetProperty("code").GetString(),
                flag = element.GetProperty("flag").GetString()
            };
        }

        private CompetitionDTO DeserializeCompetition(JsonElement element)
        {
            return new CompetitionDTO
            {
                id = element.GetProperty("id").GetInt32(),
                name = element.GetProperty("name").GetString(),
                code = element.GetProperty("code").GetString(),
                type = element.GetProperty("type").GetString(),
                emblem = element.GetProperty("emblem").GetString()
            };
        }



        private SeasonDTO DeserializeSeason(JsonElement element)
        {
            return new SeasonDTO
            {
                id = element.GetProperty("id").GetInt32(),
                startDate = element.GetProperty("startDate").GetString(),
                endDate = element.GetProperty("endDate").GetString(),
                currentMatchday = element.GetProperty("currentMatchday").GetInt32(),
                winner = element.GetProperty("winner").GetString()
            };
        }

        private ScoreDTO DeserializeScore(JsonElement element)
        {
            return new ScoreDTO
            {
                id = element.GetProperty("id").GetInt32(),
                name = element.GetProperty("name").GetString(),
                code = element.GetProperty("code").GetString(),
                flag = element.GetProperty("flag").GetString()
            };
        }

     
    }



    
}
