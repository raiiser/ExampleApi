using System.ComponentModel.DataAnnotations;

namespace Example.Api.Business.DTO
{
    public class LoginDto
    {
        /// <summary>
        /// Login
        /// </summary>
        [Required(ErrorMessage = "Le login est obligatoire")]
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        public string Password { get; set; }
    }
}
