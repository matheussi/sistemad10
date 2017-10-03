namespace Entidade
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using LC.Framework.Phantom;
    using System.Data;

    [DBTable("CLI_CLIENTES_CENTR")]
    public class Cliente : EntityBase, IPersisteableEntity
    {
        public Cliente() { } 

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
        public object ID_COMO
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

        [DBFieldInfo("ID_PROMOTOR", FieldType.Single)]
        public int ID_Promotor
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

        public bool Importado
        {
            get
            {
                return 
                    (this.ID_CIRURGIA_Old > 0 ||
                    this.ID_CLINICO_Old > 0 ||
                    this.ID_ENDO_Old > 0 ||
                    this.ID_ORTO_Old > 0 ||
                    this.ID_PEDIATRIA_Old > 0) && this.ID != null;
            }
        }

        public int TipoImportado
        {
            get
            {
                if (this.Importado)
                {
                    if (this.ID_CLINICO_Old > 0) return 1;
                    else if (this.ID_ENDO_Old > 0) return 2;
                    else if (this.ID_ORTO_Old > 0) return 3;
                    else if (this.ID_CIRURGIA_Old > 0) return 4;
                    else if (this.ID_PEDIATRIA_Old > 0) return 5;
                    else return 0;
                }
                else
                    return 0;
            }
        }

        public int IDImportado
        {
            get
            {
                if (this.Importado)
                {
                    if (this.ID_CLINICO_Old > 0) return this.ID_CLINICO_Old;
                    else if (this.ID_ENDO_Old > 0) return this.ID_ENDO_Old;
                    else if (this.ID_ORTO_Old > 0) return this.ID_ORTO_Old;
                    else if (this.ID_CIRURGIA_Old > 0) return this.ID_CIRURGIA_Old;
                    else if (this.ID_PEDIATRIA_Old > 0) return this.ID_PEDIATRIA_Old;
                    else return 0;
                }
                else
                    return 0;
            }
        }

        public string NOME_TRATADO
        {
            get
            {
                if (!this.Importado)
                    return this.NOME;
                else
                {
                    if (this.ID_CLINICO_Old > 0) { return string.Concat(this.NOME, " (", this.ID_CLINICO_Old, " - CLINICO)"); }
                    else if (this.ID_ENDO_Old > 0) { return string.Concat(this.NOME, " (", this.ID_ENDO_Old, " - ENDO)"); }
                    else if (this.ID_ORTO_Old > 0) { return string.Concat(this.NOME, " (", this.ID_ORTO_Old, " - ORTO)"); }
                    else if (this.ID_CIRURGIA_Old > 0) { return string.Concat(this.NOME, " (", this.ID_CIRURGIA_Old, " - CIRURGIA)"); }
                    else if (this.ID_PEDIATRIA_Old > 0) { return string.Concat(this.NOME, " (", this.ID_PEDIATRIA_Old, " - PEDIATRIA)"); }
                    else return this.NOME;
                }
            }
        }

        public void Salvar()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.BeginTransactionContext();

                try
                {
                    pm.Save(this);

                    var maps = Mapp.Carregar(this.ID, pm);

                    if (maps != null)
                    {
                        IClienteAntigo antigo = null;

                        foreach (Mapp m in maps)
                        {
                            antigo = new Ficha().geraClienteAntigo(this, m.TIPO.ToString(), m.idOLD, pm);
                            pm.Save(antigo);
                        }
                    }

                    #region comentado 
                    //IClienteAntigo antigo = null;
                    //if (this.ID_CLINICO_Old > 0)
                    //{
                    //    antigo = new Ficha().geraClienteAntigo(this, "1", this.ID_CLINICO_Old, pm);
                    //    pm.Save(antigo);
                    //}
                    //else if (this.ID_ENDO_Old > 0)
                    //{
                    //    antigo = new Ficha().geraClienteAntigo(this, "2", this.ID_ENDO_Old, pm);
                    //    pm.Save(antigo);
                    //}
                    //else if (this.ID_ORTO_Old > 0)
                    //{
                    //    antigo = new Ficha().geraClienteAntigo(this, "3", this.ID_ORTO_Old, pm);
                    //    pm.Save(antigo);
                    //}
                    //else if (this.ID_CIRURGIA_Old > 0)
                    //{
                    //    antigo = new Ficha().geraClienteAntigo(this, "4", this.ID_CIRURGIA_Old, pm);
                    //    pm.Save(antigo);
                    //}
                    //else if (this.ID_PEDIATRIA_Old > 0)
                    //{
                    //    antigo = new Ficha().geraClienteAntigo(this, "5", this.ID_PEDIATRIA_Old, pm);
                    //    pm.Save(antigo);
                    //}
                    #endregion

                    pm.Commit();
                }
                catch
                {
                    pm.Rollback();
                    throw;
                }
                finally
                {
                    pm.Dispose();
                }
            }

            //base.Salvar(this);
        }

        public void Carregar()
        {
            base.Carregar(this);
        }

        /// <summary>
        /// Carrega somente id, nome, senha e cpf
        /// </summary>
        public static IList<Cliente> Carregar(string nome, string cpf, string empresaId)
        {
            List<String> paramNames = new List<String>();
            List<String> paramValue = new List<String>();

            string[] arrnome = nome.Split(' ');

            string where = " and (( A.NOME Like @Nome )) ";

            paramNames.Add("@Nome");
            paramValue.Add("%" + nome + "%");
            //paramValue.Add("%" + arrnome[0] + "%");
            //paramValue.Add(arrnome[0] + "%"); 

            //if (arrnome.Length > 1)
            //{
            //    for (int i = 1; i < arrnome.Length; i++)
            //    {
            //        if(arrnome[1].Length <= 2 || arrnome[i].ToLower().Trim() == "dos" || arrnome[i].ToLower().Trim() == "das") 
            //            continue;

            //        where += " or ( A.NOME Like @Nome" + i.ToString() + ") ";

            //        paramNames.Add("@Nome" + i.ToString());
            //        paramValue.Add("%" + arrnome[i] + "%");
            //    }
            //}

            //where += " ) ";

            if (!string.IsNullOrEmpty(cpf))
            {
                 where += " and ( A.CPF = @Cpf ) ";

                 paramNames.Add("@Cpf");
                 paramValue.Add(cpf);
            }

            string orderby = " A.ID DESC ";

            if (!string.IsNullOrEmpty(nome)) orderby = " A.NOME ASC ";

            string sql = string.Concat(
            "SELECT top 100 A.ID AS ID,SENHA, A.NOME,dbo.formatarCPF(CPF) AS CPF, '' as DT_TRAT_CONCLUIDO,ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old",
//          ", (select CAST(DAY(TC.DATA_USU) AS VARCHAR(2))+'/'+CAST(MONTH(TC.DATA_USU)AS VARCHAR(2))+'/'+CAST(YEAR(TC.DATA_USU)AS VARCHAR(4)) AS DT_FIM ",
//            " from CLI_TRATA_CONCLUIDO ",
//            "TC (nolock) ,CLI_MOVDIARIO MV (nolock) ",
//            "  WHERE TC.ID_MOV = MV.ID ",
//            " AND MV.ID_CLIENTE = A.ID ) AS [DT_TRAT_CONCLUIDO] ",
            " FROM CLI_CLIENTES_CENTR A (nolock) WHERE ID_EMPRESA=", empresaId, where,
            " ORDER BY ", orderby);

            return LocatorHelper.Instance.ExecuteParametrizedQuery<Cliente>
                (sql, paramNames.ToArray(), paramValue.ToArray(), typeof(Cliente));
        }


        /// <summary>
        /// ATENCAO: Ao fazer a virada, deverá refatorar para fazer join com a tabela de ficha centralizada.
        /// </summary>
        public static IList<Cliente> CarregarPorFicha(string fichaId, string empresaId)
        {
            string sql = string.Concat(
                "SELECT        CLI_CLIENTES_CENTR.ID,CLI_CLIENTES.ID  as IdOld,CLI_CLIENTES.NOME, dbo.formatarCPF(CLI_CLIENTES.CPF)  as CPF,1 as TIPO,'CLINICO'	AS DESC_TIPO FROM CLI_CLIENTES inner join _mapp on map_oldId=ID and map_tipo=1 inner join CLI_CLIENTES_CENTR  on CLI_CLIENTES_CENTR.id=map_newId     where  CLI_CLIENTES.ID_EMPRESA=", empresaId, " and CLI_CLIENTES.ID = ", fichaId,
                " UNION SELECT CLI_CLIENTES_CENTR.ID,CLI_CLIENTES2.ID as IdOld,CLI_CLIENTES2.NOME,dbo.formatarCPF(CLI_CLIENTES2.CPF) as CPF,2 AS TIPO,'ENDO'		AS DESC_TIPO FROM CLI_CLIENTES2 inner join _mapp on map_oldId=ID and map_tipo=2 inner join CLI_CLIENTES_CENTR on CLI_CLIENTES_CENTR.id=map_newId where CLI_CLIENTES2.ID_EMPRESA=", empresaId, " and CLI_CLIENTES2.ID = ", fichaId,
                " UNION SELECT CLI_CLIENTES_CENTR.ID,CLI_CLIENTES3.ID as IdOld,CLI_CLIENTES3.NOME,dbo.formatarCPF(CLI_CLIENTES3.CPF) as CPF,3 AS TIPO,'ORTO'		AS DESC_TIPO FROM CLI_CLIENTES3 inner join _mapp on map_oldId=ID and map_tipo=3 inner join CLI_CLIENTES_CENTR on CLI_CLIENTES_CENTR.id=map_newId where CLI_CLIENTES3.ID_EMPRESA=", empresaId, " and CLI_CLIENTES3.ID = ", fichaId,
                " UNION SELECT CLI_CLIENTES_CENTR.ID,CLI_CLIENTES4.ID as IdOld,CLI_CLIENTES4.NOME,dbo.formatarCPF(CLI_CLIENTES4.CPF) as CPF,4 AS TIPO,'CIRURGIA'	AS DESC_TIPO FROM CLI_CLIENTES4 inner join _mapp on map_oldId=ID and map_tipo=4 inner join CLI_CLIENTES_CENTR on CLI_CLIENTES_CENTR.id=map_newId where CLI_CLIENTES4.ID_EMPRESA=", empresaId, " and CLI_CLIENTES4.ID = ", fichaId,
                " UNION SELECT CLI_CLIENTES_CENTR.ID,CLI_CLIENTES5.ID as IdOld,CLI_CLIENTES5.NOME,dbo.formatarCPF(CLI_CLIENTES5.CPF) as CPF,5 AS TIPO,'PEDIATRIA'	AS DESC_TIPO FROM CLI_CLIENTES5 inner join _mapp on map_oldId=ID and map_tipo=5 inner join CLI_CLIENTES_CENTR on CLI_CLIENTES_CENTR.id=map_newId where CLI_CLIENTES5.ID_EMPRESA=", empresaId, " and CLI_CLIENTES5.ID = ", fichaId,
                "ORDER BY ID");

            DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result1").Tables[0];

            List<Cliente> lista = new List<Cliente>();

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Cliente cli = new Cliente();

                    cli.ID = row["ID"];
                    cli.NOME = string.Concat(CToString(row["NOME"]), " - Ficha ", row["IdOld"], " ", row["DESC_TIPO"]);
                    cli.CPF = CToString(row["Cpf"]);

                    #region fill

                    //if (CToString(row["ID1"]) != "")
                    //{
                    //    cli.ID = row["ID1"];
                    //    cli.NOME = string.Concat(CToString(row["Nome1"]), " - Ficha ", row["ID_CLIENTE"]);
                    //    cli.CPF = CToString(row["Cpf1"]);
                    //}
                    //else if (CToString(row["ID2"]) != "")
                    //{
                    //    cli.ID = row["ID2"];
                    //    cli.NOME = string.Concat(CToString(row["Nome2"]), " - Ficha ", row["ID_CLIENTE"]);
                    //    cli.CPF = CToString(row["Cpf2"]);
                    //}
                    //else if (CToString(row["ID3"]) != "")
                    //{
                    //    cli.ID = row["ID3"];
                    //    cli.NOME = string.Concat(CToString(row["Nome3"]), " - Ficha ", row["ID_CLIENTE"]);
                    //    cli.CPF = CToString(row["Cpf3"]);
                    //}
                    //else if (CToString(row["ID4"]) != "")
                    //{
                    //    cli.ID = row["ID4"];
                    //    cli.NOME = string.Concat(CToString(row["Nome4"]), " - Ficha ", row["ID_CLIENTE"]);
                    //    cli.CPF = CToString(row["Cpf4"]);
                    //}
                    //else if (CToString(row["ID5"]) != "")
                    //{
                    //    cli.ID = row["ID5"];
                    //    cli.NOME = string.Concat(CToString(row["Nome5"]), " - Ficha ", row["ID_CLIENTE"]);
                    //    cli.CPF = CToString(row["Cpf5"]);
                    //}
                    #endregion

                    if(CToString(row["IdOld"]).IndexOf(fichaId) == -1) continue;

                    lista.Add(cli);

                }
            }

            dt.Rows.Clear();
            dt.Dispose();

            //agora carrega as novas
            sql = string.Concat(
                "select CLI_CLIENTES_CENTR.ID,CLI_CLIENTES_CENTR.NOME,dbo.formatarCPF(CLI_CLIENTES_CENTR.CPF) as CPF,ficha_clienteId_old,case ficha_tipoCliente when 1 then 'CLINICO' when 2 then 'ENDO' when 3 then 'ORTO' when 4 then 'CIRURGIA' when 5 then 'PEDIATRIA' else 'nda' end as DESC_TIPO ",
                "   from CLI_CLIENTES_CENTR ",
                "       inner join FICHA_CENTR on FICHA_CENTR.ficha_clienteId = CLI_CLIENTES_CENTR.ID ",
                " where ",
                "   CLI_CLIENTES_CENTR.ID not in (select map_newId from _mapp where map_tipo=ficha_tipoCliente) and ",
                "   (ficha_id=", fichaId, " or ficha_clienteId_old=", fichaId, ")");

            dt = LocatorHelper.Instance.ExecuteQuery(sql, "result1").Tables[0];

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Cliente cli = new Cliente();

                    cli.ID = row["ID"];
                    cli.NOME = string.Concat(CToString(row["NOME"]), " - Ficha ", row["ficha_clienteId_old"], " ", row["DESC_TIPO"]);
                    cli.CPF = CToString(row["CPF"]);

                    lista.Add(cli);
                }
            }

            return lista.OrderBy(cli => cli.NOME).ToList();
        }

        //bool jaExiste(List<Cliente> adicionados, Cliente novo)
        //{
        //    if (adicionados != null && adicionados.Count > 0)
        //    {
        //        foreach (var added in adicionados)
        //        {
        //            if(
        //        }
        //    }

        //    return false;
        //}


        public static IList<Cliente> CarregarPorFicha__(string fichaId, string empresaId)
        {
            string sql = string.Concat(
            "select CLI_MOVDIARIO.ID as FichaID, CLI_CLIENTES.ID as ID1, CLI_CLIENTES.Nome as Nome1,dbo.formatarCPF(CLI_CLIENTES.CPF) as Cpf1,CLI_CLIENTES2.ID as ID2,CLI_CLIENTES2.Nome as Nome2, dbo.formatarCPF(CLI_CLIENTES2.CPF) as Cpf2,CLI_CLIENTES3.ID as ID3, CLI_CLIENTES3.Nome as Nome3, dbo.formatarCPF(CLI_CLIENTES3.CPF) as Cpf3,CLI_CLIENTES4.ID as ID4, CLI_CLIENTES4.Nome as Nome4, dbo.formatarCPF(CLI_CLIENTES4.CPF) as Cpf4,CLI_CLIENTES5.ID as ID5, CLI_CLIENTES5.Nome as Nome5, dbo.formatarCPF(CLI_CLIENTES5.CPF) as Cpf5,   ID_CLINICO_Old,ID_ENDO_Old,ID_ORTO_Old,ID_CIRURGIA_Old,ID_PEDIATRIA_Old",
            "   from CLI_MOVDIARIO ",
            "       left join CLI_CLIENTES_CENTR as CLI_CLIENTES  on CLI_CLIENTES.ID_CLINICO_Old   = CLI_MOVDIARIO.ID_CLIENTE and tipo_cliente = 1 ",
            "       left join CLI_CLIENTES_CENTR as CLI_CLIENTES2 on CLI_CLIENTES2.ID_ENDO_Old     = CLI_MOVDIARIO.ID_CLIENTE and tipo_cliente = 2 ",
            "       left join CLI_CLIENTES_CENTR as CLI_CLIENTES3 on CLI_CLIENTES3.ID_ORTO_Old     = CLI_MOVDIARIO.ID_CLIENTE and tipo_cliente = 3 ",
            "       left join CLI_CLIENTES_CENTR as CLI_CLIENTES4 on CLI_CLIENTES4.ID_CIRURGIA_Old = CLI_MOVDIARIO.ID_CLIENTE and tipo_cliente = 4 ",
            "       left join CLI_CLIENTES_CENTR as CLI_CLIENTES5 on CLI_CLIENTES5.ID_CIRURGIA_Old = CLI_MOVDIARIO.ID_CLIENTE and tipo_cliente = 5 ",
            "   where CLI_MOVDIARIO.ID_EMPRESA=", empresaId, " and CLI_MOVDIARIO.ID = ", fichaId); //todo: and FichaID not in ficha centralizado id old ??

            DataTable dt = LocatorHelper.Instance.ExecuteQuery(sql, "result1").Tables[0];

            List<Cliente> lista = new List<Cliente>();

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Cliente cli = new Cliente();

                    #region fill 

                    if (CToString(row["ID1"]) != "")
                    {
                        cli.ID = row["ID1"];
                        cli.NOME = string.Concat(CToString(row["Nome1"]), " - Ficha ", row["FichaID"]);
                        cli.CPF = CToString(row["Cpf1"]);
                    }
                    else if (CToString(row["ID2"]) != "")
                    {
                        cli.ID = row["ID2"];
                        cli.NOME = string.Concat(CToString(row["Nome2"]), " - Ficha ", row["FichaID"]);
                        cli.CPF = CToString(row["Cpf2"]);
                    }
                    else if (CToString(row["ID3"]) != "")
                    {
                        cli.ID = row["ID3"];
                        cli.NOME = string.Concat(CToString(row["Nome3"]), " - Ficha ", row["FichaID"]);
                        cli.CPF = CToString(row["Cpf3"]);
                    }
                    else if (CToString(row["ID4"]) != "")
                    {
                        cli.ID = row["ID4"];
                        cli.NOME = string.Concat(CToString(row["Nome4"]), " - Ficha ", row["FichaID"]);
                        cli.CPF = CToString(row["Cpf4"]);
                    }
                    else if (CToString(row["ID5"]) != "")
                    {
                        cli.ID =  row["ID5"];
                        cli.NOME = string.Concat(CToString(row["Nome5"]), " - Ficha ", row["FichaID"]);
                        cli.CPF = CToString(row["Cpf5"]);
                    }
                    #endregion

                    lista.Add(cli);

                }
            }

            dt.Dispose();
            return lista.OrderBy(cli => cli.NOME).ToList();
        }

        public static void importarClientes()
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.BeginTransactionContext();

                try
                {
                    string sql = string.Concat(
                        "SELECT *,1 as TIPO,'CLINICO' AS DESC_TIPO FROM CLI_CLIENTES ",
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

                    Cliente cli = null;
                    DataRow[] rows1 = null;

                    foreach (string empresa in empresas)
                    {
                        foreach (string nome in nomes)
                        {
                            rows1 = dt.Select(string.Concat("NOME='", nome, "' AND ID_EMPRESA=", empresa), "DESC_TIPO");

                            if (rows1.Length == 0) continue;

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
                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 1)", pm);
                                        break;
                                    }
                                    case "ENDO":
                                    {
                                        cli.ID_ENDO_Old = CToInt(row["ID"]);
                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 2)", pm);
                                        break;
                                    }
                                    case "ORTO":
                                    {
                                        cli.ID_ORTO_Old = CToInt(row["ID"]);
                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 3)", pm);
                                        break;
                                    }
                                    case "CIRURGIA":
                                    {
                                        cli.ID_CIRURGIA_Old = CToInt(row["ID"]);
                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 4)", pm);
                                        break;
                                    }
                                    case "PEDIATRIA":
                                    {
                                        cli.ID_PEDIATRIA_Old = CToInt(row["ID"]);
                                        NonQueryHelper.Instance.ExecuteNonQuery("insert into importacao (imp_cliid,imp_tipo) values (" + row["ID"] + ", 5)", pm);
                                        break;
                                    }
                                    #endregion
                                }
                            }

                            pm.Save(cli);
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
    }

    [DBTable("_mapp")]
    public class Mapp : IPersisteableEntity
    {
        #region properties 

        [DBFieldInfo("map_id", FieldType.PrimaryKeyAndIdentity)]
        public object ID { get; set; }

        [DBFieldInfo("map_newId", FieldType.Single)]
        public Int64 idNEW { get; set; }

        [DBFieldInfo("map_oldId", FieldType.Single)]
        public Int64 idOLD { get; set; }

        [DBFieldInfo("map_tipo", FieldType.Single)]
        public Int64 TIPO { get; set; }

        #endregion

        public static IList<Mapp> Carregar(object idNovo, PersistenceManager pm)
        {
            return LocatorHelper.Instance.ExecuteQuery<Mapp>(
                string.Concat("* from _mapp where map_newId=", idNovo, " order by map_tipo"), 
                typeof(Mapp), pm);
        }
    }

    public interface IClienteAntigo : IPersisteableEntity
    {
        #region properties

        object ID
        {
            get;
            set;
        }

        string NOME
        {
            get;
            set;
        }

        string CPF
        {
            get;
            set;
        }

        string EMAIL
        {
            get;
            set;
        }

        DateTime NASCIMENTO
        {
            get;
            set;
        }

        string SENHA
        {
            get;
            set;
        }

        bool ATIVO
        {
            get;
            set;
        }

        string ENDERECO
        {
            get;
            set;
        }

        string NUMERO
        {
            get;
            set;
        }

        string COMPLEMENTO
        {
            get;
            set;
        }

        string CEP
        {
            get;
            set;
        }

        string CIDADE
        {
            get;
            set;
        }

        string BAIRRO
        {
            get;
            set;
        }

        string ESTADO
        {
            get;
            set;
        }

        string DDD_F
        {
            get;
            set;
        }

        string TEL_FIXO
        {
            get;
            set;
        }

        string CELULAR
        {
            get;
            set;
        }

        string DDD_C
        {
            get;
            set;
        }

        string PONTO_REFERENCIA
        {
            get;
            set;
        }

        DateTime DT_CRIACAO
        {
            get;
            set;
        }

        DateTime DT_ALTERACAO
        {
            get;
            set;
        }

        int ID_OPERADORA
        {
            get;
            set;
        }

        object ID_COMO
        {
            get;
            set;
        }

        int ID_EMPRESA
        {
            get;
            set;
        }

        string OBS
        {
            get;
            set;
        }

        #endregion

        void Carregar();
    }

    /// <summary>
    /// Clientes de Clínico
    /// </summary>
    [DBTable("CLI_CLIENTES")]
    public class Cliente1 : EntityBase, IClienteAntigo
    {
        public Cliente1() { }
        public Cliente1(object id) { this.ID = id; }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
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
        public object ID_COMO
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

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }
    }

    /// <summary>
    /// Clientes ENDO 
    /// </summary>
    [DBTable("CLI_CLIENTES2")]
    public class Cliente2 : EntityBase, IClienteAntigo
    {
        public Cliente2() { }
        public Cliente2(object id) { this.ID = id; }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
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
        public object ID_COMO
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

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }
    }

    [DBTable("CLI_CLIENTES3")]
    public class Cliente3 : EntityBase, IClienteAntigo
    {
        public Cliente3() { }
        public Cliente3(object id) { this.ID = id; }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
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
        public object ID_COMO
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

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }
    }

    /// <summary>
    /// Clientes de cirurgia
    /// </summary>
    [DBTable("CLI_CLIENTES4")]
    public class Cliente4 : EntityBase, IClienteAntigo
    {
        public Cliente4() { }
        public Cliente4(object id) { this.ID = id; }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
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
        public object ID_COMO
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

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }
    }

    [DBTable("CLI_CLIENTES5")]
    public class Cliente5 : EntityBase, IClienteAntigo
    {
        public Cliente5() { }
        public Cliente5(object id) { this.ID = id; }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
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
        public object ID_COMO
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

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }
    }
}
