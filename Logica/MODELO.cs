using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region MODELO
	/// <summary>
	/// This object represents the properties and methods of a MODELO.
	/// </summary>
	public class MODELO
	{
		private int _id;
		private string _mOD_NOMBRE = String.Empty;
		private string _mOD_VALOR = String.Empty;
		private int _mAR_ID;
		
		public MODELO()
		{
		}
		
		public MODELO(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@MOD_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM MODELO WHERE MOD_ID = @MOD_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("MODELO does not exist.");
			}
		}
		
		public MODELO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _mOD_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _mOD_VALOR = reader.GetString(2);
				if (!reader.IsDBNull(3)) _mAR_ID = reader.GetInt32(3);
			}
		}
		
		public void Delete()
		{
			MODELO.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@MOD_ID", SqlDbType.Int, Id);
            //queryParameters.Append("MOD_ID = @MOD_ID");

			sql.AddParameter("@MOD_NOMBRE", SqlDbType.VarChar, MOD_NOMBRE);
			queryParameters.Append("MOD_NOMBRE = @MOD_NOMBRE");
            //sql.AddParameter("@MOD_VALOR", SqlDbType.VarChar, MOD_VALOR);
            //queryParameters.Append(", MOD_VALOR = @MOD_VALOR");
            //sql.AddParameter("@MAR_ID", SqlDbType.Int, MAR_ID);
            //queryParameters.Append(", MAR_ID = @MAR_ID");

			string query = String.Format("Update MODELO Set {0} Where MOD_ID = "+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@MOD_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@MOD_ID");

			sql.AddParameter("@MOD_NOMBRE", SqlDbType.VarChar, MOD_NOMBRE);
			queryParameters.Append("@MOD_NOMBRE");
            //sql.AddParameter("@MOD_VALOR", SqlDbType.VarChar, MOD_VALOR);
            //queryParameters.Append(", @MOD_VALOR");
			sql.AddParameter("@MAR_ID", SqlDbType.Int, MAR_ID);
			queryParameters.Append(", @MAR_ID");

			string query = String.Format("Insert Into MODELO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static MODELO NewMODELO(int id)
		{
			MODELO newEntity = new MODELO();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string MOD_NOMBRE
		{
			get {return _mOD_NOMBRE;}
			set {_mOD_NOMBRE = value;}
		}

		public string MOD_VALOR
		{
			get {return _mOD_VALOR;}
			set {_mOD_VALOR = value;}
		}

		public int MAR_ID
		{
			get {return _mAR_ID;}
			set {_mAR_ID = value;}
		}
		#endregion
		
		public static MODELO GetMODELO(int id)
		{
			return new MODELO(id);
		}

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from modelo where mod_id=" + id);
        }
        public static Boolean valRelActivo(string idmod)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where mod_id=" + idmod);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public DataSet fGetModeloMarid(int marid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select mod_id, mod_nombre from modelo where mar_id=" + marid + " order by mod_nombre");
        }

	}
	#endregion
}

