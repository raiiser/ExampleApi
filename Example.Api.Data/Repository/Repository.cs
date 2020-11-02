using Example.Api.Data.Models;
using Example.Api.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Api.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Le contexte
        /// </summary>
        private readonly ExampleDbContext Context;

        /// <summary>
        /// Collection d'entité T dans le contexte
        /// </summary>
        private DbSet<T> Entities;

        /// <summary>
        /// Constructeur du repository
        /// </summary>
        /// <param name="dbContext">Contexte de la bdd</param>
        public Repository(ExampleDbContext context)
        {
            this.Context = context;
            this.Entities = context.Set<T>();
        }

        /// <summary>
        /// Récupère toutes les entités du repository
        /// </summary>
        /// <returns>La liste des entités du repository</returns>
        public IEnumerable<T> GetAll()
        {
            return this.Entities.AsEnumerable();
        }

        /// <summary>
        /// Récupère une entité en fonction de son id passé en paramètre
        /// </summary>
        /// <param name="id">Identifiant de l'entité à récupérer</param>
        /// <returns>L'entité</returns>
        public T Get(long id)
        {
            return this.Entities.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Ajoute l'entité au contexte
        /// </summary>
        /// <param name="entity">Entité à ajouter</param>
        public T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            this.Context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Met à jour l'entité
        /// </summary>
        /// <param name="entity">Entité à mettre à jour</param>
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Supprime l'entité
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        public void Delete(int id)
        {
            var entity = this.Entities.First(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Remove(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Sauvegarde les changements
        /// </summary>
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
