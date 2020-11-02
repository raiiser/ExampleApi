using Example.Api.Business.DTO;
using Example.Api.Business.Services.Interfaces;
using Example.Api.Data.Models;
using Example.Api.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Api.Business.Services
{
    /// <summary>
    /// Service de base
    /// </summary>
    public abstract class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto 
    {
        private IRepository<TEntity> Repository;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="repository">Repository</param>
        public Service(IRepository<TEntity> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Récupère l'entité en fonction de son identifiant passé en paramètre
        /// </summary>
        /// <param name="id">L'identifiant de l'entité à récupérer</param>
        /// <returns>L'entité</returns>
        public virtual TDto GetById(int id)
        {
            TEntity entity = this.Repository.Get(id);

            var dto = this.EntityToDto(entity);
            return dto;
        }

        /// <summary>
        /// Récupère toutes les entités
        /// </summary>
        /// <returns>La liste des entités</returns>
        public virtual IEnumerable<TDto> GetAll()
        {
            var all = this.Repository.GetAll();

            return all.Select(a => this.EntityToDto(a));
        }

        /// <summary>
        /// Ajoute l'entité passée en paramètre
        /// </summary>
        /// <param name="entity">L'entité à ajouter</param>
        /// <returns>Vrai si tout s'est bien déroulé</returns>
        public virtual TDto Add(TDto dto)
        {
            try
            {
                if (dto != null)
                {
                    // TODO Validation entité (Attribut sur le dto ?)
                    //https://enterprisecraftsmanship.com/posts/combining-asp-net-core-attributes-with-value-objects/

                    var entity = this.DtoToEntity(dto);
                    entity.CreatedDate = DateTime.Now; // TODO à mettre en filter dans le dbcontext
                    return this.EntityToDto(this.Repository.Add(entity));
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Mise à jour de l'entité en paramètre
        /// </summary>
        /// <param name="entity">Entité à mettre à jour</param>
        /// <returns>Vrai si la mise à jour s'est bien déroulée</returns>
        public virtual TDto Update(TDto dto)
        {
            try
            {
                if (dto != null)
                {
                    var entity = this.DtoToEntity(dto);
                    entity.UpdatedDate = DateTime.Now;

                    return this.EntityToDto(this.Repository.Update(entity));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Supprime l'entité en paramètre
        /// </summary>
        /// <param name="entity">Entité à supprimer</param>
        /// <returns>Vrai si la suppression a été effectuée</returns>
        public virtual void Delete(int id)
        {
            try
            {
                this.Repository.Delete(id);
            }
            catch (Exception e)
            {
            }
        }

        protected abstract TEntity DtoToEntity(TDto dto);
        protected abstract TDto EntityToDto(TEntity entity);
    }
}
