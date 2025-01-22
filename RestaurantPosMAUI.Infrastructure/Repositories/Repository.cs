using Microsoft.EntityFrameworkCore;
using RestaurantPosMAUI.Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.Repositories
{
    /// <summary>
    /// Generic repository class for database operations.
    /// </summary>
    /// <typeparam name="T">The entity type this repository works with.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDBContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Constructor that initializes the database context and entity set.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Repository(AppDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();  // Get the DbSet for the entity type T
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);  // Add the entity to the DbSet
            await _context.SaveChangesAsync();  // Save changes to the database
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);  // Mark the entity for deletion
            await _context.SaveChangesAsync();  // Save changes to the database
        }

        /// <summary>
        /// Retrieves all entities of type T from the database.
        /// </summary>
        /// <returns>An IEnumerable of all entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();  // Asynchronously fetch all entities
        }

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID, or null if not found.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);  // Find an entity by its primary key
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;  // Mark the entity as modified
            await _context.SaveChangesAsync();  // Save changes to the database
        }
    }
}
