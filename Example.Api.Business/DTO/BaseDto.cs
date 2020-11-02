using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Api.Business.DTO
{
    public abstract class BaseDto
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
