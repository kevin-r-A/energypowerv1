using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region PISO
	/// <summary>
	/// This object represents the properties and methods of a PISO.
	/// </summary>
	public class PISO
	{
		private int _id;
		private string _pIS_NOMBRE = String.Empty;
		
		public PISO()
		{
		}
		
		public PISO(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@PIS_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM PISO WHERE PIS_ID = @PIS_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("PISO does not exist.");
			}
		}
		
		public PISO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _pIS_NOMBRE = reader.GetString(1);
			}
		}
		
		public void Delete()
		{
			PISO.Delete(_id);
		}
		
		public void Update()
		{
            try
            {
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@PIS_ID", SqlDbType.Int, Id);
            //queryParameters.Append("PIS_ID = @PIS_ID");

			sql.AddParameter("@PIS_NOMBRE", SqlDbType.VarChar, PIS_NOMBRE);
			queryParameters.Append("PIS_NOMBRE = @PIS_NOMBRE");

			string query = String.Format("Update PISO Set {0} Where PIS_ID ="+Id, queryParameters.ToString());
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

                //sql.AddParameter("@PIS_ID", SqlDbType.Int, Id);
                //queryParameters.Append("@PIS_ID");

                sql.AddParameter("@PIS_NOMBRE", SqlDbType.VarChar, PIS_NOMBRE);
                queryParameters.Append("@PIS_NOMBRE");

                string query = String.Format("Insert Into PISO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
                SqlDataReader reader = sql.ExecuteSqlReader(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		
		public static PISO NewPISO(int id)
		{
			PISO newEntity = new PISO();
			newEntity._id = id;

			return newEntity;

		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string PIS_NOMBRE
		{
			get {return _pIS_NOMBRE;}
			set {_pIS_NOMBRE = value;}
		}
		#endregion
		
		public static PISO GetPISO(int id)
		{
			return new PISO(id);
		}
		
		public static void Delete(int id)
		{
             try
            {
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@PIS_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("update PISO set pis_habilitado=0 Where PIS_ID = @PIS_ID");
            }
             catch (Exception ex)
             {
                 throw ex;
             }
		}
        public static DataTable getPisos()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select pis_id as Id, pis_nombre as Nombre from piso where pis_habilitado=1 order by pis_nombre");
        }
        public static Boolean valRelActivo(string ide)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where pis_id=" + ide + " and act_eliminado=0");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
	}
	#endregion
}

