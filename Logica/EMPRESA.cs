using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region EMPRESA
	/// <summary>
	/// This object represents the properties and methods of a EMPRESA.
	/// </summary>
	public class EMPRESA
	{
		private string _id;
		private string _eMP_NOMBRE = String.Empty;
		private string _eMP_PREFIJO = String.Empty;
		private string _eMP_TOTALDIGITOS = String.Empty;
		
		public EMPRESA()
		{
		}
		
		public EMPRESA(string id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@EMP_ID", SqlDbType.VarChar, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM EMPRESA WHERE EMP_ID = @EMP_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("EMPRESA does not exist.");
			}
		}
		
		public EMPRESA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetString(0);
				if (!reader.IsDBNull(1)) _eMP_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _eMP_PREFIJO = reader.GetString(2);
				if (!reader.IsDBNull(3)) _eMP_TOTALDIGITOS = reader.GetString(3);
			}
		}
		
		public void Delete()
		{
			EMPRESA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@EMP_ID", SqlDbType.VarChar, Id);
			queryParameters.Append("EMP_ID = @EMP_ID");

			sql.AddParameter("@EMP_NOMBRE", SqlDbType.VarChar, EMP_NOMBRE);
			queryParameters.Append(", EMP_NOMBRE = @EMP_NOMBRE");
			sql.AddParameter("@EMP_PREFIJO", SqlDbType.VarChar, EMP_PREFIJO);
			queryParameters.Append(", EMP_PREFIJO = @EMP_PREFIJO");
			sql.AddParameter("@EMP_TOTALDIGITOS", SqlDbType.VarChar, EMP_TOTALDIGITOS);
			queryParameters.Append(", EMP_TOTALDIGITOS = @EMP_TOTALDIGITOS");

			string query = String.Format("Update EMPRESA Set {0} Where EMP_ID = @EMP_ID", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@EMP_ID", SqlDbType.VarChar, Id);
			queryParameters.Append("@EMP_ID");

			sql.AddParameter("@EMP_NOMBRE", SqlDbType.VarChar, EMP_NOMBRE);
			queryParameters.Append(", @EMP_NOMBRE");
			sql.AddParameter("@EMP_PREFIJO", SqlDbType.VarChar, EMP_PREFIJO);
			queryParameters.Append(", @EMP_PREFIJO");
			sql.AddParameter("@EMP_TOTALDIGITOS", SqlDbType.VarChar, EMP_TOTALDIGITOS);
			queryParameters.Append(", @EMP_TOTALDIGITOS");

			string query = String.Format("Insert Into EMPRESA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static EMPRESA NewEMPRESA(string id)
		{
			EMPRESA newEntity = new EMPRESA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string EMP_NOMBRE
		{
			get {return _eMP_NOMBRE;}
			set {_eMP_NOMBRE = value;}
		}

		public string EMP_PREFIJO
		{
			get {return _eMP_PREFIJO;}
			set {_eMP_PREFIJO = value;}
		}

		public string EMP_TOTALDIGITOS
		{
			get {return _eMP_TOTALDIGITOS;}
			set {_eMP_TOTALDIGITOS = value;}
		}
		#endregion
		
		public static EMPRESA GetEMPRESA(string id)
		{
			return new EMPRESA(id);
		}
		
		public static void Delete(string id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@EMP_ID", SqlDbType.VarChar, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete EMPRESA Where EMP_ID = @EMP_ID");
        }

        #region metodos cayman

        public DataSet fGetEmpresas()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataSet("usp_getEmpresas");
        }

        #endregion
    }
	#endregion
}

