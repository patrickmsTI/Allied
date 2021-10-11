using System.ComponentModel;

namespace Allied.Domain.Enumerator
{
    /// <summary>
    /// Enumerator that defines the type of plan.
    /// </summary>
    public enum EnumTypePlan
    {
        /// <summary>
        /// Define the type Controle.
        /// </summary>
        [Description("Controle")]
        Controle,

        /// <summary>
        /// Define the type Pos.
        /// </summary>
        [Description("Pós")]
        Pos,

        /// <summary>
        /// Define the type Pre.
        /// </summary>
        [Description("Pré")]
        Pre,
    }
}
