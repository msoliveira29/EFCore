using EFCore.Domain.Entities;
using EFCore.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EFCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public readonly HeroiContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, HeroiContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            //var listHerois = _context.Herois.ToList();
            var listHerois = (from heroi in _context.Herois select heroi).ToList();

            return Ok(listHerois);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var heroi = new Heroi() { Nome = "Spider-Man" };

            _context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Atualizar/{nome}")]
        public ActionResult Get(string nomeHeroi)
        {
            var heroi = _context.Herois
                                .Where(h => h.Id == 4)
                                .FirstOrDefault();

            heroi.Nome = "Homem Aranha";

            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listHerois = _context.Herois
                                     .Where(h => h.Nome.Contains(nome))
                                     .ToList();

            //var listHerois = (from heroi in _context.Herois
            //                  where heroi.Nome.Contains(nome)
            //                  select heroi).ToList();

            return Ok(listHerois);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
            );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(h => h.Id == id)
                                .Single();

            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}