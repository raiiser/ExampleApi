using Example.Api.Data.Models;
using Example.Api.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Example.Api.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region PROPERTIES

        /// <summary>
        /// Contexte
        /// </summary>
        private ExampleDbContext Context;

        /// <summary>
        /// Entité User
        /// </summary>
        private DbSet<User> UserEntity;

        #endregion PROPERTIES

        #region CONSTRUCTOR

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Context entity</param>
        public UserRepository(ExampleDbContext context) : base(context)
        {
            this.Context = context;
            this.UserEntity = context.Set<User>();
        }

        #endregion CONSTRUCTOR

        #region METHODS
        /// <summary>
        /// Récupére un utilisateur en fonction de son login et mot de passe passé en paramètre
        /// </summary>
        /// <param name="login">Login de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <returns>L'utilisateur correspondant au login et mot de passe en paramètre</returns>
        public User GetByLoginAndPassword(string login, string password)
        {
            return this.UserEntity.Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
        }

        #endregion METHODS
    }
}