using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    #region PROVEEDOR
    /// <summary>
    /// This object represents the properties and methods of a PROVEEDOR.
    /// </summary>
    public class PROVEEDOR
    {
        private int _id;
        private string _pRO_RAZON = String.Empty;
        private string _pRO_NOMBRE = String.Empty;
        private string _pRO_RUC = String.Empty;
        private string _pRO_CONTACTO = String.Empty;
        private string _pRO_DIRECCION = String.Empty;
        private string _pRO_TELEFONOF = String.Empty;
        private string _pRO_CELULAR = String.Empty;
        private string _pRO_FAX = String.Empty;
        private string _pRO_EMAIL = String.Empty;
        private int _pRO_CREDITO;
        private string _pRO_OBSERVACIONES = String.Empty;
        private DateTime _pRO_FECHAREGISTRO;
        private int _gRU_ID;
        private int _pAI_ID1;
        private int _pAI_ID2;
        private int _pAI_ID3;

        public PROVEEDOR()
        {
        }

        public PROVEEDOR(int id)
        {
            // NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@PRO_ID", SqlDbType.Int, id);
            SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM PROVEEDOR WHERE PRO_ID = @PRO_ID");

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("PROVEEDOR does not exist.");
            }
        }

        public PROVEEDOR(SqlDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) _pRO_RAZON = reader.GetString(1);
                if (!reader.IsDBNull(2)) _pRO_NOMBRE = reader.GetString(2);
                if (!reader.IsDBNull(3)) _pRO_RUC = reader.GetString(3);
                if (!reader.IsDBNull(4)) _pRO_CONTACTO = reader.GetString(4);
                if (!reader.IsDBNull(5)) _pRO_DIRECCION = reader.GetString(5);
                if (!reader.IsDBNull(6)) _pRO_TELEFONOF = reader.GetString(6);
                if (!reader.IsDBNull(7)) _pRO_CELULAR = reader.GetString(7);
                if (!reader.IsDBNull(8)) _pRO_FAX = reader.GetString(8);
                if (!reader.IsDBNull(9)) _pRO_EMAIL = reader.GetString(9);
                if (!reader.IsDBNull(10)) _pRO_CREDITO = reader.GetInt32(10);
                if (!reader.IsDBNull(11)) _pRO_OBSERVACIONES = reader.GetString(11);
                if (!reader.IsDBNull(12)) _pRO_FECHAREGISTRO = reader.GetDateTime(12);
                if (!reader.IsDBNull(13)) _gRU_ID = reader.GetInt32(13);
                if (!reader.IsDBNull(14)) _pAI_ID1 = reader.GetInt32(14);
                if (!reader.IsDBNull(15)) _pAI_ID2 = reader.GetInt32(15);
                if (!reader.IsDBNull(16)) _pAI_ID3 = reader.GetInt32(16);
            }
        }

        public void Delete()
        {
            PROVEEDOR.Delete(_id);
        }

        public void Update()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            sql.AddParameter("@PRO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("PRO_ID = @PRO_ID");

            sql.AddParameter("@PRO_RAZON", SqlDbType.VarChar, PRO_RAZON);
            queryParameters.Append("PRO_RAZON = @PRO_RAZON");
            sql.AddParameter("@PRO_NOMBRE", SqlDbType.VarChar, PRO_NOMBRE);
            queryParameters.Append(", PRO_NOMBRE = @PRO_NOMBRE");
            sql.AddParameter("@PRO_RUC", SqlDbType.VarChar, PRO_RUC);
            queryParameters.Append(", PRO_RUC = @PRO_RUC");
            sql.AddParameter("@PRO_CONTACTO", SqlDbType.VarChar, PRO_CONTACTO);
            queryParameters.Append(", PRO_CONTACTO = @PRO_CONTACTO");
            sql.AddParameter("@PRO_DIRECCION", SqlDbType.VarChar, PRO_DIRECCION);
            queryParameters.Append(", PRO_DIRECCION = @PRO_DIRECCION");
            sql.AddParameter("@PRO_TELEFONOF", SqlDbType.VarChar, PRO_TELEFONOF);
            queryParameters.Append(", PRO_TELEFONOF = @PRO_TELEFONOF");
            sql.AddParameter("@PRO_CELULAR", SqlDbType.VarChar, PRO_CELULAR);
            queryParameters.Append(", PRO_CELULAR = @PRO_CELULAR");
            sql.AddParameter("@PRO_FAX", SqlDbType.VarChar, PRO_FAX);
            queryParameters.Append(", PRO_FAX = @PRO_FAX");
            sql.AddParameter("@PRO_EMAIL", SqlDbType.VarChar, PRO_EMAIL);
            queryParameters.Append(", PRO_EMAIL = @PRO_EMAIL");
            sql.AddParameter("@PRO_CREDITO", SqlDbType.Int, PRO_CREDITO);
            queryParameters.Append(", PRO_CREDITO = @PRO_CREDITO");
            sql.AddParameter("@PRO_OBSERVACIONES", SqlDbType.VarChar, PRO_OBSERVACIONES);
            queryParameters.Append(", PRO_OBSERVACIONES = @PRO_OBSERVACIONES");
            //sql.AddParameter("@PRO_FECHAREGISTRO", SqlDbType.DateTime, PRO_FECHAREGISTRO);
            //queryParameters.Append(", PRO_FECHAREGISTRO = @PRO_FECHAREGISTRO");
            sql.AddParameter("@GRU_ID", SqlDbType.Int, GRU_ID);
            queryParameters.Append(", GRU_ID = @GRU_ID");
            sql.AddParameter("@PAI_ID1", SqlDbType.Int, PAI_ID1);
            queryParameters.Append(", PAI_ID1 = @PAI_ID1");
            sql.AddParameter("@PAI_ID2", SqlDbType.Int, PAI_ID2);
            queryParameters.Append(", PAI_ID2 = @PAI_ID2");
            sql.AddParameter("@PAI_ID3", SqlDbType.Int, PAI_ID3);
            queryParameters.Append(", PAI_ID3 = @PAI_ID3");

            string query = String.Format("Update PROVEEDOR Set {0} Where PRO_ID = @PRO_ID", queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public void Create()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@PRO_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@PRO_ID");

            sql.AddParameter("@PRO_RAZON", SqlDbType.VarChar, PRO_RAZON);
            queryParameters.Append("@PRO_RAZON");
            sql.AddParameter("@PRO_NOMBRE", SqlDbType.VarChar, PRO_NOMBRE);
            queryParameters.Append(", @PRO_NOMBRE");
            sql.AddParameter("@PRO_RUC", SqlDbType.VarChar, PRO_RUC);
            queryParameters.Append(", @PRO_RUC");
            sql.AddParameter("@PRO_CONTACTO", SqlDbType.VarChar, PRO_CONTACTO);
            queryParameters.Append(", @PRO_CONTACTO");
            sql.AddParameter("@PRO_DIRECCION", SqlDbType.VarChar, PRO_DIRECCION);
            queryParameters.Append(", @PRO_DIRECCION");
            sql.AddParameter("@PRO_TELEFONOF", SqlDbType.VarChar, PRO_TELEFONOF);
            queryParameters.Append(", @PRO_TELEFONOF");
            sql.AddParameter("@PRO_CELULAR", SqlDbType.VarChar, PRO_CELULAR);
            queryParameters.Append(", @PRO_CELULAR");
            sql.AddParameter("@PRO_FAX", SqlDbType.VarChar, PRO_FAX);
            queryParameters.Append(", @PRO_FAX");
            sql.AddParameter("@PRO_EMAIL", SqlDbType.VarChar, PRO_EMAIL);
            queryParameters.Append(", @PRO_EMAIL");
            sql.AddParameter("@PRO_CREDITO", SqlDbType.Int, PRO_CREDITO);
            queryParameters.Append(", @PRO_CREDITO");
            sql.AddParameter("@PRO_OBSERVACIONES", SqlDbType.VarChar, PRO_OBSERVACIONES);
            queryParameters.Append(", @PRO_OBSERVACIONES");
            //sql.AddParameter("@PRO_FECHAREGISTRO", SqlDbType.DateTime, PRO_FECHAREGISTRO);
            //queryParameters.Append(", @PRO_FECHAREGISTRO");
            sql.AddParameter("@GRU_ID", SqlDbType.Int, GRU_ID);
            queryParameters.Append(", @GRU_ID");
            sql.AddParameter("@PAI_ID1", SqlDbType.Int, PAI_ID1);
            queryParameters.Append(", @PAI_ID1");
            sql.AddParameter("@PAI_ID2", SqlDbType.Int, PAI_ID2);
            queryParameters.Append(", @PAI_ID2");
            sql.AddParameter("@PAI_ID3", SqlDbType.Int, PAI_ID3);
            queryParameters.Append(", @PAI_ID3");

            string query = String.Format("Insert Into PROVEEDOR ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public static PROVEEDOR NewPROVEEDOR(int id)
        {
            PROVEEDOR newEntity = new PROVEEDOR();
            newEntity._id = id;

            return newEntity;
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string PRO_RAZON
        {
            get { return _pRO_RAZON; }
            set { _pRO_RAZON = value; }
        }

        public string PRO_NOMBRE
        {
            get { return _pRO_NOMBRE; }
            set { _pRO_NOMBRE = value; }
        }

        public string PRO_RUC
        {
            get { return _pRO_RUC; }
            set { _pRO_RUC = value; }
        }

        public string PRO_CONTACTO
        {
            get { return _pRO_CONTACTO; }
            set { _pRO_CONTACTO = value; }
        }

        public string PRO_DIRECCION
        {
            get { return _pRO_DIRECCION; }
            set { _pRO_DIRECCION = value; }
        }

        public string PRO_TELEFONOF
        {
            get { return _pRO_TELEFONOF; }
            set { _pRO_TELEFONOF = value; }
        }

        public string PRO_CELULAR
        {
            get { return _pRO_CELULAR; }
            set { _pRO_CELULAR = value; }
        }

        public string PRO_FAX
        {
            get { return _pRO_FAX; }
            set { _pRO_FAX = value; }
        }

        public string PRO_EMAIL
        {
            get { return _pRO_EMAIL; }
            set { _pRO_EMAIL = value; }
        }

        public int PRO_CREDITO
        {
            get { return _pRO_CREDITO; }
            set { _pRO_CREDITO = value; }
        }

        public string PRO_OBSERVACIONES
        {
            get { return _pRO_OBSERVACIONES; }
            set { _pRO_OBSERVACIONES = value; }
        }

        public DateTime PRO_FECHAREGISTRO
        {
            get { return _pRO_FECHAREGISTRO; }
            set { _pRO_FECHAREGISTRO = value; }
        }

        public int GRU_ID
        {
            get { return _gRU_ID; }
            set { _gRU_ID = value; }
        }

        public int PAI_ID1
        {
            get { return _pAI_ID1; }
            set { _pAI_ID1 = value; }
        }

        public int PAI_ID2
        {
            get { return _pAI_ID2; }
            set { _pAI_ID2 = value; }
        }

        public int PAI_ID3
        {
            get { return _pAI_ID3; }
            set { _pAI_ID3 = value; }
        }
        #endregion

        public static PROVEEDOR GetPROVEEDOR(int id)
        {
            return new PROVEEDOR(id);
        }

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@PRO_ID", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("Delete PROVEEDOR Where PRO_ID = @PRO_ID");
        }
        public static Boolean valRelActivo(int idpro)
        {
            Boolean hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select act_id from activo where pro_id=" + idpro);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }
    }
    #endregion
}


