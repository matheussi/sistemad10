namespace Entidade
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using LC.Framework.Phantom;
    using System.Data;

    public class Helper
    {
        Helper() { }

        #region singleton 

        static Helper _instancia;
        public static Helper Instancia
        {
            get
            {
                if (_instancia == null) { _instancia = new Helper(); }
                return _instancia;
            }
        }
        #endregion

        public DataTable CarregarPromotores(string empresaId, PersistenceManager pm = null)
        {
            if (string.IsNullOrEmpty(empresaId)) return null;

            string cargoId = System.Configuration.ConfigurationManager.AppSettings["id_cargo_promotor"] ;

            string sql = string.Concat(
            "SELECT ID,NOME FROM CLI_USUARIOS WHERE ID_EMPRESA = ",
            empresaId, " and ID_CARGO in (", cargoId, ") order by NOME ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];
        }

        public DataTable CarregarDentistas(string empresaId, PersistenceManager pm = null)
        {
            if (string.IsNullOrEmpty(empresaId)) return null;

            string sql = string.Concat(
            "SELECT ID,NOME FROM CLI_USUARIOS WHERE MEDICO=1 AND ATIVO=1 AND ID_EMPRESA = ",
            empresaId, " order by NOME ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];
        }

        public DataTable CarregarTipoIndicacao()
        {
            string sql = string.Concat(
            "SELECT * FROM CLI_COMO_CHEGOU  order by COMO_CHEGOU ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result").Tables[0];
        }

        public DataTable CarregarEspecialidades(PersistenceManager pm = null)
        {
            string sql = string.Concat(
            "SELECT ID, TIPO_CLIENTE as NOME FROM CLI_TIPO_CLIENTE order by TIPO_CLIENTE ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];
        }

        public DataTable CarregarTipos(PersistenceManager pm = null)
        {
            string sql = string.Concat(
            "SELECT ID, TIPO_MOVIMENTO as NOME FROM CLI_TIPOMOVIMENTO WHERE ativo=1 and ID <> 2 order by TIPO_MOVIMENTO ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];
        }

        public DataTable CarregarFormasPagamento(PersistenceManager pm = null)
        {
            string sql = string.Concat(
            "SELECT ID, FORMA_PAGAMENTO as NOME FROM CLI_FORMA_PAGAMENTO WHERE ativo=1 order by ORDEM ");

            return LocatorHelper.Instance.ExecuteQuery(sql, "result", pm).Tables[0];
        }
    }
}
