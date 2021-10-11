using Allied.Domain.Entity;
using Allied.Domain.Interface.Repository;
using Allied.Domain.Interface.Validator;
using Allied.Domain.Validator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allied.Domain.Validator
{
    /// <summary>
    /// Class that implements the phonePlan validator.
    /// </summary>
    public class PhonePlanValidator : EntityValidator<PhonePlan>
    {
        /// <summary>
        /// The phonePlan repository
        /// </summary>
        private IPhonePlanRepository phonePlanRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlanValidator"/> class.
        /// </summary>
        /// <param name="phonePlanRepository">The phonePlan repository.</param>
        public PhonePlanValidator(IPhonePlanRepository phonePlanRepository)
        {
            this.phonePlanRepository = phonePlanRepository;
        }

        /// <summary>
        /// Adds the validator.
        /// </summary>
        /// <returns>
        /// Return the result of validator
        /// </returns>
        public override IBaseValidator<PhonePlan> AddValidator()
        {
            this.CommonRules();
            return base.AddValidator();
        }

        /// <summary>
        /// Updates the validator.
        /// </summary>
        /// <returns>
        /// Return the result of validator
        /// </returns>
        public override IBaseValidator<PhonePlan> UpdateValidator()
        {
            this.CommonRules();
            return base.UpdateValidator();
        }

        /// <summary>
        /// The commons rules.
        /// </summary>
        private void CommonRules()
        {          
        }
    }
}
