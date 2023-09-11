using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
	#region ANIO
	/// <summary>
	/// This object represents the properties and methods of a ANIO.
	/// </summary>
	public class ANIO
	{
		private int _id;
		private string _aNI_NOMBRE = String.Empty;
		private bool _aNI_HABILITADO;
		
		public ANIO()
		{
		}
		
		public ANIO(int id)
		{
            		// NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@ANI_ID", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM ANIO WHERE ANI_ID = @ANI_ID");
			
			if (reader.Read()) 
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("ANIO does not exist.");
			}
		}
		
		public ANIO(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}
		
		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _aNI_NOMBRE = reader.GetString(1);
				if (!reader.IsDBNull(2)) _aNI_HABILITADO = reader.GetBoolean(2);
			}
		}
		
		public void Delete()
		{
			ANIO.Delete(_id);
		}
		
		public void Update()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@ANI_ID", SqlDbType.Int, Id);
            //queryParameters.Append("ANI_ID = @ANI_ID");

			sql.AddParameter("@ANI_NOMBRE", SqlDbType.VarChar, ANI_NOMBRE);
			queryParameters.Append("ANI_NOMBRE = @ANI_NOMBRE");
            //sql.AddParameter("@ANI_HABILITADO", SqlDbType.Bit, ANI_HABILITADO);
            //queryParameters.Append(", ANI_HABILITADO = @ANI_HABILITADO");

			string query = String.Format("Update ANIO Set {0} Where ANI_ID = "+Id, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public void Create()
		{
			Datos.SqlService sql = new Datos.SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@ANI_ID", SqlDbType.Int, Id);
			queryParameters.Append("@ANI_ID");

			sql.AddParameter("@ANI_NOMBRE", SqlDbType.VarChar, ANI_NOMBRE);
			queryParameters.Append(", @ANI_NOMBRE");
            //sql.AddParameter("@ANI_HABILITADO", SqlDbType.Bit, ANI_HABILITADO);
            //queryParameters.Append(", @ANI_HABILITADO");

			string query = String.Format("Insert Into ANIO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		
		public static ANIO NewANIO(int id)
		{
			ANIO newEntity = new ANIO();
			newEntity._id = id;

			return newEntity;
		}
		
		#region Public Properties
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}
		
		public string ANI_NOMBRE
		{
			get {return _aNI_NOMBRE;}
			set {_aNI_NOMBRE = value;}
		}

		public bool ANI_HABILITADO
		{
			get {return _aNI_HABILITADO;}
			set {_aNI_HABILITADO = value;}
		}
		#endregion
		
		public static ANIO GetANIO(int id)
		{
			return new ANIO(id);
		}
		
		public static void Delete(int id)
		{
			Datos.SqlService sql = new Datos.SqlService();
			sql.AddParameter("@ANI_ID", SqlDbType.Int, id);
	
			SqlDataReader reader = sql.ExecuteSqlReader("update ANIO set ani_habilitado=0 Where ANI_ID = @ANI_ID");
		}

        public static DataTable getAnios()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select ani_id as Id, ani_nombre as Nombre from anio where ani_habilitado=1 order by ani_nombre");
        }
        public static Boolean valRelActivo(string ide)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where ani_id=" + ide + " and act_eliminado=0");
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
	}
	#endregion
}

