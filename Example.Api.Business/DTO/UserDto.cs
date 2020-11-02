using Example.Api.Business.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Example.Api.Business
{
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Login
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [RegularExpression("^(.+)@(.+)$")]
        public string Mail { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Date de dernière connexion
        /// </summary>
        public DateTime? LastConnection { get; set; }
    }
}
