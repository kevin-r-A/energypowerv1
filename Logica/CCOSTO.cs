using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region CCOSTO
	/// <summary>
	/// This object represents the properties and methods of a CCOSTO.
	/// </summary>
	public class CCOSTO
	{
		private string _id;
		private string _cCO_VALOR = String.Empty;
		private string _cCO_NOMBRE = String.Empty;
		private bool _cCO_HABILITADO;
		private int _uGE_ID;
		
		public CCOSTO()
		{
		}
		
		public CCOSTO(string id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CCO_ID", SqlDbType.VarChar, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CCOSTO WHERE CCO_ID = @CCO_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("CCOSTO does not exist.");
			}
		}
		
		public CCOSTO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetString(0);
				if (!reader.IsDBNull(1)) _cCO_VALOR = reader.GetString(1);
				if (!reader.IsDBNull(2)) _cCO_NOMBRE = reader.GetString(2);
				if (!reader.IsDBNull(3)) _cCO_HABILITADO = reader.GetBoolean(3);
				if (!reader.IsDBNull(4)) _uGE_ID = reader.GetInt32(4);
			}
		}
		
		public void Delete()
		{
			CCOSTO.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CCO_ID", SqlDbType.VarChar, Id);
            //queryParameters.Append("CCO_ID = @CCO_ID");

			sql.AddParameter("@CCO_VALOR", SqlDbType.VarChar, CCO_VALOR);
			queryParameters.Append("CCO_VALOR = @CCO_VALOR");
			sql.AddParameter("@CCO_NOMBRE", SqlDbType.VarChar, CCO_NOMBRE);
			queryParameters.Append(", CCO_NOMBRE = @CCO_NOMBRE");
			sql.AddParameter("@CCO_HABILITADO", SqlDbType.Bit, CCO_HABILITADO);
			queryParameters.Append(", CCO_HABILITADO = @CCO_HABILITADO");
			sql.AddParameter("@UGE_ID", SqlDbType.Int, UGE_ID);
			queryParameters.Append(", UGE_ID = @UGE_ID");

			string query = String.Format("Update CCOSTO Set {0} Where CCO_ID = '"+Id+"'", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@CCO_ID", SqlDbType.VarChar, Id);
			queryParameters.Append("@CCO_ID");

			sql.AddParameter("@CCO_VALOR", SqlDbType.VarChar, CCO_VALOR);
			queryParameters.Append(", @CCO_VALOR");
			sql.AddParameter("@CCO_NOMBRE", SqlDbType.VarChar, CCO_NOMBRE);
			queryParameters.Append(", @CCO_NOMBRE");
			sql.AddParameter("@CCO_HABILITADO", SqlDbType.Bit, CCO_HABILITADO);
			queryParameters.Append(", @CCO_HABILITADO");
			sql.AddParameter("@UGE_ID", SqlDbType.Int, UGE_ID);
			queryParameters.Append(", @UGE_ID");

			string query = String.Format("Insert Into CCOSTO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static CCOSTO NewCCOSTO(string id)
		{
			CCOSTO newEntity = new CCOSTO();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string CCO_VALOR
		{
			get {return _cCO_VALOR;}
			set {_cCO_VALOR = value;}
		}

		public string CCO_NOMBRE
		{
			get {return _cCO_NOMBRE;}
			set {_cCO_NOMBRE = value;}
		}

		public bool CCO_HABILITADO
		{
			get {return _cCO_HABILITADO;}
			set {_cCO_HABILITADO = value;}
		}

		public int UGE_ID
		{
			get {return _uGE_ID;}
			set {_uGE_ID = value;}
		}
		#endregion
		
		public static CCOSTO GetCCOSTO(string id)
		{
			return new CCOSTO(id);
		}
		
		public static void Delete(string id)
		{
			Datos.SqlService sql = new Datos.SqlService();
            //sql.AddParameter("@CCO_ID", SqlDbType.VarChar, id);

            sql.ExecuteSql("update ccosto SET cco_habilitado=0 Where cco_ID ='" + id+"'");
		}

        #region metodos cayman

        public DataSet fGetCcostoAll()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select cco_id, cco_nombre from ccosto where cco_habilitado=1");
        }

        public static DataTable getCcAll(int ugeid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select cco_id as Id, cco_nombre as Nombre, uge_id as Ubicacion from ccosto where uge_id="+ugeid+ " and cco_habilitado=1");
        }

        public static Boolean existeCco(string idcco)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cco_id from ccosto where cco_id='" + idcco + "'");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
        public static Boolean valRelActivo(string idcco)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where act_eliminado=0 and cco_id='"+idcco+"'");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        #endregion
	}
	#endregion
}

