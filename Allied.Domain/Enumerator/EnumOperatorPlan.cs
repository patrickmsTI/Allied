using System.ComponentModel;

namespace Allied.Domain.Enumerator
{
    /// <summary>
    /// Enumerator that defines the type of plan.
    /// </summary>
    public enum EnumOperatorPlan
    {
        /// <summary>
        /// Define the OperatorPlan Claro.
        /// </summary>
        [Description("Claro")]
        CLARO,
        
        /// <summary>
        /// Define the OperatorPlan Vivo.
        /// </summary>
        [Description("Vivo")]
        VIVO,

        /// <summary>
        /// Define the OperatorPlan Tim.
        /// </summary>
        [Description("Tim")]
        TIM,

        /// <summary>
        /// Define the OperatorPlan Oi.
        /// </summary>
        [Description("Oi")]
        OI,


        /// <summary>
        /// Define the OperatorPlan Vivo.
        /// </summary>
        [Description("Nextel")]
        NEXTEL,
    }
}
