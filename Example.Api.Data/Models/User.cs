using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Api.Data.Models
{
    /// <summary>
    /// Utilisateur
    /// </summary>
    [Table("Utilisateur")]
    public class User : BaseEntity
    {
        /// <summary>
        /// Login
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(100)]
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
