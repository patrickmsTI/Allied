using Allied.Domain.Entity;
using Allied.Domain.Interface.Repository;

namespace Allied.Data
{
    /// <summary>
    /// Class that implements the phoneplan repository
    /// </summary>
    public class PhonePlanRepository : BaseRepository<PhonePlan>, IPhonePlanRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlanRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public PhonePlanRepository(BaseContext context) : base(context) 
        { }
    }
}
