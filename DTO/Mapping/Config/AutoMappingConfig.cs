namespace YerbaSoft.DTO.Mapping.Config
{
    public abstract class AutoMappingConfig
    {
        /// <summary>
        /// Indica si se utilizará la interface IExtraMapping
        /// </summary>
        abstract internal bool UseExtraMapping { get; }

        /// <summary>
        /// Indica si se mostrará un error al mapear erróneamente un campo marcado como Direct (False ignora el error)
        /// </summary>
        abstract internal bool ThrowErrorOnDirect { get; }

        /// <summary>
        /// Indica si se deben mapear las subclases
        /// </summary>
        abstract internal bool MapSubClass { get; }

        /// <summary>
        /// Indica si al buscar las propiedades, se utiliza "Case Sesitive"
        /// </summary>
        abstract internal bool CaseSensitive { get; }
    }
}
