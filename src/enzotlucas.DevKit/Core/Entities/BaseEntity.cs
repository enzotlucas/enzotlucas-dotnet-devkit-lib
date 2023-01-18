namespace enzotlucas.DevKit.Core.Entities
{
    /// <summary>
    /// Entity base for application entities. Covers id, creation date and last update date.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Get the entity identifier.
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Get the entity creation date.
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Get the entity last update date.
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime UpdatedAt { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class with a id, creation date and update date defined.
        /// </summary>
        /// <returns><see cref="BaseEntity"/></returns>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
