using Example.Api.Data.Models;

namespace Example.Api.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Récupére un utilisateur en fonction de son login et mot de passe passé en paramètre
        /// </summary>
        /// <param name="login">Login de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <returns>L'utilisateur correspondant au login et mot de passe en paramètre</returns>
        User GetByLoginAndPassword(string login, string password);
    }
}
