using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region UGEOGRAFICA
	/// <summary>
	/// This object represents the properties and methods of a UGEOGRAFICA.
	/// </summary>
	public class UGEOGRAFICA
	{
		private int _id;
		private string _uGE_NOMBRE = String.Empty;
		private int _uGE_PADRE;
		private int _uGE_NIVEL;
		private string _uGE_VALOR = String.Empty;
		private int _uGE_UOR;
		private int _uGE_CUS;
		private bool _uGE_HABILITADA;
		private string _uGE_CODIGO;

        private string _ipReader = String.Empty;
        private string _nombreReader = String.Empty;
		
		public UGEOGRAFICA()
		{
		}
		
		public UGEOGRAFICA(int id)
		{
					// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM UGEOGRAFICA WHERE UGE_ID = @UGE_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("UGEOGRAFICA does not exist.");
			}
		}
		
		public UGEOGRAFICA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _uGE_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _uGE_PADRE = reader.GetInt32(2);
				if (!reader.IsDBNull(3)) _uGE_NIVEL = reader.GetInt32(3);
                if (!reader.IsDBNull(4)) _ipReader = reader.GetString(4);
                if (!reader.IsDBNull(5)) _nombreReader = reader.GetString(5);
                if (!reader.IsDBNull(7)) _uGE_CODIGO = reader.GetString(7);
                //if (!reader.IsDBNull(4)) _uGE_VALOR = reader.GetString(4);
                //if (!reader.IsDBNull(5)) _uGE_UOR = reader.GetInt32(5);
                //if (!reader.IsDBNull(6)) _uGE_CUS = reader.GetInt32(6);
                //if (!reader.IsDBNull(7)) _uGE_HABILITADA = reader.GetBoolean(7);
			}
		}
		
		public void Delete()
		{
			UGEOGRAFICA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			//sql.AddParameter("@UGE_ID", SqlDbType.Int, Id);
			//queryParameters.Append("UGE_ID = @UGE_ID");

			sql.AddParameter("@UGE_NOMBRE", SqlDbType.VarChar, UGE_NOMBRE);
			queryParameters.Append("UGE_NOMBRE = @UGE_NOMBRE");
            sql.AddParameter("@UGE_READERIP", SqlDbType.VarChar, UGE_READERIP);
            queryParameters.Append(", UGE_READERIP = @UGE_READERIP");
            sql.AddParameter("@UGE_READERNOMBRE", SqlDbType.VarChar, UGE_READERNOMBRE);
            queryParameters.Append(", UGE_READERNOMBRE = @UGE_READERNOMBRE");
            sql.AddParameter("@UGE_CODIGO", SqlDbType.VarChar, UGE_CODIGO);
            queryParameters.Append(", UGE_CODIGO = @UGE_CODIGO");



			//sql.AddParameter("@UGE_PADRE", SqlDbType.Int, UGE_PADRE);
			//queryParameters.Append(", UGE_PADRE = @UGE_PADRE");
			//sql.AddParameter("@UGE_NIVEL", SqlDbType.Int, UGE_NIVEL);
			//queryParameters.Append(", UGE_NIVEL = @UGE_NIVEL");
			//sql.AddParameter("@UGE_VALOR", SqlDbType.VarChar, UGE_VALOR);
			//queryParameters.Append(", UGE_VALOR = @UGE_VALOR");
			//sql.AddParameter("@UGE_UOR", SqlDbType.Int, UGE_UOR);
			//queryParameters.Append(", UGE_UOR = @UGE_UOR");
			//sql.AddParameter("@UGE_CUS", SqlDbType.Int, UGE_CUS);
			//queryParameters.Append(", UGE_CUS = @UGE_CUS");
			//sql.AddParameter("@UGE_HABILITADA", SqlDbType.Bit, UGE_HABILITADA);
			//queryParameters.Append(", UGE_HABILITADA = @UGE_HABILITADA");

			string query = String.Format("Update UGEOGRAFICA Set {0} Where UGE_ID = "+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			//sql.AddParameter("@UGE_ID", SqlDbType.Int, Id);
			//queryParameters.Append("@UGE_ID");

			sql.AddParameter("@UGE_NOMBRE", SqlDbType.VarChar, UGE_NOMBRE);
			queryParameters.Append("@UGE_NOMBRE");
			sql.AddParameter("@UGE_PADRE", SqlDbType.Int, UGE_PADRE);
			queryParameters.Append(", @UGE_PADRE");
			sql.AddParameter("@UGE_NIVEL", SqlDbType.Int, UGE_NIVEL);
			queryParameters.Append(", @UGE_NIVEL");
            sql.AddParameter("@UGE_READERIP", SqlDbType.VarChar, UGE_READERIP);
            queryParameters.Append(", @UGE_READERIP");
            sql.AddParameter("@UGE_READERNOMBRE", SqlDbType.VarChar, UGE_READERNOMBRE);
            queryParameters.Append(", @UGE_READERNOMBRE");
            sql.AddParameter("@UGE_CODIGO", SqlDbType.VarChar, UGE_CODIGO);
            queryParameters.Append(", @UGE_CODIGO");
			//sql.AddParameter("@UGE_CUS", SqlDbType.Int, UGE_CUS);
			//queryParameters.Append(", @UGE_CUS");
			//sql.AddParameter("@UGE_HABILITADA", SqlDbType.Bit, UGE_HABILITADA);
			//queryParameters.Append(", @UGE_HABILITADA");

			string query = String.Format("Insert Into UGEOGRAFICA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static UGEOGRAFICA NewUGEOGRAFICA(int id)
		{
			UGEOGRAFICA newEntity = new UGEOGRAFICA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string UGE_NOMBRE
		{
			get {return _uGE_NOMBRE;}
			set {_uGE_NOMBRE = value;}
		}

		public int UGE_PADRE
		{
			get {return _uGE_PADRE;}
			set {_uGE_PADRE = value;}
		}

		public int UGE_NIVEL
		{
			get {return _uGE_NIVEL;}
			set {_uGE_NIVEL = value;}
		}

		public string UGE_VALOR
		{
			get {return _uGE_VALOR;}
			set {_uGE_VALOR = value;}
		}

		public int UGE_UOR
		{
			get {return _uGE_UOR;}
			set {_uGE_UOR = value;}
		}

		public int UGE_CUS
		{
			get {return _uGE_CUS;}
			set {_uGE_CUS = value;}
		}

		public bool UGE_HABILITADA
		{
			get {return _uGE_HABILITADA;}
			set {_uGE_HABILITADA = value;}
		}

        public string UGE_READERIP
        {
            get { return _ipReader; }
            set { _ipReader = value; }
        }

        public string UGE_READERNOMBRE
        {
            get { return _nombreReader; }
            set { _nombreReader = value; }
        }

        public string UGE_CODIGO
        {
	        get => _uGE_CODIGO;
	        set => _uGE_CODIGO = value;
        }

        #endregion
		
		public static UGEOGRAFICA GetUGEOGRAFICA(int id)
		{
			return new UGEOGRAFICA(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID", SqlDbType.Int, id);

			SqlDataReader reader = sql.ExecuteSqlReader("delete from ugeografica Where UGE_ID = @UGE_ID");
		}

		public static void DeleteAll(int ugeid)
		{
			Datos.SqlService sql = new Datos.SqlService();

			sql.ExecuteSql("update UGEOGRAFICA SET uge_habilitada=0 Where UGE_ID =" + ugeid);
			sql.ExecuteSql("update UGEOGRAFICA SET uge_habilitada=0 Where UGE_PADRE =" + ugeid);
		}

		public static Boolean valRelActivo(string iduge)
		{
			Boolean hayrel = false;

			Datos.SqlService sql = new Datos.SqlService();
			Object obj = sql.ExecuteSqlObject("select act_id from activo where (uge_id1=" + iduge + " or uge_id2=" + iduge+ " or uge_id3=" + iduge+ " or uge_id4=" + iduge+")");
			if (obj != null)
				hayrel = true;
			return hayrel;
		}

		public static Boolean valRelActivoH(string iduge)
		{
			Boolean hayrel = false;

			Datos.SqlService sql = new Datos.SqlService();
			Object obj = sql.ExecuteSqlObject("select huc_id from hucustodio where (uge_id1=" + iduge + " or uge_id2=" + iduge + " or uge_id3=" + iduge + " or uge_id4=" + iduge + ")");
			if (obj != null)
				hayrel = true;
			return hayrel;
		}

		#region metodos cayman

        public DataSet fGetUgeAll3Level(string sp) //
		{
			Datos.SqlService sql = new Datos.SqlService();
		  //  return sql.ExecuteSPDataSet("usp_getUgeAll3Level");
			return sql.ExecuteSPDataSet(sp); //saxon
		}

		public DataTable getUgeAll(int nivel, int padre)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataTable("select uge_id, uge_nombre from ugeografica where uge_nivel=" + nivel + " and uge_padre=" + padre);
            
		}

        public DataTable getUge4PuertaPasillo(int nivel, int padre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select uge_id, uge_nombre + ' ['+ isnull(uge_readerip,'No Portal RFID') + ']' as uge_nombre from ugeografica where uge_nivel=" + nivel + " and uge_padre=" + padre);
        }

		public static void fDelUge1(int ugeid)
		{
			string error = "";
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID1", SqlDbType.Int, ugeid);
			sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
			sql.ExecuteSP("usp_delUGEOGRAFICA");
			error = sql.Parameters["@err"].Value.ToString();
		}

		public static void fDelUge2(int ugeid)
		{
			string error = "";
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID2", SqlDbType.Int, ugeid);
			sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
			sql.ExecuteSP("usp_delUGEOGRAFICA2");
			error = sql.Parameters["@err"].Value.ToString();
		}

		public static void fDelUge3(int ugeid)
		{
			string error = "";
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID3", SqlDbType.Int, ugeid);
			sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
			sql.ExecuteSP("usp_delUGEOGRAFICA3");
			error = sql.Parameters["@err"].Value.ToString();
		}

		public static void fDelUge4(int ugeid)
		{
			string error = "";
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UGE_ID4", SqlDbType.Int, ugeid);
			sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
			sql.ExecuteSP("usp_delUGEOGRAFICA4");
			error = sql.Parameters["@err"].Value.ToString();
		}

        public static void fDelUge5(int ugeid)
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UGE_ID5", SqlDbType.Int, ugeid);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delUGEOGRAFICA5");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public static bool fgetUgeIng(string nombre, int padre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select uge_id from ugeografica where uge_nombre='" + nombre + "' and uge_padre=" + padre);
            if (obj == null)
                return false;
            else
                return true;
        }

        /*DICE: VERIFICAR QUE UNA DIRECCION IP NO SE REPITA EN UBICACION GEOGRAFICA PISO/NIVEL - SISTEMA RFID*/
        public static bool VerificaIpReader(string ip)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select uge_readerip from ugeografica where uge_readerip = '" + ip + "'");
            if (obj == null)
                return false;
            else
                return true;
        }

        /*DICE: VERIFICAR QUE UNA DIRECCION IP NO SE REPITA EN UBICACION ORGANICA - SISTEMA RFID*/
        public static bool VerificaIpReaderUorganica(string ip)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select uor_readerip from uorganica where uor_readerip = '" + ip + "'");
            if (obj == null)
                return false;
            else
                return true;
        }

        /*DICE: CONSULTA PORTAL Y UBI GEO - SISTEMA RFID*/
        public static DataTable DatosReader(string ip, ref string tipo)
        {
            Datos.SqlService sql = new Datos.SqlService();

            if (!VerificaIpReaderUorganica(ip) && VerificaIpReader(ip))
            {
                tipo = "UGE";
                return sql.ExecuteSqlDataTable("select UGE_READERNOMBRE, uge_nombre from ugeografica where uge_readerip= '" + ip + "'");
            }
            else
            {
                tipo = "UOR";
                return sql.ExecuteSqlDataTable("select UOR_READERNOMBRE, uor_nombre from uorganica where uor_readerip= '" + ip + "'");
            }

        }

		#endregion
	}
	#endregion
}

