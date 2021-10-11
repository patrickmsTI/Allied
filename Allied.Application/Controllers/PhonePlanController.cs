using Allied.Domain.Entity;
using Allied.Domain.Enumerator;
using Allied.Domain.Interface.Service;
using Allied.Domain.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Allied.Application.Controllers
{
    /// <summary>
    /// Class that implements the phoneplan controller.
    /// </summary>
    [Route("api/[controller]")]
    public class PhonePlanController : BaseController<IPhonePlanService, PhonePlan>
    {
        #region Variables
        /// <summary>
        /// The phoneplan service
        /// </summary>
        private readonly IPhonePlanService _phonePlanService;

        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public PhonePlanController(IPhonePlanService phonePlanService, IConfiguration config) : base(phonePlanService)
        {
            _phonePlanService = phonePlanService;
            _config = config;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert the specified plan.
        /// </summary>
        /// <param name="entidade">The entidade.</param>
        /// <returns>Return the id of entity.</returns>
        [HttpPost]
        public override string Post([FromBody] PhonePlan entidade)
        {
            entidade.Id = _service.GetNextId();
            entidade.AvaiablesDDD = string.Join(", ", entidade.ListDDDAvaiables.Select(s => s.ToString()).ToArray());
            _phonePlanService.Insert(entidade);
            return entidade.Id;
        }


        /// <summary>
        /// Gets the plan by type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Return the plan.</returns>  
        [HttpGet("GetByType")]      
        public IEnumerable<PhonePlan> GetPlanByType(EnumTypePlan type)
        {
            var entidade = _phonePlanService.List().Where(c => c.TypePlan == type);

            if (entidade == null) throw new NotFoundException();

            return entidade;
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="operatorPlan">The operatorPlan.</param>
        /// <returns>Return the plan.</returns>
        [HttpGet("GetByOperator")]
        public IEnumerable<PhonePlan> GetByOperator(EnumOperatorPlan operatorPlan)
        {
            var entidade = _phonePlanService.List().Where(c => c.OperatorPlan == operatorPlan).ToList();

            if (entidade == null) throw new NotFoundException();

            return entidade;
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="planCode">The planCode.</param>
        /// <returns>Return the plan.</returns>
        [HttpGet("GetByPlanCode")]
        public PhonePlan GetByPlanCode(int planCode)
        {
            var entidade = _phonePlanService.List().Where(c => c.PlanCode == planCode).FirstOrDefault();

            if (entidade == null) throw new NotFoundException();

            return entidade;
        }

        /// <summary>
        /// Delete the specified entity.
        /// </summary>
        /// <param name="PlanCode">The identifier.</param>
        [HttpDelete]
        public virtual void Delete(int PlanCode)
        {
            var entidade = _service.List().Where(c => c.PlanCode == PlanCode).FirstOrDefault();
            if (entidade != null) _service.Remove(entidade);
        }
        #endregion
    }
}
