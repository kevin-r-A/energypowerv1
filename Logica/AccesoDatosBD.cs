using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Logica
{
  public class AccesoDatosBD
    {
      public Datos.SqlService conn = new Datos.SqlService();

       protected SqlConnection _connection;
        protected SqlTransaction _transaction;
        protected int _commandTimeout = 60000;
        protected bool _autoCloseConnection = true;

#region PROPIEDADES
        public void Connect()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            else
            {
                _connection = new SqlConnection(conn.ConnectionString);
                _connection.Open();
            }
        }
        public int CommandTimeout
        {
            get
            {
                return _commandTimeout;
            }
            set
            {
                _commandTimeout = value;
            }
        }
        public bool AutoCloseConnection
        {
            get
            {
                return _autoCloseConnection;
            }
            set
            {
                _autoCloseConnection = value;
            }
        }
        public void Disconnect()
        {
            if ((_connection != null) && (_connection.State != ConnectionState.Closed))
            {
                _connection.Close();
            }

            if (_connection != null) _connection.Dispose();
            if (_transaction != null) _transaction.Dispose();

            _transaction = null;
            _connection = null;
        }
#endregion

 #region METODOS
        public DataTable RetornaDT_ConParametros(string procedureName, string[] lparametros, ref string mensaje)
        {
            this.Connect();
            string scadena;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();


            if (lparametros.Length == 1)
                scadena = "'" + lparametros[0] + "'";
            else
                scadena = ArmaParametros(lparametros);

            cmd.Connection = _connection;
            _transaction = _connection.BeginTransaction("Transaccion");

            if (_transaction != null)
                cmd.Transaction = _transaction;

            try
            {
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = procedureName + scadena;
                cmd.CommandTimeout = this.CommandTimeout;

                da.SelectCommand = cmd;
                da.Fill(dt);

                da.Dispose();
                cmd.Dispose();

                _transaction.Commit();
                
                if (dt.Rows.Count > 0)
                mensaje = "iok";
            }
            catch (System.Exception ex)
            {
                mensaje = ex.Message; //mensaje si hubo error en Commit, si no hizo la sentencia sql

                try
                {
                    _transaction.Rollback();
                }
                catch (SqlException sqlex)
                {
                    if (_transaction.Connection != null)
                    {
                        mensaje = Convert.ToString(sqlex.GetType()); //mensaje si hubo error en RollBack
                    }
                }
            }
            finally
            {
                if (this.AutoCloseConnection)
                    this.Disconnect();
            }

            return dt;
        }

        public DataTable RetornaDT_SinParametros(string procedureName, ref string mensaje)
        {
            this.Connect();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cmd.Connection = _connection;
            _transaction = _connection.BeginTransaction("Transaccion");

            if (_transaction != null)
                cmd.Transaction = _transaction;

            try
            {
           
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = procedureName;
                cmd.CommandTimeout = this.CommandTimeout;

                da.SelectCommand = cmd;
                da.Fill(dt);
                da.Dispose();
                cmd.Dispose();

                _transaction.Commit();

                mensaje = "iok";
            }
            catch (System.Exception ex)
            {
                mensaje = ex.Message; //mensaje si hubo error en Commit, si no hizo la sentencia sql
                try
                {
                    _transaction.Rollback();
                }
                catch (SqlException sqlex)
                {
                    if (_transaction.Connection != null)
                    {
                        mensaje = Convert.ToString(sqlex.GetType()); //mensaje si hubo error de conexion en RollBack
                    }
                }
            }
            finally
            {
                if (this.AutoCloseConnection)
                    this.Disconnect();
            }

            return dt;
        }

        public string F_EjecutaTransaccion(string procedureName, string[] Parametros, ref string msgTrans)
        {
            this.Connect();
            string scadena;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            scadena = ArmaParametros(Parametros);

            cmd.Connection = _connection;
            _transaction = _connection.BeginTransaction("Transaccion");

            if (_transaction != null)
                cmd.Transaction = _transaction;

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = procedureName + scadena;
                cmd.CommandTimeout = this.CommandTimeout;

                int filas_Afectadas = cmd.ExecuteNonQuery(); //ExecuteNonQuery es para ejecutar Transacciones SQL Insert, Update, Deletes

                if (filas_Afectadas > 0)
                {
                    _transaction.Commit();
                    cmd.Dispose(); //libera memoria utilizada por sp
                    msgTrans = "iok";
                }
            }
            catch (SqlException sql)
            {
                if (sql.Number == 2627)
                {
                    msgTrans = Convert.ToString(sql.Number);
                }
                else
                {
                    msgTrans = "Error: " + sql.Message + " ==>> Tipo Excepción: " + sql.GetType() +  "==>> Codigo Exepción: " + sql.Number; //mensaje si hubo error en Commit, si no hizo la sentencia sql
                }
                try
                {
                    _transaction.Rollback();
                }
                catch (SqlException sqlex)
                {
                    if (_transaction.Connection != null)
                    {
                        msgTrans = "Error RollBack: " + sqlex.Message + " >> Numero Excepción:" + sqlex.Number; //mensaje si hubo error de conexion en RollBack
                    }
                }
            }
            catch (System.Exception ex)
            {
                msgTrans = "Error: " + ex.Message + " >> Tipo Excepción: " + ex.GetType(); //mensaje si hubo error del Sistema 
            }

            finally
            {
                if (this.AutoCloseConnection)
                    this.Disconnect();
            }

            return msgTrans;
        
        }

        private string ArmaParametros(string[] lparametros)
        {
            string parametros = "";
            int i = 0;

            for (i = 0; i <= lparametros.Length - 1; i++)
            {
                parametros = parametros + "'" + lparametros[i] + "'" + ",";

            }

            parametros = parametros.Substring(0, parametros.Length - 1);
            
            return parametros;
        }

 #endregion

    }
}

