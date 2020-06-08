using EFCore.Domain.Entities;
using EFCore.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        private readonly IEFCoreRepository _repository;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <remarks></remarks>
        public HeroiController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repository.GetAllHerois();
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id, false);
                return Ok(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Bazinga");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }

            return BadRequest("Não salvou");
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id, false);
                if (heroi != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Bazinga");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro {ex}");
            }

            return BadRequest("Não alterado.");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id, false);
                if (heroi != null)
                {
                    _repository.Delete(heroi);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Bazinga");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro {ex}");
            }

            return BadRequest("Não deletado.");
        }

        #endregion
    }
}