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
    public class BatalhaController : ControllerBase
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
        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post(Batalha batalha)
        {
            try
            {
                _context.Batalhas.Add(batalha);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha batalha)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking()
                                     .FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Batalhas.Update(batalha);
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

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion
    }
}