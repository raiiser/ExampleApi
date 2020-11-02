using System;

namespace Example.Api.Data.Models
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identifiant
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Date de création
        /// </summary>
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Date de mise à jour
        /// </summary>
        public DateTime? UpdatedDate
        {
            get;
            set;
        }
    }
}
