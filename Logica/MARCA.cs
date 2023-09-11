using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region MARCA
	/// <summary>
	/// This object represents the properties and methods of a MARCA.
	/// </summary>
	public class MARCA
	{
		private int _id;
		private string _mAR_NOMBRE = String.Empty;
		private string _mAR_VALOR = String.Empty;
		
		public MARCA()
		{
		}
		
		public MARCA(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@MAR_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM MARCA WHERE MAR_ID = @MAR_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("MARCA does not exist.");
			}
		}
		
		public MARCA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _mAR_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _mAR_VALOR = reader.GetString(2);
			}
		}
		
		public void Delete()
		{
			MARCA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@MAR_ID", SqlDbType.Int, Id);
            //queryParameters.Append("MAR_ID = @MAR_ID");

			sql.AddParameter("@MAR_NOMBRE", SqlDbType.VarChar, MAR_NOMBRE);
			queryParameters.Append("MAR_NOMBRE = @MAR_NOMBRE");
            //sql.AddParameter("@MAR_VALOR", SqlDbType.VarChar, MAR_VALOR);
            //queryParameters.Append(", MAR_VALOR = @MAR_VALOR");

			string query = String.Format("Update MARCA Set {0} Where MAR_ID ="+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@MAR_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@MAR_ID");

			sql.AddParameter("@MAR_NOMBRE", SqlDbType.VarChar, MAR_NOMBRE);
			queryParameters.Append("@MAR_NOMBRE");
            //sql.AddParameter("@MAR_VALOR", SqlDbType.VarChar, MAR_VALOR);
            //queryParameters.Append(", @MAR_VALOR");

			string query = String.Format("Insert Into MARCA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static MARCA NewMARCA(int id)
		{
			MARCA newEntity = new MARCA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string MAR_NOMBRE
		{
			get {return _mAR_NOMBRE;}
			set {_mAR_NOMBRE = value;}
		}

		public string MAR_VALOR
		{
			get {return _mAR_VALOR;}
			set {_mAR_VALOR = value;}
		}
		#endregion
		
		public static MARCA GetMARCA(int id)
		{
			return new MARCA(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from modelo where mar_id=" + id);
            sql.ExecuteSql("delete from marca where mar_id="+id);
		}

        public string guardarMarca()
        {
            Datos.SqlService sql = new Datos.SqlService();

            sql.AddParameter("@MAR_NOMBRE", SqlDbType.VarChar, MAR_NOMBRE);
            sql.AddParameter("@MAR_VALOR", SqlDbType.VarChar, MAR_VALOR);
            sql.AddParameter("@MAR_ID", SqlDbType.Int, Id, ParameterDirection.Output);
            sql.ExecuteSP("usp_InsertMARCA");

            return sql.Parameters["@MAR_ID"].Value.ToString();    
        }

        public static Boolean valRelActivo(string idmar)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where mar_id=" + idmar );
            if (obj != null)
                hayrel = true;
            return hayrel;
        }


        public DataSet fGetMarcasAll()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select mar_id, mar_nombre from marca order by mar_nombre");
        }

        public int fAddMarca(string nombre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlIdentity("insert into marca (mar_nombre) values ('" + nombre + "') SET @identity = SCOPE_IDENTITY()");
        }

	}
	#endregion
}

