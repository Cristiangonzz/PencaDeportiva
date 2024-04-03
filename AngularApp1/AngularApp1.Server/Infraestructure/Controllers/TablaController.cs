using AngularApp1.Server.infraestructure.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.Infraestructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaController : ControllerBase
    {

        public readonly ApplicationDbContext dbContext;

        public TablaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
