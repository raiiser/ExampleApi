using Example.Api.Data.Models;
using System.Collections.Generic;

namespace Example.Api.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(long id);

        /// <summary>
        /// Ajoute l'entité au contexte
        /// </summary>
        /// <param name="entity">Entité à ajouter</param>
        T Add(T entity);

        /// <summary>
        /// Met à jour l'entité
        /// </summary>
        /// <param name="entity">Entité à mettre à jour</param>
        T Update(T entity);

        /// <summary>
        /// Supprime l'entité
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        void Delete(int id);

        void SaveChanges();
    }
}
