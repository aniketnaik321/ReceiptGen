﻿using System;
using System.Data;
//using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Infrastructure
{
    /// <summary>  
    /// Constains overloaded method to access database and run queries  
    /// </summary>  
    public class DbAccess
    {
        private SqlConnection DbConn = new SqlConnection();
        
        private SqlCommand DbCommand = new SqlCommand();
        
        private SqlDataAdapter DbAdapter = new SqlDataAdapter();
        private SqlTransaction DbTran;

        //private string strConnString = ConfigurationManager.ConnectionStrings["SigmaAlloyConnectionStrings"].ConnectionString;
        private string strConnString = ConfigurationManager.ConnectionStrings["invPlain"].ConnectionString;
        public void setConnString(string strConn)
        {   
            try
            {
                strConnString = strConn;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public string getConnString()
        {
            try
            {                
                return strConnString;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void createConn()
        {
            try
            {
                DbConn.ConnectionString = strConnString;
                DbConn.Open();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void closeConnection()
        {
            try
            {
                if (DbConn.State != 0)
                    DbConn.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void beginTrans()
        {
            try
            {
                if (DbTran == null)
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }

                    DbTran = DbConn.BeginTransaction();
                    DbCommand.Transaction = DbTran;
                    //DbAdapter.SelectCommand.Transaction = DbTran;
                    //DbAdapter.InsertCommand.Transaction = DbTran;
                    //DbAdapter.UpdateCommand.Transaction = DbTran;
                    //DbAdapter.DeleteCommand.Transaction = DbTran;
                    //DbTran.Save("Current");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void commitTrans()
        {
            
            try
            {
                if (DbTran != null)
                {
                    DbTran.Commit();
                    DbTran = null;
                }
            }
            catch (Exception exp2)
            {
                DbConn.Close();
                throw exp2;
            }
            
        }

        public void rollbackTrans()
        {
            try
            {
                if (DbTran != null)
                {
                    DbTran.Rollback();
                    
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                DbTran.Dispose();
                DbConn.Close();
                DbAdapter.Dispose();
            }
        }


        /// <summary>  
        /// Fills the Dataset dset and its Table tblname via stored procedure provided as spName arguement.Takes Parameters as param  
        /// </summary>  
        /// <param name="dSet"></param>  
        /// <param name="spName"></param>  
        /// <param name="param"></param>  
        /// <param name="tblName"></param>  
        public void selectStoredProcedure(DataSet dSet, string spName, Hashtable param, string tblName)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                foreach (string para in param.Keys)
                {
                    DbCommand.Parameters.AddWithValue(para, param[para]);


                }


                DbAdapter.SelectCommand = (DbCommand);
                DbAdapter.Fill(dSet, tblName);
            }
            catch (Exception exp)
            {


                throw exp;
            }
        }


        public void selectStoredProcedure(DataSet dSet, string spName, string tblName)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbAdapter.SelectCommand = DbCommand;
                DbAdapter.Fill(dSet, tblName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        public void selectQuery(DataSet dSet, string query, string tblName)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.CommandTimeout = 600;
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.CommandType = CommandType.Text;
                DbAdapter = new SqlDataAdapter(DbCommand);
                DbAdapter.Fill(dSet, tblName);
            }
            catch (Exception exp)
            {
                DbAdapter.Dispose();
                DbConn.Close();
                throw exp;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }


        public int executeQuery(string query)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.CommandTimeout = 400;
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.CommandType = CommandType.Text;
                return DbCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }

        public int executeStoredProcedure(string spName, Hashtable param)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Clear(); 
                foreach (string para in param.Keys)
                {
                    DbCommand.Parameters.AddWithValue(para, param[para]);
                }
                return DbCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int returnint32(string strSql)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                else
                {
                    DbConn.Close();
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = strSql;
                DbCommand.CommandType = CommandType.Text;
                return (int)DbCommand.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Int64 returnint64(string strSql)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = strSql;
                DbCommand.CommandType = CommandType.Text;
                return (Int64)DbCommand.ExecuteScalar();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int executeDataSet(DataSet dSet, string tblName, string strSql)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }


                DbAdapter.SelectCommand.CommandText = strSql;
                DbAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(DbAdapter);


                return DbAdapter.Update(dSet, tblName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool checkDbConnection()
        {
            int _flag = 0;
            try
            {
                if (DbConn.State == ConnectionState.Open)
                {
                    DbConn.Close();
                }


                DbConn.ConnectionString = getConnString();
                DbConn.Open();
                _flag = 1;
            }
            catch (Exception)
            {
                _flag = 0;
            }
            if (_flag == 1)
            {
                DbConn.Close();
                _flag = 0;
                return true;
            }
            else
            {
                return false;
            }


        }

        public string GetColumnValue(string Query)
        {
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.CommandTimeout = 120;
                DbCommand.Connection = DbConn;
                DbCommand.CommandType = CommandType.Text;
                DbCommand.CommandText = Query;


                object objResult = DbCommand.ExecuteScalar();
                if (objResult == null)
                {
                    return "";
                }
                if (objResult == System.DBNull.Value)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(objResult);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }

        public DataSet getDataSet(string query)
        {
            DataSet mydata = new DataSet();
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.CommandType = CommandType.Text;
                DbAdapter = new SqlDataAdapter(DbCommand);
                DbAdapter.Fill(mydata);
                return mydata;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }

        public DataSet fillList(string tableName,string column)
        {
            string query = "select "+column+" from "+tableName;
            DataSet mydata = new DataSet();
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.CommandType = CommandType.Text;
                DbAdapter = new SqlDataAdapter(DbCommand);
                DbAdapter.Fill(mydata);
                return mydata;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }
        public DataTable getDataTable(string query)
        {
            DataTable mydata = new DataTable();
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.CommandTimeout = 400;
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.CommandType = CommandType.Text;
                DbAdapter = new SqlDataAdapter(DbCommand);
                DbAdapter.Fill(mydata);
                return mydata;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                DbAdapter.Dispose();
                DbConn.Close();
            }
        }

     



        public double getValue(String str)
        {
            if (str.Trim() == "")
            {
                return 0;
            }
            try
            {
                return double.Parse(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        
    }
}

