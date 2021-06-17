using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;
using Vortx.Application.Interfaces;
using Vortx.Application.ViewModels;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces;

namespace Vortx.Application.Services
{
    public class AppPlan : IAppPlan
    {
        private readonly IPlanRepository _planRepository;

        public AppPlan(IPlanRepository planRepository) =>
            _planRepository = planRepository;

        public async Task<PlanViewModel> Add(PlanViewModel planViewModel)
        {
            if (await ExistsPlan(planViewModel.Name))
                throw new ApiException("Já existe um plano cadastrado com este nome.");
            var plan = new Plan(
                    planViewModel.Id,
                    planViewModel.Name,
                    planViewModel.TimeMinutes,
                    planViewModel.CreatedAt,
                    planViewModel.UpdatedAt);
            _planRepository.Add(plan);
            return new PlanViewModel(plan);
        }

        public async Task<IEnumerable<PlanViewModel>> GetAll() =>
            (await _planRepository.GetAll()).Select(x => new PlanViewModel(x));

        public async Task<PlanViewModel> GetById(Guid id) =>
            new PlanViewModel(await VerifyPlan(id));

        public async Task Remove(Guid id) =>
            _planRepository.Delete(await VerifyPlan(id));

        public async Task<PlanViewModel> Update(Guid id, PlanViewModel planViewModel)
        {
            var planRepo = await VerifyPlan(id);
            var plan = new Plan(
                    planRepo.Id,
                    planViewModel.Name,
                    planViewModel.TimeMinutes,
                    planRepo.CreatedAt,
                    planRepo.UpdatedAt);
            _planRepository.Update(plan);
            return new PlanViewModel(plan);
        }

        public async Task<Plan> VerifyPlan(Guid id)
        {
            var plan = await _planRepository.GetById(id);
            if (plan == null)
                throw new ApiException("Plano não encontrado!");
            return plan;
        }

        public async Task<bool> ExistsPlan(string name) =>
            await _planRepository.VerifyExists(name);
    }
}
