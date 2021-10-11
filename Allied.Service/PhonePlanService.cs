using Allied.Domain.Entity;
using Allied.Domain.Interface.Repository;
using Allied.Domain.Interface.Service;
using Allied.Domain.Interface.Validator;
using Allied.Domain.Validator;
using System;

namespace Allied.Service
{
    public class PhonePlanService : BaseService<PhonePlan>, IPhonePlanService
    {
        /// <summary>
        /// The phonePlan repository.
        /// </summary>
        private IPhonePlanRepository phonePlanRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlanService"/> class.
        /// </summary>
        /// <param name="phonePlanRepository">The phonePlan repository.</param>
        public PhonePlanService(IPhonePlanRepository phonePlanRepository)
            : base(phonePlanRepository)
        {
            this.phonePlanRepository = phonePlanRepository;
        }

        /// <summary>
        /// Gets the validador.
        /// </summary>
        /// <value>
        /// The validador.
        /// </value>
        protected override IBaseValidator<PhonePlan> Validador
        {
            get
            {
                return new PhonePlanValidator(this.phonePlanRepository);
            }
        }

        
    }
}
