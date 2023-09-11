using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Ocsp;

namespace Logica
{
    #region GRUPO

    /// <summary>
    /// This object represents the properties and methods of a GRUPO.
    /// </summary>
    public class GRUPO
    {
        private int _id;
        private string _gRU_NOMBRE = String.Empty;
        private int _gRU_PADRE;
        private int _gRU_NIVEL;
        private string _gRU_VALOR = String.Empty;
        private string _gRU_CTA1;
        private string _gRU_CTA2;
        private string _gRU_CTA3;

        public GRUPO()
        {
        }

        public GRUPO(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@GRU_ID", SqlDbType.Int, id);
            SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM GRUPO WHERE GRU_ID = @GRU_ID");

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("GRUPO does not exist.");
            }
        }

        public GRUPO(SqlDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) _gRU_NOMBRE = reader.GetString(1);
                if (!reader.IsDBNull(2)) _gRU_PADRE = reader.GetInt32(2);
                if (!reader.IsDBNull(3)) _gRU_NIVEL = reader.GetInt32(3);
                if (!reader.IsDBNull(4)) _gRU_VALOR = reader.GetString(4);
                if (!reader.IsDBNull(5)) _gRU_CTA1 = reader.GetString(5);
                if (!reader.IsDBNull(6)) _gRU_CTA2 = reader.GetString(6);
                if (!reader.IsDBNull(7)) _gRU_CTA3 = reader.GetString(7);
            }
        }

        public void Delete()
        {
            GRUPO.Delete(_id);
        }

        public void Update()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@GRU_ID", SqlDbType.Int, Id);
            //queryParameters.Append("GRU_ID = @GRU_ID");

            sql.AddParameter("@GRU_NOMBRE", SqlDbType.VarChar, GRU_NOMBRE);
            queryParameters.Append("GRU_NOMBRE = @GRU_NOMBRE");
            sql.AddParameter("@GRU_PADRE", SqlDbType.Int, GRU_PADRE);
            queryParameters.Append(", GRU_PADRE = @GRU_PADRE");
            sql.AddParameter("@GRU_NIVEL", SqlDbType.Int, GRU_NIVEL);
            queryParameters.Append(", GRU_NIVEL = @GRU_NIVEL");

            sql.AddParameter("@GRU_CTA1", SqlDbType.VarChar, GRU_CTA1);
            queryParameters.Append(", GRU_CTA1 = @GRU_CTA1");
            sql.AddParameter("@GRU_CTA2", SqlDbType.VarChar, GRU_CTA2);
            queryParameters.Append(", GRU_CTA2 = @GRU_CTA2");
            sql.AddParameter("@GRU_CTA3", SqlDbType.VarChar, GRU_CTA3);
            queryParameters.Append(", GRU_CTA3 = @GRU_CTA3");


            string query = String.Format("Update GRUPO Set {0} Where GRU_ID = " + Id, queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public void Create()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            //sql.AddParameter("@GRU_ID", SqlDbType.Int, Id);
            //queryParameters.Append("@GRU_ID");

            sql.AddParameter("@GRU_NOMBRE", SqlDbType.VarChar, GRU_NOMBRE);
            queryParameters.Append("@GRU_NOMBRE");
            sql.AddParameter("@GRU_PADRE", SqlDbType.Int, GRU_PADRE);
            queryParameters.Append(", @GRU_PADRE");
            sql.AddParameter("@GRU_NIVEL", SqlDbType.Int, GRU_NIVEL);
            queryParameters.Append(", @GRU_NIVEL");
            sql.AddParameter("@GRU_VALOR", SqlDbType.VarChar, GRU_VALOR);
            queryParameters.Append(", @GRU_VALOR");

            sql.AddParameter("@GRU_CTA1", SqlDbType.VarChar, GRU_CTA1);
            queryParameters.Append(", @GRU_CTA1");
            sql.AddParameter("@GRU_CTA2", SqlDbType.VarChar, GRU_CTA2);
            queryParameters.Append(", @GRU_CTA2");
            sql.AddParameter("@GRU_CTA3", SqlDbType.VarChar, GRU_CTA3);
            queryParameters.Append(", @GRU_CTA3");


            string query = String.Format("Insert Into GRUPO ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public static GRUPO NewGRUPO(int id)
        {
            GRUPO newEntity = new GRUPO();
            newEntity._id = id;

            return newEntity;
        }

        #region Public Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string GRU_NOMBRE
        {
            get { return _gRU_NOMBRE; }
            set { _gRU_NOMBRE = value; }
        }

        public int GRU_PADRE
        {
            get { return _gRU_PADRE; }
            set { _gRU_PADRE = value; }
        }

        public int GRU_NIVEL
        {
            get { return _gRU_NIVEL; }
            set { _gRU_NIVEL = value; }
        }

        public string GRU_VALOR
        {
            get { return _gRU_VALOR; }
            set { _gRU_VALOR = value; }
        }
        public string GRU_CODIGO { get; set; }
        public string GRU_CTA1
        {
            get { return _gRU_CTA1; }
            set { _gRU_CTA1 = value; }
        }

        public string GRU_CTA2
        {
            get { return _gRU_CTA2; }
            set { _gRU_CTA2 = value; }
        }

        public string GRU_CTA3
        {
            get { return _gRU_CTA3; }
            set { _gRU_CTA3 = value; }
        }

        #endregion

        public static GRUPO GetGRUPO(int id)
        {
            return new GRUPO(id);
        }

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@GRU_ID", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("Delete GRUPO Where GRU_ID = @GRU_ID");
        }

        #region metodos cayman

        public DataSet fGetGrupos1()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet(
                "select grupo.gru_id as id, gru_nombre +' - '+ convert(varchar(10),isnull(gru_vusri,''))+' meses' as nombre from grupo left join GRUPOSRI on grupo.GRU_ID=GRUPOSRI.GRU_ID where GRU_NIVEL=1 order by gru_nombre");
        }

        public DataSet fGetGrupos2()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select grupo.gru_id as id, gru_nombre as nombre from grupo where GRU_NIVEL=1 order by gru_nombre");
        }

        public DataSet fGetGruposAll(int nivel)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select grupo.gru_id, gru_nombre, gru_padre, gru_nivel, gru_vusri from grupo left join GRUPOSRI on grupo.GRU_ID=GRUPOSRI.GRU_ID where GRU_NIVEL=" + nivel + " order by gru_nombre");
        }

        public DataSet fGetHijos(int nivel, int padre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataSet("select gru_id, gru_nombre, gru_padre, gru_nivel from grupo where gru_nivel=" + nivel + " and gru_padre=" + padre + " order by gru_nombre");
        }

        public int fAddGrupo(int vu)
        {
            Datos.SqlService sql = new Datos.SqlService();
            int x = 0;

            if (vu != -1)
            {
                x = sql.ExecuteSqlIdentity("INSERT INTO grupo (gru_nombre, gru_padre, gru_nivel,gru_codigo, gru_cta1, gru_cta2, gru_cta3) VALUES ('" + GRU_NOMBRE + "', " + GRU_PADRE + ", " + GRU_NIVEL + ", '" + GRU_CODIGO + "', '" + GRU_CTA1 + "', '" + GRU_CTA2 + "', '" + GRU_CTA3 + "') SET @identity = SCOPE_IDENTITY()");
                sql.ExecuteSql("insert into gruposri (gru_id, gru_vusri) values (" + x + "," + vu + ")");
            }
            else
            {
                x = sql.ExecuteSqlIdentity("INSERT INTO grupo (gru_nombre, gru_padre, gru_nivel, GRU_CODIGO) VALUES ('" + GRU_NOMBRE + "', " + GRU_PADRE + ", " + GRU_NIVEL + ", '" + GRU_CODIGO + "') SELECT @identity = SCOPE_IDENTITY()");
            }

            return x;
        }

        public void fUpdGrupo(int vu)
        {
            Datos.SqlService sql = new Datos.SqlService();
            int x = 0;

            if (vu != -1)
            {
                sql.ExecuteSql("update grupo set gru_nombre='" + GRU_NOMBRE + "', GRU_CODIGO='" + GRU_CODIGO + "', gru_cta1='" + GRU_CTA1 + "', gru_cta2='" + GRU_CTA2 + "', gru_cta3='" + GRU_CTA3 +"' where gru_id=" + Id);
                sql.ExecuteSql("update gruposri set gru_vusri=" + vu + " where gru_id=" + Id);
            }
            else
            {
                sql.ExecuteSql("update grupo set gru_nombre='" + GRU_NOMBRE + "', GRU_CODIGO ='" + GRU_CODIGO +"', gru_cta1='" + GRU_CTA1 + "', gru_cta2='" + GRU_CTA2 + "', gru_cta3='" + GRU_CTA3 +"' where gru_id = " + Id);
            }
        }

        public void fUpdNombre(string nuevoname, string id, string codigo)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("update grupo set gru_nombre='" + nuevoname + "', GRU_CODIGO='" + codigo + "' where gru_id=" + id);
        }

        public void fDelNombre(string id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.ExecuteSql("delete from grupo where gru_id=" + id);
        }

        public void fDelGrupo()
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@GRU_ID1", SqlDbType.Int, Id);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delGRUPO");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public void fDelGrupo2()
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@GRU_ID2", SqlDbType.Int, Id);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delGRUPO2");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public void fDelGrupo3()
        {
            string error = "";
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@GRU_ID3", SqlDbType.Int, Id);
            sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);
            sql.ExecuteSP("usp_delGRUPO3");
            error = sql.Parameters["@err"].Value.ToString();
        }

        public int fcheckActivo(string id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlInt("select count(act_id) from activo where gru_id1=" + id + " or gru_id2=" + id + " or gru_id3=" + id);
        }

        public int fcheckHijos(string id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlInt("select count(gru_id) from grupo where gru_padre=" + id);
        }

        public string fcheckClon(string nombre, string idpadre)
        {
            Object obj;
            Datos.SqlService sql = new Datos.SqlService();
            if (idpadre == "null")
                obj = sql.ExecuteSqlObject("select gru_id from grupo where gru_nombre='" + nombre + "' and gru_nivel=1");
            else
                obj = sql.ExecuteSqlObject("select gru_id from grupo where gru_nombre='" + nombre + "' and gru_padre=" + idpadre);
            if (obj == null)
                return "";
            else
                return obj.ToString();
        }

        public bool fgetGruIng(string nombre, string padre)
        {
            Datos.SqlService sql = new Datos.SqlService();
            int existe = sql.ExecuteSqlInt("select count(gru_id) from grupo where gru_nombre='" + nombre + "' and gru_padre=" + padre);
            if (existe == 0)
                return false;
            else
                return true;
        }

        #endregion
    }

    #endregion
}