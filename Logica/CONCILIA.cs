using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region CONCILIA
	/// <summary>
	/// This object represents the properties and methods of a CONCILIA.
	/// </summary>
	public class CONCILIA
	{
		private int _id;
		private int _cLI_ID;
		private int _aCT_ID;
		
		public CONCILIA()
		{
		}
		
		public CONCILIA(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CON_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CONCILIA WHERE CON_ID = @CON_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("CONCILIA does not exist.");
			}
		}
		
		public CONCILIA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _cLI_ID = reader.GetInt32(1);
				if (!reader.IsDBNull(2)) _aCT_ID = reader.GetInt32(2);
			}
		}
		
		public void Delete()
		{
			CONCILIA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@CON_ID", SqlDbType.Int, Id);
			queryParameters.Append("CON_ID = @CON_ID");

			sql.AddParameter("@CLI_ID", SqlDbType.Int, CLI_ID);
			queryParameters.Append(", CLI_ID = @CLI_ID");
			sql.AddParameter("@ACT_ID", SqlDbType.Int, ACT_ID);
			queryParameters.Append(", ACT_ID = @ACT_ID");

			string query = String.Format("Update CONCILIA Set {0} Where CON_ID = @CON_ID", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CON_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@CON_ID");

			sql.AddParameter("@CLI_ID", SqlDbType.Int, CLI_ID);
			queryParameters.Append("@CLI_ID");
			sql.AddParameter("@ACT_ID", SqlDbType.Int, ACT_ID);
			queryParameters.Append(", @ACT_ID");

			string query = String.Format("Insert Into CONCILIA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static CONCILIA NewCONCILIA(int id)
		{
			CONCILIA newEntity = new CONCILIA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public int CLI_ID
		{
			get {return _cLI_ID;}
			set {_cLI_ID = value;}
		}

		public int ACT_ID
		{
			get {return _aCT_ID;}
			set {_aCT_ID = value;}
		}
		#endregion
		
		public static CONCILIA GetCONCILIA(int id)
		{
			return new CONCILIA(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CON_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete CONCILIA Where CON_ID = @CON_ID");
		}
	}
	#endregion
}

