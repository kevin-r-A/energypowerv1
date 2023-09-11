using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region CARACTERISTICA
	/// <summary>
	/// This object represents the properties and methods of a CARACTERISTICA.
	/// </summary>
	public class CARACTERISTICA
	{
		private int _id;
		private int _aCT_ID;
		private int _cFA_ID;
		private string _cAR_VALOR = String.Empty;
		private int _uNI_ID;

		public CARACTERISTICA()
		{
		}

		public CARACTERISTICA(int id)
		{
			// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CAR_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CARACTERISTICA WHERE CAR_ID = @CAR_ID");

			if (reader.Read())
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("CARACTERISTICA does not exist.");
			}
		}

		public CARACTERISTICA(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}

		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _aCT_ID = reader.GetInt32(1);
				if (!reader.IsDBNull(2)) _cFA_ID = reader.GetInt32(2);
				if (!reader.IsDBNull(3)) _cAR_VALOR = reader.GetString(3);
				if (!reader.IsDBNull(4)) _uNI_ID = reader.GetInt32(4);
			}
		}

		public void Delete()
		{
			CARACTERISTICA.Delete(_id);
		}


		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@ACT_ID", SqlDbType.Int, ACT_ID);
			queryParameters.Append("@ACT_ID");
			sql.AddParameter("@CFA_ID", SqlDbType.Int, CFA_ID);
			queryParameters.Append(", @CFA_ID");
			sql.AddParameter("@CAR_VALOR", SqlDbType.VarChar, CAR_VALOR);
			queryParameters.Append(", @CAR_VALOR");

			if(UNI_ID==-1)
				sql.AddParameter("@UNI_ID", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
			else
				sql.AddParameter("@UNI_ID", SqlDbType.Int, UNI_ID);

			queryParameters.Append(", @UNI_ID");

			string query = String.Format("Insert Into CARACTERISTICA ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public static CARACTERISTICA NewCARACTERISTICA(int id)
		{
			CARACTERISTICA newEntity = new CARACTERISTICA();
			newEntity._id = id;

			return newEntity;
		}

		#region Public Properties
		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public int ACT_ID
		{
			get { return _aCT_ID; }
			set { _aCT_ID = value; }
		}

		public int CFA_ID
		{
			get { return _cFA_ID; }
			set { _cFA_ID = value; }
		}

		public string CAR_VALOR
		{
			get { return _cAR_VALOR; }
			set { _cAR_VALOR = value; }
		}

		public int UNI_ID
		{
			get { return _uNI_ID; }
			set { _uNI_ID = value; }
		}
		#endregion

		public static CARACTERISTICA GetCARACTERISTICA(int id)
		{
			return new CARACTERISTICA(id);
		}

		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@CAR_ID", SqlDbType.Int, id);

			SqlDataReader reader = sql.ExecuteSqlReader("Delete CARACTERISTICA Where CAR_ID = @CAR_ID");
		}

		public DataSet fgetCaracteristicas()
		{
			Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSPDataSet("usp_getCaracteristicasAva");
		}
		public DataSet fgetCaracteristicasPpc()
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSPDataSet("usp_getCaracteristicas2");
		}
		
		public DataSet fgetCarXActid(string actid)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataSet("select cfa_nombre, car_valor+' '+isnull(convert(varchar(150),uni_simbolo),'') valor from caracteristica inner join cfamilia on caracteristica.cfa_id=cfamilia.cfa_id left join UNIDAD on unidad.UNI_ID = CARACTERISTICA.UNI_ID where act_id=" + actid);
		}
		public DataSet fgetCarXActidPpc(string actid)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataSet("select cfa_nombre, car_valor+' '+isnull(uni_simbolo,'') valor from pcaracteristica inner join cfamilia on pcaracteristica.cfa_id=cfamilia.cfa_id left join unidad on pcaracteristica.uni_id=unidad.uni_id where act_id=" + actid);
		}
		public DataSet fgetCarXActid2(string actid)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataSet("select cfa_id, car_valor, uni_id from caracteristica where act_id=" + actid);
		}

		public DataTable fgetCarXActid3(string actid)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataTable("select car_nombre, car_valor, uni_id from caracteristica where act_id=" + actid);
		}

		public DataSet fgetCarXActid4(string actid)
		{
			Datos.SqlService sql = new Datos.SqlService();
			return sql.ExecuteSqlDataSet("select upper(cfa_nombre)+': '+car_valor+' '+isnull(uni_simbolo,'') as car from caracteristica left join unidad on caracteristica.uni_id= unidad.uni_id inner join cfamilia on caracteristica.cfa_id= cfamilia.cfa_id where act_id=" + actid);
		}
	}
	#endregion
}

