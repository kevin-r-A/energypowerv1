using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region COLOR
	/// <summary>
	/// This object represents the properties and methods of a COLOR.
	/// </summary>
	public class COLOR
	{
		private int _id;
		private string _cOL_NOMBRE = String.Empty;
		private string _cOL_VALOR = String.Empty;
		private bool _cOL_HABILITADO;
		
		public COLOR()
		{
		}
		
		public COLOR(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@COL_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM COLOR WHERE COL_ID = @COL_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("COLOR does not exist.");
			}
		}
		
		public COLOR(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _cOL_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _cOL_VALOR = reader.GetString(2);
				if (!reader.IsDBNull(3)) _cOL_HABILITADO = reader.GetBoolean(3);
			}
		}
		
		public void Delete()
		{
			COLOR.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@COL_ID", SqlDbType.Int, Id);
            //queryParameters.Append("COL_ID = @COL_ID");

			sql.AddParameter("@COL_NOMBRE", SqlDbType.VarChar, COL_NOMBRE);
			queryParameters.Append("COL_NOMBRE = @COL_NOMBRE");
            //sql.AddParameter("@COL_VALOR", SqlDbType.VarChar, COL_VALOR);
            //queryParameters.Append(", COL_VALOR = @COL_VALOR");
            //sql.AddParameter("@COL_HABILITADO", SqlDbType.Bit, COL_HABILITADO);
            //queryParameters.Append(", COL_HABILITADO = @COL_HABILITADO");

			string query = String.Format("Update COLOR Set {0} Where COL_ID ="+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@COL_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@COL_ID");

			sql.AddParameter("@COL_NOMBRE", SqlDbType.VarChar, COL_NOMBRE);
			queryParameters.Append("@COL_NOMBRE");
            //sql.AddParameter("@COL_VALOR", SqlDbType.VarChar, COL_VALOR);
            //queryParameters.Append(", @COL_VALOR");
            //sql.AddParameter("@COL_HABILITADO", SqlDbType.Bit, COL_HABILITADO);
            //queryParameters.Append(", @COL_HABILITADO");

			string query = String.Format("Insert Into COLOR ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static COLOR NewCOLOR(int id)
		{
			COLOR newEntity = new COLOR();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string COL_NOMBRE
		{
			get {return _cOL_NOMBRE;}
			set {_cOL_NOMBRE = value;}
		}

		public string COL_VALOR
		{
			get {return _cOL_VALOR;}
			set {_cOL_VALOR = value;}
		}

		public bool COL_HABILITADO
		{
			get {return _cOL_HABILITADO;}
			set {_cOL_HABILITADO = value;}
		}
		#endregion
		
		public static COLOR GetCOLOR(int id)
		{
			return new COLOR(id);
		}
		
		public static void Delete(int id)
		{
            try
            {
                Datos.SqlService sql = new Datos.SqlService();
                sql.AddParameter("@COL_ID", SqlDbType.Int, id);

                SqlDataReader reader = sql.ExecuteSqlReader("delete from color where col_id = @COL_ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        public DataTable getColores()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select col_id, col_nombre from color order by col_nombre");
        }
        public static Boolean valRelActivo(string ide)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where col_id=" + ide);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
	}
	#endregion
}

