//using Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LC.Framework.Phantom;

namespace Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente.importarClientes();// cli = new Cliente();
            //cli.importarClientes();
            MessageBox.Show("OK");
        }
    }

    [DBTable("_mapp")]
    public class Mapp : IPersisteableEntity
    {
        [DBFieldInfo("map_id", FieldType.PrimaryKeyAndIdentity)]
        public object ID { get; set; }
        [DBFieldInfo("map_newId", FieldType.Single)]
        public int idNEW { get; set; }
        [DBFieldInfo("map_oldId", FieldType.Single)]
        public int idOLD { get; set; }
        [DBFieldInfo("map_tipo", FieldType.Single)]
        public int TIPO { get; set; }
    }

    [DBTable("CLI_CLIENTES_CENTR")]
    public class Cliente : IPersisteableEntity
    {
        public Cliente() { }

        //public static DateTime ToDateTime(Object param)
        //{
        //    if (param == null || param == DBNull.Value || Convert.ToString(param).Trim() == "")
        //    {
        //        return DateTime.MinValue;
        //    }
        //    else
        //    {
        //        return Convert.ToDateTime(param, new System.Globalization.CultureInfo("pt-Br"));
        //    }
        //}
        //public static String CToString(Object param)
        //{
        //    if (param == null || param == DBNull.Value)
        //        return String.Empty;
        //    else
        //        return Convert.ToString(param);
        //}
        //public static Decimal CToDecimal(Object param)
        //{
        //    if (param == null || param == DBNull.Value)
        //        return Decimal.Zero;
        //    else
        //        return Convert.ToDecimal(param, new System.Globalization.CultureInfo("pt-Br"));
        //}
        //public static bool CToBool(Object param)
        //{
        //    if (param == null || param == DBNull.Value)
        //        return false;
        //    else if (Convert.ToString(param).Trim() == "1")
        //        return true;
        //    else if (Convert.ToString(param).Trim() == "0")
        //        return false;
        //    else
        //    {
        //        try
        //        {
        //            return Convert.ToBoolean(param);
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}
        //public static int CToInt(Object param)
        //{
        //    if (param == null || param == DBNull.Value)
        //        return 0;
        //    else
        //    {
        //        try
        //        {
        //            return Convert.ToInt32(param);
        //        }
        //        catch
        //        {
        //            return 0;
        //        }
        //    }
        //}

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        [DBFieldInfo("ID_CLINICO_Old", FieldType.Single)]
        public int ID_CLINICO_Old
        {
            get;
            set;
        }

        [DBFieldInfo("ID_ENDO_Old", FieldType.Single)]
        public int ID_ENDO_Old
        {
            get;
            set;
        }

        [DBFieldInfo("ID_ORTO_Old", FieldType.Single)]
        public int ID_ORTO_Old
        {
            get;
            set;
        }

        [DBFieldInfo("ID_CIRURGIA_Old", FieldType.Single)]
        public int ID_CIRURGIA_Old
        {
            get;
            set;
        }

        [DBFieldInfo("ID_PEDIATRIA_Old", FieldType.Single)]
        public int ID_PEDIATRIA_Old
        {
            get;
            set;
        }

        [DBFieldInfo("TABELA_ORIGEM", FieldType.Single)]
        public string TABELA_ORIGEM
        {
            get;
            set;
        }

        [DBFieldInfo("NOME", FieldType.Single)]
        public string NOME
        {
            get;
            set;
        }

        [DBFieldInfo("CPF", FieldType.Single)]
        public string CPF
        {
            get;
            set;
        }

        [DBFieldInfo("EMAIL", FieldType.Single)]
        public string EMAIL
        {
            get;
            set;
        }

        [DBFieldInfo("NASCIMENTO", FieldType.Single)]
        public DateTime NASCIMENTO
        {
            get;
            set;
        }

        [DBFieldInfo("SENHA", FieldType.Single)]
        public string SENHA
        {
            get;
            set;
        }

        [DBFieldInfo("ATIVO", FieldType.Single)]
        public bool ATIVO
        {
            get;
            set;
        }

        [DBFieldInfo("ENDERECO", FieldType.Single)]
        public string ENDERECO
        {
            get;
            set;
        }

        [DBFieldInfo("NUMERO", FieldType.Single)]
        public string NUMERO
        {
            get;
            set;
        }

        [DBFieldInfo("COMPLEMENTO", FieldType.Single)]
        public string COMPLEMENTO
        {
            get;
            set;
        }

        [DBFieldInfo("CEP", FieldType.Single)]
        public string CEP
        {
            get;
            set;
        }

        [DBFieldInfo("CIDADE", FieldType.Single)]
        public string CIDADE
        {
            get;
            set;
        }

        [DBFieldInfo("BAIRRO", FieldType.Single)]
        public string BAIRRO
        {
            get;
            set;
        }

        [DBFieldInfo("ESTADO", FieldType.Single)]
        public string ESTADO
        {
            get;
            set;
        }

        [DBFieldInfo("DDD_F", FieldType.Single)]
        public string DDD_F
        {
            get;
            set;
        }

        [DBFieldInfo("TEL_FIXO", FieldType.Single)]
        public string TEL_FIXO
        {
            get;
            set;
        }

        [DBFieldInfo("CELULAR", FieldType.Single)]
        public string CELULAR
        {
            get;
            set;
        }

        [DBFieldInfo("DDD_C", FieldType.Single)]
        public string DDD_C
        {
            get;
            set;
        }

        [DBFieldInfo("PONTO_REFERENCIA", FieldType.Single)]
        public string PONTO_REFERENCIA
        {
            get;
            set;
        }

        [DBFieldInfo("DT_CRIACAO", FieldType.Single)]
        public DateTime DT_CRIACAO
        {
            get;
            set;
        }

        [DBFieldInfo("DT_ALTERACAO", FieldType.Single)]
        public DateTime DT_ALTERACAO
        {
            get;
            set;
        }

        [DBFieldInfo("ID_OPERADORA", FieldType.Single)]
        public int ID_OPERADORA
        {
            get;
            set;
        }

        [DBFieldInfo("ID_COMO", FieldType.Single)]
        public int ID_COMO
        {
            get;
            set;
        }

        [DBFieldInfo("ID_EMPRESA", FieldType.Single)]
        public int ID_EMPRESA
        {
            get;
            set;
        }

        [DBFieldInfo("OBS", FieldType.Single)]
        public string OBS
        {
            get;
            set;
        }

        /// <summary>
        /// Joinned
        /// </summary>
        [Joinned("DT_TRAT_CONCLUIDO")]
        public string DT_TRAT_CONCLUIDO
        {
            get;
            set;
        }

        #endregion

        public void Carregar()
        {
            //base.Carregar(this);
        }

        public static void importarClientes_v2()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                //pm.BeginTransactionContext();
                pm.UseSingleCommandInstance();

                try
                {
                    string sql = string.Concat(
                        "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES ", // where nome='THIAGO JOSE FEITAL DOS SANTOS'  //where CLI_CLIENTES.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID and imp_tipo=1 )
                        "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2  ",
                        "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3  ",
                        "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4 ",
                        "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 ",
                        "ORDER BY ID_EMPRESA,NOME,CPF");

                    DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];

                    List<string> nomes = new List<string>();
                    List<string> empresas = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (CToString(row["NOME"]).Trim() == "") continue;
                        if (!nomes.Contains(CToString(row["NOME"]).Trim())) nomes.Add(CToString(row["NOME"]).Trim());
                        if (!empresas.Contains(CToString(row["ID_EMPRESA"]))) empresas.Add(CToString(row["ID_EMPRESA"]));
                    }

                    object oaux = null;
                    Cliente cli = null;
                    Cliente cliAux = null;
                    DataRow[] rows1 = null;
                    bool localizado = false;

                    foreach (string empresa in empresas)
                    {
                        if (empresa != "4") continue;

                        foreach (string nome in nomes)
                        {
                            if (nome.Trim() == "THIAGO JOSE FEITAL DOS SANTOS") { int kkk = 0; }

                            localizado = false;
                            rows1 = dt.Select(string.Concat("NOME='", nome, "' AND ID_EMPRESA=", empresa), "DESC_TIPO");

                            if (rows1.Length == 0) continue;

                            #region fill

                            cli = new Cliente();
                            cli.ATIVO = CToBool(rows1[0]["ATIVO"]);
                            cli.BAIRRO = CToString(rows1[0]["BAIRRO"]);
                            cli.CELULAR = CToString(rows1[0]["CELULAR"]);
                            cli.CEP = CToString(rows1[0]["CEP"]);
                            cli.CIDADE = CToString(rows1[0]["CIDADE"]);
                            cli.COMPLEMENTO = CToString(rows1[0]["COMPLEMENTO"]);
                            cli.CPF = CToString(rows1[0]["CPF"]).Trim();
                            cli.DDD_C = CToString(rows1[0]["DDD_C"]);
                            cli.DDD_F = CToString(rows1[0]["DDD_F"]);
                            cli.DT_ALTERACAO = ToDateTime(rows1[0]["DT_ALTERACAO"]);
                            cli.DT_CRIACAO = ToDateTime(rows1[0]["DT_CRIACAO"]);
                            //cli.DT_TRAT_CONCLUIDO = CToString(rows1[0]["DT_TRAT_CONCLUIDO"]);
                            cli.ID_OPERADORA = CToInt(rows1[0]["ID_OPERADORA"]);
                            cli.EMAIL = CToString(rows1[0]["EMAIL"]);
                            cli.ENDERECO = CToString(rows1[0]["ENDERECO"]);
                            cli.ESTADO = CToString(rows1[0]["ESTADO"]);
                            cli.NASCIMENTO = ToDateTime(rows1[0]["NASCIMENTO"]);
                            cli.NOME = CToString(rows1[0]["NOME"]);
                            cli.NUMERO = CToString(rows1[0]["NUMERO"]);
                            cli.OBS = CToString(rows1[0]["OBS"]);
                            cli.PONTO_REFERENCIA = CToString(rows1[0]["PONTO_REFERENCIA"]);
                            cli.SENHA = CToString(rows1[0]["SENHA"]);
                            cli.TEL_FIXO = CToString(rows1[0]["TEL_FIXO"]);

                            cli.ID_EMPRESA = CToInt(empresa);

                            #endregion

                            string aux = "";
                            foreach (DataRow row in rows1)
                            {
                                localizado = false;
                                cli.ID = null;

                                if (string.IsNullOrEmpty(cli.CPF) && CToString(row["CPF"]).Trim() != "")
                                    cli.CPF = CToString(row["CPF"]).Trim();

                                aux = CToString(row["DESC_TIPO"]);

                                switch (aux)
                                {
                                    #region
                                    case "CLINICO":
                                    {
                                        #region clinico 
                                        cli.ID_CLINICO_Old = CToInt(row["ID"]);

                                        cliAux = localizaPorId(cli, pm, "1");

                                        if (cliAux != null)
                                        {
                                            localizado = true; continue;
                                        }
                                        else
                                        {
                                            localizado = false;
                                            cliAux = localiza(cli, pm, "1"); //localiza pelo cpf

                                            if (cliAux == null)
                                            {
                                                //nao achou mesmo, salva
                                                pm.Save(cli);
                                                continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_CLINICO_Old > 0)
                                                {
                                                    //ja tem um registro com id de clinico, salva um novo
                                                    pm.Save(cli);
                                                }
                                                else if (cliAux.ID_CLINICO_Old == 0) //ja existe, mas sem o id de clinico, entao salva
                                                {
                                                    cli.ID = cliAux.ID;
                                                    pm.Save(cli);
                                                }
                                            }
                                        }
                                        #endregion

                                        break;
                                    }
                                    case "ENDO":
                                    {
                                        #region endo 

                                        cli.ID_ENDO_Old = CToInt(row["ID"]);

                                        cliAux = localizaPorId(cli, pm, "2");

                                        if (cliAux != null)
                                        {
                                            localizado = true; continue;
                                        }
                                        else
                                        {
                                            localizado = false;
                                            cliAux = localiza(cli, pm, "2"); //localiza pelo cpf ou nome 

                                            if (cliAux == null)
                                            {
                                                //nao achou mesmo, salva
                                                pm.Save(cli);
                                                continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_ENDO_Old > 0)
                                                {
                                                    //ja tem um registro com id de endo, salva um novo
                                                    pm.Save(cli);
                                                }
                                                else if (cliAux.ID_ENDO_Old == 0) //ja existe, mas sem o id de endo, entao salva
                                                {
                                                    cli.ID = cliAux.ID;
                                                    pm.Save(cli);
                                                }
                                            }
                                        }
                                        #endregion

                                        break;
                                    }
                                    case "ORTO":
                                    {
                                        #region orto 

                                        cli.ID_ORTO_Old = CToInt(row["ID"]);

                                        cliAux = localizaPorId(cli, pm, "3");

                                        if (cliAux != null)
                                        {
                                            localizado = true; continue;
                                        }
                                        else
                                        {
                                            localizado = false;
                                            cliAux = localiza(cli, pm, "3"); //localiza pelo cpf ou nome 

                                            if (cliAux == null)
                                            {
                                                //nao achou mesmo, salva
                                                pm.Save(cli);
                                                continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_ORTO_Old > 0)
                                                {
                                                    //ja tem um registro com id de orto, salva um novo
                                                    pm.Save(cli);
                                                }
                                                else if (cliAux.ID_ORTO_Old == 0) //ja existe, mas sem o id de orto, entao salva
                                                {
                                                    cli.ID = cliAux.ID;
                                                    pm.Save(cli);
                                                }
                                            }
                                        }
                                        #endregion

                                        break;
                                    }
                                    case "CIRURGIA":
                                    {
                                        #region CIRURGIA 

                                        cli.ID_CIRURGIA_Old = CToInt(row["ID"]);

                                        cliAux = localizaPorId(cli, pm, "4");

                                        if (cliAux != null)
                                        {
                                            localizado = true; continue;
                                        }
                                        else
                                        {
                                            localizado = false;
                                            cliAux = localiza(cli, pm, "4"); //localiza pelo cpf ou nome 

                                            if (cliAux == null)
                                            {
                                                //nao achou mesmo, salva
                                                pm.Save(cli);
                                                continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_CIRURGIA_Old > 0)
                                                {
                                                    //ja tem um registro com id de cirurgia, salva um novo
                                                    pm.Save(cli);
                                                }
                                                else if (cliAux.ID_CIRURGIA_Old == 0) //ja existe, mas sem o id de cirurgia, entao salva
                                                {
                                                    cli.ID = cliAux.ID;
                                                    pm.Save(cli);
                                                }
                                            }
                                        }
                                        #endregion

                                        break;
                                    }
                                    case "PEDIATRIA":
                                    {
                                        #region PEDIATRIA 

                                        cli.ID_PEDIATRIA_Old = CToInt(row["ID"]);

                                        cliAux = localizaPorId(cli, pm, "5");

                                        if (cliAux != null)
                                        {
                                            localizado = true; continue;
                                        }
                                        else
                                        {
                                            localizado = false;
                                            cliAux = localiza(cli, pm, "5"); //localiza pelo cpf ou nome 

                                            if (cliAux == null)
                                            {
                                                //nao achou mesmo, salva
                                                pm.Save(cli);
                                                continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_PEDIATRIA_Old > 0)
                                                {
                                                    //ja tem um registro com id de pediatria, salva um novo
                                                    pm.Save(cli);
                                                }
                                                else if (cliAux.ID_PEDIATRIA_Old == 0) //ja existe, mas sem o id de pediatria, entao salva
                                                {
                                                    cli.ID = cliAux.ID;
                                                    pm.Save(cli);
                                                }
                                            }
                                        }
                                        #endregion

                                        break;
                                    }
                                    #endregion
                                }
                            }

                            //if (!localizado) pm.Save(cli);
                            localizado = false;
                        }
                    }

                    //pm.Commit();
                }
                catch
                {
                    //pm.Rollback();
                }
                finally
                {
                    pm.CloseSingleCommandInstance();
                    pm.Dispose();
                }
            }
        }
        public static void importarClientes_V3()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                //pm.BeginTransactionContext();
                pm.UseSingleCommandInstance();

                try
                {
                    string sql = string.Concat(
                        "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES where CLI_CLIENTES.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID and imp_tipo=1 )",
                        "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2 ",
                        "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3 ",
                        "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4 ",
                        "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 ",
                        "ORDER BY ID_EMPRESA,NOME,CPF");

                    DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];

                    //List<string> nomes = new List<string>();
                    List<string> empresas = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (CToString(row["NOME"]).Trim() == "") continue;
                        //if (!nomes.Contains(CToString(row["NOME"]).Trim()))   nomes.Add(CToString(row["NOME"]).Trim());
                        if (!empresas.Contains(CToString(row["ID_EMPRESA"]))) empresas.Add(CToString(row["ID_EMPRESA"]));
                    }

                    object oaux = null;
                    Cliente cli = null;
                    //Cliente cliAux = null;
                    //DataRow[] rows1 = null;
                    //bool localizado = false;

                    foreach (DataRow row in dt.Rows) //foreach (string nome in nomes)
                    {
                        //localizado = false;

                        //if (rows1.Length == 0) continue;

                        #region fill

                        cli = new Cliente();
                        cli.ATIVO = CToBool(row["ATIVO"]);
                        cli.BAIRRO = CToString(row["BAIRRO"]);
                        cli.CELULAR = CToString(row["CELULAR"]);
                        cli.CEP = CToString(row["CEP"]);
                        cli.CIDADE = CToString(row["CIDADE"]);
                        cli.COMPLEMENTO = CToString(row["COMPLEMENTO"]);
                        cli.CPF = CToString(row["CPF"]).Trim();
                        cli.DDD_C = CToString(row["DDD_C"]);
                        cli.DDD_F = CToString(row["DDD_F"]);
                        cli.DT_ALTERACAO = ToDateTime(row["DT_ALTERACAO"]);
                        cli.DT_CRIACAO = ToDateTime(row["DT_CRIACAO"]);
                        //cli.DT_TRAT_CONCLUIDO = CToString(row["DT_TRAT_CONCLUIDO"]);
                        cli.ID_OPERADORA = CToInt(row["ID_OPERADORA"]);
                        cli.EMAIL = CToString(row["EMAIL"]);
                        cli.ENDERECO = CToString(row["ENDERECO"]);
                        cli.ESTADO = CToString(row["ESTADO"]);
                        cli.NASCIMENTO = ToDateTime(row["NASCIMENTO"]);
                        cli.NOME = CToString(row["NOME"]);
                        cli.NUMERO = CToString(row["NUMERO"]);
                        cli.OBS = CToString(row["OBS"]);
                        cli.PONTO_REFERENCIA = CToString(row["PONTO_REFERENCIA"]);
                        cli.SENHA = CToString(row["SENHA"]);
                        cli.TEL_FIXO = CToString(row["TEL_FIXO"]);

                        cli.ID_EMPRESA = CToInt(row["ID_EMPRESA"]);

                        #endregion

                        string aux = "";
                        if (string.IsNullOrEmpty(cli.CPF) && CToString(row["CPF"]).Trim() != "")
                            cli.CPF = CToString(row["CPF"]).Trim();

                        aux = CToString(row["DESC_TIPO"]);
                        switch (aux)
                        {
                            #region
                            case "CLINICO":
                            {
                                cli.ID_CLINICO_Old = CToInt(row["ID"]);

                                oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CLINICO_Old, " and imp_tipo=1"), null, null, pm);
                                if (oaux == null || oaux == DBNull.Value)
                                {
                                    pm.Save(cli);
                                    NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 1)", pm);
                                }

                                break;
                            }
                            case "ENDO":
                            {
                                cli.ID_ENDO_Old = CToInt(row["ID"]);

                                oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ENDO_Old, " and imp_tipo=2"), null, null, pm);
                                if (oaux == null || oaux == DBNull.Value)
                                {
                                    pm.Save(cli);
                                    NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 2)", pm);
                                }

                                break;
                            }
                            case "ORTO":
                            {
                                cli.ID_ORTO_Old = CToInt(row["ID"]);

                                oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ORTO_Old, " and imp_tipo=3"), null, null, pm);
                                if (oaux == null || oaux == DBNull.Value)
                                {
                                    pm.Save(cli);
                                    NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 3)", pm);
                                }

                                break;
                            }
                            case "CIRURGIA":
                            {
                                cli.ID_CIRURGIA_Old = CToInt(row["ID"]);

                                oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CIRURGIA_Old, " and imp_tipo=4"), null, null, pm);
                                if (oaux == null || oaux == DBNull.Value)
                                {
                                    pm.Save(cli);
                                    NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 4)", pm);
                                }

                                break;
                            }
                            case "PEDIATRIA":
                            {
                                cli.ID_PEDIATRIA_Old = CToInt(row["ID"]);

                                oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_PEDIATRIA_Old, " and imp_tipo=5"), null, null, pm);
                                if (oaux == null || oaux == DBNull.Value)
                                {
                                    pm.Save(cli);
                                    NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 5)", pm);
                                }

                                break;
                            }
                            #endregion
                        }
                    }

                    //pm.Commit();
                }
                catch
                {
                    //pm.Rollback();
                }
                finally
                {
                    pm.CloseSingleCommandInstance();

                }
            }
        }
        public static void importarClientes_V1()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.BeginTransactionContext();

                try
                {
                    string sql = string.Concat(
                        "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES where CLI_CLIENTES.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID and imp_tipo=1 )",
                        "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2 ",
                        "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3 ",
                        "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4 ",
                        "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 ",
                        "ORDER BY ID_EMPRESA,NOME,CPF");

                    //sql = string.Concat(
                    //    "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES WHERE NOME='ZILDA FERRAZ CONTILDE' ",
                    //    "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2 WHERE NOME='ZILDA FERRAZ CONTILDE' ",
                    //    "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3 WHERE NOME='ZILDA FERRAZ CONTILDE' ",
                    //    "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4 WHERE NOME='ZILDA FERRAZ CONTILDE' ",
                    //    "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 WHERE NOME='ZILDA FERRAZ CONTILDE' ",
                    //    "ORDER BY ID_EMPRESA,NOME,CPF");

                    DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];

                    List<string> nomes = new List<string>();
                    List<string> empresas = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (CToString(row["NOME"]).Trim() == "") continue;
                        if (!nomes.Contains(CToString(row["NOME"]).Trim())) nomes.Add(CToString(row["NOME"]).Trim());
                        if (!empresas.Contains(CToString(row["ID_EMPRESA"]))) empresas.Add(CToString(row["ID_EMPRESA"]));
                    }

                    object oaux = null;
                    Cliente cli = null;
                    Cliente cliAux = null;
                    DataRow[] rows1 = null;
                    bool localizado = false;

                    foreach (string empresa in empresas)
                    {
                        foreach (string nome in nomes)
                        {
                            localizado = false;
                            rows1 = dt.Select(string.Concat("NOME='", nome, "' AND ID_EMPRESA=", empresa), "DESC_TIPO");

                            if (rows1.Length == 0) continue;

                            #region fill  

                            cli = new Cliente();
                            cli.ATIVO = CToBool(rows1[0]["ATIVO"]);
                            cli.BAIRRO = CToString(rows1[0]["BAIRRO"]);
                            cli.CELULAR = CToString(rows1[0]["CELULAR"]);
                            cli.CEP = CToString(rows1[0]["CEP"]);
                            cli.CIDADE = CToString(rows1[0]["CIDADE"]);
                            cli.COMPLEMENTO = CToString(rows1[0]["COMPLEMENTO"]);
                            cli.CPF = CToString(rows1[0]["CPF"]).Trim();
                            cli.DDD_C = CToString(rows1[0]["DDD_C"]);
                            cli.DDD_F = CToString(rows1[0]["DDD_F"]);
                            cli.DT_ALTERACAO = ToDateTime(rows1[0]["DT_ALTERACAO"]);
                            cli.DT_CRIACAO = ToDateTime(rows1[0]["DT_CRIACAO"]);
                            //cli.DT_TRAT_CONCLUIDO = CToString(rows1[0]["DT_TRAT_CONCLUIDO"]);
                            cli.ID_OPERADORA = CToInt(rows1[0]["ID_OPERADORA"]);
                            cli.EMAIL = CToString(rows1[0]["EMAIL"]);
                            cli.ENDERECO = CToString(rows1[0]["ENDERECO"]);
                            cli.ESTADO = CToString(rows1[0]["ESTADO"]);
                            cli.NASCIMENTO = ToDateTime(rows1[0]["NASCIMENTO"]);
                            cli.NOME = CToString(rows1[0]["NOME"]);
                            cli.NUMERO = CToString(rows1[0]["NUMERO"]);
                            cli.OBS = CToString(rows1[0]["OBS"]);
                            cli.PONTO_REFERENCIA = CToString(rows1[0]["PONTO_REFERENCIA"]);
                            cli.SENHA = CToString(rows1[0]["SENHA"]);
                            cli.TEL_FIXO = CToString(rows1[0]["TEL_FIXO"]);

                            cli.ID_EMPRESA = CToInt(empresa);

                            if (cli.NOME == "YASMIM BARROS OLIVEIRA")
                            {
                                int k = 0;
                            }

                            #endregion

                            string aux = "";
                            foreach (DataRow row in rows1)
                            {
                                if (string.IsNullOrEmpty(cli.CPF) && CToString(row["CPF"]).Trim() != "")
                                    cli.CPF = CToString(row["CPF"]).Trim();

                                aux = CToString(row["DESC_TIPO"]);
                                switch (aux)
                                {
                                    #region
                                    case "CLINICO":
                                    {
                                        cli.ID_CLINICO_Old = CToInt(row["ID"]);

                                        oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CLINICO_Old, " and imp_tipo=1"), null, null, pm);
                                        if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                        {
                                            cliAux = localiza(cli, pm, "1");

                                            if (cliAux == null)
                                            {
                                                localizado = true; continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_CLINICO_Old > 0)
                                                {
                                                    localizado = true; continue;
                                                }
                                                else
                                                {
                                                    //cli.ID = cliAux.ID; //para dar upadate no existente
                                                    //localizado = false;
                                                    localizado = true; continue;
                                                }
                                            }
                                        }

                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 1)", pm);
                                        break;
                                    }
                                    case "ENDO":
                                    {
                                        cli.ID_ENDO_Old = CToInt(row["ID"]);

                                        oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ENDO_Old, " and imp_tipo=2"), null, null, pm);
                                        if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                        {
                                            cliAux = localiza(cli, pm, "2");

                                            if (cliAux == null)
                                            {
                                                localizado = true; continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_ENDO_Old > 0)
                                                {
                                                    localizado = true; continue;
                                                }
                                                else
                                                {
                                                    //cli.ID = cliAux.ID; //para dar upadate no existente
                                                    //localizado = false;
                                                    localizado = true; continue;
                                                }
                                            }
                                        }

                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 2)", pm);
                                        break;
                                    }
                                    case "ORTO":
                                    {
                                        cli.ID_ORTO_Old = CToInt(row["ID"]);

                                        oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ORTO_Old, " and imp_tipo=3"), null, null, pm);
                                        if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                        {
                                            cliAux = localiza(cli, pm, "3");

                                            if (cliAux == null)
                                            {
                                                localizado = true; continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_ORTO_Old > 0)
                                                {
                                                    localizado = true; continue;
                                                }
                                                else
                                                {
                                                    //cli.ID = cliAux.ID; //para dar upadate no existente
                                                    //localizado = false;
                                                    localizado = true; continue;
                                                }
                                            }
                                        }

                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 3)", pm);
                                        break;
                                    }
                                    case "CIRURGIA":
                                    {
                                        cli.ID_CIRURGIA_Old = CToInt(row["ID"]);

                                        oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CIRURGIA_Old, " and imp_tipo=4"), null, null, pm);
                                        if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                        {
                                            cliAux = localiza(cli, pm, "4");

                                            if (cliAux == null)
                                            {
                                                localizado = true; continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_CIRURGIA_Old > 0)
                                                {
                                                    localizado = true; continue;
                                                }
                                                else
                                                {
                                                    //cli.ID = cliAux.ID; //para dar upadate no existente
                                                    //localizado = false;
                                                    localizado = true; continue;
                                                }
                                            }
                                        }

                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 4)", pm);
                                        break;
                                    }
                                    case "PEDIATRIA":
                                    {
                                        cli.ID_PEDIATRIA_Old = CToInt(row["ID"]);

                                        oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_PEDIATRIA_Old, " and imp_tipo=5"), null, null, pm);
                                        if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                        {
                                            cliAux = localiza(cli, pm, "5");

                                            if (cliAux == null)
                                            {
                                                localizado = true; continue;
                                            }
                                            else
                                            {
                                                if (cliAux.ID_PEDIATRIA_Old > 0)
                                                {
                                                    localizado = true; continue;
                                                }
                                                else
                                                {
                                                    //cli.ID = cliAux.ID; //para dar upadate no existente
                                                    //localizado = false;
                                                    localizado = true; continue;
                                                }
                                            }
                                        }

                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 5)", pm);
                                        break;
                                    }
                                    #endregion
                                }
                            }

                            if(!localizado) pm.Save(cli);
                            localizado = false;
                        }
                    }

                    pm.Commit();
                }
                catch
                {
                    pm.Rollback();
                }
            }
        }

        public static void importarClientes()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                //pm.BeginTransactionContext();
                pm.UseSingleCommandInstance();

                try
                {
                    string sql = string.Concat(
                        "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES          where  CLI_CLIENTES.ID  NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID  and imp_tipo=1 ) and id_empresa in (2,5) ", //where CLI_CLIENTES.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID and imp_tipo=1 )
                        "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2      where  CLI_CLIENTES2.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES2.ID and imp_tipo=2 ) and id_empresa in (2,5) ",
                        "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3      where  CLI_CLIENTES3.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES3.ID and imp_tipo=3 ) and id_empresa in (2,5) ",
                        "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4  where  CLI_CLIENTES4.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES4.ID and imp_tipo=4 ) and id_empresa in (2,5) ",
                        "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 where  CLI_CLIENTES5.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES5.ID and imp_tipo=5 ) and id_empresa in (2,5) ",
                        "ORDER BY ID_EMPRESA,NOME,CPF");

                    //sql = string.Concat(
                    //    "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES          where CLI_CLIENTES.ID  NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID  and imp_tipo=1 ) and  id_empresa=3 ", //where CLI_CLIENTES.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES.ID and imp_tipo=1 )
                    //    "UNION SELECT *,2 AS TIPO,'ENDO' AS DESC_TIPO FROM CLI_CLIENTES2      where CLI_CLIENTES2.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES2.ID and imp_tipo=2 ) and id_empresa=3  ",
                    //    "UNION SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3      where CLI_CLIENTES3.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES3.ID and imp_tipo=3 )  and id_empresa=3  ",
                    //    "UNION SELECT *,4 AS TIPO,'CIRURGIA' AS DESC_TIPO FROM CLI_CLIENTES4  where CLI_CLIENTES4.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES4.ID and imp_tipo=4 )  and id_empresa=3  ",
                    //    "UNION SELECT *,5 AS TIPO,'PEDIATRIA' AS DESC_TIPO FROM CLI_CLIENTES5 where CLI_CLIENTES5.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES5.ID and imp_tipo=5 )  and id_empresa=3  ",
                    //    "ORDER BY ID_EMPRESA,NOME,CPF");

                    //sql = string.Concat(
                    //    "SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3 where id = 6475",
                    //    "ORDER BY ID_EMPRESA,NOME,CPF");

                    //sql = string.Concat(
                    //    "SELECT *,3 AS TIPO,'ORTO' AS DESC_TIPO FROM CLI_CLIENTES3      where  CLI_CLIENTES3.ID NOT IN (select imp_cliid from importacao where imp_cliid=CLI_CLIENTES3.ID and imp_tipo=3 ) and id_empresa=3 and id=7098  ",
                    //    "ORDER BY ID_EMPRESA,NOME,CPF");

                    DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];

                    List<string> nomes = new List<string>();
                    List<string> empresas = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        //if (CToString(row["NOME"]).Trim().ToUpper().IndexOf("THIAGO JOSE FEITAL DOS SANTOS") == -1) continue;

                        if (CToString(row["NOME"]).Trim() == "") continue;
                        if (!nomes.Contains(CToString(row["NOME"]))) nomes.Add(CToString(row["NOME"]));//if (!nomes.Contains(CToString(row["NOME"]).Trim())) nomes.Add(CToString(row["NOME"]).Trim());
                        if (!empresas.Contains(CToString(row["ID_EMPRESA"]))) empresas.Add(CToString(row["ID_EMPRESA"]));
                    }

                    Mapp map = null;
                    object oaux = null;
                    Cliente cli = null;
                    Cliente cliAux = null;
                    DataRow[] rows1 = null;
                    //bool localizado = false;
                    int count = 0;

                    foreach (string empresa in empresas)
                    {
                        if (empresa != "2" && empresa != "5") continue; //1 = taquara; 6 = nova iguacu; 3 = campo grande; 4 = madureira

                        foreach (string nome in nomes)
                        {
                            count++;
                            //localizado = false;
                            rows1 = dt.Select(string.Concat("NOME='", nome, "' AND ID_EMPRESA=", empresa), "DESC_TIPO");

                            if (rows1.Length == 0) continue;

                            string aux = "";
                            foreach (DataRow row in rows1)
                            {
                                #region fill

                                cli = new Cliente();
                                cli.ATIVO = CToBool(rows1[0]["ATIVO"]);
                                cli.BAIRRO = CToString(rows1[0]["BAIRRO"]);
                                cli.CELULAR = CToString(rows1[0]["CELULAR"]);
                                cli.CEP = CToString(rows1[0]["CEP"]);
                                cli.CIDADE = CToString(rows1[0]["CIDADE"]);
                                cli.COMPLEMENTO = CToString(rows1[0]["COMPLEMENTO"]);
                                cli.CPF = CToString(rows1[0]["CPF"]).Trim();
                                cli.DDD_C = CToString(rows1[0]["DDD_C"]);
                                cli.DDD_F = CToString(rows1[0]["DDD_F"]);
                                cli.DT_ALTERACAO = ToDateTime(rows1[0]["DT_ALTERACAO"]);
                                cli.DT_CRIACAO = ToDateTime(rows1[0]["DT_CRIACAO"]);
                                //cli.DT_TRAT_CONCLUIDO = CToString(rows1[0]["DT_TRAT_CONCLUIDO"]);
                                cli.ID_OPERADORA = CToInt(rows1[0]["ID_OPERADORA"]);
                                cli.EMAIL = CToString(rows1[0]["EMAIL"]);
                                cli.ENDERECO = CToString(rows1[0]["ENDERECO"]);
                                cli.ESTADO = CToString(rows1[0]["ESTADO"]);
                                cli.NASCIMENTO = ToDateTime(rows1[0]["NASCIMENTO"]);
                                cli.NOME = CToString(rows1[0]["NOME"]);
                                cli.NUMERO = CToString(rows1[0]["NUMERO"]);
                                cli.OBS = CToString(rows1[0]["OBS"]);
                                cli.PONTO_REFERENCIA = CToString(rows1[0]["PONTO_REFERENCIA"]);
                                cli.SENHA = CToString(rows1[0]["SENHA"]);
                                cli.TEL_FIXO = CToString(rows1[0]["TEL_FIXO"]);

                                cli.ID_EMPRESA = CToInt(empresa);

                                //if (cli.NOME == "YASMIM BARROS OLIVEIRA")
                                //{
                                //    int k = 0;
                                //}

                                #endregion

                                aux = CToString(row["DESC_TIPO"]);
                                switch (aux)
                                {
                                    #region
                                    case "CLINICO":
                                        {
                                            cli.ID_CLINICO_Old = CToInt(row["ID"]);

                                            oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CLINICO_Old, " and imp_tipo=1"), null, null, pm);
                                            if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                            {
                                                continue; //ja importou
                                            }

                                            NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 1)", pm);

                                            cliAux = localiza(cli, pm, "1");
                                            if (cliAux != null) { cli.ID = cliAux.ID; }
                                            else { pm.Save(cli); }

                                            map = new Mapp();
                                            map.idNEW = Convert.ToInt32(cli.ID);
                                            map.idOLD = Convert.ToInt32(row["ID"]);
                                            map.TIPO = 1;
                                            pm.Save(map);

                                            break;
                                        }
                                    case "ENDO":
                                        {
                                            cli.ID_ENDO_Old = CToInt(row["ID"]);

                                            oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ENDO_Old, " and imp_tipo=2"), null, null, pm);
                                            if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                            {
                                                continue;
                                            }

                                            NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 2)", pm);

                                            cliAux = localiza(cli, pm, "2");
                                            if (cliAux != null) { cli.ID = cliAux.ID; }
                                            else { pm.Save(cli); }

                                            map = new Mapp();
                                            map.idNEW = Convert.ToInt32(cli.ID);
                                            map.idOLD = Convert.ToInt32(row["ID"]);
                                            map.TIPO = 2;
                                            pm.Save(map);

                                            break;
                                        }
                                    case "ORTO":
                                        {
                                            cli.ID_ORTO_Old = CToInt(row["ID"]);

                                            oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_ORTO_Old, " and imp_tipo=3"), null, null, pm);
                                            if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                            {
                                                continue;
                                            }

                                            NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 3)", pm);

                                            cliAux = localiza(cli, pm, "3");
                                            if (cliAux != null) { cli.ID = cliAux.ID; }
                                            else { pm.Save(cli); }

                                            map = new Mapp();
                                            map.idNEW = Convert.ToInt32(cli.ID);
                                            map.idOLD = Convert.ToInt32(row["ID"]);
                                            map.TIPO = 3;
                                            pm.Save(map);
                                            break;
                                        }
                                    case "CIRURGIA":
                                        {
                                            cli.ID_CIRURGIA_Old = CToInt(row["ID"]);

                                            oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_CIRURGIA_Old, " and imp_tipo=4"), null, null, pm);
                                            if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                            {
                                                continue;
                                            }

                                            NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 4)", pm);

                                            cliAux = localiza(cli, pm, "4");
                                            if (cliAux != null) { cli.ID = cliAux.ID; }
                                            else { pm.Save(cli); }

                                            map = new Mapp();
                                            map.idNEW = Convert.ToInt32(cli.ID);
                                            map.idOLD = Convert.ToInt32(row["ID"]);
                                            map.TIPO = 4;
                                            pm.Save(map);

                                            break;
                                        }
                                    case "PEDIATRIA":
                                        {
                                            cli.ID_PEDIATRIA_Old = CToInt(row["ID"]);

                                            oaux = LocatorHelper.Instance.ExecuteScalar(string.Concat("select imp_id from importacao where imp_cliid=", cli.ID_PEDIATRIA_Old, " and imp_tipo=5"), null, null, pm);
                                            if (oaux != null && oaux != DBNull.Value && Convert.ToInt32(oaux) > 0)
                                            {
                                                continue;
                                            }

                                            NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 5)", pm);

                                            cliAux = localiza(cli, pm, "5");
                                            if (cliAux != null) { cli.ID = cliAux.ID; }
                                            else { pm.Save(cli); }

                                            map = new Mapp();
                                            map.idNEW = Convert.ToInt32(cli.ID);
                                            map.idOLD = Convert.ToInt32(row["ID"]);
                                            map.TIPO = 5;
                                            pm.Save(map);

                                            break;
                                        }
                                    #endregion
                                }
                            }

                            //lbl.Text = string.Concat(count.ToString(), " de ", nomes.Count.ToString());
                            //Application.DoEvents();
                        }
                    }
                    //pm.Commit();
                }
                catch
                {
                    //pm.Rollback();
                }
                finally
                {
                    pm.CloseSingleCommandInstance();
                    pm.Dispose();
                }
            }
        }

        /// <summary>
        /// Localiza por nome
        /// </summary>
        static Cliente localiza(Cliente cli, PersistenceManager pm, string tipo)
        {
            IList<Cliente> ret = null;

            /*if (!string.IsNullOrEmpty(cli.CPF) && cli.CPF.Trim().Length > 7)
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                     string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where cpf='", cli.CPF, "'"),
                     typeof(Cliente), pm);
            }
            else*/ if (!string.IsNullOrEmpty(cli.NOME) && cli.NOME.Trim().Length > 7)
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                     string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where NOME='", cli.NOME, "' and ID_EMPRESA=", cli.ID_EMPRESA),
                     typeof(Cliente), pm);
            }
            else
                return null;

            if (ret != null && ret.Count > 0)
                return ret[0];
            else
                return null;
        }

        static Cliente localizaPorId(Cliente cli, PersistenceManager pm, string tipo)
        {
            IList<Cliente> ret = null;

            if (tipo == "1") 
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                    string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where ID_CLINICO_Old=", cli.ID_CLINICO_Old, " and ID_EMPRESA=", cli.ID_EMPRESA),
                    typeof(Cliente), pm);
            }
            else if (tipo == "2")
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                    string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where ID_ENDO_Old=", cli.ID_ENDO_Old, " and ID_EMPRESA=", cli.ID_EMPRESA),
                    typeof(Cliente), pm);
            }
            else if (tipo == "3")
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                    string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where ID_ORTO_Old=", cli.ID_ORTO_Old, " and ID_EMPRESA=", cli.ID_EMPRESA),
                    typeof(Cliente), pm);
            }
            else if (tipo == "4")
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                    string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where ID_CIRURGIA_Old=", cli.ID_CIRURGIA_Old, " and ID_EMPRESA=", cli.ID_EMPRESA),
                    typeof(Cliente), pm);
            }
            else if (tipo == "5")
            {
                ret = LocatorHelper.Instance.ExecuteQuery<Cliente>(
                    string.Concat("select ID,NOME,CPF,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old from CLI_CLIENTES_CENTR where ID_PEDIATRIA_Old=", cli.ID_PEDIATRIA_Old, " and ID_EMPRESA=", cli.ID_EMPRESA),
                    typeof(Cliente), pm);
            }
            else
                return null;

            if (ret != null && ret.Count > 0)
                return ret[0];
            else
                return null;
        }

        #region metodos entitybase


        static void limpaCPF(ref String cpf)
        {
            if (!String.IsNullOrEmpty(cpf))
            {
                cpf = cpf.Replace("_", "");
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");
            }
        }

        protected static readonly String DateFormat = "yyyy-MM-dd";
        protected static readonly String DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static DateTime ToDateTime(Object param)
        {
            if (param == null || param == DBNull.Value || Convert.ToString(param).Trim() == "")
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(param, new System.Globalization.CultureInfo("pt-Br"));
            }
        }
        public static String CToString(Object param)
        {
            if (param == null || param == DBNull.Value)
                return String.Empty;
            else
                return Convert.ToString(param);
        }
        public static Decimal CToDecimal(Object param)
        {
            if (param == null || param == DBNull.Value)
                return Decimal.Zero;
            else
                return Convert.ToDecimal(param, new System.Globalization.CultureInfo("pt-Br"));
        }
        public static bool CToBool(Object param)
        {
            if (param == null || param == DBNull.Value)
                return false;
            else if (Convert.ToString(param).Trim() == "1")
                return true;
            else if (Convert.ToString(param).Trim() == "0")
                return false;
            else
            {
                try
                {
                    return Convert.ToBoolean(param);
                }
                catch
                {
                    return false;
                }
            }
        }
        public static int CToInt(Object param)
        {
            if (param == null || param == DBNull.Value)
                return 0;
            else
            {
                try
                {
                    return Convert.ToInt32(param);
                }
                catch
                {
                    return 0;
                }
            }
        }

        protected void Salvar(IPersisteableEntity entity)
        {
            PersistenceManager pm = new PersistenceManager();
            pm.Save(entity);
            pm = null;
        }
        protected void Remover(IPersisteableEntity entity)
        {
            PersistenceManager pm = new PersistenceManager();
            pm.Remove(entity);
            pm = null;
        }
        protected void Carregar(IPersisteableEntity entity)
        {
            PersistenceManager pm = new PersistenceManager();
            pm.Load(entity);
            pm = null;
        }

        protected String FormataTelefone(String fone)
        {
            if (String.IsNullOrEmpty(fone)) { return fone; }

            fone = fone.Replace("(", "").Replace(")", "").Replace(" ", ""); ;

            try
            {
                if (fone.Length == 10)
                {
                    return String.Format("{0:(##) ####-####}", Convert.ToDouble(fone));
                }
                else if (fone.Length == 8)
                {
                    return String.Format("{0: ####-####}", Convert.ToDouble(fone));
                }
                else
                    return fone;
            }
            catch
            {
                return String.Empty;
            }
        }

        protected String ToLower(String param)
        {
            if (param == null)
                return null;
            else
                return param.ToLower();
        }

        public static String GeraNumeroDeContrato(Int32 numero, Int32 qtdZerosEsquerda, String letra)
        {
            String _numero = Convert.ToString(numero);

            if (qtdZerosEsquerda > 0)
            {
                String mascara = new String('0', qtdZerosEsquerda);
                _numero = String.Format("{0:" + mascara + "}", numero);
            }

            if (!String.IsNullOrEmpty(letra))
                _numero = letra + _numero;

            return _numero;
        }

        public static String PrimeiraPosicaoELetra(String param)
        {
            if (String.IsNullOrEmpty(param)) { return ""; }

            String pos1 = param.Substring(0, 1);

            if (pos1 != "0" && pos1 != "1" && pos1 != "2" && pos1 != "3" && pos1 != "4" &&
                pos1 != "5" && pos1 != "6" && pos1 != "7" && pos1 != "8" && pos1 != "9")
            {
                return param.Substring(0, 1);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Método para Retirar a acentuação de um texto.
        /// </summary>
        /// <param name="Texto">Texto a ser modificado.</param>
        /// <returns>Texto sem acentuação.</returns>
        public static String RetiraAcentos(String Texto)
        {
            if (String.IsNullOrEmpty(Texto)) { return Texto; }
            String comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            String semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
                Texto = Texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());

            return Texto.Replace("'", "");
        }

        #region AppendPreparedField

        #endregion


        #endregion
    }
}
