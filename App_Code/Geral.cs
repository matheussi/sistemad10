﻿using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using Entidade;

    /// <summary>
    /// Summary description for Geral
    /// </summary>
    public class SecureQueryString
    {
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        string sEncryptionKey = "#R3@2o16";

        public string Decrypt(string stringToDecrypt)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                    des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Encrypt(string stringToEncrypt)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                    des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    public class Geral
    {
        public delegate void GenericMessage();

        /// <summary>
        /// Registra blocos de script javascript na página.
        /// </summary>
        public static void JSScript(Page page, string script)
        {
            JSScript(page, "_scr", script);
        }

        /// <summary>
        /// Registra blocos de script javascript na página.
        /// </summary>
        public static void JSScript(Page page, string key, string script)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), key, script, true);
        }

        public static void JSScriptResizeIFrame(Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "resize", "window.parent.resizeIframe2();", true);
        }

        //-------------------------------------------------------------------------

        public static T ObterDataKeyValDoGrid<T>(GridView grid, GridViewCommandEventArgs e, int indice)
        {
            if (grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value == null) return default(T);

            object val = null;

            if (e != null)
                val = grid.DataKeys[Convert.ToInt32(e.CommandArgument)][indice];
            else
                val = grid.DataKeys[indice].Value;

            return CTipos.CTipo<T>(val);
        }

        public static void grid_RowDataBound_Confirmacao(Object sender, GridViewRowEventArgs e, int indiceControle, String Msg)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[indiceControle].Attributes.Add("onClick", "return confirm('" + Msg + "');");
            }
        }

        public static void grid_AdicionaToolTip<T>(GridViewRowEventArgs e, int indiceCelula, int indiceControle, string toolTip) where T : WebControl
        {
            ((T)e.Row.Cells[indiceCelula].Controls[indiceControle]).ToolTip = toolTip;
        }

        //-------------------------------------------------------------------------

        public static string RetiraAcentos(String Texto)
        {
            if (String.IsNullOrEmpty(Texto)) { return Texto; }
            String comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            String semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
                Texto = Texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());

            return Texto.Replace("'", "").Replace("©", "");
        }

        public static void ExibirOpcoesDeSexo(DropDownList combo, Boolean itemSELECIONE)
        {
            combo.Items.Clear();

            if (itemSELECIONE)
                combo.Items.Add(new ListItem("Selecione", "-1"));

            combo.Items.Add(new ListItem("MASCULINO", "1"));
            combo.Items.Add(new ListItem("FEMININO", "2"));
        }

        public static String PegaDDD(String fone)
        {
            if (String.IsNullOrEmpty(fone)) { return String.Empty; }

            String[] aux = fone.Split(')');
            return aux[0].Replace("(", "").Trim();
        }
        public static String PegaTelefone(String fone)
        {
            if (String.IsNullOrEmpty(fone)) { return String.Empty; }

            String[] aux = fone.Split(')');
            if (aux.Length == 1) { return fone; }

            return aux[1].Trim();
        }

        public static String[] PegaEndereco(Page page, TextBox txtCEP, TextBox txtRua, TextBox txtBairro, TextBox txtCidade, TextBox txtUF, TextBox txtNumero)
        {
            txtRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";

            String xml = "";

            try
            {
                String url = String.Concat("http://cep.republicavirtual.com.br/web_cep.php?cep=", txtCEP.Text.Replace("-", ""), "&formato=xml");
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                System.Net.WebResponse response = request.GetResponse();

                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("ISO-8859-1"));
                xml = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                response.Close();
            }
            catch
            {
                Alerta(null, page, "_errCep0", "CEP não encontrado.\\nVerfique os dados informados e tente novamente.");
                txtCEP.Focus();
                return null;
            }

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);

            System.Xml.XmlNode root = doc.DocumentElement;
            System.Xml.XmlNode current = root.SelectSingleNode("/webservicecep/resultado");

            if (current.InnerText == "0") { Alerta(null, page, "_errCep1", "CEP não encontrado.\\nVerfique os dados informados e tente novamente."); txtCEP.Focus(); return null; }

            current = root.SelectSingleNode("/webservicecep/uf");
            txtUF.Text = current.InnerText.ToUpper();

            current = root.SelectSingleNode("/webservicecep/cidade");
            txtCidade.Text = current.InnerText;

            current = root.SelectSingleNode("/webservicecep/bairro");
            txtBairro.Text = current.InnerText;

            current = root.SelectSingleNode("/webservicecep/tipo_logradouro");
            String tipoLogradouro = current.InnerText;

            current = root.SelectSingleNode("/webservicecep/logradouro");
            String logradouro = current.InnerText;

            txtRua.Text = tipoLogradouro + " " + logradouro;
            txtNumero.Focus();

            String[] arr = new String[] { txtUF.Text, txtCidade.Text, txtBairro.Text, txtRua.Text };
            return arr;
        }

        public static void Alerta(UpdatePanel uPanel, Page page, String chave, String Mensagem)
        {
            if (uPanel != null)
            {
                ScriptManager.RegisterClientScriptBlock(
                    uPanel, page.GetType(), chave, "alert('" + Mensagem + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(
                    page, page.GetType(), chave, "alert('" + Mensagem + "');", true);
            }
        }

        public static void Alerta(UpdatePanel uPanel, Page page, String Mensagem)
        {
            if (uPanel != null)
            {
                ScriptManager.RegisterClientScriptBlock(
                    uPanel, page.GetType(), "alt", "alert('" + Mensagem + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(
                    page, page.GetType(), "alt", "alert('" + Mensagem + "');", true);
            }
        }

        public static void Alerta(Page page, String Mensagem)
        {
            if (Mensagem == null) Mensagem = "";
            Alerta(null, page, "_scr", Mensagem.Replace("'", ""));
        }

        public static Boolean ValidaEmail(String email, out String mensagem)
        {
            mensagem = "";

            if (email.Trim() == "") { return true; }

            String pattern = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";

            Regex rg = new Regex(pattern);
            Boolean result = rg.IsMatch(email);

            if (!result)
                mensagem = "E-mail inválido.";

            return result;
        }

        public static List<String> UFs()
        {
            List<String> ufs = new List<String>();

            ufs.Add("AC");
            ufs.Add("AL");
            ufs.Add("AM");
            ufs.Add("AP");
            ufs.Add("BA");
            ufs.Add("CE");
            ufs.Add("DF");
            ufs.Add("ES");
            ufs.Add("GO");
            ufs.Add("MA");
            ufs.Add("MG");
            ufs.Add("MS");
            ufs.Add("MT");
            ufs.Add("PA");
            ufs.Add("PB");
            ufs.Add("PE");
            ufs.Add("PI");
            ufs.Add("PR");
            ufs.Add("RJ");
            ufs.Add("RN");
            ufs.Add("RO");
            ufs.Add("RR");
            ufs.Add("RS");
            ufs.Add("SC");
            ufs.Add("SE");
            ufs.Add("SP");
            ufs.Add("TO");

            return ufs;
        }
        public static Boolean ValidaUF(String uf)
        {
            return UFs().Contains(uf.ToUpper());
        }

        //-------------------------------------------------------------------------

        public static long IdEnviado(HttpContext contexto, string chave)
        {
            if (contexto.Request[chave] != null && contexto.Request[chave] != "")
                return CTipos.CTipo<long>(contexto.Request[chave]);
            else
                return 0;
        }

        public static long? IdEnviadoNull(HttpContext contexto, string chave)
        {
            if (contexto.Request[chave] != null && contexto.Request[chave] != "")
                return CTipos.CTipo<long>(contexto.Request[chave]);
            else
                return null;
        }

        //public static void ConsultaCEP(string cep, TextBox txtLogradouro, TextBox txtBairro, TextBox txtCidade, TextBox txtUF)
        //{
        //    if (txtLogradouro == null) return;

        //    System.Net.WebRequest request;

        //    try
        //    {
        //        request = System.Net.WebRequest.Create("http://cloud-cep.herokuapp.com/get-cep/" + cep.Replace("-", ""));
        //    }
        //    catch
        //    {
        //        txtLogradouro.Text = "";
        //        txtBairro.Text = "";
        //        txtCidade.Text = "";
        //        txtUF.Text = "";
        //        return;
        //    }

        //    System.Net.WebResponse resp = null;
        //    System.IO.StreamReader sr = null;

        //    try
        //    {
        //        resp = request.GetResponse();
        //        sr = new System.IO.StreamReader(resp.GetResponseStream());
        //    }
        //    catch
        //    {
        //        txtLogradouro.Text = "";
        //        txtBairro.Text = "";
        //        txtCidade.Text = "";
        //        txtUF.Text = "";
        //        return;
        //    }

        //    try
        //    {
        //        Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(sr.ReadToEnd());

        //        txtLogradouro.Text = Convert.ToString(obj["Endereco"]["Tipo"]) + " " + Convert.ToString(obj["Endereco"]["Logradouro"]);
        //        txtBairro.Text = Convert.ToString(obj["Endereco"]["Bairro"]);
        //        txtCidade.Text = Convert.ToString(obj["Endereco"]["Cidade"]);
        //        txtUF.Text = Convert.ToString(obj["Endereco"]["Estado"]);
        //    }
        //    catch
        //    {
        //        txtLogradouro.Text = "";
        //        txtBairro.Text = "";
        //        txtCidade.Text = "";
        //        txtUF.Text = "";
        //    }
        //    finally
        //    {
        //        sr.Dispose();
        //        resp.Close();
        //    }
        //}

        //-------------------------------------------------------------------------

        public static string EncryptBetweenPHP(string param)
        {
            byte[] key = Encoding.UTF8.GetBytes("passwordDR0wSS@P6660juht");
            byte[] iv = Encoding.UTF8.GetBytes("password");
            byte[] data = Encoding.UTF8.GetBytes(param);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();
            tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateEncryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return Bin2Hex(enc);
        }

        public static string DecryptBetweenPHP(string Data)
        {
            byte[] key = Encoding.ASCII.GetBytes("passwordDR0wSS@P6660juht");
            byte[] iv = Encoding.ASCII.GetBytes("password");
            byte[] data = StringToByteArray(Data);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();
            tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateDecryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return Encoding.ASCII.GetString(enc);
        }

        static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        static string Bin2Hex(byte[] bin)
        {
            StringBuilder sb = new StringBuilder(bin.Length * 2);
            foreach (byte b in bin)
            {
                sb.Append(b.ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }


        public class Mail
        {
            private Mail() { }

            /// <summary>
            /// Parâmetros de e-mail hard coded
            /// </summary>
//            public static bool Enviar(string assunto, string corpo, string para, bool html, out string erro)
//            {
//                erro = "";
//                MailMessage msg = new MailMessage();

//#if DEBUG
//                SmtpClient client = new SmtpClient("smtp.linkecerebro.com.br");
//                client.Credentials = new System.Net.NetworkCredential("noreply@linkecerebro.com.br", "321mudar");
//                MailAddress from = new MailAddress("noreply@linkecerebro.com.br", "Clube Azul");
//                msg.Bcc.Add("denis.goncalves@wedigi.com.br");
//#else
//                SmtpClient client = new SmtpClient("localhost");
//                client.Credentials = new System.Net.NetworkCredential("noreply@linkecerebro.com.br", "321mudar");
//                MailAddress from = new MailAddress("noreply@linkecerebro.com.br", "Clube Azul");
//#endif

//                msg.From = from;
//                msg.To.Add(para);
//                msg.Subject = assunto;
//                msg.Body = corpo;

//                msg.IsBodyHtml = html;

//                try
//                {
//                    client.Send(msg);
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    erro = ex.Message;
//                    return false;
//                }
//                finally
//                {
//                    msg.Dispose();
//                    client.Dispose();
//                }
//            }

//            public static bool Enviar2(string assunto, string corpo, string para, bool html, out string erro)
//            {
//                MailSrv.Service1Client proxy = new MailSrv.Service1Client();

//                erro = "";
//                try
//                {
//                    bool ret = proxy.Enviar(assunto, corpo, para, html, erro, "123456789/");
//                    return ret;
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    proxy.Close();
//                }


//                //    SmtpClient client = new SmtpClient();
//                //    //MailAddress from = new MailAddress("teste@sysdemo.com.br", "Clube Azul");

//                //    MailAddress from = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["mailFrom"], "Clube Azul");


//                //    MailMessage msg = new MailMessage(); //("contato@clubeazul.org.br", para, assunto, corpo);

//                //    msg.From = from;
//                //    msg.To.Add(para);
//                //    msg.Subject = assunto;
//                //    msg.Body = corpo;

//                //    msg.IsBodyHtml = html;

//                //    try
//                //    {
//                //        client.Send(msg);
//                //        return true;
//                //    }
//                //    catch(Exception ex)
//                //    {
//                //        erro = ex.Message;
//                //        return false;
//                //    }
//                //    finally
//                //    {
//                //        msg.Dispose();
//                //        client.Dispose();
//                //    }
//            }
        }
    }

    public class HttpExtensions
    {
        public static void ForceDownload(HttpResponse Response, string virtualPath, string fileName)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.WriteFile(virtualPath);
            Response.ContentType = "";
            Response.End();
        }
    }

    public class Keys
    {
        public static string IDKey = "ID";
        public static string IDKeyOld = "IDOld";
        public static string EmpresaIDKey = "EMPRESA";
        public static string UsuarioIDKey = "USUARIO";
        public static string ClienteIDKey = "CLIENTE";
        public static string ClienteIDKeyOld = "CLIENTEOld";
        public static string NovoKey = "NOVO";
    }
