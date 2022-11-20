
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
    public class EntityOperations<TEty> : IEntityOperations<TEty>, IDisposable where TEty:class
    {
        public string DbFile
        {
            get { return Environment.CurrentDirectory + "\\ResumeBuilderDB.db"; }
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
                    conn.Execute("delete from " + EtyService.GetTableName<TEty>() + " where id=" + Convert.ToString(id));
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

        public TEty FindById(object id)
        {
            TEty result;
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                result= cnn.Query<TEty>(
                    @"SELECT * from "+ EtyService.GetTableName<TEty>()+" where id=@id" , new { id }).FirstOrDefault();
                return result;
            }
        }

        public IQueryable<TEty> GetAll()
        {
            return null;
        }

        public List<TEty> GetList()
        {
            List<TEty> result =new List<TEty>();
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
               result = cnn.Query<TEty>(
                    @"SELECT * from " + EtyService.GetTableName<TEty>()).ToList();
            }
            return result;
        }

        public int Save(TEty inp)
        {
            int _result=0;
            using (var conn = SimpleDbConnection())
            {
                conn.Open();
                try {
                  _result=  conn.ExecuteScalar<int>(
                         @"INSERT INTO " + EtyService.GetTableName<TEty>() + "(" +
                         string.Join(",", EtyService.GetColumnNames<TEty>())
                         + ") values(@" + string.Join(",@", EtyService.GetColumnNames<TEty>()) + " );SELECT last_insert_rowid();", inp);
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    conn.Close();
                }
                 
            }
            return _result;           
        }

        public bool Update(TEty inp, object id)
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
