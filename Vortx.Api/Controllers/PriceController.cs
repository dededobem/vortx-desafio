using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vortx.Application.Interfaces;
using Vortx.Application.ViewModels;

namespace Vortx.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriceController : Controller
    {
        private readonly IAppPrice _appPrice;

        public PriceController(IAppPrice appPrice) => _appPrice = appPrice;

        /// <summary>
        /// Consultar todos os preços das origens e destinos cadastrados 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _appPrice.GetAll());

        /// <summary>
        /// Consultar os preços das origens e destinos por id
        /// </summary>
        /// <param name="id">Identificador do priceo a ser consultado</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) =>
            Ok(await _appPrice.GetById(id));

        /// <summary>
        /// Cadastrar novo preço das origens e destinos
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]PriceViewModel price) =>
            Ok(_appPrice.Add(price));

        /// <summary>
        /// Atualizar um preço das origens e destinos
        /// </summary>
        /// <param name="id">Identificador do preço a ser atualizado</param>
        /// <param name="price">Dados do preço a serem atualizados</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PriceViewModel price) =>
            Ok(await _appPrice.Update(id, price));

        /// <summary>
        /// Remover um preço das origens e destinos cadastrado
        /// </summary>
        /// <param name="id">Identificador do preço a ser removido</param>
        [HttpDelete("{id:guid}")]
        public async Task Remove(Guid id) => await _appPrice.Remove(id);
    }
}
