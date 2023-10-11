using System;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    #region ACTIVO

    /// <summary>
    /// This object represents the properties and methods of a ACTIVO.
    /// </summary>
    public class ACTIVO
    {
        private int _id;
        private string _eMP_ID = String.Empty;
        private DateTime _aCT_FECHACREACION;
        private DateTime _aCT_FECHAINIDEPRE;
        private bool _aCT_DEPRECIABLESRI;
        private bool _aCT_DEPRECIABLE;
        private bool _aCT_DEPRECIADOSRI;
        private bool _aCT_DEPRECIADONIIF;
        private DateTime _aCT_FECHAINIOPER;
        private DateTime _aCT_FECHAINIDEPRENIIF;
        private DateTime _aCT_FECHABAJA;
        private string _uSERNAME = String.Empty;
        private string _aCT_TIPO = String.Empty;
        private string _aCT_CODBARRAS = String.Empty;
        private string _aCT_CODBARRASPADRE = String.Empty;
        private string _aCT_CODIGO1 = String.Empty;
        private int _gRU_ID1;
        private int _gRU_ID2;
        private int _gRU_ID3;
        private string _aCT_FOTO1 = String.Empty;
        private string _aCT_FOTO2 = String.Empty;
        private string _aCT_DOC1 = String.Empty;
        private string _aCT_DOC2 = String.Empty;
        private int _uGE_ID1;
        private int _uGE_ID2;
        private int _uGE_ID3;
        private int _uGE_ID4;
        private int _uOR_ID1;
        private int _uOR_ID2;
        private int _uOR_ID3;
        private int _cUS_ID1;
        private int _cUS_ID2;
        private int _eST_ID1;
        private int _eST_ID2;
        private int _eST_ID3;
        private int _mAR_ID;
        private int _mOD_ID;
        private string _aCT_SERIE1 = String.Empty;
        private int _cOL_ID;
        private int _eCO_ID1;
        private int _eCO_ID2;
        private int _pRO_ID;
        private string _aCT_TIPOING = String.Empty;
        private Int64 _aCT_NUMFACT;
        private DateTime _aCT_FECHACOMPRA;
        private decimal _aCT_VALORCOMPRA;
        private decimal _aCT_VALORRAZONABLE;
        private int _aCT_ANIO;
        private int _aCT_VIDAUTIL;
        private int _aCT_VIDAUTILNIIF;
        private decimal _aCT_VALORRESIDUALNIIF;
        private bool _aCT_GARANTIA;
        private DateTime _aCT_FECHAGARANTIAVENCE;
        private string _aCT_OBSERVACIONES = String.Empty;
        private bool _aCT_TRANSFEROK;
        private int _aCT_PPC;
        private string _aCT_H1 = String.Empty;
        private string _aCT_H2 = String.Empty;
        private string _aCT_PE = String.Empty;
        private string _aCT_OBSERVACIONES2 = String.Empty;
        private int _aCT_TIPOBAJA;
        private string _aCT_OBSBAJA = String.Empty;
        private bool _aCT_BAJAPROCESADA;
        private int _ACT_TIPRFID;
        private string _ACT_CODRFID;
        private object _aCT_NUMFACT1;
        private int _aCT_TIPOSEGURO;
        private string _aCT_SEGURO;
        private string _aCT_NUMPOLIZA = String.Empty;
        private int _aCT_VIGENCIAPOLIZAMESES;
        private DateTime? _aCT_FECHAEMISIONPOLIZA = null;
        private DateTime? _aCT_FECHAVENCEPOLIZA = null;
        private decimal _aCT_VALORASEGURADO;
        public DateTime? ACT_FECHAULTDEPRE { get; set; }
        public  decimal ACT_DEPREACUMULADA { get; set; }
        private string _aCT_DESCRIPCIONLARGA = String.Empty;

        /*Propieades Asiento Ingreso*/
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public string Oficina1 { get; set; }
        public string Oficina2 { get; set; }
        public string CentroCosto1 { get; set; }
        public string CentroCosto2 { get; set; }
        public string CuentaDepreOrigen { get; set; }
        public string CuentaDepreDestino { get; set; }
        public string OficinaDepre1 { get; set; }
        public string OficinaDepre2 { get; set; }
        public string CentroCostoDepre1 { get; set; }
        public string CentroCostoDepre2 { get; set; }
        public string DebitoDepre1 { get; set; }
        public string CreditoDepre1 { get; set; }
        public string DebitoDepre2 { get; set; }
        public string CreditoDepre2 { get; set; }


        public decimal ACT_VALORASEGURADO
        {
            get { return _aCT_VALORASEGURADO; }
            set { _aCT_VALORASEGURADO = value; }
        }


        public DateTime? ACT_FECHAVENCEPOLIZA
        {
            get { return _aCT_FECHAVENCEPOLIZA; }
            set { _aCT_FECHAVENCEPOLIZA = value; }
        }


        public DateTime? ACT_FECHAEMISIONPOLIZA
        {
            get { return _aCT_FECHAEMISIONPOLIZA; }
            set { _aCT_FECHAEMISIONPOLIZA = value; }
        }


        public int ACT_VIGENCIAPOLIZAMESES
        {
            get { return _aCT_VIGENCIAPOLIZAMESES; }
            set { _aCT_VIGENCIAPOLIZAMESES = value; }
        }


        public string ACT_NUMPOLIZA
        {
            get { return _aCT_NUMPOLIZA; }
            set { _aCT_NUMPOLIZA = value; }
        }


        public ACTIVO()
        {
        }

        public ACTIVO(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ACT_ID", SqlDbType.Int, id);
            SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM ACTIVO WHERE ACT_ID = @ACT_ID");

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("El Item no existe.");
            }
        }

        public ACTIVO(string cod, string campo)
        {
            Datos.SqlService sql = new Datos.SqlService();

            SqlDataReader reader = null;

            if (campo == "cb")
            {
                sql.AddParameter("@ACT_CODBARRAS", SqlDbType.VarChar, cod);
                reader = sql.ExecuteSqlReader("SELECT * FROM ACTIVO WHERE ACT_CODBARRAS = @ACT_CODBARRAS");
            }
            else if (campo == "cs")
            {
                sql.AddParameter("@ACT_CODIGO1", SqlDbType.VarChar, cod);
                reader = sql.ExecuteSqlReader("SELECT * FROM ACTIVO WHERE ACT_ID = @ACT_CODIGO1");
            }
            else if (campo == "id")
            {
                sql.AddParameter("@ACT_ID", SqlDbType.Int, cod);
                reader = sql.ExecuteSqlReader("SELECT * FROM ACTIVO WHERE ACT_ID = @ACT_ID");
            }
            else if (campo == "cs1")
            {
                sql.AddParameter("@ACT_SERIE1", SqlDbType.VarChar, cod);
                reader = sql.ExecuteSqlReader("SELECT * FROM ACTIVO WHERE ACT_SERIE1 = @ACT_SERIE1");
            }

            if (reader.Read())
            {
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("El Item con c�digo: " + cod + " no existe...");
            }
        }

        public ACTIVO(SqlDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) _eMP_ID = reader.GetString(1);
                if (!reader.IsDBNull(2)) _aCT_FECHACREACION = reader.GetDateTime(2);
                if (!reader.IsDBNull(3)) _aCT_FECHAINIDEPRE = reader.GetDateTime(3);
                if (!reader.IsDBNull(4)) _aCT_DEPRECIABLESRI = reader.GetBoolean(4);
                if (!reader.IsDBNull(5)) _aCT_DEPRECIABLE = reader.GetBoolean(5);
                if (!reader.IsDBNull(6)) _aCT_DEPRECIADOSRI = reader.GetBoolean(6);
                if (!reader.IsDBNull(7)) _aCT_DEPRECIADONIIF = reader.GetBoolean(7);
                if (!reader.IsDBNull(8)) _aCT_FECHAINIOPER = reader.GetDateTime(8);
                if (!reader.IsDBNull(9)) _aCT_FECHAINIDEPRENIIF = reader.GetDateTime(9);
                if (!reader.IsDBNull(10)) _aCT_FECHABAJA = reader.GetDateTime(10);
                if (!reader.IsDBNull(11)) _uSERNAME = reader.GetString(11);
                if (!reader.IsDBNull(12)) _aCT_TIPO = reader.GetString(12);
                if (!reader.IsDBNull(13)) _aCT_CODBARRAS = reader.GetString(13);
                if (!reader.IsDBNull(14)) _aCT_CODBARRASPADRE = reader.GetString(14);
                if (!reader.IsDBNull(15)) _aCT_CODIGO1 = reader.GetString(15);
                if (!reader.IsDBNull(16)) _gRU_ID1 = reader.GetInt32(16);
                if (!reader.IsDBNull(17)) _gRU_ID2 = reader.GetInt32(17);
                if (!reader.IsDBNull(18)) _gRU_ID3 = reader.GetInt32(18);
                if (!reader.IsDBNull(19)) _aCT_FOTO1 = reader.GetString(19);
                if (!reader.IsDBNull(20)) _aCT_FOTO2 = reader.GetString(20);
                if (!reader.IsDBNull(21)) _aCT_DOC1 = reader.GetString(21);
                if (!reader.IsDBNull(22)) _aCT_DOC2 = reader.GetString(22);
                if (!reader.IsDBNull(23)) _uGE_ID1 = reader.GetInt32(23);
                if (!reader.IsDBNull(24)) _uGE_ID2 = reader.GetInt32(24);
                if (!reader.IsDBNull(25)) _uGE_ID3 = reader.GetInt32(25);
                if (!reader.IsDBNull(26)) _uGE_ID4 = reader.GetInt32(26);
                if (!reader.IsDBNull(27)) _uOR_ID1 = reader.GetInt32(27);
                if (!reader.IsDBNull(28)) _uOR_ID2 = reader.GetInt32(28);
                if (!reader.IsDBNull(29)) _uOR_ID3 = reader.GetInt32(29);
                if (!reader.IsDBNull(30)) _cUS_ID1 = reader.GetInt32(30);
                if (!reader.IsDBNull(31)) _cUS_ID2 = reader.GetInt32(31);
                if (!reader.IsDBNull(32)) _eST_ID1 = reader.GetInt32(32);
                if (!reader.IsDBNull(33)) _eST_ID2 = reader.GetInt32(33);
                if (!reader.IsDBNull(34)) _eST_ID3 = reader.GetInt32(34);
                if (!reader.IsDBNull(35)) _mAR_ID = reader.GetInt32(35);
                if (!reader.IsDBNull(36)) _mOD_ID = reader.GetInt32(36);
                if (!reader.IsDBNull(37)) _aCT_SERIE1 = reader.GetString(37);
                if (!reader.IsDBNull(38)) _cOL_ID = reader.GetInt32(38);
                if (!reader.IsDBNull(39)) _eCO_ID1 = reader.GetInt32(39);
                if (!reader.IsDBNull(40)) _eCO_ID2 = reader.GetInt32(40);
                if (!reader.IsDBNull(41)) _pRO_ID = reader.GetInt32(41);
                if (!reader.IsDBNull(42)) _aCT_TIPOING = reader.GetString(42);
                if (!reader.IsDBNull(43)) _aCT_NUMFACT1 = reader["ACT_NUMFACT"];
                //if (!reader.IsDBNull(43)) _aCT_NUMFACT = reader.GetInt64(43);
                if (!reader.IsDBNull(44)) _aCT_FECHACOMPRA = reader.GetDateTime(44);
                if (!reader.IsDBNull(45)) _aCT_VALORCOMPRA = reader.GetDecimal(45);
                if (!reader.IsDBNull(46)) _aCT_ANIO = reader.GetInt32(46);
                if (!reader.IsDBNull(47)) _aCT_VIDAUTIL = reader.GetInt32(47);
                if (!reader.IsDBNull(48)) _aCT_VIDAUTILNIIF = reader.GetInt32(48);
                if (!reader.IsDBNull(49)) _aCT_VALORRESIDUALNIIF = reader.GetDecimal(49);
                if (!reader.IsDBNull(50)) _aCT_GARANTIA = reader.GetBoolean(50);
                if (!reader.IsDBNull(51)) _aCT_FECHAGARANTIAVENCE = reader.GetDateTime(51);
                if (!reader.IsDBNull(52)) _aCT_OBSERVACIONES = reader.GetString(52);
                if (!reader.IsDBNull(53)) _aCT_TRANSFEROK = reader.GetBoolean(53);
                if (!reader.IsDBNull(54)) _aCT_PPC = reader.GetInt32(54);
                if (!reader.IsDBNull(55)) _aCT_H1 = reader.GetString(55);
                if (!reader.IsDBNull(56)) _aCT_H2 = reader.GetString(56);
                if (!reader.IsDBNull(57)) _aCT_PE = reader.GetString(57);
                if (!reader.IsDBNull(58)) _aCT_OBSERVACIONES2 = reader.GetString(58);
                if (!reader.IsDBNull(59)) _aCT_TIPOBAJA = reader.GetInt32(59);
                if (!reader.IsDBNull(60)) _aCT_OBSBAJA = reader.GetString(60);
                if (!reader.IsDBNull(61)) _aCT_BAJAPROCESADA = reader.GetBoolean(61);
                if (!reader.IsDBNull(67)) _ACT_CODRFID = reader.GetString(67);
                if (!reader.IsDBNull(72)) _ACT_TIPRFID = reader.GetInt32(72);
                if (!reader.IsDBNull(73)) _aCT_SEGURO = reader.GetString(73);
                if (!reader.IsDBNull(74)) _aCT_TIPOSEGURO = reader.GetInt32(74);
                if (!reader.IsDBNull(79)) _aCT_NUMPOLIZA = reader.GetString(79);
                if (!reader.IsDBNull(80)) _aCT_VIGENCIAPOLIZAMESES = reader.GetInt32(80);
                if (!reader.IsDBNull(81)) _aCT_FECHAEMISIONPOLIZA = reader.GetDateTime(81);
                if (!reader.IsDBNull(82)) _aCT_FECHAVENCEPOLIZA = reader.GetDateTime(82);
                if (!reader.IsDBNull(83)) _aCT_VALORASEGURADO = reader.GetDecimal(83);
                if (!reader.IsDBNull(84)) ACT_FECHAULTDEPRE = reader.GetDateTime(84);
                if (!reader.IsDBNull(85)) ACT_DEPREACUMULADA = reader.GetDecimal(85);
                if (!reader.IsDBNull(65)) _aCT_VALORRAZONABLE = reader.GetDecimal(65);
                if (!reader.IsDBNull(78)) _aCT_DESCRIPCIONLARGA = reader.GetString(78);

            }
        }

        public void Delete()
        {
            ACTIVO.Delete(_id);
        }

        public static ACTIVO NewACTIVO(int id)
        {
            ACTIVO newEntity = new ACTIVO();
            newEntity._id = id;

            return newEntity;
        }

        #region Public Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ACT_TIPRFID
        {
            get { return _ACT_TIPRFID; }
            set { _ACT_TIPRFID = value; }
        }


        public string EMP_ID
        {
            get { return _eMP_ID; }
            set { _eMP_ID = value; }
        }

        public string ACT_CODRFID
        {
            get { return _ACT_CODRFID; }
            set { _ACT_CODRFID = value; }
        }

        public DateTime ACT_FECHACREACION
        {
            get { return _aCT_FECHACREACION; }
            set { _aCT_FECHACREACION = value; }
        }

        public DateTime ACT_FECHAINIDEPRE
        {
            get { return _aCT_FECHAINIDEPRE; }
            set { _aCT_FECHAINIDEPRE = value; }
        }

        public bool ACT_DEPRECIABLESRI
        {
            get { return _aCT_DEPRECIABLESRI; }
            set { _aCT_DEPRECIABLESRI = value; }
        }

        public bool ACT_DEPRECIABLE
        {
            get { return _aCT_DEPRECIABLE; }
            set { _aCT_DEPRECIABLE = value; }
        }

        public bool ACT_DEPRECIADOSRI
        {
            get { return _aCT_DEPRECIADOSRI; }
            set { _aCT_DEPRECIADOSRI = value; }
        }

        public bool ACT_DEPRECIADONIIF
        {
            get { return _aCT_DEPRECIADONIIF; }
            set { _aCT_DEPRECIADONIIF = value; }
        }

        public DateTime ACT_FECHAINIOPER
        {
            get { return _aCT_FECHAINIOPER; }
            set { _aCT_FECHAINIOPER = value; }
        }

        public DateTime ACT_FECHAINIDEPRENIIF
        {
            get { return _aCT_FECHAINIDEPRENIIF; }
            set { _aCT_FECHAINIDEPRENIIF = value; }
        }

        public DateTime ACT_FECHABAJA
        {
            get { return _aCT_FECHABAJA; }
            set { _aCT_FECHABAJA = value; }
        }

        public string USERNAME
        {
            get { return _uSERNAME; }
            set { _uSERNAME = value; }
        }

        public string ACT_TIPO
        {
            get { return _aCT_TIPO; }
            set { _aCT_TIPO = value; }
        }

        public string ACT_CODBARRAS
        {
            get { return _aCT_CODBARRAS; }
            set { _aCT_CODBARRAS = value; }
        }

        public string ACT_CODBARRASPADRE
        {
            get { return _aCT_CODBARRASPADRE; }
            set { _aCT_CODBARRASPADRE = value; }
        }

        public string ACT_CODIGO1
        {
            get { return _aCT_CODIGO1; }
            set { _aCT_CODIGO1 = value; }
        }

        public int GRU_ID1
        {
            get { return _gRU_ID1; }
            set { _gRU_ID1 = value; }
        }

        public int GRU_ID2
        {
            get { return _gRU_ID2; }
            set { _gRU_ID2 = value; }
        }

        public int GRU_ID3
        {
            get { return _gRU_ID3; }
            set { _gRU_ID3 = value; }
        }

        public string ACT_FOTO1
        {
            get { return _aCT_FOTO1; }
            set { _aCT_FOTO1 = value; }
        }

        public string ACT_FOTO2
        {
            get { return _aCT_FOTO2; }
            set { _aCT_FOTO2 = value; }
        }

        public string ACT_DOC1
        {
            get { return _aCT_DOC1; }
            set { _aCT_DOC1 = value; }
        }

        public string ACT_DOC2
        {
            get { return _aCT_DOC2; }
            set { _aCT_DOC2 = value; }
        }

        public int UGE_ID1
        {
            get { return _uGE_ID1; }
            set { _uGE_ID1 = value; }
        }

        public int UGE_ID2
        {
            get { return _uGE_ID2; }
            set { _uGE_ID2 = value; }
        }

        public int UGE_ID3
        {
            get { return _uGE_ID3; }
            set { _uGE_ID3 = value; }
        }

        public int UGE_ID4
        {
            get { return _uGE_ID4; }
            set { _uGE_ID4 = value; }
        }

        public int UOR_ID1
        {
            get { return _uOR_ID1; }
            set { _uOR_ID1 = value; }
        }

        public int UOR_ID2
        {
            get { return _uOR_ID2; }
            set { _uOR_ID2 = value; }
        }

        public int UOR_ID3
        {
            get { return _uOR_ID3; }
            set { _uOR_ID3 = value; }
        }

        public int CUS_ID1
        {
            get { return _cUS_ID1; }
            set { _cUS_ID1 = value; }
        }

        public int CUS_ID2
        {
            get { return _cUS_ID2; }
            set { _cUS_ID2 = value; }
        }

        public int EST_ID1
        {
            get { return _eST_ID1; }
            set { _eST_ID1 = value; }
        }

        public int EST_ID2
        {
            get { return _eST_ID2; }
            set { _eST_ID2 = value; }
        }

        public int EST_ID3
        {
            get { return _eST_ID3; }
            set { _eST_ID3 = value; }
        }

        public int MAR_ID
        {
            get { return _mAR_ID; }
            set { _mAR_ID = value; }
        }

        public int MOD_ID
        {
            get { return _mOD_ID; }
            set { _mOD_ID = value; }
        }

        public string ACT_SERIE1
        {
            get { return _aCT_SERIE1; }
            set { _aCT_SERIE1 = value; }
        }

        public int COL_ID
        {
            get { return _cOL_ID; }
            set { _cOL_ID = value; }
        }

        public int ECO_ID1
        {
            get { return _eCO_ID1; }
            set { _eCO_ID1 = value; }
        }

        public int ECO_ID2
        {
            get { return _eCO_ID2; }
            set { _eCO_ID2 = value; }
        }

        public int PRO_ID
        {
            get { return _pRO_ID; }
            set { _pRO_ID = value; }
        }

        public string ACT_TIPOING
        {
            get { return _aCT_TIPOING; }
            set { _aCT_TIPOING = value; }
        }

        public object ACT_NUMFACT1
        {
            get { return _aCT_NUMFACT1; }
            set { _aCT_NUMFACT1 = value; }
        }

        public Int64 ACT_NUMFACT
        {
            get { return _aCT_NUMFACT; }
            set { _aCT_NUMFACT = value; }
        }

        public DateTime ACT_FECHACOMPRA
        {
            get { return _aCT_FECHACOMPRA; }
            set { _aCT_FECHACOMPRA = value; }
        }

        public decimal ACT_VALORCOMPRA
        {
            get { return _aCT_VALORCOMPRA; }
            set { _aCT_VALORCOMPRA = value; }
        }
        public decimal ACT_VALORRAZONABLE
        {
            get { return _aCT_VALORRAZONABLE; }
            set { _aCT_VALORRAZONABLE = value; }
        }
        public int ACT_ANIO
        {
            get { return _aCT_ANIO; }
            set { _aCT_ANIO = value; }
        }

        public int ACT_VIDAUTIL
        {
            get { return _aCT_VIDAUTIL; }
            set { _aCT_VIDAUTIL = value; }
        }

        public int ACT_VIDAUTILNIIF
        {
            get { return _aCT_VIDAUTILNIIF; }
            set { _aCT_VIDAUTILNIIF = value; }
        }

        public decimal ACT_VALORRESIDUALNIIF
        {
            get { return _aCT_VALORRESIDUALNIIF; }
            set { _aCT_VALORRESIDUALNIIF = value; }
        }

        public bool ACT_GARANTIA
        {
            get { return _aCT_GARANTIA; }
            set { _aCT_GARANTIA = value; }
        }

        public DateTime ACT_FECHAGARANTIAVENCE
        {
            get { return _aCT_FECHAGARANTIAVENCE; }
            set { _aCT_FECHAGARANTIAVENCE = value; }
        }

        public string ACT_OBSERVACIONES
        {
            get { return _aCT_OBSERVACIONES; }
            set { _aCT_OBSERVACIONES = value; }
        }
        
              public string ACT_DESCRIPCIONLARGA
        {
            get { return _aCT_DESCRIPCIONLARGA; }
            set { _aCT_DESCRIPCIONLARGA = value; }
        }
        public bool ACT_TRANSFEROK
        {
            get { return _aCT_TRANSFEROK; }
            set { _aCT_TRANSFEROK = value; }
        }

        public int ACT_PPC
        {
            get { return _aCT_PPC; }
            set { _aCT_PPC = value; }
        }

        public string ACT_H1
        {
            get { return _aCT_H1; }
            set { _aCT_H1 = value; }
        }

        public string ACT_H2
        {
            get { return _aCT_H2; }
            set { _aCT_H2 = value; }
        }

        public string ACT_PE
        {
            get { return _aCT_PE; }
            set { _aCT_PE = value; }
        }

        public string ACT_OBSERVACIONES2
        {
            get { return _aCT_OBSERVACIONES2; }
            set { _aCT_OBSERVACIONES2 = value; }
        }

        public int ACT_TIPOBAJA
        {
            get { return _aCT_TIPOBAJA; }
            set { _aCT_TIPOBAJA = value; }
        }

        public string ACT_OBSBAJA
        {
            get { return _aCT_OBSBAJA; }
            set { _aCT_OBSBAJA = value; }
        }

        public bool ACT_BAJAPROCESADA
        {
            get { return _aCT_BAJAPROCESADA; }
            set { _aCT_BAJAPROCESADA = value; }
        }

        public string ACT_SEGURO
        {
            get { return _aCT_SEGURO; }
            set { _aCT_SEGURO = value; }
        }

        public int ACT_TIPOSEGURO
        {
            get { return _aCT_TIPOSEGURO; }
            set { _aCT_TIPOSEGURO = value; }
        }

        #endregion

        public static ACTIVO GetACTIVO(int id)
        {
            return new ACTIVO(id);
        }

        public static void Delete(int id)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@ACT_ID", SqlDbType.Int, id);

            SqlDataReader reader = sql.ExecuteSqlReader("Delete ACTIVO Where ACT_ID = @ACT_ID");
        }

        //METODOS cayman
        public string insActivo()
        {
            Datos.SqlService sql = new Datos.SqlService();
            string err = "";

            try
            {
                sql.AddParameter("@ACT_ID", SqlDbType.Int, Id);
                sql.AddParameter("@EMP_ID", SqlDbType.VarChar, EMP_ID);

                sql.AddParameter("@ACT_FECHACREACION", SqlDbType.SmallDateTime, System.DateTime.Now.ToShortDateString());

                if (ACT_FECHAINIDEPRE == null)
                {
                    sql.AddParameter("@ACT_FECHAINIDEPRE", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAINIDEPRE", SqlDbType.SmallDateTime, ACT_FECHAINIDEPRE);
                }

                sql.AddParameter("@ACT_DEPRECIABLE", SqlDbType.Bit, ACT_DEPRECIABLE);
                //sql.AddParameter("@ACT_DEPRECIABLESRI", SqlDbType.Bit, ACT_DEPRECIABLESRI);
                sql.AddParameter("@USERNAME", SqlDbType.VarChar, USERNAME);
                sql.AddParameter("@ACT_TIPO", SqlDbType.VarChar, ACT_TIPO);
                sql.AddParameter("@ACT_CODBARRASPADRE", SqlDbType.VarChar, ACT_CODBARRASPADRE);
                sql.AddParameter("@ACT_CODIGO1", SqlDbType.VarChar, ACT_CODIGO1);
                sql.AddParameter("@GRU_ID1", SqlDbType.Int, GRU_ID1);
                sql.AddParameter("@GRU_ID2", SqlDbType.Int, GRU_ID2);
                sql.AddParameter("@GRU_ID3", SqlDbType.Int, GRU_ID3);
                sql.AddParameter("@ACT_FOTO1", SqlDbType.VarChar, ACT_FOTO1);
                sql.AddParameter("@ACT_FOTO2", SqlDbType.VarChar, ACT_FOTO2);
                sql.AddParameter("@ACT_DOC1", SqlDbType.VarChar, ACT_DOC1);
                sql.AddParameter("@ACT_DOC2", SqlDbType.VarChar, ACT_DOC2);
                sql.AddParameter("@UGE_ID1", SqlDbType.Int, UGE_ID1);
                sql.AddParameter("@UGE_ID2", SqlDbType.Int, UGE_ID2);
                sql.AddParameter("@UGE_ID3", SqlDbType.Int, UGE_ID3);
                sql.AddParameter("@UGE_ID4", SqlDbType.Int, UGE_ID4);
                sql.AddParameter("@UOR_ID1", SqlDbType.Int, UOR_ID1);
                sql.AddParameter("@UOR_ID2", SqlDbType.Int, UOR_ID2);
                sql.AddParameter("@UOR_ID3", SqlDbType.Int, UOR_ID3);
                sql.AddParameter("@CUS_ID1", SqlDbType.Int, CUS_ID1);

                if (EST_ID1 == -1)
                    sql.AddParameter("@EST_ID1", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID1", SqlDbType.Int, EST_ID1);

                if (EST_ID2 == -1)
                    sql.AddParameter("@EST_ID2", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID2", SqlDbType.Int, EST_ID2);

                if (EST_ID3 == -1)
                    sql.AddParameter("@EST_ID3", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID3", SqlDbType.Int, EST_ID3);

                sql.AddParameter("@MAR_ID", SqlDbType.Int, MAR_ID);
                sql.AddParameter("@MOD_ID", SqlDbType.Int, MOD_ID);
                sql.AddParameter("@ACT_SERIE1", SqlDbType.VarChar, ACT_SERIE1);

                if (COL_ID == -1)
                    sql.AddParameter("@COL_ID", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@COL_ID", SqlDbType.Int, COL_ID);

                if (ECO_ID1 == -1)
                    sql.AddParameter("@ECO_ID1", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ECO_ID1", SqlDbType.VarChar, ECO_ID1);

                if (ECO_ID2 == -1)
                    sql.AddParameter("@ECO_ID2", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ECO_ID2", SqlDbType.VarChar, ECO_ID2);

                sql.AddParameter("@PRO_ID", SqlDbType.Int, PRO_ID);
                sql.AddParameter("@ACT_TIPOING", SqlDbType.VarChar, ACT_TIPOING);
                sql.AddParameter("@ACT_NUMFACT", SqlDbType.BigInt, ACT_NUMFACT);

                if (ACT_FECHACOMPRA != null)
                {
                    sql.AddParameter("@ACT_FECHACOMPRA", SqlDbType.SmallDateTime, ACT_FECHACOMPRA);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHACOMPRA", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }

                sql.AddParameter("@ACT_VALORCOMPRA", SqlDbType.Decimal, ACT_VALORCOMPRA);
                sql.AddParameter("@ACT_VALORRAZONABLE", SqlDbType.Decimal, ACT_VALORRAZONABLE);


                if (ACT_ANIO == -1)
                    sql.AddParameter("@ACT_ANIO", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ACT_ANIO", SqlDbType.Int, ACT_ANIO);

                sql.AddParameter("@ACT_VIDAUTIL", SqlDbType.Int, ACT_VIDAUTIL);
                sql.AddParameter("@ACT_VIDAUTILNIIF", SqlDbType.Int, ACT_VIDAUTILNIIF);
                sql.AddParameter("@ACT_VALORRESIDUALNIIF", SqlDbType.Decimal, ACT_VALORRESIDUALNIIF);
                sql.AddParameter("@ACT_GARANTIA", SqlDbType.Bit, ACT_GARANTIA);

                if (!ACT_GARANTIA)
                    sql.AddParameter("@ACT_FECHAGARANTIAVENCE", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                else
                    sql.AddParameter("@ACT_FECHAGARANTIAVENCE", SqlDbType.SmallDateTime, ACT_FECHAGARANTIAVENCE);

                sql.AddParameter("@ACT_OBSERVACIONES", SqlDbType.VarChar, ACT_OBSERVACIONES);

                if (ACT_FECHAINIOPER == null)
                {
                    sql.AddParameter("@ACT_FECHAINIOPER", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                    sql.AddParameter("@ACT_FECHAINIDEPRENIIF", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAINIOPER", SqlDbType.SmallDateTime, ACT_FECHAINIOPER);
                    sql.AddParameter("@ACT_FECHAINIDEPRENIIF", SqlDbType.SmallDateTime, ACT_FECHAINIDEPRENIIF);
                }

                sql.AddParameter("@ACT_CODBARRAS", SqlDbType.VarChar, ACT_CODBARRAS);
                sql.AddParameter("@ACT_CODRFID", SqlDbType.VarChar, ACT_CODRFID);
                sql.AddParameter("@ACT_TIPRFID", SqlDbType.VarChar, ACT_TIPRFID);
                sql.AddParameter("@ACT_SEGURO", SqlDbType.VarChar, ACT_SEGURO);

                if (ACT_TIPOSEGURO != 0)
                    sql.AddParameter("@ACT_TIPOSEGURO", SqlDbType.Int, ACT_TIPOSEGURO);
                else
                    sql.AddParameter("@ACT_TIPOSEGURO", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);


                if (ACT_NUMPOLIZA != "")
                {
                    sql.AddParameter("@ACT_NUMPOLIZA", SqlDbType.VarChar, ACT_NUMPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_NUMPOLIZA", SqlDbType.VarChar, System.Data.SqlTypes.SqlString.Null);
                }

                if (ACT_VIGENCIAPOLIZAMESES > 0)
                {
                    sql.AddParameter("@ACT_VIGENCIAPOLIZAMESES", SqlDbType.Int, ACT_VIGENCIAPOLIZAMESES);
                }
                else
                {
                    sql.AddParameter("@ACT_VIGENCIAPOLIZAMESES", SqlDbType.Int, 0);
                }

                if (ACT_FECHAEMISIONPOLIZA != null)
                {
                    sql.AddParameter("@ACT_FECHAEMISIONPOLIZA", SqlDbType.DateTime, ACT_FECHAEMISIONPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAEMISIONPOLIZA", SqlDbType.DateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }

                if (ACT_FECHAVENCEPOLIZA != null)
                {
                    sql.AddParameter("@ACT_FECHAVENCEPOLIZA", SqlDbType.DateTime, ACT_FECHAVENCEPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAVENCEPOLIZA", SqlDbType.DateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }

                if (ACT_VALORASEGURADO > 0)
                    sql.AddParameter("@ACT_VALORASEGURADO", SqlDbType.Decimal, ACT_VALORASEGURADO);
                else
                    sql.AddParameter("@ACT_VALORASEGURADO", SqlDbType.Decimal, 0);


                sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

                sql.ExecuteSP("usp_InsertACTIVO");

                err = sql.Parameters["@err"].Value.ToString();

                return err;
            }
            catch (Exception ex)
            {
                return err + ". Sistema: " + ex.Message;
            }
        }

        public string updActivo()
        {
            Datos.SqlService sql = new Datos.SqlService();
            string error = "";

            try
            {
                sql.AddParameter("@ACT_ID", SqlDbType.Int, Id);
                sql.AddParameter("@USERNAME", SqlDbType.VarChar, USERNAME);
                sql.AddParameter("@ACT_CODBARRASPADRE", SqlDbType.VarChar, ACT_CODBARRASPADRE);
                sql.AddParameter("@ACT_CODIGO1", SqlDbType.VarChar, ACT_CODIGO1);
                sql.AddParameter("@GRU_ID2", SqlDbType.Int, GRU_ID2);
                sql.AddParameter("@GRU_ID3", SqlDbType.Int, GRU_ID3);
                sql.AddParameter("@ACT_FOTO1", SqlDbType.VarChar, ACT_FOTO1);
                sql.AddParameter("@ACT_FOTO2", SqlDbType.VarChar, ACT_FOTO2);
                sql.AddParameter("@ACT_DOC1", SqlDbType.VarChar, ACT_DOC1);
                sql.AddParameter("@ACT_DOC2", SqlDbType.VarChar, ACT_DOC2);

                sql.AddParameter("@UGE_ID1", SqlDbType.Int, UGE_ID1);
                sql.AddParameter("@UGE_ID2", SqlDbType.Int, UGE_ID2);
                sql.AddParameter("@UGE_ID3", SqlDbType.Int, UGE_ID3);
                sql.AddParameter("@UGE_ID4", SqlDbType.Int, UGE_ID4);
                sql.AddParameter("@UOR_ID1", SqlDbType.Int, UOR_ID1);
                sql.AddParameter("@UOR_ID2", SqlDbType.Int, UOR_ID2);
                sql.AddParameter("@UOR_ID3", SqlDbType.Int, UOR_ID3);
                sql.AddParameter("@CUS_ID1", SqlDbType.Int, CUS_ID1);


                if (EST_ID1 == -1)
                    sql.AddParameter("@EST_ID1", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID1", SqlDbType.Int, EST_ID1);

                if (EST_ID2 == -1)
                    sql.AddParameter("@EST_ID2", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID2", SqlDbType.Int, EST_ID2);

                if (EST_ID3 == -1)
                    sql.AddParameter("@EST_ID3", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@EST_ID3", SqlDbType.Int, EST_ID3);

                sql.AddParameter("@MAR_ID", SqlDbType.Int, MAR_ID);
                sql.AddParameter("@MOD_ID", SqlDbType.Int, MOD_ID);
                sql.AddParameter("@ACT_SERIE1", SqlDbType.VarChar, ACT_SERIE1);

                if (COL_ID == -1)
                    sql.AddParameter("@COL_ID", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@COL_ID", SqlDbType.Int, COL_ID);

                if (ECO_ID1 == -1)
                    sql.AddParameter("@ECO_ID1", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ECO_ID1", SqlDbType.VarChar, ECO_ID1);

                if (ECO_ID2 == -1)
                    sql.AddParameter("@ECO_ID2", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ECO_ID2", SqlDbType.VarChar, ECO_ID2);

                sql.AddParameter("@PRO_ID", SqlDbType.Int, PRO_ID);
                sql.AddParameter("@ACT_NUMFACT", SqlDbType.BigInt, ACT_NUMFACT);
                sql.AddParameter("@ACT_FECHACOMPRA", SqlDbType.SmallDateTime, ACT_FECHACOMPRA);
                sql.AddParameter("@ACT_VALORCOMPRA", SqlDbType.Decimal, ACT_VALORCOMPRA);
                sql.AddParameter("@ACT_VALORRAZONABLE", SqlDbType.Decimal, ACT_VALORRAZONABLE);

                if (ACT_ANIO == -1)
                    sql.AddParameter("@ACT_ANIO", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);
                else
                    sql.AddParameter("@ACT_ANIO", SqlDbType.Int, ACT_ANIO);

                sql.AddParameter("@ACT_VALORRESIDUALNIIF", SqlDbType.Decimal, ACT_VALORRESIDUALNIIF);
                sql.AddParameter("@ACT_GARANTIA", SqlDbType.Bit, ACT_GARANTIA);

                if (!ACT_GARANTIA)
                    sql.AddParameter("@ACT_FECHAGARANTIAVENCE", SqlDbType.SmallDateTime, System.Data.SqlTypes.SqlDateTime.Null);
                else
                    sql.AddParameter("@ACT_FECHAGARANTIAVENCE", SqlDbType.SmallDateTime, ACT_FECHAGARANTIAVENCE);

                sql.AddParameter("@ACT_OBSERVACIONES", SqlDbType.VarChar, ACT_OBSERVACIONES);
                sql.AddParameter("@ACT_DESCRIPCIONLARGA", SqlDbType.VarChar, ACT_DESCRIPCIONLARGA);

                sql.AddParameter("@ACT_DEPRECIADOSRI", SqlDbType.Bit, ACT_DEPRECIADOSRI);
                sql.AddParameter("@ACT_DEPRECIADONIIF", SqlDbType.Bit, ACT_DEPRECIADONIIF);

                sql.AddParameter("@ACT_TIPRFID", SqlDbType.VarChar, ACT_TIPRFID);
                sql.AddParameter("@ACT_SEGURO", SqlDbType.VarChar, ACT_SEGURO);

                if (ACT_TIPOSEGURO != 0)
                    sql.AddParameter("@ACT_TIPOSEGURO", SqlDbType.Int, ACT_TIPOSEGURO);
                else
                    sql.AddParameter("@ACT_TIPOSEGURO", SqlDbType.Int, System.Data.SqlTypes.SqlInt32.Null);


                if (ACT_NUMPOLIZA != "")
                {
                    sql.AddParameter("@ACT_NUMPOLIZA", SqlDbType.VarChar, ACT_NUMPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_NUMPOLIZA", SqlDbType.VarChar, System.Data.SqlTypes.SqlString.Null);
                }

                if (ACT_VIGENCIAPOLIZAMESES > 0)
                {
                    sql.AddParameter("@ACT_VIGENCIAPOLIZAMESES", SqlDbType.Int, ACT_VIGENCIAPOLIZAMESES);
                }
                else
                {
                    sql.AddParameter("@ACT_VIGENCIAPOLIZAMESES", SqlDbType.Int, 0);
                }

                if (ACT_FECHAEMISIONPOLIZA != null)
                {
                    sql.AddParameter("@ACT_FECHAEMISIONPOLIZA", SqlDbType.DateTime, ACT_FECHAEMISIONPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAEMISIONPOLIZA", SqlDbType.DateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }

                if (ACT_FECHAVENCEPOLIZA != null)
                {
                    sql.AddParameter("@ACT_FECHAVENCEPOLIZA", SqlDbType.DateTime, ACT_FECHAVENCEPOLIZA);
                }
                else
                {
                    sql.AddParameter("@ACT_FECHAVENCEPOLIZA", SqlDbType.DateTime, System.Data.SqlTypes.SqlDateTime.Null);
                }

                if (ACT_VALORASEGURADO > 0)
                    sql.AddParameter("@ACT_VALORASEGURADO", SqlDbType.Decimal, ACT_VALORASEGURADO);
                else
                    sql.AddParameter("@ACT_VALORASEGURADO", SqlDbType.Decimal, 0);

                sql.AddParameter("@err", SqlDbType.VarChar, "", 350, ParameterDirection.Output);

                sql.ExecuteSP("usp_UpdateACTIVO");

                error = sql.Parameters["@err"].Value.ToString();

                return error;
            }
            catch (Exception ex)
            {
                return error + ". Sistema: " + ex.Message;
            }
        }

        public DataTable getCbPadre(string cb, string emp)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@cbp", SqlDbType.VarChar, cb);
            sql.AddParameter("@emp", SqlDbType.VarChar, emp);
            return sql.ExecuteSPDataTable("usp_GetBusCbP");
        }

        public DataTable CargaTipoActivo(string param)
        {
            Datos.SqlService sql = new Datos.SqlService();
            sql.AddParameter("@par_nombre", SqlDbType.VarChar, param);
            return sql.ExecuteSPDataTable("PARAMETROSPC01");
        }

        public DateTime calcularFechaIniDepre(DateTime fechaCompra)
        {
            DateTime fechaComienzoDepre = fechaCompra.Date;
            //fechaComienzoDepre = fechaComienzoDepre.AddDays(-fechaComienzoDepre.Day + DateTime.DaysInMonth(fechaComienzoDepre.Year, fechaComienzoDepre.Month));
            
                // Si el día es mayor a 1, obtenemos la última fecha del mes siguiente.
                int siguienteMes = fechaComienzoDepre.Month == 12 ? 1 : fechaComienzoDepre.Month + 1;
                int siguienteAnio = fechaComienzoDepre.Month == 12 ? fechaComienzoDepre.Year + 1 : fechaComienzoDepre.Year;
                int diasEnSiguienteMes = DateTime.DaysInMonth(siguienteAnio, siguienteMes);
                return new DateTime(siguienteAnio, siguienteMes, diasEnSiguienteMes);
            
            /*if (fechaComienzoDepre.Day != 1)
            {
                if (fechaComienzoDepre.Day < 16)
                {
                    while (fechaComienzoDepre.Day != 1)
                    {
                        fechaComienzoDepre = fechaComienzoDepre.AddDays(-1);
                    }
                }
                else
                {
                    while (fechaComienzoDepre.Day != 1)
                    {
                        fechaComienzoDepre = fechaComienzoDepre.AddDays(1);
                    }
                }
            }*/

            
        }
    }

    #endregion
}