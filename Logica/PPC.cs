using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    #region PPC
    /// <summary>
    /// This object represents the properties and methods of a PPC.
    /// </summary>
    public class PPC
    {
        private int _id;
        private string _pPC_SERIAL = String.Empty;

        public PPC()
        {
        }

        public PPC(int id)
        {
            // NOTE: If this reference doesn't exist then add Datos.SqlService.cs from the template directory to your solution.
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@PPC_NUMERO", SqlDbType.Int, id);
            SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM PPC WHERE PPC_NUMERO = @PPC_NUMERO");

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("PPC does not exist.");
            }
        }

        public PPC(SqlDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) _pPC_SERIAL = reader.GetString(1);
            }
        }

        public void Delete()
        {
            PPC.Delete(_id);
        }

        public void Update()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            sql.AddParameter("@PPC_NUMERO", SqlDbType.Int, Id);
            //queryParameters.Append("PPC_NUMERO = @PPC_NUMERO");

            sql.AddParameter("@PPC_SERIAL", SqlDbType.VarChar, PPC_SERIAL);
            queryParameters.Append("PPC_SERIAL = @PPC_SERIAL");

            string query = String.Format("Update PPC Set {0} Where PPC_NUMERO = @PPC_NUMERO", queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public void Create()
        {
            Datos.SqlService sql = new Datos.SqlService();
            StringBuilder queryParameters = new StringBuilder();

            sql.AddParameter("@PPC_NUMERO", SqlDbType.Int, Id);
            queryParameters.Append("@PPC_NUMERO");

            sql.AddParameter("@PPC_SERIAL", SqlDbType.VarChar, PPC_SERIAL);
            queryParameters.Append(", @PPC_SERIAL");

            string query = String.Format("Insert Into PPC ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
            SqlDataReader reader = sql.ExecuteSqlReader(query);
        }

        public static PPC NewPPC(int id)
        {
            PPC newEntity = new PPC();
            newEntity._id = id;

            return newEntity;
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string PPC_SERIAL
        {
            get { return _pPC_SERIAL; }
            set { _pPC_SERIAL = value; }
        }
        #endregion

        public static PPC GetPPC(int id)
        {
            return new PPC(id);
        }

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@PPC_NUMERO", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("Delete PPC Where PPC_NUMERO = @PPC_NUMERO");
        }

        public static bool valRelActivo(string numppc)
        {
            bool hayrel = false;

            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select top 1 act_ppc from activo where act_ppc=" + numppc);
            if (obj != null)
                hayrel = true;
            return hayrel;
        }

        public bool fgetUniIng(string numppc)
        {
            Datos.SqlService sql = new Datos.SqlService();
            Object obj = sql.ExecuteSqlObject("select ppc_numero from ppc where ppc_numero=" + numppc);
            if (obj == null)
                return false;
            else
                return true;
        }
        public DataTable fGetPpc()
        {
            Datos.SqlService sql = new Datos.SqlService();
            return sql.ExecuteSqlDataTable("select ppc_numero Id, ppc_serial Serie from ppc order by ppc_numero");
        }


    }
    #endregion
}