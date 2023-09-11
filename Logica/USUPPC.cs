using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region USUPPC
	/// <summary>
	/// This object represents the properties and methods of a USUPPC.
	/// </summary>
	public class USUPPC
	{
		private string _id;
		private string _uPP_CLAVE = String.Empty;
		
		public USUPPC()
		{
		}
		
		public USUPPC(string id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UPP_USUARIO", SqlDbType.VarChar, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM USUPPC WHERE UPP_USUARIO = @UPP_USUARIO");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("USUPPC does not exist.");
			}
		}
		
		public USUPPC(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetString(0);
				if (!reader.IsDBNull(1)) _uPP_CLAVE = reader.GetString(1);
			}
		}
		
		public void Delete()
		{
			USUPPC.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@UPP_USUARIO", SqlDbType.VarChar, Id);
			//queryParameters.Append("UPP_USUARIO = @UPP_USUARIO");

			sql.AddParameter("@UPP_CLAVE", SqlDbType.VarChar, UPP_CLAVE);
			queryParameters.Append("UPP_CLAVE = @UPP_CLAVE");

			string query = String.Format("Update USUPPC Set {0} Where UPP_USUARIO = @UPP_USUARIO", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@UPP_USUARIO", SqlDbType.VarChar, Id);
			queryParameters.Append("@UPP_USUARIO");

			sql.AddParameter("@UPP_CLAVE", SqlDbType.VarChar, UPP_CLAVE);
			queryParameters.Append(", @UPP_CLAVE");

			string query = String.Format("Insert Into USUPPC ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static USUPPC NewUSUPPC(string id)
		{
			USUPPC newEntity = new USUPPC();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string UPP_CLAVE
		{
			get {return _uPP_CLAVE;}
			set {_uPP_CLAVE = value;}
		}
		#endregion
		
		public static USUPPC GetUSUPPC(string id)
		{
			return new USUPPC(id);
		}
		
		public static void Delete(string id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UPP_USUARIO", SqlDbType.VarChar, id);

            sql.ExecuteSql("delete from usurolppc where upp_usuario='" + id + "'");
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete USUPPC Where UPP_USUARIO = @UPP_USUARIO");
		}

        public static DataTable Cargar()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select upp_usuario Id, upp_usuario+ ' - [ '+upp_clave+' ]' Clave from usuppc order by upp_usuario");
        }
	}
	#endregion
}

