namespace Win
{
    using LC.Framework.Phantom;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.Http;
    using System.Net;
    using System.IO;
    using System.Configuration;
    using System.Threading;

    public partial class frmReportCache : Form
    {
        private static readonly HttpClient client = new HttpClient();
        PersistenceManager _pm = null;

        PersistenceManager getPM()
        {
            if (_pm == null)
            {
                _pm = new PersistenceManager();
                _pm.UseSingleCommandInstance();
            }

            return _pm;
        }

        bool working = false;
        bool workingMAPA = false;
        bool workingMAPA2 = false;
        bool workingMAPA3 = false;
        bool workingMAPA4 = false;
        bool workingMAPA5 = false;
        bool workingMAPA6 = false;

        public frmReportCache()
        {
            InitializeComponent();
            timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]); // 30000; // 60000;
            //timer.Enabled = false;/////////////////////// todo: comentar

            timerMAPA.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["intervalMapa"]); 
        }

        string HTMLEspeciais(string sString)
        {
            if (!string.IsNullOrEmpty(sString))
            {
                sString = sString.Replace("á", "&aacute;");
                sString = sString.Replace("â", "&acirc;");
                sString = sString.Replace("à", "&agrave;");
                sString = sString.Replace("ã", "&atilde;");

                sString = sString.Replace("ç", "&ccedil;");

                sString = sString.Replace("é", "&eacute;");
                sString = sString.Replace("ê", "&ecirc;");

                sString = sString.Replace("í", "&iacute;");

                sString = sString.Replace("ó", "&oacute;");
                sString = sString.Replace("ô", "&ocirc;");
                sString = sString.Replace("õ", "&otilde;");

                sString = sString.Replace("ú", "&uacute;");
                sString = sString.Replace("ü", "&uuml;");

                sString = sString.Replace("Á", "&Aacute;");
                sString = sString.Replace("Â", "&Acirc;");
                sString = sString.Replace("À", "&Agrave;");
                sString = sString.Replace("Ã", "&Atilde;");

                sString = sString.Replace("Ç", "&Ccedil;");

                sString = sString.Replace("É", "&Eacute;");
                sString = sString.Replace("Ê", "&Ecirc;");

                sString = sString.Replace("Í", "&Iacute;");

                sString = sString.Replace("Ó", "&Oacute;");
                sString = sString.Replace("Ô", "&Ocirc;");
                sString = sString.Replace("Õ", "&Otilde;");

                sString = sString.Replace("Ú", "&Uacute;");
                sString = sString.Replace("Ü", "&Uuml;");

                //sString = Replace(sString, """", "&quot;");
                //sString = Replace(sString, "<", "&lt;") '<
                //sString = Replace(sString, ">", "&gt;") '>
            }

            return sString;
        }

        private void frmReportCache_Load(object sender, EventArgs e)
        {
            this.checkPendencies(); //todo: descomentar
            this.checkPendenciesMAPA_0();
        }

        void folhaDiaria(DataRow row, PersistenceManager pm)
        {
            string id = Convert.ToString(row["tr_id"]);
            string empresaId = "";
            DateTime dataEv = Convert.ToDateTime(row["tr_data"], new System.Globalization.CultureInfo("pt-Br"));

            //empresaId = Convert.ToString(LocatorHelper.Instance.ExecuteScalar(
            //    string.Concat("select ID_EMPRESA from CLI_MOVDIARIO where id=", dt.Rows[0]["tr_ID_MOV_DIARIO"]),
            //    null, null, pm));
            empresaId = Convert.ToString(row["ID_EMPRESA"]);
            //empresaId = "1";////////////////

            //https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request
            //var request = (HttpWebRequest)WebRequest.Create("http://sysdemo.iphotel.info/002/teste.asp");
            var request = (HttpWebRequest)WebRequest.Create("http://sysdemo.iphotel.info/002/mov_dia.asp");
            var postData = string.Concat("DATA=", dataEv.ToString("yyyy-MM-dd"), "&pEMPRESA=", empresaId, "&OP=OP");
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            //https://stackoverflow.com/questions/227575/encoding-trouble-with-httpwebresponse
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1")).ReadToEnd();
            response.Close();

            #region escreve arquivo local 
            
            string arquivo_nome = string.Concat("folha_", empresaId, "_", dataEv.ToString("yyyy-MM-dd"), ".txt");
            string caminhoBase = ConfigurationManager.AppSettings["filelocalpath"];

            string arquivo = string.Concat(caminhoBase, arquivo_nome);
            if (File.Exists(arquivo)) { File.Delete(arquivo); }
            System.IO.File.WriteAllText(arquivo, HTMLEspeciais(responseString));

            #endregion

            #region envia arquivo via ftp 

            string ftpBase = string.Concat(ConfigurationManager.AppSettings["ftp"], arquivo_nome);

            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpBase);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            ftpRequest.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["ftpLogin"], 
                ConfigurationManager.AppSettings["ftpSenha"]);

            StreamReader sourceStream = new StreamReader(arquivo);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd()); //Encoding.GetEncoding("iso-8859-1").GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            ftpRequest.ContentLength = fileContents.Length;

            Stream requestStream = ftpRequest.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            ftpResponse.Close();

            #endregion

            File.Delete(arquivo);
            NonQueryHelper.Instance.ExecuteNonQuery(
                string.Concat("update t_trigger set tr_processado=1, tr_processadoEm=getdate() where tr_id=", row["tr_id"]),
                pm);
        }
        void checkPendencies()
        {
            if (working) return;

            working = true;

            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.UseSingleCommandInstance();

                try
                {
                    DataTable dt = LocatorHelper.Instance.ExecuteQuery("select top 5 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where tr_processado=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt == null) return;
                    if (dt.Rows == null || dt.Rows.Count == 0) { dt.Dispose(); return; }

                    foreach (DataRow row in dt.Rows)
                    {
                        this.folhaDiaria(row, pm);
                    }

                    dt.Dispose();

                }
                catch
                {
                }
                finally
                {
                    pm.CloseSingleCommandInstance();
                    working = false;
                }
            }
        }

        void mapaFinanceiro(object param)//(DataRow row, string tipo, PersistenceManager pm)
        {
            try
            {
                object[] arr = (object[])param;
                string tipo = (string)arr[1];
                PersistenceManager pm = (PersistenceManager)arr[2];

                string id = Convert.ToString(((DataRow)arr[0])["tr_id"]); //Convert.ToString(row["tr_id"]);
                string empresaId = "";
                DateTime dataEv = Convert.ToDateTime(((DataRow)arr[0])["tr_data"], new System.Globalization.CultureInfo("pt-Br")); //Convert.ToDateTime(row["tr_data"], new System.Globalization.CultureInfo("pt-Br"));

                empresaId = Convert.ToString(((DataRow)arr[0])["ID_EMPRESA"]); //Convert.ToString(row["ID_EMPRESA"]);

                //https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request
                var request = (HttpWebRequest)WebRequest.Create("http://sysdemo.iphotel.info/002/mov_mes_2.asp");
                var postData = string.Concat("DATA=", "", "&pEMPRESA=", empresaId, "&TIPO=", tipo,
                    "&ENVIA=1&MES_SEL=", dataEv.Month, "&ANO_SEL=", dataEv.Year);
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                //https://stackoverflow.com/questions/227575/encoding-trouble-with-httpwebresponse
                var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1")).ReadToEnd();
                response.Close();

                #region escreve arquivo local

                string arquivo_nome = string.Concat("mapa_", empresaId, "_", tipo, "_", dataEv.Month, "_", dataEv.Year, ".txt");
                string caminhoBase = ConfigurationManager.AppSettings["filelocalpath"];

                string arquivo = string.Concat(caminhoBase, arquivo_nome);
                if (File.Exists(arquivo)) { File.Delete(arquivo); }
                System.IO.File.WriteAllText(arquivo, HTMLEspeciais(responseString));

                #endregion

                #region envia arquivo via ftp

                string ftpBase = string.Concat(ConfigurationManager.AppSettings["ftp"], arquivo_nome);

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpBase);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                ftpRequest.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["ftpLogin"],
                    ConfigurationManager.AppSettings["ftpSenha"]);

                StreamReader sourceStream = new StreamReader(arquivo);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd()); //Encoding.GetEncoding("iso-8859-1").GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                ftpRequest.ContentLength = fileContents.Length;

                Stream requestStream = ftpRequest.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpResponse.Close();

                #endregion

                File.Delete(arquivo);
                int ret = NonQueryHelper.Instance.ExecuteNonQuery(
                    string.Concat("update t_trigger set tr_processadoMapa=1, tr_processadoMapaEm=getdate() where tr_processadoMapa=0 and month(tr_data)=", dataEv.Month, " and year(tr_data)=", dataEv.Year, " and tr_id <= ", ((DataRow)arr[0])["tr_id"], " and tr_id_mov_diario in (select id from CLI_MOVDIARIO where id_empresa=", empresaId, ") "), 
                    //string.Concat("update t_trigger set tr_processadoMapa=1, tr_processadoMapaEm=getdate() where tr_id=", ((DataRow)arr[0])["tr_id"]),
                    pm);
            }
            catch
            {
            }
        }
        void checkPendenciesMAPA_0()
        {
            ThreadStart ts1 = new ThreadStart(checkPendenciesMAPA_1);//ParameterizedThreadStart ts1 = new ParameterizedThreadStart(mapaFinanceiro);
            Thread th1 = new Thread(ts1);
            ThreadStart ts2 = new ThreadStart(checkPendenciesMAPA_2);
            Thread th2 = new Thread(ts2);
            ThreadStart ts3 = new ThreadStart(checkPendenciesMAPA_3);
            Thread th3 = new Thread(ts3);
            ThreadStart ts4 = new ThreadStart(checkPendenciesMAPA_4);
            Thread th4 = new Thread(ts4);
            ThreadStart ts5 = new ThreadStart(checkPendenciesMAPA_5);
            Thread th5 = new Thread(ts5);
            ThreadStart ts6 = new ThreadStart(checkPendenciesMAPA_6);
            Thread th6 = new Thread(ts6);

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
            th6.Start();
        }
        void checkPendenciesMAPA_1()
        {
            #region 1
            if (!workingMAPA)
            {
                workingMAPA = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=1 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_2()
        {
            #region 2
            if (!workingMAPA2)
            {
                workingMAPA2 = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=2 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA2 = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_3()
        {
            #region 3 
            if (!workingMAPA3)
            {
                workingMAPA3 = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=3 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA3 = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_4()
        {
            #region 4
            if (!workingMAPA4)
            {
                workingMAPA4 = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=4 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA4 = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_5()
        {
            #region 5 
            if (!workingMAPA5)
            {
                workingMAPA5 = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=5 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA5 = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_6()
        {
            #region 6 
            if (!workingMAPA6)
            {
                workingMAPA6 = true;

                using (PersistenceManager pm = new PersistenceManager())
                {
                    pm.UseSingleCommandInstance();

                    try
                    {
                        DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA >= 6 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                        if (dt1 == null) { }
                        else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                        else
                        {
                            object[] arr = new object[3];
                            foreach (DataRow row in dt1.Rows)
                            {
                                arr[0] = row;
                                arr[1] = "1";
                                arr[2] = pm;
                                //th1.Start(arr);  
                                //th1.Join();

                                this.mapaFinanceiro(arr);//this.mapaFinanceiro(row, "1", pm);
                            }

                            dt1.Dispose();
                        }
                    }
                    finally
                    {
                        pm.CloseSingleCommandInstance();
                        workingMAPA6 = false;
                    }
                }
            }
            #endregion
        }

        void checkPendenciesMAPA_old()
        {
            if (workingMAPA) return;

            workingMAPA = true;

            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.UseSingleCommandInstance();

                ParameterizedThreadStart ts1 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th1 = new Thread(ts1);
                ParameterizedThreadStart ts2 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th2 = new Thread(ts2);
                ParameterizedThreadStart ts3 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th3 = new Thread(ts3);
                ParameterizedThreadStart ts4 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th4 = new Thread(ts4);
                ParameterizedThreadStart ts5 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th5 = new Thread(ts5);
                ParameterizedThreadStart ts6 = new ParameterizedThreadStart(mapaFinanceiro);
                Thread th6 = new Thread(ts6);

                try
                {
                    #region 1 
                    DataTable dt1 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=1 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt1 == null) { }
                    else if (dt1.Rows == null || dt1.Rows.Count == 0) { dt1.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt1.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th1.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th1.Join();
                        }

                        dt1.Dispose();
                    }
                    #endregion

                    #region 2 
                    DataTable dt2 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=2 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt2 == null) { }
                    else if (dt2.Rows == null || dt2.Rows.Count == 0) { dt2.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt2.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th2.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th2.Join();
                        }

                        dt2.Dispose();
                    }
                    #endregion

                    #region 3 
                    DataTable dt3 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=3 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt3 == null) { }
                    else if (dt3.Rows == null || dt3.Rows.Count == 0) { dt3.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt3.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th3.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th3.Join();
                        }

                        dt3.Dispose();
                    }
                    #endregion

                    #region 4 
                    DataTable dt4 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=4 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt4 == null) { }
                    else if (dt4.Rows == null || dt4.Rows.Count == 0) { dt4.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt4.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th4.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th4.Join();
                        }

                        dt4.Dispose();
                    }
                    #endregion

                    #region 5 
                    DataTable dt5 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA=5 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt5 == null) { }
                    else if (dt5.Rows == null || dt5.Rows.Count == 0) { dt5.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt5.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th5.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th5.Join();
                        }

                        dt5.Dispose();
                    }
                    #endregion

                    #region >= 6 
                    DataTable dt6 = LocatorHelper.Instance.ExecuteQuery("select top 1 t_trigger.*,ID_EMPRESA from t_trigger inner join CLI_MOVDIARIO on ID=tr_ID_MOV_DIARIO where ID_EMPRESA>=6 and tr_processadoMAPA=0 order by tr_id desc", "result", pm).Tables[0];

                    if (dt6 == null) { }
                    else if (dt6.Rows == null || dt6.Rows.Count == 0) { dt6.Dispose(); }
                    else
                    {
                        object[] arr = new object[3];
                        foreach (DataRow row in dt6.Rows)
                        {
                            arr[0] = row;
                            arr[1] = "1";
                            arr[2] = pm;
                            th6.Start(arr);  //this.mapaFinanceiro(row, "1", pm);
                            //th6.Join();
                        }

                        dt6.Dispose();
                    }
                    #endregion

                    th1.Join();
                    th2.Join();
                    th3.Join();
                    th4.Join();
                    th5.Join();
                    th6.Join();
                }
                catch
                {
                }
                finally
                {
                    pm.CloseSingleCommandInstance();
                    //workingMAPA = false;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.checkPendencies();
        }

        private void timerMAPA_Tick(object sender, EventArgs e)
        {
            this.checkPendenciesMAPA_0();
        }
    }
}
