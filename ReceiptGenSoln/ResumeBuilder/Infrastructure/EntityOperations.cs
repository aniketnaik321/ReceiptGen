
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using Dapper;
using ResumeBuilder.Service;

namespace ResumeBuilder.Infrastructure
{
    public class EntityOperations<TDto, TEty> : IEntityOperations<TDto, TEty>, IDisposable where TEty:class where TDto:class
    {
        public string DbFile
        {
            get { return Environment.SystemDirectory + "\\ResumeBuilderDB.db"; }
        }

        public SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }

        public EntityOperations()
        {
          
        }

        public bool Delete(object id) {
            bool result = true;
            using(var conn=SimpleDbConnection()){
                conn.Open();
                try
                {
                    conn.Execute("delete from " + EtyService.GetTableName<TDto>() + " where id=" + Convert.ToString(id));
                }
                catch (Exception) { 
                result = false;
                }
                finally {
                    conn.Close();
                }
            }
            return result;
        }

        public void Dispose()
        {
            try {
            //    SimpleDbConnection

            } catch (Exception) { }            
        }

        public TDto FindById(object id)
        {
            TDto result;
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                result= cnn.Query<TDto>(
                    @"SELECT * from "+ EtyService.GetTableName<TDto>()+" where id=@id" , new { id }).FirstOrDefault();
                return result;
            }
        }

        public IQueryable<TEty> GetAll()
        {
            return null;
        }

        public List<TDto> GetList()
        {
            List<TDto> result;
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
               result = cnn.Query<TDto>(
                    @"SELECT * from " + EtyService.GetTableName<TDto>()).ToList();
            }
            return result;
        }

        public bool Save(TDto inp)
        {
            bool _result=false;
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                 cnn.Query<TDto>(
                     @"SELECT * from " + EtyService.GetTableName<TDto>()).ToList();
            }
            return _result;           
        }

        public bool Update(TDto inp, object id)
        {
            bool result = true;            
            TEty entityInput = null;
            return result;
        }

        public bool UpdateEntity(TEty inp, object id)
        {
            bool result = true;
          
            return result;
        }
    }
}
