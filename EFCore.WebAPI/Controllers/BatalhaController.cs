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
    public class BatalhaController : ControllerBase
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
        public BatalhaController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repository.GetAllBatalhas();
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id, false);
                return Ok(batalha);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro; {ex}");
            }
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
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

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id, false);
                if (batalha != null)
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

            return BadRequest("Não atualizado.");
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id, false);
                if (batalha != null)
                {
                    _repository.Delete(batalha);

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