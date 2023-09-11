using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region ESTRUCOMP
	/// <summary>
	/// This object represents the properties and methods of a ESTRUCOMP.
	/// </summary>
	public class ESTRUCOMP
	{
		private int _id;
		private string _eCO_NOMBRE = String.Empty;
		private bool _eCO_HABILITADA;
		
		public ESTRUCOMP()
		{
		}
		
		public ESTRUCOMP(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@ECO_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM ESTRUCOMP WHERE ECO_ID = @ECO_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("ESTRUCOMP does not exist.");
			}
		}
		
		public ESTRUCOMP(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _eCO_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _eCO_HABILITADA = reader.GetBoolean(2);
			}
		}
		
		public void Delete()
		{
			ESTRUCOMP.Delete(_id);
		}
		
		public void Update()
		{
            try
            {
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@ECO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("ECO_ID = @ECO_ID");

			sql.AddParameter("@ECO_NOMBRE", SqlDbType.VarChar, ECO_NOMBRE);
            queryParameters.Append("ECO_NOMBRE = @ECO_NOMBRE");
            //sql.AddParameter("@ECO_HABILITADA", SqlDbType.Bit, ECO_HABILITADA);
            //queryParameters.Append(", ECO_HABILITADA = @ECO_HABILITADA");

			string query = String.Format("Update ESTRUCOMP Set {0} Where ECO_ID ="+Id, queryParameters.ToString());
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

            //sql.AddParameter("@ECO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@ECO_ID");

			sql.AddParameter("@ECO_NOMBRE", SqlDbType.VarChar, ECO_NOMBRE);
			queryParameters.Append("@ECO_NOMBRE");
            //sql.AddParameter("@ECO_HABILITADA", SqlDbType.Bit, ECO_HABILITADA);
            //queryParameters.Append(", @ECO_HABILITADA");

			string query = String.Format("Insert Into ESTRUCOMP ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
             }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		
		public static ESTRUCOMP NewESTRUCOMP(int id)
		{
			ESTRUCOMP newEntity = new ESTRUCOMP();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string ECO_NOMBRE
		{
			get {return _eCO_NOMBRE;}
			set {_eCO_NOMBRE = value;}
		}

		public bool ECO_HABILITADA
		{
			get {return _eCO_HABILITADA;}
			set {_eCO_HABILITADA = value;}
		}
		#endregion
		
		public static ESTRUCOMP GetESTRUCOMP(int id)
		{
			return new ESTRUCOMP(id);
		}
		
		public static void Delete(int id)
		{
            try
            {
                Datos.SqlService sql = new Datos.SqlService();
                sql.AddParameter("@ECO_ID", SqlDbType.Int, id);

                SqlDataReader reader = sql.ExecuteSqlReader("delete from ESTRUCOMP Where ECO_ID = @ECO_ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
        public DataTable getEstructuras()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select eco_id, eco_nombre from estrucomp order by eco_nombre");
        }
        public static Boolean valRelActivo(string ide)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where (eco_id1=" + ide + " or eco_id2=" + ide + " )");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
	}
	#endregion
}

