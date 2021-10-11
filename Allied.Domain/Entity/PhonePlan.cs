using Allied.Domain.Enumerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Allied.Domain.Entity
{
    /// <summary>
    /// Class that implements the PhonePlan
    /// </summary>
    public class PhonePlan : BaseEntity
    {
        /// <summary>
        /// Gets or sets the PlanCode
        /// </summary>
        [Key]
        public int PlanCode { get; set; }

        /// <summary>
        /// Gets or sets the minutes.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Gets or sets the franchise.
        /// </summary>
        public int Franchise { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the TypePlan.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumTypePlan TypePlan { get; set; }


        /// <summary>
        /// Gets or sets the OperatorPlan.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumOperatorPlan OperatorPlan { get; set; }

        public string AvaiablesDDD { get; set; }

        /// <summary>
        /// Gets or sets the list of DDD Avaiables for this plan.
        /// </summary>
        [NotMapped] 
        public List<EnumDDD> ListDDDAvaiables { get; set; }
    }
}
