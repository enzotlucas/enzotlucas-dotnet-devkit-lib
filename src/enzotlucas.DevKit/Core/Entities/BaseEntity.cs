namespace enzotlucas.DevKit.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Get the entity identifier
        /// </summary>
        /// <returns>The <see cref="Guid"/> that represents the entity Id</returns>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Get the entity creation date
        /// </summary>
        /// <returns>A <see cref="DateTime"/> that represants the entity creation date</returns>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Get the entity last update date
        /// </summary>
        /// <returns>A <see cref="DateTime"/> that represants the entity last update date</returns>
        public DateTime UpdatedAt { get; protected set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
