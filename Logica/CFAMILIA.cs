using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region CFAMILIA
	/// <summary>
	/// This object represents the properties and methods of a CFAMILIA.
	/// </summary>
	public class CFAMILIA
	{
		private int _id;
		private string _cFA_NOMBRE = String.Empty;
		private int _cFA_ORDEN;
		private bool _cFA_HABILITADA;
		private int _gRU_ID1;
		private bool _cFA_UNIDADES;
		
		public CFAMILIA()
		{
		}
		
		public CFAMILIA(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CFA_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CFAMILIA WHERE CFA_ID = @CFA_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("CFAMILIA does not exist.");
			}
		}
		
		public CFAMILIA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _cFA_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _cFA_ORDEN = reader.GetInt32(2);
				if (!reader.IsDBNull(3)) _cFA_HABILITADA = reader.GetBoolean(3);
				if (!reader.IsDBNull(4)) _gRU_ID1 = reader.GetInt32(4);
				if (!reader.IsDBNull(5)) _cFA_UNIDADES = reader.GetBoolean(5);
			}
		}
		
		public void Delete()
		{
			CFAMILIA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CFA_ID", SqlDbType.Int, Id);
            //queryParameters.Append("CFA_ID = @CFA_ID");

			sql.AddParameter("@CFA_NOMBRE", SqlDbType.VarChar, CFA_NOMBRE);
			queryParameters.Append("CFA_NOMBRE = @CFA_NOMBRE");
			sql.AddParameter("@CFA_ORDEN", SqlDbType.Int, CFA_ORDEN);
			queryParameters.Append(", CFA_ORDEN = @CFA_ORDEN");
			sql.AddParameter("@CFA_HABILITADA", SqlDbType.Bit, CFA_HABILITADA);
			queryParameters.Append(", CFA_HABILITADA = @CFA_HABILITADA");
			sql.AddParameter("@GRU_ID1", SqlDbType.Int, GRU_ID1);
			queryParameters.Append(", GRU_ID1 = @GRU_ID1");
			sql.AddParameter("@CFA_UNIDADES", SqlDbType.Bit, CFA_UNIDADES);
			queryParameters.Append(", CFA_UNIDADES = @CFA_UNIDADES");

			string query = String.Format("Update CFAMILIA Set {0} Where CFA_ID = "+ Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CFA_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@CFA_ID");

			sql.AddParameter("@CFA_NOMBRE", SqlDbType.VarChar, CFA_NOMBRE);
			queryParameters.Append("@CFA_NOMBRE");
			sql.AddParameter("@CFA_ORDEN", SqlDbType.Int, CFA_ORDEN);
			queryParameters.Append(", @CFA_ORDEN");
			sql.AddParameter("@CFA_HABILITADA", SqlDbType.Bit, CFA_HABILITADA);
			queryParameters.Append(", @CFA_HABILITADA");
			sql.AddParameter("@GRU_ID1", SqlDbType.Int, GRU_ID1);
			queryParameters.Append(", @GRU_ID1");
			sql.AddParameter("@CFA_UNIDADES", SqlDbType.Bit, CFA_UNIDADES);
			queryParameters.Append(", @CFA_UNIDADES");

			string query = String.Format("Insert Into CFAMILIA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static CFAMILIA NewCFAMILIA(int id)
		{
			CFAMILIA newEntity = new CFAMILIA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string CFA_NOMBRE
		{
			get {return _cFA_NOMBRE;}
			set {_cFA_NOMBRE = value;}
		}

		public int CFA_ORDEN
		{
			get {return _cFA_ORDEN;}
			set {_cFA_ORDEN = value;}
		}

		public bool CFA_HABILITADA
		{
			get {return _cFA_HABILITADA;}
			set {_cFA_HABILITADA = value;}
		}

		public int GRU_ID1
		{
			get {return _gRU_ID1;}
			set {_gRU_ID1 = value;}
		}

		public bool CFA_UNIDADES
		{
			get {return _cFA_UNIDADES;}
			set {_cFA_UNIDADES = value;}
		}
		#endregion
		
		public static CFAMILIA GetCFAMILIA(int id)
		{
			return new CFAMILIA(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CFA_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("Delete CFAMILIA Where CFA_ID = @CFA_ID");
		}

        public DataSet fgetCaractXGruId(string id, string nivel)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select cfa_id, cfa_caracteristica from cfamilia where " + nivel + "=" + id + " order by cfa_orden");
        }
        public string fGetNextOrder(string id, string nivel)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max(cfa_orden)+1 from cfamilia where " + nivel + "=" + id);
            if (obj == null || obj.ToString() == "")
                return "1";
            else
                return obj.ToString();
        }

        public void fSubirOrden(string gruid, string posicion, string nivel, string cfaid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update cfamilia set cfa_orden=cfa_orden+1 where cfa_orden=" + posicion + " and " + nivel + "=" + gruid);
            sql.ExecuteSql("update cfamilia set cfa_orden=cfa_orden-1 where cfa_id=" + cfaid);
        }

        public void fBajarOrden(string gruid, string posicion, string nivel, string cfaid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update cfamilia set cfa_orden=cfa_orden-1 where cfa_orden=" + posicion + " and " + nivel + "=" + gruid);
            sql.ExecuteSql("update cfamilia set cfa_orden=cfa_orden+1 where cfa_id=" + cfaid);
        }

        public bool fcomprobarExistencia(string nivel, string caract, string gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cfa_id from cfamilia where cfa_caracteristica='" + caract + "' and " + nivel + "=" + gruid);
            if (obj == null || obj.ToString() == "")
                return false;
            else
                return true;
        }

        public void fupdCar(string car, string cfaid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update cfamilia set cfa_caracteristica='" + car + "' where cfa_id=" + cfaid);
        }

        public int fgetMaxOrden(string gruid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select max(cfa_orden) from cfamilia where gru_id1=" + gruid);
            if (obj == null || obj.ToString()=="")
                return 1;
            else
                return (int.Parse(obj.ToString()) + 1);
        }

        public bool fgetcarIng(string gruid, string car)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select cfa_id from cfamilia where gru_id1=" + gruid+ " and cfa_nombre='"+car+"'");
            if (obj == null)
                return false;
            else
                return true;
        }
	}
	#endregion
}

