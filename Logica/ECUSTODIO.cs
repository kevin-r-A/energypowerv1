using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region ECUSTODIO
	/// <summary>
	/// This object represents the properties and methods of a ECUSTODIO.
	/// </summary>
	public class ECUSTODIO
	{
		private int _id;
		private string _eCU_NOMBRE = String.Empty;
		private bool _eCU_HABILITADO;
		
		public ECUSTODIO()
		{
		}
		
		public ECUSTODIO(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@ECU_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM ECUSTODIO WHERE ECU_ID = @ECU_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("ECUSTODIO does not exist.");
			}
		}
		
		public ECUSTODIO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _eCU_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _eCU_HABILITADO = reader.GetBoolean(2);
			}
		}
		
		public void Delete()
		{
			ECUSTODIO.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@ECU_ID", SqlDbType.Int, Id);
			queryParameters.Append("ECU_ID = @ECU_ID");

			sql.AddParameter("@ECU_NOMBRE", SqlDbType.VarChar, ECU_NOMBRE);
			queryParameters.Append(", ECU_NOMBRE = @ECU_NOMBRE");
			sql.AddParameter("@ECU_HABILITADO", SqlDbType.Bit, ECU_HABILITADO);
			queryParameters.Append(", ECU_HABILITADO = @ECU_HABILITADO");

			string query = String.Format("Update ECUSTODIO Set {0} Where ECU_ID = @ECU_ID", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@ECU_ID", SqlDbType.Int, Id);
			queryParameters.Append("@ECU_ID");

			sql.AddParameter("@ECU_NOMBRE", SqlDbType.VarChar, ECU_NOMBRE);
			queryParameters.Append(", @ECU_NOMBRE");
			sql.AddParameter("@ECU_HABILITADO", SqlDbType.Bit, ECU_HABILITADO);
			queryParameters.Append(", @ECU_HABILITADO");

			string query = String.Format("Insert Into ECUSTODIO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static ECUSTODIO NewECUSTODIO(int id)
		{
			ECUSTODIO newEntity = new ECUSTODIO();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string ECU_NOMBRE
		{
			get {return _eCU_NOMBRE;}
			set {_eCU_NOMBRE = value;}
		}

		public bool ECU_HABILITADO
		{
			get {return _eCU_HABILITADO;}
			set {_eCU_HABILITADO = value;}
		}
		#endregion
		
		public static ECUSTODIO GetECUSTODIO(int id)
		{
			return new ECUSTODIO(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@ECU_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete ECUSTODIO Where ECU_ID = @ECU_ID");
		}

        #region metodos cayman

        public DataSet fGetECustodioAll()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select ecu_id, ecu_nombre from ecustodio where ecu_habilitado=1");
        }

        #endregion
	}
	#endregion
}

