namespace Entidade
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using LC.Framework.Phantom;

    [DBTable("FICHA_CENTR")]
    public class Ficha : EntityBase, IPersisteableEntity
    {
        public Ficha() { ATENDIDO = false; DATA = DateTime.Now; }

        #region properties

        [DBFieldInfo("ficha_id", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        /// <summary>
        /// ID na modelagem antiga
        /// </summary>
        [DBFieldInfo("ficha_id_old", FieldType.Single)]
        public object ID_Old
        {
            get;
            set;
        }

        public string ID_TRATADO
        {
            get
            {
                return Convert.ToString(this.ID_CLIENTE_Old);
                //if (this.ID_CLIENTE_Old != null)
                //{
                //    if (this.ID == null || Convert.ToInt32(this.ID) == -1)
                //        return Convert.ToString(this.ID_CLIENTE_Old);
                //    else
                //        return string.Concat(this.ID_CLIENTE_Old, " (novo: ", this.ID, ")");
                //}
                //else
                //    return Convert.ToString(this.ID);
            }
        }

        [DBFieldInfo("ficha_usuarioId", FieldType.Single)]
        public object ID_USUARIO
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_destistaId", FieldType.Single)]
        public object ID_DENTISTA
        {
            get;
            set;
        }
        
        [DBFieldInfo("ficha_cpfPagador", FieldType.Single)]
        public string CPF_PAGADOR
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_valorTotal", FieldType.Single)]
        public decimal TOTAL
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_valorOrcado", FieldType.Single)]
        public decimal TOTAL_ORCADO
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_data", FieldType.Single)]
        public DateTime DATA
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_clienteId", FieldType.Single)]
        public object ID_CLIENTE
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_clienteId_old", FieldType.Single)]
        public object ID_CLIENTE_Old
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_empresaId", FieldType.Single)]
        public object ID_EMPRESA
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_atendido", FieldType.Single)]
        public bool ATENDIDO
        {
            get;
            set;
        }

        /// <summary>
        /// Especialidade
        /// </summary>
        [DBFieldInfo("ficha_tipoCliente", FieldType.Single)]
        public object TIPO_CLIENTE
        {
            get;
            set;
        }

        [DBFieldInfo("ficha_obs", FieldType.Single)]
        public string OBS
        {
            get;
            set;
        }

        ////Se é liquidada, orçamento contratado, etc
        //[DBFieldInfo("ficha_tipoId", FieldType.Single)]
        //public object TIPO_FICHA
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Joinned
        /// </summary>
        [Joinned("DentistaNome")]
        public string DentistaNome
        {
            get;
            set;
        }

        [Joinned("PacienteNome")]
        public string PacienteNome
        {
            get;
            set;
        }

        [Joinned("Especialidade")]
        public string Especialidade
        {
            get;
            set;
        }

        [Joinned("TipoFicha")]
        public string TipoFicha
        {
            get;
            set;
        }

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }

        internal static object ObtemIdAntigoDeCliente(Cliente cli, Ficha ficha, PersistenceManager pm)
        {
            object ret = null;

            ret = LocatorHelper.Instance.ExecuteScalar(
                string.Concat("select map_oldId from _mapp where map_tipo=", ficha.TIPO_CLIENTE, " and map_newId=", cli.ID, " order by map_id desc"), 
                null, null, pm);

            //if (CToString(ficha.TIPO_CLIENTE) == "1")
            //    ret = cli.ID_CLINICO_Old;
            //else if (CToString(ficha.TIPO_CLIENTE) == "2")
            //    ret = cli.ID_ENDO_Old;
            //else if (CToString(ficha.TIPO_CLIENTE) == "3")
            //    ret = cli.ID_ORTO_Old;
            //else if (CToString(ficha.TIPO_CLIENTE) == "4")
            //    ret = cli.ID_CIRURGIA_Old;
            //else if (CToString(ficha.TIPO_CLIENTE) == "5")
            //    ret = cli.ID_PEDIATRIA_Old;
            //else
            //    return null;

            if (ret == null || ret == DBNull.Value) return null;
            else if (Convert.ToInt32(ret) == 0) return null;
            else return ret;
        }

        internal IClienteAntigo geraClienteAntigo(Cliente from, object TIPO_CLIENTE, object idAntigo = null, PersistenceManager pm = null)
        {
            IClienteAntigo antigo = null;

            if (CToString(TIPO_CLIENTE) == "1")
                antigo = new Cliente1(idAntigo);
            else if (CToString(TIPO_CLIENTE) == "2")
                antigo = new Cliente2(idAntigo);
            else if (CToString(TIPO_CLIENTE) == "3")
                antigo = new Cliente3(idAntigo);
            else if (CToString(TIPO_CLIENTE) == "4")
                antigo = new Cliente4(idAntigo);
            else if (CToString(TIPO_CLIENTE) == "5")
                antigo = new Cliente5(idAntigo);

            if (pm != null)
            {
                pm.Load(antigo);
                antigo.ATIVO = from.ATIVO;
            }
            else
                antigo.ATIVO = true;

            antigo.BAIRRO = from.BAIRRO;
            antigo.CELULAR = from.CELULAR;
            antigo.CEP = from.CEP;
            antigo.CIDADE = from.CIDADE;
            antigo.COMPLEMENTO = from.COMPLEMENTO;
            antigo.CPF = from.CPF;
            antigo.DDD_C = from.DDD_C;
            antigo.DDD_F = from.DDD_F;
            antigo.DT_ALTERACAO = DateTime.MinValue;
            antigo.DT_CRIACAO = from.DT_CRIACAO;
            antigo.EMAIL = from.EMAIL;
            antigo.ENDERECO = from.ENDERECO;
            antigo.ESTADO = from.ESTADO;
            antigo.ID_COMO = from.ID_COMO;

            if (from.ID_COMO != null)
                antigo.ID_COMO = Convert.ToInt32(from.ID_COMO);
            else
                antigo.ID_COMO = 3; //3=bairro //antigo.ID_COMO = null;

            antigo.ID_EMPRESA = from.ID_EMPRESA;
            antigo.ID_OPERADORA = from.ID_OPERADORA;
            antigo.NASCIMENTO = from.NASCIMENTO;
            antigo.NOME = from.NOME;
            antigo.NUMERO = from.NUMERO;
            antigo.OBS = from.OBS;
            antigo.PONTO_REFERENCIA = from.PONTO_REFERENCIA;
            antigo.SENHA = from.SENHA;
            antigo.TEL_FIXO = from.TEL_FIXO;

            return antigo;
        }

        /// <summary>
        /// Gera o mapeamento 
        /// </summary>
        void setaIDOldDeCliente(ref Cliente novo, Ficha ficha, IClienteAntigo antigo, PersistenceManager pm)
        {
            //if (CToString(ficha.TIPO_CLIENTE) == "1")
            //    novo.ID_CLINICO_Old = Convert.ToInt32(antigo.ID);
            //else if (CToString(ficha.TIPO_CLIENTE) == "2")
            //    novo.ID_ENDO_Old = Convert.ToInt32(antigo.ID);
            //else if (CToString(ficha.TIPO_CLIENTE) == "3")
            //    novo.ID_ORTO_Old = Convert.ToInt32(antigo.ID);
            //else if (CToString(ficha.TIPO_CLIENTE) == "4")
            //    novo.ID_CIRURGIA_Old = Convert.ToInt32(antigo.ID);
            //else if (CToString(ficha.TIPO_CLIENTE) == "5")
            //    novo.ID_PEDIATRIA_Old = Convert.ToInt32(antigo.ID);

            NonQueryHelper.Instance.ExecuteNonQuery(
                string.Concat("insert into _mapp (map_newId,map_oldId,map_tipo,map_importado) values (", novo.ID, ", ", antigo.ID, ", ", this.TIPO_CLIENTE, ",0)"), 
                pm);
        }

        public static void AtualizarIDOld(Object idNova, object idOld)
        {
            NonQueryHelper.Instance.ExecuteNonQuery(
                string.Concat("update FICHA_CENTR set ficha_id_old=", idOld, " where ficha_id=", idNova), 
                null);
        }

        public void Salvar(FichaTipo tipo, IList<FichaPagto> pagtos, bool forcarNova = false)
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.BeginTransactionContext();

                try
                {
                    //1) obtem o id old de cliente a ser configurado
                    Cliente cli = new Cliente();
                    cli.ID = this.ID_CLIENTE;
                    pm.Load(cli);

                    if(!forcarNova)
                        this.ID_CLIENTE_Old = Ficha.ObtemIdAntigoDeCliente(cli, this, pm);

                    //2) Se o cliente não existe nas tabelas antigas, deve-se criá-lo
                    if (this.ID_CLIENTE_Old == null)
                    {
                        IClienteAntigo antigo = this.geraClienteAntigo(cli, this.TIPO_CLIENTE);
                        pm.Save(antigo);
                        this.setaIDOldDeCliente(ref cli, this, antigo, pm);
                        //pm.Save(cli);
                        this.ID_CLIENTE_Old = antigo.ID;
                    }

                    //3) Salva na tabela existente no sistema para obter o id old da ficha (CLI_MOVDIARIO)
                    FichaAntiga fAntiga = new FichaAntiga();
                    if (this.ID_Old != null)
                    {
                        fAntiga.ID = this.ID_Old;
                        pm.Load(fAntiga);
                        this.DATA = fAntiga.DATA;
                    }
                    else if (this.DATA == DateTime.MinValue)
                        this.DATA = DateTime.Now;

                    fAntiga.ATENDIDO = this.ATENDIDO ? 1 : 0;
                    fAntiga.DATA_USUARIO = this.DATA;
                    fAntiga.DATA = this.DATA;
                    fAntiga.ID_CLIENTE = this.ID_CLIENTE_Old;
                    fAntiga.ID_DENTISTA = this.ID_DENTISTA;
                    fAntiga.ID_EMPRESA = this.ID_EMPRESA;
                    fAntiga.ID_USUARIO = this.ID_USUARIO;
                    fAntiga.TIPO_CLIENTE = this.TIPO_CLIENTE;
                    fAntiga.TOTAL_ORCADO = this.TOTAL_ORCADO;
                    fAntiga.TOTAL = this.TOTAL;
                    fAntiga.CPF_PAGADOR = this.CPF_PAGADOR;
                    //pm.Save(fAntiga);

                    if(this.ID_Old == null) this.ID_Old = fAntiga.ID;

                    //4) Salva a ficha (ja na nova modelagem)
                    pm.Save(this);

                    ////5) tipo de ficha
                    //object aux = LocatorHelper.Instance.ExecuteScalar("select max(id) from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + this.ID_Old, null, null, pm);
                    //if (aux != null && aux != DBNull.Value) tipo.ID = aux;
                    //tipo.ID_FICHA = this.ID_Old;
                    //pm.Save(tipo);

                    //6) formas de pagto TODO: fazer uma inteligencia para NAO deletar tudo antes de inserir, mas verificar os existentes e atualizá-los, excluindo só o que for necessário
                    //NonQueryHelper.Instance.ExecuteNonQuery("delete from CLI_PGTO_MOV_DIA where ID_MOV_DIARIO=" + this.ID_Old, pm);
                    if (pagtos != null)
                    {
                        bool fichaCentralizadaSalva = false;
                        #region distinct de datas

                        List<DateTime> datas = new List<DateTime>();
                        List<FichaPagto> pagtosOrdenados = pagtos.OrderBy(p => p.DATA).ToList();
                        bool tem = false;
                        foreach (var p in pagtosOrdenados)
                        {
                            tem = false;

                            foreach (DateTime d in datas)
                            {
                                if (d.Day == p.DATA.Day && d.Month == p.DATA.Month && d.Year == p.DATA.Year)
                                {
                                    tem = true; break;
                                }
                            }

                            if (!tem)
                            {
                                datas.Add(p.DATA);
                            }
                        }

                        #endregion

                        fAntiga.TOTAL = 0;
                        List<FichaPagto> pagtosTrat = new List<FichaPagto>();

                        foreach (DateTime d in datas)
                        {
                            pagtosTrat.Clear();
                            fAntiga.TOTAL = 0;

                            foreach (var pagto in pagtosOrdenados)
                            {
                                if (pagto.DATA.Day != d.Day || pagto.DATA.Month != d.Month || pagto.DATA.Year != d.Year) continue;

                                if (pagto.ID == null && (pagto.DATA.Day == fAntiga.DATA.Day && pagto.DATA.Month == fAntiga.DATA.Month && pagto.DATA.Year == fAntiga.DATA.Year))
                                {
                                    fAntiga.TOTAL += pagto.VALOR; 
                                    fAntiga.DATA = pagto.DATA;
                                    fAntiga.DATA_USUARIO = pagto.DATA;
                                    pm.Save(fAntiga);
                                    pagto.ID_FICHA = fAntiga.ID;
                                    pm.Save(pagto);

                                    this.ID_Old = fAntiga.ID;
                                    pm.Save(this);

                                    //5) tipo de ficha
                                    object aux = LocatorHelper.Instance.ExecuteScalar("select max(id) from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + fAntiga.ID, null, null, pm);
                                    if (aux != null && aux != DBNull.Value) tipo.ID = aux;
                                    tipo.ID_FICHA = fAntiga.ID;
                                    pm.Save(tipo);
                                }
                                else
                                {
                                    fAntiga.ID = null;
                                    fAntiga.TOTAL += pagto.VALOR;
                                    fAntiga.DATA = pagto.DATA;
                                    fAntiga.DATA_USUARIO = pagto.DATA;
                                    pm.Save(fAntiga);
                                    pagto.ID_FICHA = fAntiga.ID;
                                    pm.Save(pagto);

                                    //if (!fichaCentralizadaSalva)
                                    //{
                                    this.ID_Old = fAntiga.ID;
                                    pm.Save(this);
                                    fichaCentralizadaSalva = true;
                                    //}

                                    //5) tipo de ficha
                                    object aux = LocatorHelper.Instance.ExecuteScalar("select max(id) from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + fAntiga.ID, null, null, pm);
                                    if (aux != null && aux != DBNull.Value) tipo.ID = aux;
                                    else tipo.ID = null;
                                    tipo.ID_FICHA = fAntiga.ID;
                                    pm.Save(tipo);
                                }
                            }
                        }
                    }
                    else
                    {
                        pm.Save(fAntiga);

                        //5) tipo de ficha
                        object aux = LocatorHelper.Instance.ExecuteScalar("select max(id) from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + fAntiga.ID, null, null, pm);
                        if (aux != null && aux != DBNull.Value) tipo.ID = aux;
                        else tipo.ID = null;
                        tipo.ID_FICHA = fAntiga.ID;
                        pm.Save(tipo);

                        this.ID_Old = fAntiga.ID;
                        pm.Save(this);
                    }

                    //pm.Rollback(); 
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
        }

        public static IList<Ficha> CarregarPorCliente(object clienteId)
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.UseSingleCommandInstance();

                IList<Ficha> lista = LocatorHelper.Instance.ExecuteQuery<Ficha>(
                    string.Concat("select FICHA_CENTR.*,CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES_CENTR.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha from FICHA_CENTR ",
                                  "     inner join CLI_USUARIOS on ficha_destistaId = CLI_USUARIOS.ID ",
                                  "     inner join CLI_CLIENTES_CENTR on ficha_clienteId = CLI_CLIENTES_CENTR.ID ",
                                  "     inner join CLI_TIPO_CLIENTE on ficha_tipoCliente = CLI_TIPO_CLIENTE.ID ",
                                  "     left join CLI_OP_MOVDIARIO on ficha_id_old = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                  "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                  " where CLI_CLIENTES_CENTR.ID = ", clienteId, " order by ficha_tipoCliente asc, ficha_id desc"),
                    typeof(Ficha), pm);

                if (lista == null) lista = new List<Ficha>();

                Cliente cli = new Cliente();
                cli.ID = clienteId;
                pm.Load(cli);

                string qry = "";

                //IList<FichaAntiga> antigas = new List<FichaAntiga>();

                IList<Mapp> mapa = Mapp.Carregar(cli.ID, pm);

                if (mapa != null && mapa.Count > 0)
                {
                    foreach (var m in mapa)
                    {
                        #region Cirurgia

                        if (m.TIPO == 4) 
                        {
                            //antigas = FichaAntiga.Carregar(m.idOLD, m.TIPO, pm);

                            qry = string.Concat("select CLI_MOVDIARIO.ID,CLI_MOVDIARIO.tipo_cliente,CLI_MOVDIARIO.ID_USUARIO,CLI_MOVDIARIO.ID_DENTISTA,CLI_MOVDIARIO.VALOR,CLI_MOVDIARIO.DATA_USUARIO,CLI_MOVDIARIO.ID_CLIENTE,TOTAL_PRIMEIRO,  CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES4.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha ",
                                "from CLI_MOVDIARIO ",
                                "     inner join CLI_USUARIOS on CLI_MOVDIARIO.ID_DENTISTA = CLI_USUARIOS.ID ",
                                "     inner join CLI_CLIENTES4 on CLI_MOVDIARIO.ID_CLIENTE = CLI_CLIENTES4.ID ",
                                "     inner join CLI_TIPO_CLIENTE on CLI_MOVDIARIO.tipo_cliente = CLI_TIPO_CLIENTE.ID ",
                                "     left join CLI_OP_MOVDIARIO on CLI_MOVDIARIO.ID = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                " where CLI_MOVDIARIO.ID not in (select ficha_id_old from FICHA_CENTR where ficha_tipoCliente=4 and ficha_id_old=CLI_MOVDIARIO.ID) and CLI_MOVDIARIO.tipo_cliente=4 and CLI_CLIENTES4.ID = ", m.idOLD,
                                " order by CLI_OP_MOVDIARIO.ID DESC");

                            IList<FichaAntiga> _antigas4 = LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(qry, typeof(FichaAntiga), pm);

                            if (_antigas4 != null && _antigas4.Count > 0)
                            {
                                adicionaAntigaNaColecao(_antigas4[_antigas4.Count - 1], ref lista);
                            }
                        }
                        #endregion

                        #region Clinico

                        if (m.TIPO == 1)
                        {
                            qry = string.Concat("select CLI_MOVDIARIO.ID,CLI_MOVDIARIO.tipo_cliente,CLI_MOVDIARIO.ID_USUARIO,CLI_MOVDIARIO.ID_DENTISTA,CLI_MOVDIARIO.VALOR,CLI_MOVDIARIO.DATA_USUARIO,CLI_MOVDIARIO.ID_CLIENTE,TOTAL_PRIMEIRO,  CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha ",
                                "from CLI_MOVDIARIO ",
                                "     inner join CLI_USUARIOS on CLI_MOVDIARIO.ID_DENTISTA = CLI_USUARIOS.ID ",
                                "     inner join CLI_CLIENTES on CLI_MOVDIARIO.ID_CLIENTE = CLI_CLIENTES.ID ",
                                "     inner join CLI_TIPO_CLIENTE on CLI_MOVDIARIO.tipo_cliente = CLI_TIPO_CLIENTE.ID ",
                                "     left join CLI_OP_MOVDIARIO on CLI_MOVDIARIO.ID = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                " where CLI_MOVDIARIO.ID not in (select ficha_id_old from FICHA_CENTR where ficha_tipoCliente=1 and ficha_id_old=CLI_MOVDIARIO.ID) and CLI_MOVDIARIO.tipo_cliente=1 and CLI_CLIENTES.ID = ", m.idOLD,
                                " order by CLI_OP_MOVDIARIO.ID DESC");
                                //" order by CLI_OP_MOVDIARIO.ID DESC");

                            IList<FichaAntiga> _antigas = LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(qry, typeof(FichaAntiga), pm);

                            if (_antigas != null && _antigas.Count > 0)
                            {
                                adicionaAntigaNaColecao(_antigas[_antigas.Count - 1], ref lista);
                            }
                        }
                        #endregion

                        #region Endo

                        if (m.TIPO == 2)
                        {
                            qry = string.Concat("select CLI_MOVDIARIO.ID,CLI_MOVDIARIO.tipo_cliente,CLI_MOVDIARIO.ID_USUARIO,CLI_MOVDIARIO.ID_DENTISTA,CLI_MOVDIARIO.VALOR,CLI_MOVDIARIO.DATA_USUARIO,CLI_MOVDIARIO.ID_CLIENTE,TOTAL_PRIMEIRO,  CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES2.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha ",
                                "from CLI_MOVDIARIO ",
                                "     inner join CLI_USUARIOS on CLI_MOVDIARIO.ID_DENTISTA = CLI_USUARIOS.ID ",
                                "     inner join CLI_CLIENTES2 on CLI_MOVDIARIO.ID_CLIENTE = CLI_CLIENTES2.ID ",
                                "     inner join CLI_TIPO_CLIENTE on CLI_MOVDIARIO.tipo_cliente = CLI_TIPO_CLIENTE.ID ",
                                "     left join CLI_OP_MOVDIARIO on CLI_MOVDIARIO.ID = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                " where CLI_MOVDIARIO.ID not in (select ficha_id_old from FICHA_CENTR where ficha_tipoCliente=2 and ficha_id_old=CLI_MOVDIARIO.ID) and CLI_MOVDIARIO.tipo_cliente=2 and CLI_CLIENTES2.ID = ", m.idOLD,
                                " order by CLI_OP_MOVDIARIO.ID DESC");

                            IList<FichaAntiga> _antigas = LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(qry, typeof(FichaAntiga), pm);

                            if (_antigas != null && _antigas.Count > 0)
                            {
                                adicionaAntigaNaColecao(_antigas[_antigas.Count - 1], ref lista);
                            }
                        }
                        #endregion

                        #region Orto

                        if (m.TIPO == 3)
                        {
                            qry = string.Concat("select CLI_MOVDIARIO.ID,CLI_MOVDIARIO.tipo_cliente,CLI_MOVDIARIO.ID_USUARIO,CLI_MOVDIARIO.ID_DENTISTA,CLI_MOVDIARIO.VALOR,CLI_MOVDIARIO.DATA_USUARIO,CLI_MOVDIARIO.ID_CLIENTE,TOTAL_PRIMEIRO,  CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES3.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha ",
                                "from CLI_MOVDIARIO ",
                                "     inner join CLI_USUARIOS on CLI_MOVDIARIO.ID_DENTISTA = CLI_USUARIOS.ID ",
                                "     inner join CLI_CLIENTES3 on CLI_MOVDIARIO.ID_CLIENTE = CLI_CLIENTES3.ID ",
                                "     inner join CLI_TIPO_CLIENTE on CLI_MOVDIARIO.tipo_cliente = CLI_TIPO_CLIENTE.ID ",
                                "     left join CLI_OP_MOVDIARIO on CLI_MOVDIARIO.ID = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                " where CLI_MOVDIARIO.ID not in (select ficha_id_old from FICHA_CENTR where ficha_tipoCliente=3 and ficha_id_old=CLI_MOVDIARIO.ID) and CLI_MOVDIARIO.tipo_cliente=3 and CLI_CLIENTES3.ID = ", m.idOLD,
                                " order by CLI_OP_MOVDIARIO.ID DESC");

                            IList<FichaAntiga> _antigas = LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(qry, typeof(FichaAntiga), pm);

                            if (_antigas != null && _antigas.Count > 0)
                            {
                                adicionaAntigaNaColecao(_antigas[_antigas.Count - 1], ref lista);
                            }
                        }
                        #endregion

                        #region Pediatria

                        if (m.TIPO == 5)
                        {
                            qry = string.Concat("select CLI_MOVDIARIO.ID,CLI_MOVDIARIO.tipo_cliente,CLI_MOVDIARIO.ID_USUARIO,CLI_MOVDIARIO.ID_DENTISTA,CLI_MOVDIARIO.VALOR,CLI_MOVDIARIO.DATA_USUARIO,CLI_MOVDIARIO.ID_CLIENTE,TOTAL_PRIMEIRO,  CLI_USUARIOS.NOME as DentistaNome, CLI_CLIENTES5.NOME as PacienteNome, CLI_TIPO_CLIENTE.TIPO_CLIENTE as Especialidade, CLI_TIPOMOVIMENTO.TIPO_MOVIMENTO as TipoFicha ",
                                "from CLI_MOVDIARIO ",
                                "     inner join CLI_USUARIOS on CLI_MOVDIARIO.ID_DENTISTA = CLI_USUARIOS.ID ",
                                "     inner join CLI_CLIENTES5 on CLI_MOVDIARIO.ID_CLIENTE = CLI_CLIENTES5.ID ",
                                "     inner join CLI_TIPO_CLIENTE on CLI_MOVDIARIO.tipo_cliente = CLI_TIPO_CLIENTE.ID ",
                                "     left join CLI_OP_MOVDIARIO on CLI_MOVDIARIO.ID = CLI_OP_MOVDIARIO.ID_MOVDIARIO ",
                                "     left join CLI_TIPOMOVIMENTO on CLI_OP_MOVDIARIO.ID_CODIGO = CLI_TIPOMOVIMENTO.ID ",
                                " where CLI_MOVDIARIO.ID not in (select ficha_id_old from FICHA_CENTR where ficha_tipoCliente=5 and ficha_id_old=CLI_MOVDIARIO.ID) and CLI_MOVDIARIO.tipo_cliente=5 and CLI_CLIENTES5.ID = ", m.idOLD,
                                " order by CLI_OP_MOVDIARIO.ID DESC");

                            IList<FichaAntiga> _antigas = LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(qry, typeof(FichaAntiga), pm);

                            if (_antigas != null)
                            {
                                if (_antigas != null && _antigas.Count > 0)
                                {
                                    adicionaAntigaNaColecao(_antigas[_antigas.Count - 1], ref lista);
                                }
                            }
                        }
                        #endregion
                    }
                }

                

                if (lista != null)
                    return lista.OrderByDescending(f => f.DATA).ToList<Ficha>();
                else
                    return null;
            }
        }

        static void adicionaAntigaNaColecao(FichaAntiga _antiga, ref IList<Ficha> fichas)
        {
            foreach (var _ficha in fichas)
            {
                //não adiciona se ja existir na coleção
                if (Convert.ToString(_ficha.ID_Old) == Convert.ToString(_antiga.ID))
                {
                    _ficha.TipoFicha += "," + _antiga.TipoFicha;
                    return;
                }
            }

            Ficha ficha = new Ficha();

            if (_antiga.ATENDIDO == 1)
                ficha.ATENDIDO = true;
            else
                ficha.ATENDIDO = false;

            ficha.DATA = _antiga.DATA_USUARIO;
            ficha.DentistaNome = _antiga.DentistaNome;
            ficha.Especialidade = _antiga.Especialidade;
            ficha.ID = -1;
            ficha.ID_CLIENTE = -1;
            ficha.ID_CLIENTE_Old = _antiga.ID_CLIENTE;
            ficha.ID_DENTISTA = _antiga.ID_DENTISTA;
            ficha.ID_EMPRESA = _antiga.ID_EMPRESA;
            ficha.ID_Old = _antiga.ID;
            ficha.ID_USUARIO = _antiga.ID_USUARIO;
            ficha.PacienteNome = _antiga.PacienteNome;
            ficha.TIPO_CLIENTE = _antiga.TIPO_CLIENTE; //Tipo
            ficha.TipoFicha = _antiga.TipoFicha;
            ficha.TOTAL = _antiga.TOTAL;
            ficha.TOTAL_ORCADO = _antiga.TOTAL_ORCADO;

            fichas.Add(ficha);
        }

        public static IList<FichaTipo> CarregarTipoPorIdOld(object idFichaOld)
        {
            string sql = "* from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + idFichaOld;

            return LocatorHelper.Instance.ExecuteQuery<FichaTipo>(sql, typeof(FichaTipo));
        }

        public static IList<FichaPagto> CarregarPagtoPorIdOld(object idFichaOld)
        {
            string sql = "CLI_PGTO_MOV_DIA.*,CLI_FORMA_PAGAMENTO.FORMA_PAGAMENTO as DESCR_FORMA_PAGAMENTO from CLI_PGTO_MOV_DIA inner join CLI_FORMA_PAGAMENTO on CLI_FORMA_PAGAMENTO.ID = CLI_PGTO_MOV_DIA.ID_FORMA_PAGAMENTO where ID_MOV_DIARIO=" + idFichaOld;

            return LocatorHelper.Instance.ExecuteQuery<FichaPagto>(sql, typeof(FichaPagto));
        }
    }

    /// <summary>
    /// Se é liquidada, orçamento contratado, etc
    /// </summary>
    [DBTable("CLI_OP_MOVDIARIO")]
    public class FichaTipo : EntityBase, IPersisteableEntity
    {
        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        [DBFieldInfo("ID_MOVDIARIO", FieldType.Single)]
        public object ID_FICHA
        {
            get;
            set;
        }

        //Se é liquidado, orçamento contratado, etc
        [DBFieldInfo("ID_CODIGO", FieldType.Single)]
        public object CODIGO
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// Forma de pagamento
    /// </summary>
    [Serializable]
    [DBTable("CLI_PGTO_MOV_DIA")]
    public class FichaPagto : EntityBase, IPersisteableEntity
    {
        public void Salvar()
        {
            base.Salvar(this);
        }

        public void Carregar()
        {
            base.Carregar(this);
        }

        public void Remover()
        {
            base.Remover(this);
        }

        public static IList<FichaPagto> Carregar(int clienteAntigoId, int tipo)
        {
            string sql = string.Concat(
                "CLI_PGTO_MOV_DIA.*,CLI_USUARIOS.NOME as NOME_DENTISTA,CLI_MOVDIARIO.DATA_USUARIO,CLI_FORMA_PAGAMENTO.FORMA_PAGAMENTO as DESCR_FORMA_PAGAMENTO ",
                " from CLI_PGTO_MOV_DIA ",
                " inner join CLI_FORMA_PAGAMENTO on CLI_FORMA_PAGAMENTO.ID = CLI_PGTO_MOV_DIA.ID_FORMA_PAGAMENTO ",
                " inner join CLI_MOVDIARIO on CLI_MOVDIARIO.ID=CLI_PGTO_MOV_DIA.ID_MOV_DIARIO ",
                " left join CLI_USUARIOS on CLI_USUARIOS.ID = CLI_MOVDIARIO.ID_DENTISTA ",
                " where CLI_MOVDIARIO.tipo_cliente=", tipo, " and CLI_MOVDIARIO.ID_CLIENTE=", clienteAntigoId,
                " order by CLI_MOVDIARIO.DATA_USUARIO");

            return LocatorHelper.Instance.ExecuteQuery<FichaPagto>(sql, typeof(FichaPagto));
        }

        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        [DBFieldInfo("ID_MOV_DIARIO", FieldType.Single)]
        public object ID_FICHA
        {
            get;
            set;
        }

        //Forma de pagto
        [DBFieldInfo("ID_FORMA_PAGAMENTO", FieldType.Single)]
        public object ID_FORMA
        {
            get;
            set;
        }

        [DBFieldInfo("VALOR", FieldType.Single)]
        public decimal VALOR
        {
            get;
            set;
        }

        //[DBFieldInfo("CPF", FieldType.Single)]
        public string CPF
        {
            get;
            set;
        }

        [DBFieldInfo("num_autorizacao", FieldType.Single)]
        public string AUTORIZACAO
        {
            get;
            set;
        }

        [DBFieldInfo("DATA", FieldType.Single)]
        public DateTime DATA
        {
            get;
            set;
        }

        /// <summary>
        /// Nome da forma de pagamento
        /// </summary>
        [Joinned("DESCR_FORMA_PAGAMENTO")]
        public string DESCR_FORMA
        {
            get;
            set;
        }

        [Joinned("DATA_USUARIO")]
        public DateTime FICHA_DATA_USUARIO
        {
            get;
            set;
        }

        [Joinned("NOME_DENTISTA")]
        public string NOME_DENTISTA
        {
            get;
            set;
        }

        #endregion
    }

    [DBTable("CLI_MOVDIARIO")]
    public class FichaAntiga : EntityBase, IPersisteableEntity
    {
        #region properties

        [DBFieldInfo("ID", FieldType.PrimaryKeyAndIdentity)]
        public object ID
        {
            get;
            set;
        }

        [DBFieldInfo("ID_USUARIO", FieldType.Single)]
        public object ID_USUARIO
        {
            get;
            set;
        }

        [DBFieldInfo("ID_DENTISTA", FieldType.Single)]
        public object ID_DENTISTA
        {
            get;
            set;
        }

        [DBFieldInfo("VALOR", FieldType.Single)]
        public decimal TOTAL
        {
            get;
            set;
        }

        [DBFieldInfo("DATA_USUARIO", FieldType.Single)]
        public DateTime DATA_USUARIO
        {
            get;
            set;
        }

        [DBFieldInfo("DATA", FieldType.Single)]
        public DateTime DATA
        {
            get;
            set;
        }

        [DBFieldInfo("ID_CLIENTE", FieldType.Single)]
        public object ID_CLIENTE
        {
            get;
            set;
        }

        [DBFieldInfo("ID_EMPRESA", FieldType.Single)]
        public object ID_EMPRESA
        {
            get;
            set;
        }

        [DBFieldInfo("ATENDIDO", FieldType.Single)]
        public int ATENDIDO
        {
            get;
            set;
        }

        [DBFieldInfo("cpf_pagador", FieldType.Single)]
        public string CPF_PAGADOR
        {
            get;
            set;
        }

        [DBFieldInfo("TIPO_CLIENTE", FieldType.Single)]
        public object TIPO_CLIENTE
        {
            get;
            set;
        }

        [DBFieldInfo("TOTAL_PRIMEIRO", FieldType.Single)]
        public decimal TOTAL_ORCADO
        {
            get;
            set;
        }

        [Joinned("DentistaNome")]
        public string DentistaNome
        {
            get;
            set;
        }

        [Joinned("PacienteNome")]
        public string PacienteNome
        {
            get;
            set;
        }

        [Joinned("Especialidade")]
        public string Especialidade
        {
            get;
            set;
        }

        [Joinned("TipoFicha")]
        public string TipoFicha
        {
            get;
            set;
        }

        #endregion

        public void Carregar()
        {
            base.Carregar(this);
        }

        public void Salvar(FichaTipo tipo, IList<FichaPagto> pagtos)
        {
            using (PersistenceManager pm = new PersistenceManager())
            {
                pm.BeginTransactionContext();

                try
                {
                    //TODO: necessario verificar se nao existe uma ficha centralizada ???
                    pm.Save(this);

                    //tipo de ficha
                    object aux = LocatorHelper.Instance.ExecuteScalar("select max(id) from CLI_OP_MOVDIARIO where ID_MOVDIARIO=" + this.ID, null, null, pm);
                    if (aux != null && aux != DBNull.Value) tipo.ID = aux;
                    tipo.ID_FICHA = this.ID;
                    pm.Save(tipo);

                    //formas de pagto TODO: fazer uma inteligencia para NAO deletar tudo antes de inserir, mas verificar os existentes e atualizá-los, excluindo só o que for necessário
                    //NonQueryHelper.Instance.ExecuteNonQuery("delete from CLI_PGTO_MOV_DIA where ID_MOV_DIARIO=" + this.ID, pm);

                    if (pagtos != null)
                    {
                        foreach (var pgto in pagtos)
                        {
                            if (pgto.ID == null || pgto.ID_FICHA == null) //se nao fizer isso, o sistema passa ERRONEAMENTE os pagtos de uma ficha para a outra
                            {
                                pgto.ID_FICHA = this.ID;
                            }

                            pm.Save(pgto);
                        }
                    }

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
        }

        public void Salvar()
        {
            base.Salvar(this);
        }

        public static IList<FichaAntiga> Carregar(int clienteAntigoId, int tipo, PersistenceManager pm = null)
        {
            string sql = string.Concat(
                "CLI_MOVDIARIO.* from CLI_MOVDIARIO ",
                " where CLI_MOVDIARIO.tipo_cliente=", tipo, " and CLI_MOVDIARIO.ID_CLIENTE=", clienteAntigoId,
                " order by CLI_MOVDIARIO.DATA_USUARIO desc, CLI_MOVDIARIO.ID desc");

            return LocatorHelper.Instance.ExecuteQuery<FichaAntiga>(sql, typeof(FichaAntiga), pm);
        }
    }
}
/*
 
 INSERT INTO CLI_MOVDIARIO (
  ID_USUARIO,ID_DENTISTA,VALOR,  DATA_USUARIO,ID_CLIENTE,ID_EMPRESA,ATENDIDO,TIPO_CLIENTE,TOTAL_PRIMEIRO) VALUES(
  '1',       '16',       '0.00','2017/3/25',  '407',     '1',       '0',     '2','452.00')
  
 
 
  
  
  //string sql = string.Concat(
                        //    "INSERT INTO CLI_MOVDIARIO (",
                        //    "ID_USUARIO,ID_DENTISTA,VALOR,  DATA_USUARIO,ID_CLIENTE,ID_EMPRESA,ATENDIDO,TIPO_CLIENTE,TOTAL_PRIMEIRO) VALUES(",
                        //    this.ID_USUARIO, ",", this.ID_DENTISTA, ",'", this.TOTAL, "','", this.DATA.ToString("yyyy-MM-dd HH:mm:ss"), "',", this.ID_CLIENTE_Old, ",", this.ID_EMPRESA, ",", this.ATENDIDO, ",", this.TIPO_CLIENTE, ", '", this.TOTAL_ORCADO, "') ",
                        //    "select @@identity from CLI_MOVDIARIO ");

                        //this.ID_Old = LocatorHelper.Instance.ExecuteScalar(sql, null, null, pm);
  
  
  
 */