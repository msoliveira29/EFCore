using EFCore.Domain.Entities;
using EFCore.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: .
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        #region Attributes

        private readonly HeroiContext _context;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <remarks></remarks>
        public HeroiController(HeroiContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        // GET: api/<HeroiController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post(Heroi heroi)
        {
            try
            {
                _context.Herois.Add(heroi);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi heroi)
        {
            try
            {
                if (_context.Herois.AsNoTracking()
                                   .FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Herois.Update(heroi);
                    _context.SaveChanges();

                    return Ok("Bazinga");
                }

                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion
    }
}