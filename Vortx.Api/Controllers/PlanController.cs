using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vortx.Application.Interfaces;
using Vortx.Application.ViewModels;

namespace Vortx.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanController : Controller
    {
        private readonly IAppPlan _appPlan;

        public PlanController(IAppPlan appPlan) => _appPlan = appPlan;

        /// <summary>
        /// Consultar todos os planos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _appPlan.GetAll());

        /// <summary>
        /// Consultar plano por id
        /// </summary>
        /// <param name="id">Identificador do plano a ser consultado</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) =>
            Ok(await _appPlan.GetById(id));

        /// <summary>
        /// Cadastrar novo plano
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]PlanViewModel plan) =>
            Ok(_appPlan.Add(plan)); 

        /// <summary>
        /// Atualizar um plano
        /// </summary>
        /// <param name="id">Identificador do plano a ser atualizado</param>
        /// <param name="plan">Dados do plano a serem atualizados</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]PlanViewModel plan) =>
            Ok(await _appPlan.Update(id, plan));

        /// <summary>
        /// Remover um plano cadastrado
        /// </summary>
        /// <param name="id">Identificador do plano a ser removido</param>
        [HttpDelete("{id:guid}")]
        public async Task Remove(Guid id) => await _appPlan.Remove(id);

    }
}
