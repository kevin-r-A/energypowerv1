using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region UNIDAD
	/// <summary>
	/// This object represents the properties and methods of a UNIDAD.
	/// </summary>
	public class UNIDAD
	{
		private int _id;
		private string _uNI_SIMBOLO = String.Empty;
		private string _uNI_NOMBRE = String.Empty;
		
		public UNIDAD()
		{
		}
		
		public UNIDAD(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UNI_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM UNIDAD WHERE UNI_ID = @UNI_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("UNIDAD does not exist.");
			}
		}
		
		public UNIDAD(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _uNI_SIMBOLO = reader.GetString(1);
				if (!reader.IsDBNull(2)) _uNI_NOMBRE = reader.GetString(2);
			}
		}
		
		public void Delete()
		{
			UNIDAD.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			//sql.AddParameter("@UNI_ID", SqlDbType.Int, Id);
			//queryParameters.Append("UNI_ID = @UNI_ID");

			sql.AddParameter("@UNI_SIMBOLO", SqlDbType.VarChar, UNI_SIMBOLO);
			queryParameters.Append("UNI_SIMBOLO = @UNI_SIMBOLO");
			//sql.AddParameter("@UNI_NOMBRE", SqlDbType.VarChar, UNI_NOMBRE);
			//queryParameters.Append(", UNI_NOMBRE = @UNI_NOMBRE");

			string query = String.Format("Update UNIDAD Set {0} Where UNI_ID ="+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			//sql.AddParameter("@UNI_ID", SqlDbType.Int, Id);
			//queryParameters.Append("@UNI_ID");

			sql.AddParameter("@UNI_SIMBOLO", SqlDbType.VarChar, UNI_SIMBOLO);
			queryParameters.Append("@UNI_SIMBOLO");
			//sql.AddParameter("@UNI_NOMBRE", SqlDbType.VarChar, UNI_NOMBRE);
			//queryParameters.Append(", @UNI_NOMBRE");

			string query = String.Format("Insert Into UNIDAD ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static UNIDAD NewUNIDAD(int id)
		{
			UNIDAD newEntity = new UNIDAD();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string UNI_SIMBOLO
		{
			get {return _uNI_SIMBOLO;}
			set {_uNI_SIMBOLO = value;}
		}

		public string UNI_NOMBRE
		{
			get {return _uNI_NOMBRE;}
			set {_uNI_NOMBRE = value;}
		}
		#endregion
		
		public static UNIDAD GetUNIDAD(int id)
		{
			return new UNIDAD(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UNI_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete UNIDAD Where UNI_ID = @UNI_ID");
		}

		public DataTable getUnidades()
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataTable("select uni_id, uni_simbolo from unidad order by uni_simbolo");
		}

		public static Boolean valRelActivo(string caract)
		{
			Boolean hayrel = false;

			Datos.SqlService sql = new Datos.SqlService();
			Object obj = sql.ExecuteSqlObject("select top 1 car_id from caracteristica where uni_id='"+caract+"'");
			if (obj != null)
				hayrel = true;
			return hayrel;
		}
		public static bool fgetUniIng(string simbolo)
		{
			Datos.SqlService sql = new Datos.SqlService();
			Object obj = sql.ExecuteSqlObject("select uni_id from unidad where uni_simbolo='" + simbolo + "'");
			if (obj == null)
				return false;
			else
				return true;
		}
	}
	#endregion
}

