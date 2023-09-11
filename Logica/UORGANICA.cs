using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region UORGANICA
	/// <summary>
	/// This object represents the properties and methods of a UORGANICA.
	/// </summary>
	public class UORGANICA
	{
		private int _id;
		private string _uOR_NOMBRE = String.Empty;
		private int _uOR_PADRE;
		private int _uOR_NIVEL;
		private string _uOR_VALOR = String.Empty;
		private bool _uOR_HABILITADA;
		private int _uGE_ID;
		private string _cCO_ID = String.Empty;
		private string _uOR_CODIGO;
		
		public UORGANICA()
		{
		}
		
		public UORGANICA(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@UOR_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM UORGANICA WHERE UOR_ID = @UOR_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("UORGANICA does not exist.");
			}
		}
		
		public UORGANICA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _uOR_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _uOR_PADRE = reader.GetInt32(2);
				if (!reader.IsDBNull(3)) _uOR_NIVEL = reader.GetInt32(3);
				if (!reader.IsDBNull(5)) _uOR_CODIGO = reader.GetString(5);
				//if (!reader.IsDBNull(5)) _uOR_HABILITADA = reader.GetBoolean(5);
				if (!reader.IsDBNull(4)) _uGE_ID = reader.GetInt32(4);
				//if (!reader.IsDBNull(7)) _cCO_ID = reader.GetString(7);
			}
		}
		
		public void Delete()
		{
			UORGANICA.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@UOR_ID", SqlDbType.Int, Id);
            //queryParameters.Append("UOR_ID = @UOR_ID");

			sql.AddParameter("@UOR_NOMBRE", SqlDbType.VarChar, UOR_NOMBRE);
			queryParameters.Append("UOR_NOMBRE = @UOR_NOMBRE");
			sql.AddParameter("@UOR_CODIGO", SqlDbType.VarChar, UOR_CODIGO);
			queryParameters.Append(",UOR_CODIGO = @UOR_CODIGO");
            //sql.AddParameter("@UOR_PADRE", SqlDbType.Int, UOR_PADRE);
            //queryParameters.Append(", UOR_PADRE = @UOR_PADRE");
            //sql.AddParameter("@UOR_NIVEL", SqlDbType.Int, UOR_NIVEL);
            //queryParameters.Append(", UOR_NIVEL = @UOR_NIVEL");
            //sql.AddParameter("@UOR_VALOR", SqlDbType.VarChar, UOR_VALOR);
            //queryParameters.Append(", UOR_VALOR = @UOR_VALOR");
            //sql.AddParameter("@UOR_HABILITADA", SqlDbType.Bit, UOR_HABILITADA);
            //queryParameters.Append(", UOR_HABILITADA = @UOR_HABILITADA");
            //sql.AddParameter("@UGE_ID", SqlDbType.Int, UGE_ID);
            //queryParameters.Append(", UGE_ID = @UGE_ID");
            //sql.AddParameter("@CCO_ID", SqlDbType.VarChar, CCO_ID);
            //queryParameters.Append(", CCO_ID = @CCO_ID");

			string query = String.Format("Update UORGANICA Set {0} Where UOR_ID ="+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create(string codigo)
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@UOR_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@UOR_ID");

			sql.AddParameter("@UOR_NOMBRE", SqlDbType.VarChar, UOR_NOMBRE);
			queryParameters.Append("@UOR_NOMBRE");
			sql.AddParameter("@UOR_PADRE", SqlDbType.Int, UOR_PADRE);
			queryParameters.Append(", @UOR_PADRE");
			sql.AddParameter("@UOR_NIVEL", SqlDbType.Int, UOR_NIVEL);
			queryParameters.Append(", @UOR_NIVEL");
            sql.AddParameter("@UOR_CODIGO", SqlDbType.VarChar, codigo);
            queryParameters.Append(", @UOR_CODIGO");
            //sql.AddParameter("@UOR_VALOR", SqlDbType.VarChar, UOR_VALOR);
            //queryParameters.Append(", @UOR_VALOR");
            //sql.AddParameter("@UOR_HABILITADA", SqlDbType.Bit, UOR_HABILITADA);
            //queryParameters.Append(", @UOR_HABILITADA");
            if (UGE_ID != 0)
            {
                sql.AddParameter("@UGE_ID", SqlDbType.Int, UGE_ID);
                queryParameters.Append(", @UGE_ID");
            }
            //sql.AddParameter("@CCO_ID", SqlDbType.VarChar, CCO_ID);
            //queryParameters.Append(", @CCO_ID");

			string query = String.Format("Insert Into UORGANICA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static UORGANICA NewUORGANICA(int id)
		{
			UORGANICA newEntity = new UORGANICA();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string UOR_NOMBRE
		{
			get {return _uOR_NOMBRE;}
			set {_uOR_NOMBRE = value;}
		}

		public int UOR_PADRE
		{
			get {return _uOR_PADRE;}
			set {_uOR_PADRE = value;}
		}

		public int UOR_NIVEL
		{
			get {return _uOR_NIVEL;}
			set {_uOR_NIVEL = value;}
		}

		public string UOR_VALOR
		{
			get {return _uOR_VALOR;}
			set {_uOR_VALOR = value;}
		}

		public bool UOR_HABILITADA
		{
			get {return _uOR_HABILITADA;}
			set {_uOR_HABILITADA = value;}
		}

		public int UGE_ID
		{
			get {return _uGE_ID;}
			set {_uGE_ID = value;}
		}

		public string CCO_ID
		{
			get {return _cCO_ID;}
			set {_cCO_ID = value;}
		}

		public string UOR_CODIGO
		{
			get => _uOR_CODIGO;
			set => _uOR_CODIGO = value;
		}

		#endregion
		
		public static UORGANICA GetUORGANICA(int id)
		{
			return new UORGANICA(id);
		}

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UOR_ID", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("update UORGANICA SET uor_habilitada=0 Where UOR_ID = @UOR_ID");
        }

        public static void DeleteAll(int uorid)
        {
            Datos.SqlService sql = new Datos.SqlService();

            sql.ExecuteSql("update UORGANICA SET uor_habilitada=0 Where UOR_ID =" + uorid);
            sql.ExecuteSql("update UORGANICA SET uor_habilitada=0 Where UOR_PADRE =" + uorid);
        }

        public static Boolean valRelActivo(string iduor)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where (uor_id1=" + iduor + " or uor_id2=" + iduor + " or uor_id3=" + iduor + ")");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public static Boolean valRelActivoH(string iduor)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select huc_id from hucustodio where (uor_id1=" + iduor + " or uor_id2=" + iduor + " or uor_id3=" + iduor + ")");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
        
        public DataSet fGetUorAll3Level()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataSet("usp_getUorAll3Level");
        }

        public DataTable getUorAll(int nivel, int padre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select uor_id, uor_nombre from uorganica where uor_nivel=" + nivel + " and uor_padre=" + padre + " order by uor_nombre");
        }

        public DataTable getUorAll(int nivel)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select uor_id, uor_nombre from uorganica where uor_nivel=" + nivel + " order by uor_nombre");
        }

        public DataTable getUorAll1(int nivel, int padre, int ugeid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select uor_id, uor_nombre from uorganica where uor_nivel=" + nivel + " and uor_padre=" + padre + " and uge_id=" + ugeid + " order by uor_nombre");
        }
        public static void fDelUor2(int uorid)
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UOR_ID2", SqlDbType.Int, uorid);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delUORGANICA2");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public static void fDelUor3(int uorid)
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UOR_ID3", SqlDbType.Int, uorid);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delUORGANICA3");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public static void fDelUor4(int uorid)
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@UOR_ID4", SqlDbType.Int, uorid);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delUORGANICA4");
            error = sql.Parameters["@err"].Value.ToString();
        }

	}
	#endregion
}

