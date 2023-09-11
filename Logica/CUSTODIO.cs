using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    #region CUSTODIO
    /// <summary>
    /// This object represents the properties and methods of a CUSTODIO.
    /// </summary>
    public class CUSTODIO
    {
        private int _id;
        private string _cUS_CODIGO = String.Empty;
        private string _cUS_APELLIDOS = String.Empty;
        private string _cUS_NOMBRES = String.Empty;
        private string _cUS_CEDULA = String.Empty;
        private string _cUS_TELEFONOFIJO = String.Empty;
        private string _cUS_EXT = String.Empty;
        private string _cUS_CELULAR = String.Empty;
        private string _cUS_FOTO = String.Empty;
        private string _cUS_EMAIL = String.Empty;
        private int _cGO_ID;
        private string _cUS_ESTADO = String.Empty;

        public CUSTODIO()
        {
        }

        public CUSTODIO(int id)
        {
            // NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@CUS_ID", SqlDbType.Int, id);
            SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM CUSTODIO WHERE CUS_ID = @CUS_ID");

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("CUSTODIO does not exist.");
            }
        }

        public CUSTODIO(SqlDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) _cUS_CODIGO = reader.GetString(1);
                if (!reader.IsDBNull(2)) _cUS_APELLIDOS = reader.GetString(2);
                if (!reader.IsDBNull(3)) _cUS_NOMBRES = reader.GetString(3);
                if (!reader.IsDBNull(4)) _cUS_CEDULA = reader.GetString(4);
                if (!reader.IsDBNull(5)) _cUS_TELEFONOFIJO = reader.GetString(5);
                if (!reader.IsDBNull(6)) _cUS_EXT = reader.GetString(6);
                if (!reader.IsDBNull(7)) _cUS_CELULAR = reader.GetString(7);
                if (!reader.IsDBNull(8)) _cUS_FOTO = reader.GetString(8);
                if (!reader.IsDBNull(9)) _cUS_EMAIL = reader.GetString(9);
                if (!reader.IsDBNull(10)) _cGO_ID = reader.GetInt32(10);
                if (!reader.IsDBNull(11)) _cUS_ESTADO = reader.GetString(11);
            }
        }

        public void Delete()
        {
            CUSTODIO.Delete(_id);
        }

        public void Update()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            sql.AddParameter("@CUS_ID", SqlDbType.Int, Id);
            //queryParameters.Append("CUS_ID = @CUS_ID");

            sql.AddParameter("@CUS_CODIGO", SqlDbType.VarChar, CUS_CODIGO);
            queryParameters.Append("CUS_CODIGO = @CUS_CODIGO");
            sql.AddParameter("@CUS_APELLIDOS", SqlDbType.VarChar, CUS_APELLIDOS);
            queryParameters.Append(", CUS_APELLIDOS = @CUS_APELLIDOS");
            sql.AddParameter("@CUS_NOMBRES", SqlDbType.VarChar, CUS_NOMBRES);
            queryParameters.Append(", CUS_NOMBRES = @CUS_NOMBRES");
            sql.AddParameter("@CUS_CEDULA", SqlDbType.VarChar, CUS_CEDULA);
            queryParameters.Append(", CUS_CEDULA = @CUS_CEDULA");
            sql.AddParameter("@CUS_TELEFONOFIJO", SqlDbType.VarChar, CUS_TELEFONOFIJO);
            queryParameters.Append(", CUS_TELEFONOFIJO = @CUS_TELEFONOFIJO");
            sql.AddParameter("@CUS_EXT", SqlDbType.VarChar, CUS_EXT);
            queryParameters.Append(", CUS_EXT = @CUS_EXT");
            sql.AddParameter("@CUS_CELULAR", SqlDbType.VarChar, CUS_CELULAR);
            queryParameters.Append(", CUS_CELULAR = @CUS_CELULAR");
            sql.AddParameter("@CUS_FOTO", SqlDbType.VarChar, CUS_FOTO);
            queryParameters.Append(", CUS_FOTO = @CUS_FOTO");
            sql.AddParameter("@CUS_EMAIL", SqlDbType.VarChar, CUS_EMAIL);
            queryParameters.Append(", CUS_EMAIL = @CUS_EMAIL");
            sql.AddParameter("@CGO_ID", SqlDbType.Int, CGO_ID);
            queryParameters.Append(", CGO_ID = @CGO_ID");
            sql.AddParameter("@CUS_ESTADO", SqlDbType.VarChar, CUS_ESTADO);
            queryParameters.Append(", CUS_ESTADO = @CUS_ESTADO");

            string query = String.Format("Update CUSTODIO Set {0} Where CUS_ID = @CUS_ID", queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public void Create()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@CUS_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@CUS_ID");

            sql.AddParameter("@CUS_CODIGO", SqlDbType.VarChar, CUS_CODIGO);
            queryParameters.Append("@CUS_CODIGO");
            sql.AddParameter("@CUS_APELLIDOS", SqlDbType.VarChar, CUS_APELLIDOS);
            queryParameters.Append(", @CUS_APELLIDOS");
            sql.AddParameter("@CUS_NOMBRES", SqlDbType.VarChar, CUS_NOMBRES);
            queryParameters.Append(", @CUS_NOMBRES");
            sql.AddParameter("@CUS_CEDULA", SqlDbType.VarChar, CUS_CEDULA);
            queryParameters.Append(", @CUS_CEDULA");
            sql.AddParameter("@CUS_TELEFONOFIJO", SqlDbType.VarChar, CUS_TELEFONOFIJO);
            queryParameters.Append(", @CUS_TELEFONOFIJO");
            sql.AddParameter("@CUS_EXT", SqlDbType.VarChar, CUS_EXT);
            queryParameters.Append(", @CUS_EXT");
            sql.AddParameter("@CUS_CELULAR", SqlDbType.VarChar, CUS_CELULAR);
            queryParameters.Append(", @CUS_CELULAR");
            sql.AddParameter("@CUS_FOTO", SqlDbType.VarChar, CUS_FOTO);
            queryParameters.Append(", @CUS_FOTO");
            sql.AddParameter("@CUS_EMAIL", SqlDbType.VarChar, CUS_EMAIL);
            queryParameters.Append(", @CUS_EMAIL");
            sql.AddParameter("@CGO_ID", SqlDbType.Int, CGO_ID);
            queryParameters.Append(", @CGO_ID");
            sql.AddParameter("@CUS_ESTADO", SqlDbType.VarChar, CUS_ESTADO);
            queryParameters.Append(", @CUS_ESTADO");

            string query = String.Format("Insert Into CUSTODIO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public static CUSTODIO NewCUSTODIO(int id)
        {
            CUSTODIO newEntity = new CUSTODIO();
            newEntity._id = id;

            return newEntity;
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CUS_CODIGO
        {
            get { return _cUS_CODIGO; }
            set { _cUS_CODIGO = value; }
        }

        public string CUS_APELLIDOS
        {
            get { return _cUS_APELLIDOS; }
            set { _cUS_APELLIDOS = value; }
        }

        public string CUS_NOMBRES
        {
            get { return _cUS_NOMBRES; }
            set { _cUS_NOMBRES = value; }
        }

        public string CUS_CEDULA
        {
            get { return _cUS_CEDULA; }
            set { _cUS_CEDULA = value; }
        }

        public string CUS_TELEFONOFIJO
        {
            get { return _cUS_TELEFONOFIJO; }
            set { _cUS_TELEFONOFIJO = value; }
        }

        public string CUS_EXT
        {
            get { return _cUS_EXT; }
            set { _cUS_EXT = value; }
        }

        public string CUS_CELULAR
        {
            get { return _cUS_CELULAR; }
            set { _cUS_CELULAR = value; }
        }

        public string CUS_FOTO
        {
            get { return _cUS_FOTO; }
            set { _cUS_FOTO = value; }
        }

        public string CUS_EMAIL
        {
            get { return _cUS_EMAIL; }
            set { _cUS_EMAIL = value; }
        }

        public int CGO_ID
        {
            get { return _cGO_ID; }
            set { _cGO_ID = value; }
        }

        public string CUS_ESTADO
        {
            get { return _cUS_ESTADO; }
            set { _cUS_ESTADO = value; }
        }
        #endregion

        public static CUSTODIO GetCUSTODIO(int id)
        {
            return new CUSTODIO(id);
        }

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@CUS_ID", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("Delete CUSTODIO Where CUS_ID = @CUS_ID");
        }

        public static void Delete2(int cusid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("Delete xcuor Where CUS_ID = " + cusid);
            sql.ExecuteSql("Delete CUSTODIO Where CUS_ID = "+cusid);
        }

        public DataTable getCustodiosAll()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select cus_id as id, cus_apellidos+' '+cus_nombres as nom from custodio order by nom");
        }
        public DataTable getCustodiosRel(int uorid)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("SELECT CUSTODIO.CUS_ID as id FROM CUSTODIO, XCUOR WHERE XCUOR.CUS_ID=CUSTODIO.CUS_ID AND XCUOR.UOR_ID=" + uorid);
        }
    }
    #endregion
}

