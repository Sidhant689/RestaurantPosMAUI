using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.InterfaceRepositories
{
    /// <summary>
    /// 
    /// The use of async methods in the IRepository<T> interface is a common practice in modern .NET development, especially when working with databases. Here's why:

    /// I/O Operations: Database operations are I/O-bound, meaning they spend most of their time waiting for the database to respond rather than using CPU. Async methods 
    /// allow the thread to be released back to the thread pool while waiting for the I/O operation to complete, improving overall application responsiveness and scalability.
    /// Scalability: In a web application, using async methods allows the server to handle more concurrent requests with fewer threads.This is because threads are not blocked 
    /// waiting for I/O operations to complete.
    /// Performance: While async doesn't necessarily make individual operations faster, it improves the overall throughput of the application, especially under high load.
    /// Consistency: By making all methods async, you ensure that consumers of this interface can use async/await throughout their codebase, leading to more consistent and maintainable code.
    /// Future-proofing: Even if your current implementation doesn't require async operations, having the interface defined with async methods allows for future implementations 
    /// that might benefit from asynchronous operations without breaking the contract.
    /// Best Practice: It's generally considered a best practice to use async methods for I/O operations in .NET, as recommended by Microsoft.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 

    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
