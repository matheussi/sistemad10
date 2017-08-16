

namespace Entidade
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using LC.Framework.Phantom;

    [Serializable()]
    public abstract class EntityBase
    {
        public EntityBase() { }

        public static Boolean ChecaCpf(Object beneficiarioId, String cpf)
        {
            limpaCPF(ref cpf);
            return ValidaCpf(cpf);
            //if (!ValidaCpf(cpf)) { return false; } else { return true; }

            //String query = "SELECT beneficiario_id FROM beneficiario WHERE beneficiario_cpf=@CPF";
            //if (beneficiarioId != null)
            //    query += " AND beneficiario_id <> " + beneficiarioId;

            //System.Data.DataTable dt = LocatorHelper.Instance.
            //    ExecuteParametrizedQuery(query, new String[] { "@CPF" }, new String[] { cpf }).Tables[0];

            //return dt == null || dt.Rows.Count == 0;
        }

        public static Boolean ChecaCpfEmUso(Object beneficiarioId, String cpf)
        {
            limpaCPF(ref cpf);
            if (!ValidaCpf(cpf)) { return false; }

            if (cpf == "99999999999") { return false; }
            if (cpf == "11111111111") { return true; }

            String query = "SELECT ID FROM CLI_CLIENTES_CENTR WHERE CPF=@CPF";
            if (beneficiarioId != null && Convert.ToString(beneficiarioId).Trim() != "")
                query += " AND ID <> " + beneficiarioId;

            System.Data.DataTable dt = LocatorHelper.Instance.
                ExecuteParametrizedQuery(query, new String[] { "@CPF" }, new String[] { cpf }).Tables[0];

            return dt == null || dt.Rows.Count == 0;
        }

        public static bool ValidaCpf(String vrCPF)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["naoValidaDocs"] != null &&
                System.Configuration.ConfigurationManager.AppSettings["naoValidaDocs"].ToUpper() == "Y")
            {
                return true;
            }

            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");
            valor = valor.Replace("_", "");

            if (string.IsNullOrWhiteSpace(valor)) return false;

            if (valor == "11111111111") { return true; }

            if (valor.Length != 11)
                return false;

            if (valor == "99999999999") { return false; }

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }

        public static Object VerificaExistenciaCPF(String cpf)
        {
            limpaCPF(ref cpf);
            String query = "SELECT beneficiario_id FROM beneficiario WHERE beneficiario_cpf=@CPF";

            System.Data.DataTable dt = LocatorHelper.Instance.
                ExecuteParametrizedQuery(query, new String[] { "@CPF" }, new String[] { cpf }).Tables[0];

            Object beneficiarioId = new Object();

            if (dt != null && dt.Rows.Count > 0)
                beneficiarioId = dt.Rows[0].ItemArray[0];
            else
                beneficiarioId = null;

            return beneficiarioId;
        }

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

        protected static string _connString = System.Configuration.ConfigurationManager.ConnectionStrings["conn01"].ConnectionString;

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

        /// <summary>
        /// Inclui o Valor de um Campo de acordo com o seu tamanho. 
        /// </summary>
        /// <param name="SB">StringBuilder com as informações.</param>
        /// <param name="Value">Valor a ser Incluído.</param>
        /// <param name="ValueLength">Tamanho máximo do Valor a ser Incluído.</param>
        /// <returns>True se conseguiu incluir e False se não conseguir incluir.</returns>
        internal static Boolean AppendPreparedField(ref StringBuilder SB, Object Value, Int32 ValueLength)
        {
            if (SB != null && Value != null)
            {
                Value = EntityBase.RetiraAcentos(Value.ToString());

                if (Value.ToString().Length > ValueLength)
                    SB.Append(Value.ToString().Substring(0, ValueLength));
                else
                    SB.Append(Value.ToString().PadRight(ValueLength, ' '));

                return true;
            }

            return false;
        }

        #endregion

        internal static String Join(IList<String> list, String separator)
        {
            if (list == null) { return null; }

            StringBuilder sb = new StringBuilder();
            foreach (String item in list)
            {
                if (sb.Length > 0) { sb.Append(separator); }
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
