//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResumeBuilder.Infrastructure
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data.SqlClient;
//    using System.Linq;
//    using System.Threading.Tasks;
//    using Dapper;
//    using MySql.Data.MySqlClient;

//    namespace MyApp
//    {
//        public interface IRepository<T> where T : class
//        {
//            Task<IEnumerable<T>> GetAllAsync();
//            Task<T> GetByIdAsync(int id);
//            Task<int> InsertAsync(T entity);
//            Task<int> UpdateAsync(T entity);
//            Task<int> DeleteAsync(int id);
//        }

//        public class Repository<T> : IRepository<T> where T : class
//        {
//            private readonly string _connectionString;
//            private readonly string _tableName;

//            public Repository(string connectionString, string tableName)
//            {
//                _connectionString = connectionString;
//                _tableName = tableName;
//            }

//            public async Task<IEnumerable<T>> GetAllAsync()
//            {
//                using (var connection = new MySqlConnection(_connectionString))
//                {
//                    return await connection.QueryAsync<T>($"SELECT * FROM {_tableName}");
//                }
//            }

//            public async Task<T> GetByIdAsync(int id)
//            {
//                using (var connection = new MySqlConnection(_connectionString))
//                {
//                    return await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE id = @id", new { id });
//                }
//            }

//            public async Task<int> InsertAsync(T entity)
//            {
//                using (var connection = new MySqlConnection(_connectionString))
//                {
//                    return await connection.ExecuteAsync($"INSERT INTO {_tableName} ({string.Join(", ", entity.GetType().GetProperties().Select(p => p.Name))}) VALUES (@{string.Join(", @", entity.GetType().GetProperties().Select(p => p.Name))})", entity);
//                }
//            }

//            public async Task<int> UpdateAsync(T entity)
//            {
//                using (var connection = new MySqlConnection(_connectionString))
//                {
//                    var properties = entity.GetType().GetProperties().Where(p => p.Name != "Id");
//                    return await connection.ExecuteAsync($"UPDATE {_tableName} SET {string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"))} WHERE id = @Id", entity);
//                }
//            }

//            public async Task<int> DeleteAsync(int id)
//            {
//                using (var connection = new MySqlConnection(_connectionString))
//                {
//                    return await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE id = @id", new { id });
//                }
//            }
//        }
//    }

//}
