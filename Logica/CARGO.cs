using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region CARGO
	/// <summary>
	/// This object represents the properties and methods of a CARGO.
	/// </summary>
	public class CARGO
	{
		private int _id;
		private string _cGO_NOMBRE = String.Empty;
		private bool _cGO_HABILITADO;
		
		public CARGO()
		{
		}
		
		public CARGO(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CGO_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CARGO WHERE CGO_ID = @CGO_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("CARGO does not exist.");
			}
		}
		
		public CARGO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _cGO_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _cGO_HABILITADO = reader.GetBoolean(2);
			}
		}
		
		public void Delete()
		{
			CARGO.Delete(_id);
		}
		
		public void Update()
		{
             try
            {
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CGO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("CGO_ID = @CGO_ID");

			sql.AddParameter("@CGO_NOMBRE", SqlDbType.VarChar, CGO_NOMBRE);
			queryParameters.Append("CGO_NOMBRE = @CGO_NOMBRE");
            //sql.AddParameter("@CGO_HABILITADO", SqlDbType.Bit, CGO_HABILITADO);
            //queryParameters.Append(", CGO_HABILITADO = @CGO_HABILITADO");

			string query = String.Format("Update CARGO Set {0} Where CGO_ID = "+ Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
                        }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		
		public void Create()
		{
            try
            {
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CGO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@CGO_ID");

			sql.AddParameter("@CGO_NOMBRE", SqlDbType.VarChar, CGO_NOMBRE);
			queryParameters.Append("@CGO_NOMBRE");
            //sql.AddParameter("@CGO_HABILITADO", SqlDbType.Bit, CGO_HABILITADO);
            //queryParameters.Append(", @CGO_HABILITADO");

			string query = String.Format("Insert Into CARGO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
                        }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		
		public static CARGO NewCARGO(int id)
		{
			CARGO newEntity = new CARGO();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string CGO_NOMBRE
		{
			get {return _cGO_NOMBRE;}
			set {_cGO_NOMBRE = value;}
		}

		public bool CGO_HABILITADO
		{
			get {return _cGO_HABILITADO;}
			set {_cGO_HABILITADO = value;}
		}
		#endregion
		
		public static CARGO GetCARGO(int id)
		{
			return new CARGO(id);
		}
		
		public static void Delete(int id)
		{
            try
            {
                Datos.SqlService sql = new Datos.SqlService();
                sql.AddParameter("@CGO_ID", SqlDbType.Int, id);

                SqlDataReader reader = sql.ExecuteSqlReader("DELETE FROM CARGO Where CGO_ID = @CGO_ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
        public DataSet fGetCargos()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataSet("usp_getCargos");
        }

        public DataTable getCargos()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select cgo_id, cgo_nombre from cargo order by cgo_nombre");
        }
        public static Boolean valRelActivo(string ide)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cus_id from custodio where cgo_id=" + ide );
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
	}
	#endregion
}

