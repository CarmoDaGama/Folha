using MySql.Data.MySqlClient;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Data
{
    public class Motor
    {
        List<string> ListaLog = new List<string>();

        public Motor()
        {
              
        }

        public string CriaBancoDados(string Server, string Porta)
        {
            try
            {
                String StrConecao = @"server=" + Server + ";userid=root;password=VisualBasic;Port=" + Porta;
                string Sql = "CREATE DATABASE IF NOT EXISTS `FolhaERP`;";

                MySqlConnection myConn = new MySqlConnection(StrConecao);
                MySqlCommand myCommand = new MySqlCommand(Sql, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    return "\n1; Base de Dados Criada!\n";
                }
                catch (MySqlException ex)
                {
                    string txt = " Erro a criar base de dados \n - Erro: " + ex.Message + "!";
                    return txt;
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
            }
            catch (Exception er)
            {
                string txt = " Erro a criar base de dados \n Erro: " + er.Message + "!";
                return txt;
            }
        }

        public void CriaouActualizaTabelas()
        {
         
            Tabela tbBD = new Tabela("App", "codigo int(11)", true);
            string[] CamposBD = { "VersaoBD int(11)", "Instalacao dateTime" };
            tbBD.addCampo(CamposBD); tbBD.gravarTabela();


            Tabela tbEMpresa = new Tabela("Empresa", "codigo int(11)", true);
            string[] Empresa = {
                "Nome varchar(50)",
                "NIF varchar(100)",
                "Morada varchar(200)",
                "Telefones varchar(100)",
                "WebSite varchar(100)",
                "Email varchar(100)",
                "Logotipo LongBlob",
                "Validou int(11)",
                "TipoEmpresa  varchar(100)",
                "Responsavel  varchar(100)",
                "Slogan  varchar(100)" };
            tbEMpresa.addCampo(Empresa);
            tbEMpresa.gravarTabela();


            Tabela tbPerfil = new Tabela("Perfil", "codigo int(11)", true);
            string[] cpPerfil = { "Descricao varchar(50)", "Acessos Text" };
            tbPerfil.addCampo(cpPerfil);
            tbPerfil.addUnique("Descricao", "Perfil");
            tbPerfil.gravarTabela();


            Tabela tbLicensas = new Tabela("Licensa", "codigo int(11)", true);
            string[] CamposLic = { "Licensa Text" };
            tbLicensas.addCampo(CamposLic);
            tbLicensas.gravarTabela();


            Tabela tbDefFactura = new Tabela("DefFactura", "codigo int(11)", true);
            string[] DefFactura = { "Detalhes varchar(500)", "Validade varchar(60)", "Decreto varchar(500)" };
            tbDefFactura.addCampo(DefFactura);
            tbDefFactura.gravarTabela();

            Tabela tbDocumentoPagamento = new Tabela("DocumentoPagamento", "Codigo int(11)", true);
            string[] DefDocumentoPagamento = {
                "DescricaoDocumento varchar(300)",
                "CodRecibo int(11)",
                "DataOperacao Date",
                "Taxa decimal(18,2)", 
                "Valor decimal(18,2)", 

            };
            tbDocumentoPagamento.addCampo(DefDocumentoPagamento);
            tbDocumentoPagamento.gravarTabela();


            Tabela tbDefPreco = new Tabela("DefPreco", "codigo int(11)", true);
            string[] DefPreco = { "Preco1 decimal(18,2)", "Preco2 decimal(18,2)", "Preco3 decimal(18,2)" };
            tbDefPreco.addCampo(DefPreco);
            tbDefPreco.gravarTabela();

            Tabela tbTemasPc = new Tabela("PC_Temas", "CodPC varchar(60)", false);
            string[] TemasPC = { "Descricao varchar(60)" };
            tbTemasPc.addCampo(TemasPC);


            Tabela GavetasPC = new Tabela("Pc_Gavetas", "CodPc varchar(30)", false);
            string[] cpGavetasPC = { "Dispositivo varchar(60)", "Porta varchar(60)", "Comando varchar(60)" };
            GavetasPC.addCampo(cpGavetasPC);
            GavetasPC.gravarTabela();

            Tabela tbImpressoraspc = new Tabela("ConfigMaquinas", "CodPc varchar(200)", false);
            string[] Impressorascp = { "Predifinida varchar(200)", "Ticket varchar(200)", "A4 varchar(200)", "AreaRestaurante varchar(200)" };
            tbImpressoraspc.addCampo(Impressorascp);
            tbImpressoraspc.gravarTabela();

            Tabela tbRemoto = new Tabela("Remoto", "CodPc varchar(60)", false);
            string[] ConfigServidor = { "Iniciar_Windows int(11) ", "Sincronizar int(11)", "Temposync varchar(60) ", "Directorio varchar(60) ", "DataFim varchar(60) " };
            tbRemoto.addCampo(ConfigServidor);
            tbRemoto.gravarTabela();

            Tabela PrintMonitor = new Tabela("ConfigPrintMonitor", "CodPc varchar(60)", false);
            string[] ConfigPrintMonitor = { "Servidor varchar(60)", "IP varchar(60)", "Banco varchar(60)", "Usuario varchar(60)", "Senha varchar(60)", "EMail varchar(60)", "Enviar varchar(60)" };
            PrintMonitor.addCampo(ConfigPrintMonitor);
            PrintMonitor.gravarTabela();

            Tabela tbImpressorasMonitoradas = new Tabela("ImpressorasaMonitorar", "CodPc varchar(20)", false);
            string[] Monitorar = { "Impressora varchar(60)", "Tarifa varchar(60)", "Custo varchar(60)" };
            tbImpressorasMonitoradas.addCampo(Monitorar);

            Tabela tbImpressoesLiberadas = new Tabela("ImpressoesLiberadas", "CodPc varchar(20)", false);
            string[] cpImprimir = { "CodMaquina int(11)", "CodDocumento int(11)", "Proprietario varchar(60)", "CodMonitora int(11)", "Paginas int(11)", "Tarifa varchar(60)", "Preço varchar(60)", "Total varchar(60)", "status int(11)" };
            tbImpressoesLiberadas.addCampo(cpImprimir);

            Tabela tbOperacoes = new Tabela("Operacoes", "codigo int(11)", true);
            string[] Operacoes = { "Nome varchar(100)", "MovStk varchar(20)", "MovFin varchar(50)", "APP varchar(4)", "Entidade varchar(30)", "Sistema int(11)", "Pos int(11)", "Hotel int(11)", "Restaurante int(11)", "Escolar int(11)", "Hospitalar int(11)", "Pt int(11)", "Cyber int(11)", "Rh int(11)", "LAV int(11)", "Viagem int(11)" };
            tbOperacoes.addCampo(Operacoes);
            tbOperacoes.addUnique("Nome", "Operacoes");
            tbOperacoes.gravarTabela();

            Tabela tbDefOperacao = new Tabela("DefOperacao", "codigo int(11)", true);
            string[] DefOperacao = { "CodOperacoes int(11)", "Descricao Text", "Reembolso varchar(50)" };
            tbDefOperacao.addCampo(DefOperacao);
            tbDefOperacao.addChaveEstrangeira("CodOperacoes", "Operacoes", "codigo");
            tbDefOperacao.gravarTabela();

            Tabela tbPais = new Tabela("Pais", "codigo int(11)", true);
            string[] Pais = { "Descricao varchar(100)" };
            tbPais.addCampo(Pais);
            tbPais.addUnique("Descricao", "Pais"); tbPais.gravarTabela();

            Tabela tbCompanhia = new Tabela("Companhia", "codigo int(11)", true);
            string[] Companhia = { "Descricao varchar(100)" };
            tbCompanhia.addCampo(Companhia);
            tbCompanhia.addUnique("Descricao", "Companhia");
            tbCompanhia.gravarTabela();

            Tabela tbTipologia = new Tabela("Tipologia", "codigo int(11)", true);
            string[] Tipologia = { "Descricao varchar(100)" };
            tbTipologia.addCampo(Tipologia);
            tbTipologia.addUnique("Descricao", "Tipologia");
            tbTipologia.gravarTabela();

            Tabela tbCidades = new Tabela("Cidades", "codigo int(11)", true);
            string[] Cidades = { "CodPais int(11)", "Descricao varchar(100)", "status int(11)" };
            tbCidades.addCampo(Cidades);
            tbCidades.addUnique("Descricao", "Cidades");
            tbCidades.addChaveEstrangeira("CodPais", "Pais", "Codigo");
            tbCidades.gravarTabela();


            Tabela TbTipoEntidade = new Tabela("TipoEntidade", "codigo int(11)", true);
            string[] TipoEntidade = { "descricao varchar(100)" };
            TbTipoEntidade.addCampo(TipoEntidade);
            TbTipoEntidade.addUnique("descricao", "TipoEntidade");
            TbTipoEntidade.gravarTabela();


            Tabela tbCondicoesPagamentos = new Tabela("CondicoesPagamentos", "Codigo int(11)", true);
            string[] CondicoesPagamentos = { "Descricao varchar(100)", "Dias int(11)" };
            tbCondicoesPagamentos.addCampo(CondicoesPagamentos);
            tbCondicoesPagamentos.gravarTabela();

            Tabela tbEntidades = new Tabela("Entidades", "Codigo int(11)", true);
            string[] Entidades = {
                "Nome varchar(100)",
                "Nif varchar(30)",
                "CodTipo int(11)",
                "Limite varchar(20)",
                "CodPais int(11)",
                "Cliente int(11)",
                "Fornecedor int(11)",
                "Funcionario int(11)",
                "Foto LongBlob",
                "Status int(11) default 1",
                "CodCondicaoPagamento int(11)",
            };
            tbEntidades.addCampo(Entidades);
            tbEntidades.addChaveEstrangeira("CodPais", "Pais", "codigo");
            tbEntidades.addChaveEstrangeira("CodTipo", "TipoEntidade", "codigo");
            tbEntidades.addChaveEstrangeira("CodCondicaoPagamento", "CondicoesPagamentos", "Codigo");
            tbEntidades.gravarTabela();


            Tabela tbUsuarios = new Tabela("Usuarios", "codigo int(11)", true);
            string[] Usuarios = {
                "Login varchar(20)",
                "CodEntidade int(11)",
                "Nome varchar(50)",
                "Senha varchar(50)",
                "CodPerfil int(11)",
                "Alterado tinyint"
            };
            tbUsuarios.addCampo(Usuarios);
            tbUsuarios.addUnique("Login", "Usuarios");
            tbUsuarios.addChaveEstrangeira("CodPerfil", "Perfil", "codigo");
            tbUsuarios.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbUsuarios.gravarTabela();



            Tabela TbContaCorrente = new Tabela("ContaCorrente", "CodEntidade int(11)", false);
            string[] ContaCorrente = { "Senha varchar(100)" };
            TbContaCorrente.addCampo(ContaCorrente);
            TbContaCorrente.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            TbContaCorrente.gravarTabela();

            Tabela tbDefinicoes = new Tabela("Definicoes", "Codigo int(11)", true);
            string[] Definicoes = { "HoraCheckin varchar(3)", "HoraChecOut varchar(3)", "PrazoFactura varchar(3)", "EmailPosReserva varchar(3)" };
            tbDefinicoes.addCampo(Definicoes); tbDefinicoes.gravarTabela();

            Tabela tbBackUpAutomatico = new Tabela("BackUpAutomatico", "Codigo int(11)", true);
            string[] BackUpAutomatico = { "Data varchar(100)", "Horas varchar(20)", "Local varchar(500)", "NovoCampo varchar(50)", };
            tbBackUpAutomatico.addCampo(BackUpAutomatico);
            tbBackUpAutomatico.gravarTabela();

            Tabela tbDefHotel = new Tabela("DefHotel", "codigo int(11)", true);
            string[] DefHotel = { "Checkin varchar(10)", "CheckOut varchar(10)", "CTempo int(11)", "Automatico int(11)", "Horas int(11)", "Consumidor int(11)" };
            tbDefHotel.addCampo(DefHotel);
            tbDefHotel.gravarTabela();

            Tabela tbSectores = new Tabela("Sectores", "codigo int(11)", true);
            string[] Sectores = { "Descricao varchar(50)" };
            tbSectores.addCampo(Sectores);
            tbSectores.addUnique("Descricao", "Sectores");
            tbSectores.gravarTabela();

            Tabela tbReligiao = new Tabela("Religiao", "codigo int(11)", true);
            string[] Religiao = { "Descricao varchar(50)" };
            tbReligiao.addCampo(Religiao);
            tbReligiao.addUnique("Descricao", "Religiao");
            tbReligiao.gravarTabela();

            Tabela tbSalas = new Tabela("Salas", "codigo int(11)", true);
            string[] Salas = { "Descricao varchar(50)" };
            tbSalas.addCampo(Salas);
            tbSalas.addUnique("Descricao", "Salas");
            tbSalas.gravarTabela();


            Tabela tbTipoDuracao = new Tabela("TipoDuracao", "codigo int(11)", true);
            string[] TipoDuracao = { "Descricao varchar(50)" };
            tbTipoDuracao.addCampo(TipoDuracao);
            tbTipoDuracao.addUnique("Descricao", "TipoDuracao");
            tbTipoDuracao.gravarTabela();

            Tabela tbPeriodoAvaliacao = new Tabela("PeriodoAvaliacao", "codigo int(11)", true);
            string[] PeriodoAvaliacao = { "Descricao varchar(50)", };
            tbPeriodoAvaliacao.addCampo(PeriodoAvaliacao);
            tbPeriodoAvaliacao.addUnique("Descricao", "PeriodoAvaliacao");
            tbPeriodoAvaliacao.gravarTabela();


            Tabela tbCriterioAvaliacao = new Tabela("CriterioAvaliacao", "codigo int(11)", true);
            string[] CriterioAvaliacao = { "Descricao varchar(50)", "CodPeriodoAvaliacao int(11)", "QtdePeriodoAvaliacao int(11)", "ReprovaFalta int(11)", "PercentagemAprovacao decimal(18,2)", "AlertaFalta int(11)", "AlertaFaltaPercentagem decimal(18,2)", "ClasseExame int(11)", "PesoExame decimal(18,2)", "Recurso int(11)", "NotaMinimaAprovar decimal(18,2)", "MenorNota decimal(18,2)", "MaiorNota decimal(18,2)", "MaxNegativa decimal(18,2)", "ProvasPorPeriodo int(11)", "NotaMinRecurso decimal(18,2)" };
            tbCriterioAvaliacao.addCampo(CriterioAvaliacao);
            tbCriterioAvaliacao.addUnique("Descricao", "CriterioAvaliacao");
            tbCriterioAvaliacao.addChaveEstrangeira("CodPeriodoAvaliacao", "PeriodoAvaliacao", "Codigo");
            tbCriterioAvaliacao.gravarTabela();


            Tabela tbProvas = new Tabela("Provas", "codigo int(11)", true);
            string[] Provas = { "Descricao varchar(50)", };
            tbProvas.addCampo(Provas);
            tbProvas.addUnique("Descricao", "Provas");
            tbProvas.gravarTabela();

            Tabela tbProvasCriterioAvaliacao = new Tabela("ProvasCriterioAvaliacao", "codigo int(11)", true);
            string[] ProvasCriterioAvaliacao = { "CodCriterio int(11)", "CodProva int(11)", "Periodo int(11)", "Expressao varchar(100)" };
            tbProvasCriterioAvaliacao.addCampo(ProvasCriterioAvaliacao);
            tbProvasCriterioAvaliacao.addUnique("CodCriterio, CodProva, Periodo", "CodCriterio");
            tbProvasCriterioAvaliacao.addChaveEstrangeira("CodCriterio", "CriterioAvaliacao", "Codigo");
            tbProvasCriterioAvaliacao.addChaveEstrangeira("CodProva", "Provas", "Codigo");
            tbProvasCriterioAvaliacao.gravarTabela();


            Tabela tbTarifasEscolar = new Tabela("MultaEscolar", "codigo int(11)", true);
            string[] TarifasEscolar = { "Descricao varchar(100)", "TipoMulta int(11)", "ModalidadeMulta int(11)", "ValorMulta decimal(18,2)", "PrazoMulta int(11)" };
            tbTarifasEscolar.addCampo(TarifasEscolar);
            tbTarifasEscolar.addUnique("Descricao", "MultaEscolar");
            tbTarifasEscolar.gravarTabela();


            Tabela tbCursosNiveis = new Tabela("CursosNiveis", "codigo int(11)", true);
            string[] CursosNiveis = { "Descricao varchar(50)", "CodTipoDuracao int(11)", "Duracao int(11)", "CodMulta int(11)" };
            tbCursosNiveis.addCampo(CursosNiveis);
            tbCursosNiveis.addUnique("Descricao", "CursosNiveis");
            tbCursosNiveis.addChaveEstrangeira("CodTipoDuracao", "TipoDuracao", "Codigo");
            tbCursosNiveis.addChaveEstrangeira("CodMulta", "MultaEscolar", "Codigo");
            tbCursosNiveis.gravarTabela();


            Tabela tbTarifasAcessos = new Tabela("TarifasAcessos", "codigo int(11)", true);
            string[] Tarifascessos = { "Descricao varchar(50)", "Minutos int(11)", "Valor decimal(18,2)" };
            tbTarifasAcessos.addCampo(Tarifascessos);
            tbTarifasAcessos.addUnique("Descricao", "TarifasAcessos"); tbTarifasAcessos.gravarTabela();

            Tabela tbTarifasImpressao = new Tabela("TarifasImpressao", "codigo int(11)", true);
            string[] TarifasImpressao = { "Descricao varchar(50)", "Valor decimal(18,2)", "Impressora varchar(50)" };
            tbTarifasImpressao.addCampo(TarifasImpressao);
            tbTarifasImpressao.addUnique("Descricao", "TarifasImpressao"); tbTarifasImpressao.gravarTabela();


            Tabela tbMsgFim = new Tabela("MsgFim", "codigo int(11)", true);
            string[] MsgFim = { "Descricao varchar(50)", "Minutos int(11)", "Valor decimal(18,2)" };
            tbMsgFim.addCampo(MsgFim);
            tbMsgFim.addUnique("Descricao", "MsgFim"); tbMsgFim.gravarTabela();


            Tabela tbCyberConfig = new Tabela("CyberConfig", "codigo int(11)", true);
            string[] CyberConfig = { "Ctrl int(11)", "Executar int(11)", "Rede int(11)", "Lixeira int(11)", "Documentos int(11)", "Computador int(11)", "Sonoro int(11)", "Segundos int(11)", "Tela LongBlob", "Programa LongBlob" };
            tbCyberConfig.addCampo(CyberConfig);
            tbCyberConfig.gravarTabela();


            Tabela tbSitesBloqueados = new Tabela("SitesBloqueados", "codigo int(11)", true);
            string[] SitesBloqueados = { "Descricao varchar(50)" };
            tbSitesBloqueados.addCampo(SitesBloqueados);
            tbSitesBloqueados.addUnique("Descricao", "SitesBloqueados"); tbSitesBloqueados.gravarTabela();


            Tabela tbCyberFundos = new Tabela("CyberFundos", "codigo int(11)", true);
            string[] CyberFundos = { "Login varchar(50)", "Ambiente varchar(50)" };
            tbCyberFundos.addCampo(CyberFundos);
            tbCyberFundos.gravarTabela();


            Tabela tbDfFormacao = new Tabela("DefEscola", "codigo int(11)", true);
            string[] DefEscola = { "Descricao varchar(50)", "DiaCobrarMulta int(11)", "MultaObrigatoria int(11)" };
            tbDfFormacao.addCampo(DefEscola);
            tbDfFormacao.addUnique("Descricao", "DefEscola");
            tbDfFormacao.gravarTabela();


            Tabela tbDefGeral = new Tabela("DefGeral", "codigo int(11)", true);
            string[] DefGeral = { "VenderSemStock int(11)", "HospedagemAberta int(11)", "LucroPos int(11)", "Incluir10Porcento int(11)", "MostrarImposto int(11)", "Documento int(11)", "Cliente int(11)", "ObrigatorioComissionario int(11)", "ImprimirComissionarios int(11)", "VariasLinhas int(11)" };
            tbDefGeral.addCampo(DefGeral);
            tbDefGeral.addUnique("VenderSemStock", "DefGeral");
            tbDefGeral.gravarTabela();


            Tabela tbContasMail = new Tabela("ContasEmail", "Codigo int(11)", true);
            string[] ContasEmail = { "descricao varchar(100)", "SMTP varchar(100)", "Porta int(11)", "Email varchar(100)", "Senha varchar(100)" };
            tbContasMail.addCampo(ContasEmail); tbContasMail.gravarTabela();


            Tabela tbTipoAvaliacao = new Tabela("TiposAvaliacoes", "codigo int(11)", true);
            string[] TipoAvaliacao = { "Descricao varchar(50)", "Avaliacoes int(11)", "Tipo varchar(30)", "Minimo varchar(10)", "Aprova varchar(10)", "Reprova varchar(10)" };
            tbTipoAvaliacao.addCampo(TipoAvaliacao);
            tbTipoAvaliacao.addUnique("Descricao", "TiposAvaliacoes"); tbTipoAvaliacao.gravarTabela();


            Tabela TbCaixas = new Tabela("Caixas", "codigo int(11)", true);
            string[] Caixas = { "Descricao varchar(100)" };
            TbCaixas.addCampo(Caixas);
            TbCaixas.addUnique("Descricao", "Caixas"); TbCaixas.gravarTabela();


            Tabela tbUnidade = new Tabela("Unidade", "codigo int(11)", true);
            string[] Unidade = { "descricao varchar(100)", "sigla varchar(5)" };
            tbUnidade.addCampo(Unidade);
            tbUnidade.addUnique("sigla", "Unidade"); tbUnidade.gravarTabela();


            Tabela tbCategoria = new Tabela("Categoria", "codigo int(11)", true);
            string[] Categorias = { "descricao varchar(100)", "Vender varchar(20)", "Foto LongBlob" };
            tbCategoria.addCampo(Categorias);
            tbCategoria.addUnique("descricao", "Categoria"); tbCategoria.gravarTabela();


            Tabela tbBanco = new Tabela("Banco_Dados", "codigo int(11)", true);
            string[] Banco_Dados = { "Versao int(11)", "Data varchar(50)", "X varchar(50)" };
            tbBanco.addCampo(Banco_Dados); tbBanco.gravarTabela();


            Tabela tbSistema = new Tabela("Sistema", "codigo int(11)", true);
            string[] Sistema = { "UrlDownoad varchar(10)", "NovoCampo varchar(50)", "NovoCampo1 varchar(50)", "NovoCampo2 varchar(50)", };
            tbSistema.addCampo(Sistema); tbSistema.gravarTabela();


            Tabela tbAreasMesas = new Tabela("AreasMesas", "codigo int(11)", true);
            string[] AreasMesas = { "descricao varchar(100)" };
            tbAreasMesas.addCampo(AreasMesas);
            tbAreasMesas.addUnique("descricao", "AreasMesas"); tbAreasMesas.gravarTabela();


            Tabela tbArmazens = new Tabela("Armazens", "codigo int(11)", true);
            string[] Armazens = { "descricao varchar(100)" };
            tbArmazens.addCampo(Armazens);
            tbArmazens.addUnique("descricao", "Armazens"); tbArmazens.gravarTabela();


            Tabela tbAcessos = new Tabela("Acessos", "codigo int(11)", true);
            string[] Acessos = { "CodPerfil int(11)", "Antecessor varchar(50)", "Descricao varchar(50)", "Valor decimal(18,2)" };
            tbAcessos.addCampo(Acessos);
            tbAcessos.addChaveEstrangeira("CodPerfil", "Perfil", "codigo"); tbAcessos.gravarTabela();

            Tabela tbAreasHabitacionais = new Tabela("AreasHabitacoes", "codigo int(11)", true);
            string[] AreasHabitacoes = { "descricao varchar(100)" };
            tbAreasHabitacionais.addCampo(AreasHabitacoes);
            tbAreasHabitacionais.addUnique("descricao", "AreasHabitacoes"); tbAreasHabitacionais.gravarTabela();

            Tabela tbTiposDocumentos = new Tabela("TiposDocumentos", "codigo int(11)", true);
            string[] TEntidade = { "descricao varchar(100)" };
            tbTiposDocumentos.addCampo(TEntidade);
            tbTiposDocumentos.addUnique("descricao", "TiposDocumentos"); tbTiposDocumentos.gravarTabela();


            Tabela tbDisciplina = new Tabela("Disciplinas", "codigo int(11)", true);
            string[] Disciplina = { "Descricao varchar(100)", "Abreviatura varchar(20)" };
            tbDisciplina.addCampo(Disciplina);
            tbDisciplina.addUnique("Descricao", "Disciplinas"); tbDisciplina.gravarTabela();


            Tabela tbTipoContacto = new Tabela("TipoContacto", "codigo int(11)", true);
            string[] TContactos = { "descricao varchar(100)" };
            tbTipoContacto.addCampo(TContactos);
            tbTipoContacto.addUnique("descricao", "TipoContacto"); tbTipoContacto.gravarTabela();



            Tabela tbTipoOperacoes = new Tabela("TipoOperacoes", "codigo int(11)", true);
            string[] TipoOperacoes = { "descricao varchar(100)" };
            tbTipoOperacoes.addCampo(TipoOperacoes);
            tbTipoOperacoes.addUnique("descricao", "TipoOperacoes"); tbTipoOperacoes.gravarTabela();


            Tabela tbAreas = new Tabela("Areas", "codigo int(11)", true);
            string[] Areas = { "descricao varchar(100)" };
            tbAreas.addCampo(Areas);
            tbAreas.addUnique("descricao", "Areas"); tbAreas.gravarTabela();

            Tabela tbCamas = new Tabela("Camas", "codigo int(11)", true);
            string[] Camas = { "descricao varchar(100)", "Solteira int(11)", "Casal int(11)", "Berco int(11)", "MaxHospedes int(11)", "MinHospedes int(11)" };
            tbCamas.addCampo(Camas);
            tbCamas.addUnique("descricao", "Camas"); tbCamas.gravarTabela();

            Tabela tbItensHabitacionais = new Tabela("ItensHabitacionais", "codigo int(11)", true);
            string[] ItensHabitacionais = { "descricao varchar(100)" };
            tbItensHabitacionais.addCampo(ItensHabitacionais);
            tbItensHabitacionais.addUnique("descricao", "ItensHabitacionais"); tbItensHabitacionais.gravarTabela();

            Tabela tbBancos = new Tabela("Bancos", "codigo int(11)", true);
            string[] Bancos = { "descricao varchar(100)" };
            tbBancos.addCampo(Bancos);
            tbBancos.addUnique("descricao", "Bancos"); tbBancos.gravarTabela();

            Tabela tbMarcas = new Tabela("Marca", "codigo int(11)", true);
            string[] Marcas = { "descricao varchar(20)" };
            tbMarcas.addCampo(Marcas);
            tbMarcas.addUnique("descricao", "Marca"); tbMarcas.gravarTabela();

            Tabela tbHabilitacoes = new Tabela("Habilitacoes", "Codigo int(11)", true);
            string[] Habilitacoes = { "Descricao varchar(100)" };
            tbHabilitacoes.addCampo(Habilitacoes);
            tbHabilitacoes.addUnique("Descricao", "Habilitacoes"); tbHabilitacoes.gravarTabela();


            Tabela tbProfissao = new Tabela("Profissao", "Codigo int(11)", true);
            string[] Profissao = { "Descricao varchar(100)" };
            tbProfissao.addCampo(Profissao);
            tbProfissao.addUnique("Descricao", "Profissao"); tbProfissao.gravarTabela();


            Tabela tbSexo = new Tabela("Sexo", "codigo int(11)", true);
            string[] Sexo = { "descricao varchar(100)" };
            tbSexo.addCampo(Sexo);
            tbSexo.addUnique("descricao", "Sexo"); tbSexo.gravarTabela();


            Tabela tbEstadoCivill = new Tabela("EstadoCivil", "codigo int(11)", true);
            string[] EstadoCivil = { "descricao varchar(100)" };
            tbEstadoCivill.addCampo(EstadoCivil);
            tbEstadoCivill.addUnique("descricao", "EstadoCivil"); tbEstadoCivill.gravarTabela();



            Tabela TbCargo = new Tabela("Cargos", "Codigo int(11)", true);
            string[] Cargo = { "Descricao varchar(100)", "SalarioBase varchar(20)", "Abono varchar(20)", "Desconto varchar(20)", "Liquido varchar(20)" };
            TbCargo.addCampo(Cargo);
            TbCargo.addUnique("Descricao", "Cargos"); TbCargo.gravarTabela();


            Tabela TbPeriodoBackup = new Tabela("PeriodoBackup", "Codigo int(11)", true);
            string[] PeriodoBackup = { "Periodo varchar(100)", "Intervalo int(11)", "Data dateTime", "Caminho text", };
            TbPeriodoBackup.addCampo(PeriodoBackup);
            TbPeriodoBackup.gravarTabela();



            Tabela tbFolhaSalario = new Tabela("FolhadeSalario", "IDFolhaSalario int(11)", true);
            string[] FolhadeSalario = { "Ano int(11)", "Mes varchar(100)", "status int(11)" };
            tbFolhaSalario.addCampo(FolhadeSalario);
            tbFolhaSalario.addUnique("Ano, Mes", "FolhadeSalario"); tbFolhaSalario.gravarTabela();


            Tabela tbFolhadeEfectividade = new Tabela("FolhadeEfectividade", "IDFolha int(11)", true);
            string[] FolhadeEfectividade = { "Ano int(11)", "Mes varchar(100)" };
            tbFolhadeEfectividade.addCampo(FolhadeEfectividade);
            tbFolhadeEfectividade.addUnique("Ano,Mes", "FolhadeEfectividade"); tbFolhadeEfectividade.gravarTabela();


            Tabela tbFolhahExtra = new Tabela("FolhaHoraExtra", "IDFolhaHora int(11)", true);
            string[] FolhaHoraExtra = { "Ano int(11)", "Mes varchar(100)", "status int(11)" };
            tbFolhahExtra.addCampo(FolhadeSalario);
            tbFolhahExtra.addUnique("Ano,Mes", "FolhaHoraExtra"); tbFolhahExtra.gravarTabela();


            Tabela tbDiasSemana = new Tabela("DiasSemana", "IDDias int(11)", true);
            string[] DiasSemana = { "DescricaoDias varchar(100)", "DayOfWeak varchar(100)" };
            tbDiasSemana.addCampo(DiasSemana);
            tbDiasSemana.addUnique("DescricaoDias", "DiasSemana");
            tbDiasSemana.gravarTabela();



            Tabela tbDescontos = new Tabela("Descontos", "IDDesconto int(11)", true);
            string[] Descontos = { "DescricaoDesconto varchar(100)", "FisicoPercentual varchar(100)", "Valor decimal(18,2)" };
            tbDescontos.addCampo(Descontos);
            tbDescontos.addUnique("DescricaoDesconto", "Descontos"); tbDescontos.gravarTabela();



            Tabela tbDepartamentos = new Tabela("Departamentos", "Codigo int(11)", true);
            string[] Departamentos = { "Descricao varchar(100)" };
            tbDepartamentos.addCampo(Departamentos);
            tbDepartamentos.addUnique("Descricao", "Departamentos"); tbDepartamentos.gravarTabela();

            Tabela tbTipoProvas = new Tabela("TipoProvas", "Codigo int(11)", true);
            string[] tbTipoProvasCampos = { "Descricao varchar(100)", "Abrev varchar(4)" };
            tbTipoProvas.addCampo(tbTipoProvasCampos);
            tbTipoProvas.addUnique("Descricao", "TipoProvas");
            tbTipoProvas.gravarTabela();

            Tabela tbFuncao = new Tabela("Funcao", "Codigo int(11)", true);
            string[] Funcao = { "Descricao varchar(100)", "SubSideo varchar(20)" };
            tbFuncao.addCampo(Funcao);
            tbFuncao.addUnique("Descricao", "Funcao"); tbFuncao.gravarTabela();

            Tabela tbSubsideo = new Tabela("SubSidios", "IDSubSidio int(11)", true);
            string[] SubSidios = { "DescricaoSubsidio varchar(100)", "FisicoPercentual varchar(100)", "Valor decimal(18,2)" };
            tbSubsideo.addCampo(SubSidios);
            tbSubsideo.addUnique("DescricaoSubsidio", "SubSidios"); tbSubsideo.gravarTabela();

            Tabela tbTurno = new Tabela("Turno", "IDTurno int(11)", true);
            string[] Turno = { "DescricaoTurno varchar(100)", "HoraMensal varchar(20)", "Controlar int(11)", "Especifico int(11)" };
            tbTurno.addCampo(Turno);
            tbTurno.addUnique("DescricaoTurno", "Turno"); tbTurno.gravarTabela();

            Tabela tbPeriodos = new Tabela("Periodos", "Codigo int(11)", true);
            string[] Periodos = { "Descricao varchar(100)", "QuantidadeAulas int(11)" };
            tbPeriodos.addCampo(Periodos);
            tbPeriodos.addUnique("Descricao", "Periodos"); tbPeriodos.gravarTabela();


            //LegDocumento


            Tabela tbTipoContrato = new Tabela("TipoContrato", "IDTipoContrato int(11)", true);
            string[] TipoContrato = { "Descricao varchar(100)", "Duracao varchar(20)" };
            tbTipoContrato.addCampo(TipoContrato);
            tbTipoContrato.addUnique("Descricao", "TipoContrato"); tbTipoContrato.gravarTabela();


            Tabela tbTiposHabitacoes = new Tabela("TiposHabitacoes", "Codigo int(11)", true);
            string[] TipoHabitacao = { "Descricao varchar(100)" };
            tbTiposHabitacoes.addCampo(TipoHabitacao);
            tbTiposHabitacoes.addUnique("Descricao", "TiposHabitacoes"); tbTiposHabitacoes.gravarTabela();

            Tabela tbTipoHospede = new Tabela("TipoHospede", "Codigo int(11)", true);
            string[] TipoHospede = { "Descricao varchar(100)" };
            tbTipoHospede.addCampo(TipoHospede);
            tbTipoHospede.addUnique("Descricao", "TipoHospede"); tbTipoHospede.gravarTabela();


            Tabela tbTipoHospedagem = new Tabela("TipoTarifaHospedagem", "Codigo int(11)", true);
            string[] TipoTarifa = { "Descricao varchar(100)" };
            tbTipoHospedagem.addCampo(TipoTarifa);
            tbTipoHospedagem.addUnique("Descricao", "TipoTarifaHospedagem"); tbTipoHospedagem.gravarTabela();


            Tabela tbEstadoReserva = new Tabela("EstadoReservas", "Codigo int(11)", true);
            string[] EstadoReserva = { "Descricao varchar(50)" };
            tbEstadoReserva.addCampo(EstadoReserva);
            tbEstadoReserva.addUnique("Descricao", "EstadoReservas"); tbEstadoReserva.gravarTabela();



            // TABELAS DEPENDENTES DE OUTRAS             // TABELAS DEPENDENTES DE OUTRAS             // TABELAS DEPENDENTES DE OUTRAS
            // TABELAS DEPENDENTES DE OUTRAS             // TABELAS DEPENDENTES DE OUTRAS             // TABELAS DEPENDENTES DE OUTRAS


            Tabela tbEtiquetas = new Tabela("Etiquetas", "codigo int(11)", true);
            string[] cEtiquetas = { "Nome varchar(50)"
                                    , "CodBarra varchar(20)", "CorLinha varchar(20)", "CorFundo varchar(20)", "Tipo varchar(40)", "CodBarraAltura varchar(5)", "CodBarraLargura varchar(5)", "CodBarraPosx varchar(5)", "CodBarraPosy varchar(5)"
                                    , "CodProduto varchar(20)", "CodProdutoFonte varchar(30)","CodProdutoTamanho varchar(5)","CodProdutoCor varchar(20)", "CodProdutoPosx varchar(5)", "CodProdutoPosy varchar(5)"
                                    , "Descricao varchar(20)", "DescricaoFonte varchar(30)","DescricaoTamanho varchar(5)", "DescricaoCor varchar(20)", "DescricaoPosx varchar(5)", "DescricaoPosy varchar(5)"
                                    , "Preco varchar(20)", "PrecoFonte varchar(20)", "PrecoTamanho varchar(5)","PrecoCor varchar(20)", "PrecoPosx varchar(5)", "PrecoPosy varchar(5)"
                                   , "Qtdade varchar(20)", "QtdadeFonte varchar(20)", "QtdadeTamanho varchar(5)","QtdadeCor varchar(20)", "QtdadePosx varchar(5)", "QtdadePosy varchar(5)"
                                   , "Empresa varchar(20)", "EmpresaFonte varchar(20)","EmpresaTamanho varchar(5)", "EmpresaCor varchar(20)", "EmpresaPosx varchar(5)", "EmpresaPosy varchar(5)"
                                   , "Logotipo varchar(20)", "LogotipoAltura varchar(5)", "LogoTipoLargura varchar(5)", "LogoTipoPosx varchar(5)", "LogoTipoPosy varchar(5)"
                                  };
            tbEtiquetas.addCampo(cEtiquetas);
            tbEtiquetas.addUnique("Nome", "Etiquetas"); tbEtiquetas.gravarTabela();

            Tabela tbPasses = new Tabela("ConfigPasses", "codigo int(11)", true);
            string[] cPasses = { "Nome varchar(20)", "PasseAltura int(11)", "PasseLargura int(11)","EmpresaLargura int(11)", "EmpresaAltura int(11)", "LogotipoLargura int(11)", "LogotipoAltura int(11)"
                                    , "DadosPessoaisLargura int(11)", "DadosPessoaisAltura int(11)", "TurmaLargura int(11)", "TurmaAltura int(11)", "FotografiaLargura int(11)", "FotografiaAltura int(11)", "ValidadeLargura int(11)", "ValidadeAltura int(11)"
                                    , "CorNome varchar(20)", "Empresa  int(11)","EmpresaX int(11)","EmpresaY int(11)", "CorEmpresa varchar(20)", "CorGeral varchar(20)", "CorFundo varchar(20)"
                                    , "Logotipo int(11)","LogotipoX int(11)","LogotipoY int(11)","Fotografia int(11)", "FotografiaX int(11)", "FotografiaY int(11)"
                                    , "Turma int(11)","TurmaX int(11)","TurmaY int(11)","Validade int(11)","ValidadeX int(11)","ValidadeY int(11)","DadosPessoais int(11)","DadosPessoaisX int(11)","DadosPessoaisY int(11)"
                                  };
            tbPasses.addCampo(cPasses);
            tbPasses.addUnique("Nome", "ConfigPasses");
            tbPasses.gravarTabela();


            Tabela tbMesas = new Tabela("Mesas", "codigo int(11)", true);
            string[] Mesas = { "descricao varchar(100)", "codArea int(11)", "Cadeiras int(11)", "Venda varchar(20)" };
            tbMesas.addCampo(Mesas);
            tbMesas.addChaveEstrangeira("codArea", "AreasMesas", "codigo"); tbMesas.gravarTabela();


            /////////////////////////////////IMPOSTO////////////////////////////////

            Tabela tbTipoImposto = new Tabela("TipoImposto", "Codigo int(11)", true);
            string[] Campos_tbTipoImposto = { "Sigla varchar(200)", "Descricao varchar(200)" };
            tbTipoImposto.addCampo(Campos_tbTipoImposto);
            tbTipoImposto.gravarTabela();

            Tabela tbImposto = new Tabela("Imposto", "Codigo int(11)", true);
            string[] Campos_tbImposto = { "CodTipo int(11)", "Sigla varchar(200)", "Descricao varchar(200)", "Percentagem decimal(18,2)" };
            tbImposto.addCampo(Campos_tbImposto);
            tbImposto.addChaveEstrangeira("CodTipo", "TipoImposto", "Codigo");
            tbImposto.gravarTabela();

            Tabela tbMotivoIsencao = new Tabela("MotivoIsencao", "Codigo int(11)", true);
            string[] Campos_tbMotivoIsencao = { "Descricao varchar(200)", "Referencia  varchar(150)" };
            tbMotivoIsencao.addCampo(Campos_tbMotivoIsencao);
            tbMotivoIsencao.gravarTabela();

            /////////////////////////////////IMPOSTO////////////////////////////////


            Tabela tbProdutos = new Tabela("Produtos", "Codigo int(11)", true);
            string[] Produtos = {
                "descricao varchar(100)",
                "Codcategoria int(11)",
                "Codunidade int(11)",
                "taxa varchar(20)",
                "Retencao decimal(18,2)",
                "preco1 decimal(18,2)",
                "preco2 decimal(18,2)",
                "preco3 decimal(18,2)",
                "movimentaStock int(11)",
                "Vender int(11)",
                "custo decimal(18,2)",
                "data_fabrico varchar(20)",
                "data_validade varchar(20)",
                "Imagem LongBlob",
                "Barra varchar(100)",
                "status int(11)", "Imposto decimal(18, 2)", "CodImposto int(11)", "CodMotivoIsencao int(11)", "MotivoIsencao varchar(100)" };
            tbProdutos.addCampo(Produtos);
            tbProdutos.addUnique("descricao", "Produtos");
            tbProdutos.addChaveEstrangeira("CodCategoria", "categoria", "codigo");
            tbProdutos.addChaveEstrangeira("CodUnidade", "unidade", "codigo");
            tbProdutos.addChaveEstrangeira("CodImposto", "Imposto", "codigo");
            tbProdutos.addChaveEstrangeira("CodMotivoIsencao", "MotivoIsencao", "codigo");
            tbProdutos.gravarTabela();

            Tabela TbProdutoEMbalagem = new Tabela("ProdutoEmbalagem", "codigo int(11)", true);
            string[] ProdutosEmbalagem = { "CodProduto int(11)", "embalagem varchar(100)" };
            TbProdutoEMbalagem.addCampo(ProdutosEmbalagem);
            TbProdutoEMbalagem.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); TbProdutoEMbalagem.gravarTabela();


            Tabela TbLote = new Tabela("Lote", "Codigo int(11)", true);
            string[] Lote = {
                "Descricao varchar(150)",
                "DataValidade datetime",
                "DataVencimento datetime"
            };
            TbLote.addCampo(Lote);
            TbLote.gravarTabela();

            Tabela TbLoteArtigos = new Tabela("LoteArtigos", "Codigo int(11)", true);
            string[] LoteArtigos = {
                "CodProduto int(11)",
                "CodLote int(11)"
            };
            TbLoteArtigos.addCampo(LoteArtigos);
            TbLoteArtigos.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            TbLoteArtigos.addChaveEstrangeira("CodLote", "Lote", "Codigo");
            TbLoteArtigos.gravarTabela();


            Tabela tbAcessoArmazem = new Tabela("AcessoArmazens", "codigo int(11)", true);
            string[] AcessoArmazem = { "CodUsuario int(11)", "CodArmazem int(11)" };
            tbAcessoArmazem.addCampo(AcessoArmazem);
            tbAcessoArmazem.addChaveEstrangeira("CodArmazem", "Armazens", "codigo");
            tbAcessoArmazem.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbAcessoArmazem.gravarTabela();



            Tabela tbProdutosMarca = new Tabela("ProdutoMarca", "codigo int(11)", true);
            string[] ProdutoMarca = { "CodProduto int(11)", "marca int(11)" };
            tbProdutosMarca.addCampo(ProdutoMarca);
            tbProdutosMarca.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            tbProdutosMarca.addChaveEstrangeira("marca", "Marca", "codigo"); tbProdutosMarca.gravarTabela();


            Tabela tbProdutoObs = new Tabela("ProdutoObs", "codigo int(11)", true);
            string[] ProdutosObs = { "CodProduto int(11)", "obs varchar(100)" };
            tbProdutoObs.addCampo(ProdutosObs);
            tbProdutoObs.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); tbProdutoObs.gravarTabela();



            Tabela tbProdutoPeso = new Tabela("ProdutoPeso", "codigo int(11)", true);
            string[] ProdutosPeso = { "CodProduto int(11)", "peso varchar(20)" };
            tbProdutoPeso.addCampo(ProdutosPeso);
            tbProdutoPeso.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); tbProdutoPeso.gravarTabela();



            Tabela tbProdutoStock = new Tabela("ProdutoStock", "codigo int(11)", true);
            string[] ProdutoStock = { "CodProduto int(11)", "CodArmazem int(11)", "qtde decimal(18,2)", "stockMin decimal(18,2)", "stockMax decimal(18,2)" };
            tbProdutoStock.addCampo(ProdutoStock);
            //tbProdutoStock.addUnique("CodProduto, CodArmazem", "ProdutoStock");
            tbProdutoStock.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            tbProdutoStock.addChaveEstrangeira("CodArmazem", "Armazens", "codigo"); tbProdutoStock.gravarTabela();



            Tabela tbSubCategoria = new Tabela("SubCategoria", "codigo int(11)", true);
            string[] SubCategoria = { "descricao varchar(100)", "categoria int(11)" };
            tbSubCategoria.addCampo(SubCategoria);
            tbSubCategoria.addUnique("descricao, categoria", "SubCategoria");
            tbSubCategoria.addChaveEstrangeira("categoria", "Categoria", "codigo"); tbSubCategoria.gravarTabela();


            Tabela tbProdutoSubCategoria = new Tabela("ProdutoSubCategoria", "codigo int(11)", true);
            string[] ProdutoSubCategoria = { "CodProduto int(11)", "CodSubcategoria int(11)" };
            tbProdutoSubCategoria.addCampo(ProdutoSubCategoria);
            tbProdutoSubCategoria.addUnique("CodProduto, CodSubcategoria", "ProdutoSubCategoria");
            tbProdutoSubCategoria.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            tbProdutoSubCategoria.addChaveEstrangeira("CodSubcategoria", "SubCategoria", "codigo"); tbProdutoSubCategoria.gravarTabela();


            Tabela tbProdutoVolume = new Tabela("ProdutoVolume", "codigo int(11)", true);
            string[] ProdutoVolume = { "CodProduto int(11)", "volume varchar(20)" };
            tbProdutoVolume.addCampo(ProdutoVolume);
            tbProdutoVolume.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); tbProdutoVolume.gravarTabela();


            Tabela tbAcessoCaixas = new Tabela("AcessoCaixas", "codigo int(11)", true);
            string[] AcessoCaixas = { "CodUsuario int(11)", "CodCaixa int(11)" };
            tbAcessoCaixas.addCampo(AcessoCaixas);
            tbAcessoCaixas.addChaveEstrangeira("CodCaixa", "Caixas", "codigo");
            tbAcessoCaixas.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbAcessoCaixas.gravarTabela();

            Tabela tbAcessoDocumentos = new Tabela("AcessoDocumentos", "codigo int(11)", true);
            string[] AcessoDocumentos = { "CodUsuario int(11)", "CodOperacao int(11)" };
            tbAcessoDocumentos.addCampo(AcessoDocumentos);
            tbAcessoDocumentos.addChaveEstrangeira("CodOperacao", "Operacoes", "codigo");
            tbAcessoDocumentos.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbAcessoDocumentos.gravarTabela();

            Tabela tbMoedas = new Tabela("Moedas", "codigo int(11)", true);
            string[] cpMoedas = { "Descricao varchar(50)", "Sigla varchar(10)", "moedapadrao int(11)" };
            tbMoedas.addCampo(cpMoedas);
            tbMoedas.addUnique("Descricao", "Moedas");
            tbMoedas.addUnique("sigla", "Moedas");
            tbMoedas.gravarTabela();

            Tabela tbCambios = new Tabela("Cambios", "codigo int(11) ", true);
            string[] cpCambios = { "Moeda1 int(11)", "Moeda2 int(11)", "cambio decimal(18,2)", "data Date", "estado int(11)", "Padrao varchar(50)", "Pretendida varchar(50)" };
            tbCambios.addCampo(cpCambios);
            tbCambios.gravarTabela();

            Tabela tbDocumentos = new Tabela("Documentos", "codigo int(11)", true);
            string[] Documentos = {
                "Data date" ,
                "Hora varchar(20)",
                "CodUsuario int(11)",
                "CodArea int(11)",
                "CodMesa int(11)",
                "CodEntidade int(11)",
                "CodTurno int(11)",
                "Total decimal(18,2)",
                "CodOperacao int(11)",
                "Estado varchar(20)",
                "Descritivo varchar(100)",
                "NomeCliente varchar(250)",
                "NumeroOrdem int(11)",
                "Mascara varchar(100)",
                "DataVencimento date" ,
                "Emitido varchar(100) default 'Não Imprimido'",
                "Geracao varchar(250) default 'ISENTO'",
                "Liquidado varchar(20)",
                "Hash varchar(250)",
                "NifCliente varchar(250)",
                "TelCliente varchar(550)",
                "MoredaCliente Text",
                "Desconto decimal(18,2)",
                "Imposto decimal(18,2)",
                "TotalIliquido decimal(18,2)"
             };
            tbDocumentos.addCampo(Documentos);
            tbDocumentos.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbDocumentos.addChaveEstrangeira("CodEntidade", "Entidades", "codigo", "");
            tbDocumentos.addChaveEstrangeira("CodArea", "Areas", "codigo", "");
            tbDocumentos.addChaveEstrangeira("CodOperacao", "Operacoes", "codigo"); tbDocumentos.gravarTabela();


            Tabela tbEntregas = new Tabela("Entregas", "codigo int(11)", true);
            string[] Entregas = { "CodDocumento int(11)", "CodEntregador int(11)", "Endereco varchar(100)", "Contactos varchar(400)", "Estado int(11)" };
            tbEntregas.addCampo(Entregas);
            tbEntregas.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbEntregas.addChaveEstrangeira("CodEntregador", "Entidades", "codigo"); tbEntregas.gravarTabela();


            Tabela tbEntidadesPessoa = new Tabela("EntidadesPessoa", "CodEntidade int(11)", false);
            string[] EntidadesPessoa = { "CodSexo int(11)", "CodEstadoCivil int(11)", "DataNascimento varchar(20)", "CodHabilitacao int(11)", "CodProfissao int(11)", "NomePai varchar(50)", "NomeMae varchar(50)" };
            tbEntidadesPessoa.addCampo(EntidadesPessoa);
            tbEntidadesPessoa.addChaveEstrangeira("CodEntidade", "Entidades", "codigo");
            tbEntidadesPessoa.addChaveEstrangeira("CodSexo", "Sexo", "codigo");
            tbEntidadesPessoa.addChaveEstrangeira("CodEstadoCivil", "EstadoCivil", "codigo");
            tbEntidadesPessoa.addChaveEstrangeira("CodHabilitacao", "Habilitacoes", "Codigo");
            tbEntidadesPessoa.addChaveEstrangeira("CodProfissao", "Profissao", "Codigo"); tbEntidadesPessoa.gravarTabela();


            Tabela tbContactos = new Tabela("Contactos", "codigo int(11)", true);
            string[] Contactos = { "CodEntidade int(11)", "CodTipoContacto int(11)", "descricao varchar(100)" };
            tbContactos.addCampo(Contactos);
            tbContactos.addChaveEstrangeira("CodEntidade", "Entidades", "codigo");
            tbContactos.addChaveEstrangeira("CodTipoContacto", "TipoContacto", "codigo"); tbContactos.gravarTabela();

            Tabela tbContactosEntidade = new Tabela("ContactosEntidade", "codigo int(11)", true);
            string[] ContactosEntidade = { "CodEntidade int(11)" };
            tbContactosEntidade.addCampo(ContactosEntidade);
            tbContactosEntidade.addUnique("CodEntidade", "ContactosEntidade");
            tbContactosEntidade.addChaveEstrangeira("CodEntidade", "Entidades", "codigo");
            tbContactosEntidade.gravarTabela();

            Tabela tbDocumentosEntidade = new Tabela("DocumentosEntidade", "codigo int(11)", true);
            string[] DocumentosEntidade = { "CodEntidade int(11)", "CodTipoDocumento int(11)", "Numero varchar(100)", "Emissao varchar(50)", "Validade varchar(50)" };
            tbDocumentosEntidade.addCampo(DocumentosEntidade);
            tbDocumentosEntidade.addChaveEstrangeira("CodEntidade", "Entidades", "codigo");
            tbDocumentosEntidade.addChaveEstrangeira("CodTipoDocumento", "TiposDocumentos", "codigo"); tbDocumentosEntidade.gravarTabela();


            Tabela tbContasBancarias = new Tabela("ContasBancarias", "codigo int(11)", true);
            string[] ContaBancaria = { "Numero varchar(50)", "Iban varchar(50)", "Natureza varchar(10)", "Sequencia varchar(10)", "Swift varchar(50)", "CodBanco int(11)" };
            tbContasBancarias.addCampo(ContaBancaria);
            tbContasBancarias.addUnique("Numero", "ContasBancarias");
            tbContasBancarias.addChaveEstrangeira("CodBanco", "Bancos", "codigo"); tbContasBancarias.gravarTabela();


            Tabela tbAcessoContas = new Tabela("AcessoContas", "codigo int(11)", true);
            string[] AcessoContas = { "CodUsuario int(11)", "CodContaBancaria int(11)" };
            tbAcessoContas.addCampo(AcessoContas);
            tbAcessoContas.addChaveEstrangeira("CodContaBancaria", "ContasBancarias", "codigo");
            tbAcessoContas.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbAcessoContas.gravarTabela();


            Tabela tbEntidadesContas = new Tabela("EntidadesContas", "codigo int(11)", true);
            string[] EntidadeContas = { "CodBanco int(11)", "CodEntidade int(11)", "Numero varchar(10)", "Natureza varchar(10)", "Sequencia varchar(10)", "iban varchar(50)", "swift varchar(50)" };
            tbEntidadesContas.addCampo(EntidadeContas);
            tbEntidadesContas.addChaveEstrangeira("CodEntidade", "Entidades", "codigo");
            tbEntidadesContas.addChaveEstrangeira("CodBanco", "Bancos", "codigo"); tbEntidadesContas.gravarTabela();


            Tabela tbAnulados = new Tabela("Anulados", "codigo int(11)", true);
            string[] Anulados = { "Numero int(11)", "CodUsuario int(11)", "Data varchar(20)", "Hora varchar(20)", "Motivo varchar(4000)" };
            tbAnulados.addCampo(Anulados);
            tbAnulados.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbAnulados.gravarTabela();


            Tabela tbAnexos = new Tabela("Anexos", "codigo int(11)", true);
            string[] Anexos = { "Documento varchar(50)", "CodDoc int(11)", "Anexo LongBlob" };
            tbAnexos.addCampo(Anexos);
            tbAnexos.addChaveEstrangeira("CodDoc", "Documentos", "codigo"); tbAnexos.gravarTabela();


            Tabela tbTurnos = new Tabela("Turnos", "codigo int(11)", true);
            string[] Turnos = {
                "DataAbertura datetime",
                "DataFecho datetime",
                "SaldoInicial decimal(18,2)",
                "SaldoInformado decimal(18,2)",
                "SaldoTotal decimal(18,2)",
                "SaldoVendas decimal(18,2)",
                "SaldoHospedagem decimal(18,2)",
                "QuebraCaixa decimal(18,2)",
                "Estado varchar(20)",
                "CodCaixa int(11)",
                "CodUsuario int(11)",
                "CodSuperVisor int(11)",
                "DataConfirmacao Date",
                "Confirmado varchar(20)"
            };
            tbTurnos.addCampo(Turnos);
            tbTurnos.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbTurnos.gravarTabela();

            Tabela tbProdutosComposicao = new Tabela("ProdutosComposicao", "codigo int(11)", true);
            string[] ComposicaoProdutos = { "CodigoProduto varchar(50)", "CodProduto int(11)", "Qtde decimal(18,2)" };
            tbProdutosComposicao.addCampo(ComposicaoProdutos);
            tbProdutosComposicao.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); tbProdutosComposicao.gravarTabela();

            Tabela tbMaquinas = new Tabela("Maquinas", "Codigo int(11)", true);
            string[] Maquinas = { "Maq int(11)", "Rede varchar(50)", "IP varchar(50)", "Windows varchar(50)", "Ram varchar(50)", "Processador varchar(50)", "Mac varchar(50)", "Venda varchar(50)", "Estado varchar(50)" };
            tbMaquinas.addCampo(Maquinas);
            tbMaquinas.addUnique("Maq", "Maquinas");
            tbMaquinas.gravarTabela();

            Tabela tbProdutosSubstitutos = new Tabela("ProdutosSubstitutos", "codigo int(11)", true);
            string[] SubstituicaoProdutos = { "CodigoProduto varchar(50)", "CodProduto int(11)" };
            tbProdutosSubstitutos.addCampo(SubstituicaoProdutos);
            tbProdutosSubstitutos.addChaveEstrangeira("CodProduto", "Produtos", "codigo"); tbProdutosSubstitutos.gravarTabela();

            Tabela tbFuncionarios = new Tabela("Funcionarios", "IDPessoa int(11)", true);
            string[] Funcionarios = { "CodEntidade int(11)", "CodDepartamento int(11)", "DataRegisto varchar(20)" };
            tbFuncionarios.addCampo(Funcionarios);
            tbFuncionarios.addUnique("CodEntidade", "Funcionarios");
            tbFuncionarios.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbFuncionarios.addChaveEstrangeira("CodDepartamento", "Departamentos", "Codigo");
            tbFuncionarios.gravarTabela();

            Tabela tbPonto = new Tabela("Ponto", "Codigo int(11)", true);
            string[] Ponto = { "CodFuncionario int(11)", "Data date", "Hora varchar(20)" };
            tbPonto.addCampo(Ponto);
            tbPonto.addChaveEstrangeira("CodFuncionario", "Funcionarios", "IDPessoa");
            tbPonto.gravarTabela();

            Tabela tbComissoes = new Tabela("Comissoes", "codigo int(11)", true);
            string[] Comissoes = { "codDocumento int(11)", "CodEntidade int(11)" };
            tbComissoes.addCampo(Comissoes);
            tbComissoes.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbComissoes.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbComissoes.gravarTabela();

            Tabela tbCamareira = new Tabela("Camareiras", "Codigo int(11)", true);
            string[] Camareira = { "CodEntidade int(11)" };
            tbCamareira.addCampo(Camareira);
            tbCamareira.addChaveEstrangeira("CodEntidade", "Funcionarios", "IDPessoa"); tbCamareira.gravarTabela();

            Tabela tbTecnicos = new Tabela("Tecnicos", "Codigo int(11)", true);
            string[] Tecnicos = { "CodEntidade int(11)" };
            tbTecnicos.addCampo(Tecnicos);
            tbTecnicos.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo"); tbTecnicos.gravarTabela();

            Tabela tbMotoristas = new Tabela("Motoristas", "Codigo int(11)", true);
            string[] Motoristas = { "CodEntidade int(11)" };
            tbMotoristas.addCampo(Motoristas);
            tbMotoristas.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo"); tbMotoristas.gravarTabela();

            Tabela tbMovTecnicos = new Tabela("MovTecnicos", "codigo int(11)", true);
            string[] MovTecnicos = { "codDocumento int(11)", "CodTecnico int(11)" };
            tbMovTecnicos.addCampo(MovTecnicos);
            tbMovTecnicos.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbMovTecnicos.addChaveEstrangeira("CodTecnico", "Tecnicos", "Codigo");
            tbMovTecnicos.gravarTabela();

            Tabela tbMovMotoristas = new Tabela("MovMotoristas", "codigo int(11)", true);
            string[] MovMotoristas = { "codDocumento int(11)", "CodMotorista int(11)" };
            tbMovMotoristas.addCampo(MovMotoristas);
            tbMovMotoristas.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbMovMotoristas.addChaveEstrangeira("CodMotorista", "Motoristas", "Codigo");
            tbMovMotoristas.gravarTabela();

            Tabela TbAgregado = new Tabela("Agregado", "IDAgregato int(11)", true);
            string[] Agregado = { "Nome varchar(100)", "DataNascimento datetime", "Dificiente varchar(100)", "Estudante varchar(100)", "Afinidade varchar(100)", "IDPessoa int(11)", "Bilhete varchar(20)" };
            TbAgregado.addCampo(Agregado);
            TbAgregado.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa"); TbAgregado.gravarTabela();


            Tabela tbEfectividades = new Tabela("Efetividades", "IDEfetividade int(11)", true);
            string[] Efetividades = { "IDFolha int(11)", "IDPessoa int(11)", "Dias  varchar(20)", "FaltaJustificada int(11)", "FaltaNaoJustificada int(11)" };
            tbEfectividades.addCampo(Efetividades);
            tbEfectividades.addUnique("IDFolha,IDPessoa", "Efetividades");
            tbEfectividades.addChaveEstrangeira("IDFolha", "FolhadeEfectividade", "IDFolha");
            tbEfectividades.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa"); tbEfectividades.gravarTabela();



            Tabela tbHoraExtra = new Tabela("HoraExtra", "IDHora int(11)", true);
            string[] HoraExtra = { "IDFolhaHora int(11)", "IDPessoa int(11)", "Dias int(11)" };
            tbHoraExtra.addCampo(HoraExtra);
            tbHoraExtra.addUnique("IDFolhaHora,IDPessoa", "HoraExtra");
            tbHoraExtra.addChaveEstrangeira("IDFolhaHora", "FolhaHoraExtra", "IDFolhaHora");
            tbHoraExtra.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa"); tbHoraExtra.gravarTabela();

            Tabela tbMapaFerias = new Tabela("MapaFerias", "IDMapaFeria int(11)", true);
            string[] MapaFerias = { "IDPessoa int(11)", "IDTipo int(11)", "Mes varchar(20)", "Ano int(11)", "DataInicio datetime", "DataTermino datetime", "status int(11)" };
            tbMapaFerias.addCampo(MapaFerias);
            tbMapaFerias.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa"); tbMapaFerias.gravarTabela();

            Tabela TbMoradas = new Tabela("Morada", "IDMorada int(11)", true);
            string[] Morada = { "IDPessoa int(11)", "DescricaoMorada varchar(100)", "status int(11)" };
            TbMoradas.addCampo(Morada);
            TbMoradas.addChaveEstrangeira("IDPessoa", "Entidades", "codigo"); TbMoradas.gravarTabela();

            Tabela tbRegEfectividade = new Tabela("RegistoEfetividade", "IDRegisto int(11)", true);
            string[] RegistoEfetividade = { "IDEfetividade int(11)", "Dia int(11)", "Entrada varchar(20)", "Saida varchar(20)", "Detalhe varchar(20)", "Atraso varchar(20)" };
            tbRegEfectividade.addCampo(RegistoEfetividade);
            tbRegEfectividade.addChaveEstrangeira("IDEfetividade", "Efetividades", "IDEfetividade"); tbRegEfectividade.gravarTabela();

            Tabela tbRegistoHora = new Tabela("RegistoHoraExtra", "IDRegistoHora int(11)", true);
            string[] RegistoHoraExtra = { "IDHora int(11)", "Entrada varchar(20)", "Saida varchar(20)", "Descricao varchar(20)", "Dia int(11)" };
            tbRegistoHora.addCampo(RegistoHoraExtra);
            tbRegistoHora.addChaveEstrangeira("IDHora", "HoraExtra", "IDHora"); tbRegistoHora.gravarTabela();

            Tabela tbSalario = new Tabela("Salario", "IDSalario int(11)", true);
            string[] Salario = { "IDFolhaSalario int(11)", "IDPessoa int(11)", "faltas varchar(20)", "Abonos varchar(20)", "Descontos varchar(20)", "SalarioLiquido varchar(20)", "DataRegisto datetime", "CodDoc int(11)" };
            tbSalario.addCampo(Salario);
            tbSalario.addChaveEstrangeira("IDFolhaSalario", "FolhadeSalario", "IDFolhaSalario");
            tbSalario.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa"); tbSalario.gravarTabela();

            Tabela tbSalarioMov = new Tabela("SalarioMovimento", "IDMovSalario int(11)", true);
            string[] SalarioMovimento = { "IDSalario int(11)", "Descricao varchar(100)", "Tipo varchar(20)", "Valor decimal(18,2)" };
            tbSalarioMov.addCampo(SalarioMovimento);
            tbSalarioMov.addChaveEstrangeira("IDSalario", "Salario", "IDSalario"); tbSalarioMov.gravarTabela();

            Tabela tbTurnosDias = new Tabela("TurnoDias", "IDTurnoDias int(11)", true);
            string[] TurnoDias = { "IDTurno int(11)", "IDDia int(11)", "HoraEntrada varchar(20)", "HoraSaida varchar(20)" };
            tbTurnosDias.addCampo(TurnoDias);
            tbTurnosDias.addUnique("IDTurno,IDDia", "TurnoDias");
            tbTurnosDias.addChaveEstrangeira("IDTurno", "Turno", "IDTurno");
            tbTurnosDias.addChaveEstrangeira("IDDia", "DiasSemana", "IDDias"); tbTurnosDias.gravarTabela();

            Tabela tbPeriodoDias = new Tabela("PeriodoDias", "Codigo int(11)", true);
            string[] PeriodoDias = { "CodPeriodo int(11)", "IDDia int(11)" };
            tbPeriodoDias.addCampo(PeriodoDias);
            tbPeriodoDias.addUnique("CodPeriodo,IDDia", "PeriodoDias");
            tbPeriodoDias.addChaveEstrangeira("CodPeriodo", "Periodos", "Codigo");
            tbPeriodoDias.addChaveEstrangeira("IDDia", "DiasSemana", "IDDias"); tbPeriodoDias.gravarTabela();

            Tabela tbTipoHabitacoesItem = new Tabela("TipoHabitacaoItens", "Codigo int(11)", true);
            string[] TipoHabitacaoItens = { "CodTipo int(11)", "Descricao varchar(100)" };
            tbTipoHabitacoesItem.addCampo(TipoHabitacaoItens);
            tbTipoHabitacoesItem.addUnique("Descricao", "TipoHabitacaoItens");
            tbTipoHabitacoesItem.addChaveEstrangeira("CodTipo", "TiposHabitacoes", "Codigo"); tbTipoHabitacoesItem.gravarTabela();

            Tabela TbTarifaHospedagem = new Tabela("TarifasHospedagens", "Codigo int(11)", true);
            string[] TarifasHospedagens = { "CodTipoHabitacao int(11)", "CodCama int(11)", "CodTipoTarifa int(11)", "Descricao varchar(100)", "Horas int(11)", "Valor varchar(100)" };
            TbTarifaHospedagem.addCampo(TarifasHospedagens);
            TbTarifaHospedagem.addChaveEstrangeira("CodTipoHabitacao", "TiposHabitacoes", "Codigo");
            TbTarifaHospedagem.addChaveEstrangeira("CodCama", "Camas", "Codigo"); TbTarifaHospedagem.gravarTabela();

            Tabela tbHabitacoes = new Tabela("Habitacoes", "Codigo int(11)", true);
            string[] Habitacoes = { "CodTipoHabitacao int(11)", "CodArea int(11)", "Descricao varchar(100)", "CodCama int(11)", "Manutencao int(11)", "Venda varchar(20)", "Estado varchar(20)" };
            tbHabitacoes.addCampo(Habitacoes);
            tbHabitacoes.addUnique("Descricao", "Habitacoes");
            tbHabitacoes.addChaveEstrangeira("CodTipoHabitacao", "TiposHabitacoes", "Codigo");
            tbHabitacoes.addChaveEstrangeira("CodArea", "AreasHabitacoes", "Codigo");
            tbHabitacoes.addChaveEstrangeira("CodCama", "Camas", "Codigo"); tbHabitacoes.gravarTabela();

            Tabela TbHospedagensHabit = new Tabela("HospedagensHabitacao", "Codigo int(11)", true);
            string[] HospedagensHabitacao = { "CodDocumento int(11)", "CodHabitacao int(11)", "CodTarifa int(11)", "Checkin varchar(50)", "CheckOut varchar(50)" };
            TbHospedagensHabit.addCampo(HospedagensHabitacao);
            TbHospedagensHabit.addChaveEstrangeira("CodHabitacao", "Habitacoes", "Codigo");
            TbHospedagensHabit.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo"); TbHospedagensHabit.gravarTabela();

            Tabela tbAcessoMaquina = new Tabela("AcessoMaquina", "Codigo int(11)", true);
            string[] AcessoMaquinas = { "CodDocumento int(11)", "CodMaquina int(11)", "CodTarifa int(11)", "Checkin varchar(50)", "CheckOut varchar(50)", "Preco varchar(50)" };
            tbAcessoMaquina.addCampo(AcessoMaquinas);
            tbAcessoMaquina.addChaveEstrangeira("CodMaquina", "Maquinas", "Codigo");
            tbAcessoMaquina.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo"); tbAcessoMaquina.gravarTabela();

            Tabela tbfPagamentos = new Tabela("fPagamentos", "codigo int(11)", true);
            string[] fPagamentos = { "descricao varchar(100)", "Movimentar varchar(15)", "CodConta varchar(4)", "Sistema int(11)" };
            tbfPagamentos.addCampo(fPagamentos); tbfPagamentos.gravarTabela();

            Tabela tbReservas = new Tabela("Reservas", "Codigo int(11)", true);
            string[] Reservas = { "CodEntidade int(11)", "Data varchar(100)", "CodUsuario int(11)", "CodEstado int(11)" };
            tbReservas.addCampo(Reservas);
            tbReservas.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbReservas.addChaveEstrangeira("CodUsuario", "Usuarios", "Codigo"); tbReservas.gravarTabela();

            Tabela tbMovHabitacoes = new Tabela("MovHabitacoes", "Codigo int(11)", true);
            string[] MovHabitacoes = { "CodDocumento int(11)", "CodHabitacao int(11)", "CodTarifa int(11)", "Checkin varchar(40)", "CheckOut varchar(40)", "Horas int(11)", "Quantidade varchar(40)", "Preco varchar(40)", "Total varchar(100)" };
            tbMovHabitacoes.addCampo(MovHabitacoes);
            tbMovHabitacoes.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovHabitacoes.addChaveEstrangeira("CodHabitacao", "Habitacoes", "Codigo"); tbMovHabitacoes.gravarTabela();

            Tabela tbReservasHab = new Tabela("ReservasHabitacao", "Codigo int(11)", true);
            string[] ReservasHabitacao = { "CodReserva int(11)", "CodTarifas int(11)", "Checkin varchar(100)", "CheckOut varchar(100)" };
            tbReservasHab.addCampo(ReservasHabitacao);
            tbReservasHab.addChaveEstrangeira("CodReserva", "Reservas", "Codigo");
            tbReservasHab.gravarTabela();

            Tabela tbHospedehab = new Tabela("HospedesHabitacao", "Codigo int(11)", true);
            string[] HospedesHabitacao = { "CodDocumento int(11)", "CodHabitacao int(11)", "CodEntidade int(11)" };
            tbHospedehab.addCampo(HospedesHabitacao);
            tbHospedehab.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbHospedehab.addChaveEstrangeira("CodHabitacao", "Habitacoes", "Codigo");
            tbHospedehab.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbHospedehab.gravarTabela();

            Tabela tbItemHab = new Tabela("ItemHabitacao", "Codigo int(11)", true);
            string[] ItemHabitacao = { "CodItem int(11)", "CodTipoHabitacao int(11)" };
            tbItemHab.addCampo(ItemHabitacao);
            tbItemHab.addUnique("CodItem,CodTipoHabitacao", "ItemHabitacao");
            tbItemHab.addChaveEstrangeira("CodTipoHabitacao", "TiposHabitacoes", "Codigo");
            tbItemHab.addChaveEstrangeira("CodItem", "ItensHabitacionais", "Codigo"); tbItemHab.gravarTabela();

            Tabela tbCursos = new Tabela("Cursos", "codigo int(11)", true);
            string[] Cursos = { "CodNiveis int(11)", "Descricao varchar(50)" };
            tbCursos.addCampo(Cursos);
            tbCursos.addUnique("Descricao", "Cursos");
            tbCursos.addChaveEstrangeira("CodNiveis", "CursosNiveis", "Codigo");
            tbCursos.gravarTabela();

            Tabela tbClasses = new Tabela("Classes", "codigo int(11)", true);
            string[] Classes = { "Descricao varchar(50)", "Exame int(11)" };
            tbClasses.addCampo(Classes);
            tbClasses.addUnique("Descricao", "Classes");
            tbClasses.gravarTabela();


            Tabela tbCursosClasses = new Tabela("CursoClasses", "codigo int(11)", true);
            string[] CursosClasses = { "CodCurso int(11)", "CodClasse int(11)", "CodCriterio int(11)" };
            tbCursosClasses.addCampo(CursosClasses);
            tbCursosClasses.addUnique("CodCurso,CodClasse", "CursoClasses");
            tbCursosClasses.addChaveEstrangeira("CodCurso", "Cursos", "codigo");
            tbCursosClasses.addChaveEstrangeira("CodClasse", "Classes", "codigo");
            tbCursosClasses.addChaveEstrangeira("CodCriterio", "CriterioAvaliacao", "codigo");
            tbCursosClasses.gravarTabela();

            Tabela tbCursosDisciplinas = new Tabela("CursosClasseDisciplinas", "codigo int(11)", true);
            string[] CursosDisciplinas = { "CodCursoClasse int(11)", "CodDisciplina int(11)", "Exame int(11) default 0", "Eliminatoria int(11) default 0", "Recurso int(11) default 0" };
            tbCursosDisciplinas.addCampo(CursosDisciplinas);
            tbCursosDisciplinas.addUnique("CodCursoClasse, CodDisciplina", "CursosClasseDisciplinas");
            tbCursosDisciplinas.addChaveEstrangeira("CodCursoClasse", "CursoClasses", "codigo");
            tbCursosDisciplinas.addChaveEstrangeira("CodDisciplina", "Disciplinas", "codigo");
            tbCursosDisciplinas.gravarTabela();

            
            Tabela tbEmolumentos = new Tabela("EmolumentosEscolar", "codigo int(11)", true);
            string[] Emolumentos = { "Descricao varchar(200)", "Valor decimal(18,2) default 0" };
            tbEmolumentos.addCampo(Emolumentos);
            tbEmolumentos.addUnique("Descricao", "Emolumentos");
            tbEmolumentos.gravarTabela();

            Tabela tbCursosEmolumentos = new Tabela("CursosEmolumentos", "codigo int(11)", true);
            string[] CursosEmolumentos = { "CodCursoClasse int(11)", "CodEmolumento int(11)", "Valor decimal(18,2)", "Multa int(11)", "Desconto decimal(18,2)", "Total decimal(18,2)", "status int(11)" };
            tbCursosEmolumentos.addCampo(CursosEmolumentos);
            tbCursosEmolumentos.addUnique("CodCursoClasse, CodEmolumento", "CursosEmolumentos");
            tbCursosEmolumentos.addChaveEstrangeira("CodCursoClasse", "CursoClasses", "codigo");
            tbCursosEmolumentos.addChaveEstrangeira("CodEmolumento", "EmolumentosEscolar", "codigo");
            tbCursosEmolumentos.gravarTabela();

            Tabela tbDocumentoEmolumento = new Tabela("DocumentoEmolumento", "codigo int(11)", true);
            string[] DocumentoEmolumento = { "CodCursoEmol int(11)", "CodDocumento int(11)", "Valor decimal(18,2)", "Multa decimal(18,2)", "Desconto decimal(18,2)", "Total decimal(18,2)", "status int(11)" };
            tbDocumentoEmolumento.addCampo(DocumentoEmolumento);
            tbDocumentoEmolumento.addUnique("CodCursoEmol,CodDocumento", "DocumentoEmolumento");
            tbDocumentoEmolumento.addChaveEstrangeira("CodCursoEmol", "CursosEmolumentos", "codigo");
            tbDocumentoEmolumento.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbDocumentoEmolumento.gravarTabela();

            Tabela tbEscolarTurnos = new Tabela("EscolarTurnos", "codigo int(11)", true);
            string[] EscolarTurnos = { "Descricao varchar(100)" };
            tbEscolarTurnos.addUnique("Descricao", "EscolarTurnos");
            tbEscolarTurnos.addCampo(EscolarTurnos);
            tbEscolarTurnos.gravarTabela();

            Tabela tbEscolarTurnosHorarios = new Tabela("EscolarTurnosHorarios", "codigo int(11)", true);
            string[] EscolarTurnosHorarios = { "CodEscolarTurnos int(11)", "Descricao varchar(100)", "entrada datetime", "saida datetime" };
            //tbEscolarTurnosHorarios.addUnique("Descricao", "EscolarTurnosHorarios");
            tbEscolarTurnosHorarios.addChaveEstrangeira("CodEscolarTurnos", "EscolarTurnos", "Codigo");
            tbEscolarTurnosHorarios.addCampo(EscolarTurnosHorarios);
            tbEscolarTurnosHorarios.gravarTabela();


            Tabela tbProfessor = new Tabela("Professores", "codigo int(11)", true);
            string[] CProfessor = { "CodEntidade int(11)" };
            tbProfessor.addUnique("CodEntidade", "Professores");
            tbProfessor.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbProfessor.addCampo(CProfessor);
            tbProfessor.gravarTabela();

            Tabela tbTurmas = new Tabela("Turmas", "Codigo int(11)", true);
            string[] Turmas = { "Descricao varchar(50)", "CodCursoClasse int(11)", "CodSala int(11)", "CodTurno int(11)", "Total int(11)", "Inscritos int(11)", "AnoLectivo int(11)", "Aberta int(11)", "DataRegisto date", "DataInicio date", "DataTermino date" };
            tbTurmas.addCampo(Turmas);
            tbTurmas.addChaveEstrangeira("CodCursoClasse", "CursoClasses", "codigo");
            tbTurmas.addChaveEstrangeira("CodSala", "Salas", "codigo");
            tbTurmas.addChaveEstrangeira("CodTurno", "EscolarTurnos", "codigo");
            tbTurmas.gravarTabela();


            Tabela tbProfessorDisciplinas = new Tabela("ProfessorDisciplinas", "codigo int(11)", true);
            string[] ProfessorDisciplinas = { "CodProfessor int(11)", "CodDisciplina int(11)" };
            tbProfessorDisciplinas.addCampo(ProfessorDisciplinas);
            tbProfessorDisciplinas.addUnique("CodProfessor,CodDisciplina", "ProfessorDisciplinas");
            tbProfessorDisciplinas.addChaveEstrangeira("CodProfessor", "Professores", "codigo");
            tbProfessorDisciplinas.addChaveEstrangeira("CodDisciplina", "Disciplinas", "codigo");
            tbProfessorDisciplinas.gravarTabela();

            Tabela tbProfessorDisciplinasTurma = new Tabela("ProfessorDisciplinasTurmas", "codigo int(11)", true);
            string[] ProfessorDisciplinasTurma = { "CodProfessorDisc int(11)", "CodTurma int(11)" };
            tbProfessorDisciplinasTurma.addCampo(ProfessorDisciplinasTurma);
            tbProfessorDisciplinasTurma.addUnique("CodProfessorDisc,CodTurma", "ProfessorDisciplinasTurmas");
            tbProfessorDisciplinasTurma.addChaveEstrangeira("CodProfessorDisc", "ProfessorDisciplinas", "codigo");
            tbProfessorDisciplinasTurma.addChaveEstrangeira("CodTurma", "Turmas", "codigo");
            tbProfessorDisciplinasTurma.gravarTabela();

            Tabela tbHorario = new Tabela("Horario", "codigo int(11)", true);
            string[] Horario = { "CodTurma int(11)", "CodEscolarTurnosHorarios int(11)", "CodDiaSemana int(11)", "CodProfessorDisciplina int(11)", "CodProfessor int(11)" };
            tbHorario.addCampo(Horario);
            tbHorario.addUnique("CodTurma,CodEscolarTurnosHorarios,CodDiaSemana", "Horario");
            tbHorario.addUnique("CodEscolarTurnosHorarios,CodDiaSemana,CodProfessor", "Horario");
            tbHorario.addChaveEstrangeira("CodTurma", "Turmas", "Codigo");
            tbHorario.addChaveEstrangeira("CodProfessor", "Professores", "Codigo");
            tbHorario.addChaveEstrangeira("CodDiaSemana", "DiasSemana", "IDDias");
            tbHorario.addChaveEstrangeira("CodProfessorDisciplina", "ProfessorDisciplinas", "Codigo");
            tbHorario.addChaveEstrangeira("CodEscolarTurnosHorarios", "EscolarTurnosHorarios", "Codigo");
            tbHorario.gravarTabela();

            Tabela tbDesconto = new Tabela("DescontoVenda", "Codigo int(11)", true);
            string[] DescontoVenda = { "CodDocumento int(11)", "Venda varchar(100)", "Tipo varchar(100)", "ValorDesconto varchar(100)" };
            tbDesconto.addCampo(DescontoVenda);
            tbDesconto.addUnique("CodDocumento", "DescontoVenda");
            tbDesconto.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo"); tbDesconto.gravarTabela();


            Tabela tbPagamentos = new Tabela("Pagamentos", "codigo int(11)", true);
            string[] Pagamentos = {
                "Descricao varchar(100)",
                "Data date",
                "Hora varchar(20)",
                "CodForma int(11)",
                "Valor decimal(18,2)",
                "Tipo varchar(20)",
                "CodDocumento int(11)",
                "CodCaixa int(11)",
                "CodConta int(11)",
                "CodTurno int(11)",
                "Estado varchar(20)",
                "CodMoeda int(11)",
                "CodCambio int(11)",
                "Emitido varchar(100)",
                "NumeroOrdem int(11)"
            };
            tbPagamentos.addChaveEstrangeira("CodForma", "fPagamentos", "codigo");
            tbPagamentos.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbPagamentos.addChaveEstrangeira("CodCaixa", "Caixas", "codigo");
            tbPagamentos.addChaveEstrangeira("CodConta", "ContasBancarias", "codigo");
            tbPagamentos.addChaveEstrangeira("CodTurno", "Turnos", "codigo");
            tbPagamentos.addChaveEstrangeira("CodMoeda", "Moedas", "codigo");
            tbPagamentos.addCampo(Pagamentos); tbPagamentos.gravarTabela();

            Tabela tbContagem = new Tabela("ContagemProduto", "Codigo int(11)", true);
            string[] ContagemProduto = { "CodDocumento int(11)", "CodProduto int(11)", "Armazem varchar(100)", "Stock varchar(100)", "Qtdade decimal(18,2)", "Info varchar(100)", "Diferenca decimal(18,2)", "CodArmazem int(11)" };
            tbContagem.addCampo(ContagemProduto);
            tbContagem.addUnique("CodDocumento", "ContagemProduto");
            tbContagem.addChaveEstrangeira("CodProduto", "Produtos", "Codigo");
            tbContagem.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo"); tbContagem.gravarTabela();


            Tabela tbTransfProdutos = new Tabela("TransferenciaProduto", "Codigo int(11)", true);
            string[] TransferenciaProduto = { "CodDocumento int(11)", "CodProduto int(11)", "Qtidade decimal(18,2)", "Origem varchar(100)", "Destino varchar(100)", "CodOrigem int(11)", "CodDestino int(11)" };
            tbTransfProdutos.addCampo(TransferenciaProduto);
            tbTransfProdutos.addChaveEstrangeira("CodProduto", "Produtos", "Codigo");
            tbTransfProdutos.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo"); tbTransfProdutos.gravarTabela();

            Tabela tbFornecedores = new Tabela("Fornecedores", "codigo int(11)", true);
            string[] CFornecedores = { "CodEntidade int(11)" };
            tbFornecedores.addCampo(CFornecedores);
            tbFornecedores.addUnique("CodEntidade", "Fornecedores");
            tbFornecedores.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbFornecedores.gravarTabela();

            Tabela tbProdutosFornecedor = new Tabela("ProdutoFornecedor", "codigo int(11)", true);
            string[] ProdutoFornecedor = { "CodProduto int(11)", "CodFornecedor int(11)", "Custo decimal(18,2)" };
            tbProdutosFornecedor.addCampo(ProdutoFornecedor);
            tbProdutosFornecedor.addUnique("CodProduto,CodFornecedor", "ProdutoFornecedor");
            tbProdutosFornecedor.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            tbProdutosFornecedor.addChaveEstrangeira("CodFornecedor", "Fornecedores", "codigo"); tbProdutosFornecedor.gravarTabela();


            Tabela tbContatratos = new Tabela("Contrato", "IDContrato int(11)", true);
            string[] Contrato = { "IDPessoa int(11)", "CodCargo int(11)", "CodFuncao int(11)", "IDTipo int(11)", "DataInicio datetime", "DataTermino datetime", "Duracao varchar(20)", "PeriodoExperimental varchar(10)", "IDturno int(11)", "status int(11)", "FPagamento varchar(100)", "ContaCaixa varchar(50)", "FBanco int(11)", "FCaixa int(11)" };
            tbContatratos.addCampo(Contrato);
            tbContatratos.addChaveEstrangeira("IDPessoa", "Funcionarios", "IDPessoa");
            tbContatratos.addChaveEstrangeira("CodCargo", "Cargos", "Codigo");
            tbContatratos.addChaveEstrangeira("CodFuncao", "Funcao", "Codigo");
            tbContatratos.addChaveEstrangeira("IDTipo", "TipoContrato", "IDTipoContrato");
            tbContatratos.addChaveEstrangeira("IDTurno", "Turno", "IDTurno");
            tbContatratos.addChaveEstrangeira("FBanco", "ContasBancarias", "codigo");
            tbContatratos.addChaveEstrangeira("FCaixa", "Caixas", "codigo"); tbContatratos.gravarTabela();

            Tabela tbLimpeza = new Tabela("Limpeza", "Codigo int(11)", true);
            string[] CamposLimpeza = { "CodFuncionario int(11)", "CodUsuario int(11)", "Descricao varchar(3000)", "Data varchar(10)", "Hora varchar(10)", "CodMovHabitacao int(11)" };
            tbLimpeza.addCampo(CamposLimpeza);
            tbLimpeza.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbLimpeza.addChaveEstrangeira("CodFuncionario", "Funcionarios", "IDPessoa");
            tbLimpeza.addChaveEstrangeira("CodMovHabitacao", "MovHabitacoes", "Codigo");
            tbLimpeza.gravarTabela();


            Tabela tbPedidoManutencao = new Tabela("PedidoManutencao", "codigo int(11)", true);
            string[] PedidoManutencao = { "CodSector int(11)", "Data varchar(20)", "Descricao Text", "DataInicio varchar(100)", "DataTermino varchar(100)", "CodTecnico int(11)", "CodUsuario int(11)", "status int(11)" };
            tbPedidoManutencao.addCampo(PedidoManutencao);
            tbPedidoManutencao.addChaveEstrangeira("CodSector", "Sectores", "codigo");
            tbPedidoManutencao.addChaveEstrangeira("CodTecnico", "Tecnicos", "codigo");
            tbPedidoManutencao.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo"); tbPedidoManutencao.gravarTabela();

            Tabela tbAlunos = new Tabela("Alunos", "codigo int(11)", true);
            string[] CAlunos = { "CodEntidade int(11)", "status int(11)", "DataRegisto date" };
            tbAlunos.addUnique("CodEntidade", "Alunos");
            tbAlunos.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbAlunos.addCampo(CAlunos);
            tbAlunos.gravarTabela();

            Tabela tbConfirmacao = new Tabela("Confirmacao", "Codigo int(11)", true);
            string[] CConfirmacao = { "CodAluno int(11)", "CodTurma int(11)", "DataRegisto Date", "CodDocumento int(11)" };
            tbConfirmacao.addCampo(CConfirmacao);
            tbConfirmacao.addUnique("CodAluno,CodTurma", "Confirmacao");
            tbConfirmacao.addChaveEstrangeira("CodAluno", "Alunos", "codigo");
            tbConfirmacao.addChaveEstrangeira("CodTurma", "Turmas", "codigo");
            tbConfirmacao.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbConfirmacao.gravarTabela();

            // Trnsporte Escolar

            Tabela tbTransporte = new Tabela("Transporte", "codigo int(11)", true);
            string[] Transporte = { "Descricao varchar(200)" };
            tbTransporte.addCampo(Transporte);
            tbTransporte.addUnique("Descricao", "Transporte");
            tbTransporte.gravarTabela();

            Tabela tbTarifasTransporte = new Tabela("TarifasTransporte", "codigo int(11)", true);
            string[] TarifasTransporte = { "Descricao varchar(100)", "Contrato decimal(18,2)", "Mensalidade decimal(18,2)", "CobrarMulta int(11)", "TipoMulta int(11)", "ModalidadeMulta int(11)", "ValorMulta decimal(18,2)" };
            tbTarifasTransporte.addCampo(TarifasTransporte);
            tbTarifasTransporte.addUnique("Descricao", "TarifasTransporte");
            tbTarifasTransporte.gravarTabela();

            Tabela tbContratoTransporte = new Tabela("ContratoTransporte", "codigo int(11)", true);
            string[] ContratoTransporte = { "CodDocumento int(11)", "CodTransporte int(11)", "CodTarifa int(11)", "DataInicio Date", "OBS Text", "status int(11)" };
            tbContratoTransporte.addCampo(ContratoTransporte);
            tbContratoTransporte.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbContratoTransporte.addChaveEstrangeira("CodTransporte", "Transporte", "codigo");
            tbContratoTransporte.addChaveEstrangeira("CodTarifa", "TarifasTransporte", "codigo");
            tbContratoTransporte.gravarTabela();

            Tabela tbMensalidade = new Tabela("Mensalidades", "codigo int(11)", true);
            string[] Mensalidades = { "Descricao varchar(100)" };
            tbMensalidade.addCampo(Mensalidades);
            tbMensalidade.addUnique("Descricao", "Mensalidades");
            tbMensalidade.gravarTabela();

            Tabela tbMensaliadadeContratoTransporte = new Tabela("MensaliadadeContratoTransporte", "codigo int(11)", true);
            string[] MensaliadadeContratoTransporte = { "CodContrato int(11)", "CodMensalidade int(11)", "Ano int(11)", "Descricao varchar(100)", "Valor decimal(18,2)", "Multa decimal(18,2)", "Desconto decimal(18,2)", "Total decimal(18,2)", "Vencimento Date", "status int(11)", "CodDocumento int(11)" };
            tbMensaliadadeContratoTransporte.addCampo(MensaliadadeContratoTransporte);
            tbMensaliadadeContratoTransporte.addUnique("CodContrato,CodMensalidade,Ano", "MensaliadadeContratoTransporte");
            tbMensaliadadeContratoTransporte.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbMensaliadadeContratoTransporte.addChaveEstrangeira("CodContrato", "ContratoTransporte", "codigo");
            tbMensaliadadeContratoTransporte.addChaveEstrangeira("CodMensalidade", "Mensalidades", "codigo");
            tbMensaliadadeContratoTransporte.gravarTabela();

            // Fim Transporte

            Tabela tbPropinas = new Tabela("Propinas", "codigo int(11)", true);
            string[] Propinas = { "CodCursoEmolumento int(11)", "CodConfirmacao int(11)", "Descricao varchar(50)", "Valor decimal(18,2)", "Multa decimal(18,2)", "Desconto decimal(18,2)", "Total decimal(18,2)", "status int(11)", "CodDocumento int(11)", "Vencimento Date" };
            tbPropinas.addCampo(Propinas);
            tbPropinas.addUnique("CodCursoEmolumento, CodConfirmacao", "Propinas");
            tbPropinas.addChaveEstrangeira("CodCursoEmolumento", "CursosEmolumentos", "codigo");
            tbPropinas.addChaveEstrangeira("CodConfirmacao", "Confirmacao", "codigo");
            tbPropinas.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbPropinas.gravarTabela();

            Tabela tbNotas = new Tabela("Notas", "codigo int(11)", true);
            string[] Notas = { "CodConfirmacao int(11)", "CodProvaCriterio int(11)", "CodProDiscTurma int(11)", "Nota decimal(18,2)", "Data date", "DataRegisto datetime", "status int(11)" };
            tbNotas.addCampo(Notas);
            tbNotas.addUnique("CodProvaCriterio, CodConfirmacao, CodProDiscTurma ", "Notas");
            tbNotas.addChaveEstrangeira("CodProvaCriterio", "ProvasCriterioAvaliacao", "codigo");
            tbNotas.addChaveEstrangeira("CodProDiscTurma", "ProfessorDisciplinasTurmas", "codigo");
            tbNotas.addChaveEstrangeira("CodConfirmacao", "Confirmacao", "codigo");
            tbNotas.gravarTabela();

            Tabela tbMovimentos = new Tabela("Movimentos", "Codigo int(11)", true);
            string[] CMovimentos = { "Descricao varchar(100), Tipo varchar(20)" };
            tbMovimentos.addCampo(CMovimentos);
            tbMovimentos.addUnique("Descricao", "Movimentos");
            tbMovimentos.gravarTabela();

            Tabela tbMovimentosCargo = new Tabela("CargoMovimentos", "Codigo int(11)", true);
            string[] CMovimentosCargos = { "CodMovimento int(11), CodCargo int(11), Valor decimal(18,2)", "Descricao varchar(50)", "ValorPercentagem varchar(50)" };
            tbMovimentosCargo.addCampo(CMovimentosCargos);
            tbMovimentosCargo.addUnique("CodMovimento,CodCargo", "CargoMovimentos");
            tbMovimentosCargo.addChaveEstrangeira("CodMovimento", "Movimentos", "Codigo");
            tbMovimentosCargo.addChaveEstrangeira("CodCargo", "Cargos", "Codigo");
            tbMovimentosCargo.gravarTabela();

            Tabela tbPendentes = new Tabela("VendaPendente", "Codigo int(11)", true);
            string[] CPendentes = { "CodDocumento int(11), Cliente varchar(50)" };
            tbPendentes.addCampo(CPendentes);
            tbPendentes.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbPedidoManutencao.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbPendentes.gravarTabela();

            Tabela tbIOrdemSaque = new Tabela("Saque", "codigo int(11)", true);
            string[] itSaque = { "CodDocumento int(11)", "CodEmpresa int(11)", "CodEntidade int(11)", "CodConta int(11)", "NumeroBancario varchar(30)", "Mes varchar(100)", "Descricao varchar(500)", "Valor varchar(15)", "DataEmissao varchar(20)", "CodUsuario int(11)" };
            tbIOrdemSaque.addCampo(itSaque);
            tbIOrdemSaque.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbIOrdemSaque.addChaveEstrangeira("CodEmpresa", "Empresa", "codigo");
            tbIOrdemSaque.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbIOrdemSaque.addChaveEstrangeira("CodConta", "ContasBancarias", "Codigo");
            tbIOrdemSaque.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbIOrdemSaque.gravarTabela();

            Tabela tbUnidadeOS = new Tabela("UnidadeOS", "Codigo int(11)", true);
            string[] UnidadeOS = { "Descricao varchar(50)" };
            tbUnidadeOS.addCampo(UnidadeOS);
            tbUnidadeOS.addUnique("Descricao", "UnidadeOS");
            tbUnidadeOS.gravarTabela();

            Tabela tbServico = new Tabela("Servico", "Codigo int(11)", true);
            string[] Servico = { "Descricao varchar(50)", "Preco varchar(20)", "CodUnidade int(11)" };
            tbServico.addCampo(Servico);
            tbServico.addUnique("Descricao", "Servico");
            tbServico.addChaveEstrangeira("CodUnidade", "UnidadeOS", "Codigo");
            tbServico.gravarTabela();

            Tabela tbFabricante = new Tabela("Fabricante", "Codigo int(11)", true);
            string[] Fabricante = { "Descricao varchar(100)" };
            tbFabricante.addCampo(Fabricante);
            tbFabricante.addUnique("Descricao", "Fabricante");
            tbFabricante.gravarTabela();

            Tabela tbModelo = new Tabela("Modelo", "Codigo int(11)", true);
            string[] Modelo = { "Descricao varchar(50)", "CodFabricante int(11)" };
            tbModelo.addCampo(Modelo);
            tbModelo.addChaveEstrangeira("CodFabricante", "Fabricante", "Codigo");
            tbModelo.gravarTabela();

            Tabela tbEquipamento = new Tabela("Equipamento", "Codigo int(11)", true);
            string[] Equipamento = { "CodModelo int(11)", "MatriculaSerie varchar(50)" };
            tbEquipamento.addCampo(Equipamento);
            tbEquipamento.addChaveEstrangeira("CodModelo", "Modelo", "Codigo");
            tbEquipamento.gravarTabela();

            Tabela tbMovEquipamento = new Tabela("MovEquipamento", "Codigo int(11)", true);
            string[] MovEquipamento = { "CodEquipamento int(11)", "CodDocumento int(11)", "Descricao varchar(50)", "Fabricante varchar(50)", "Matricula varchar(50)" };
            tbMovEquipamento.addCampo(MovEquipamento);
            tbMovEquipamento.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovEquipamento.addChaveEstrangeira("CodEquipamento", "Equipamento", "Codigo");
            tbMovEquipamento.gravarTabela();


            Tabela tbModalidade = new Tabela("Modalidades", "Codigo int(11)", true);
            string[] Modalidades = { "Descricao varchar(50)" };
            tbModalidade.addCampo(Modalidades);
            tbModalidade.addUnique("Descricao", "Modalidades");
            tbModalidade.gravarTabela();

            Tabela tbAtendimento = new Tabela("Atendimento", "Codigo int(11)", true);
            string[] Atendimento = { "Descricao varchar(50)" };
            tbAtendimento.addCampo(Atendimento);
            tbAtendimento.addUnique("Descricao", "Atendimento");
            tbAtendimento.gravarTabela();

            Tabela tbGarantia = new Tabela("Garantia", "Codigo int(11)", true);
            string[] Garantia = { "Descricao varchar(50)" };
            tbGarantia.addCampo(Garantia);
            tbGarantia.addUnique("Descricao", "Garantia");
            tbGarantia.gravarTabela();

            Tabela tbOrdemServico = new Tabela("OrdemServico", "Codigo int(11)", true);
            string[] OrdemServico = { "CodDocumento int(11)", "CodModalidade int(11)", "CodAtendimento int(11)", "CodEquipamento int(11)", "Problema Text", "Observacao Text", "Solucao Text", "CodGarantia int(11)", "Entrada varchar(20)", "Saida varchar(20)" };
            tbOrdemServico.addCampo(OrdemServico);
            tbOrdemServico.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbOrdemServico.addChaveEstrangeira("CodModalidade", "Modalidades", "Codigo");
            tbOrdemServico.addChaveEstrangeira("CodAtendimento", "Atendimento", "Codigo");
            tbOrdemServico.addChaveEstrangeira("CodEquipamento", "Equipamento", "Codigo");
            tbOrdemServico.addChaveEstrangeira("CodGarantia", "Garantia", "Codigo");
            tbOrdemServico.gravarTabela();

            Tabela tbEntidadesAgencia = new Tabela("EntidadesAgencia", "Codigo int(11)", true);
            string[] EntidadesAgencia = { "CodEntidade int(11)", "Descricao varchar(200)", "Contacto varchar(30)", "Endereco varchar(500)", "Responsavel varchar(100)" };
            tbEntidadesAgencia.addCampo(EntidadesAgencia);
            tbEntidadesAgencia.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbEntidadesAgencia.gravarTabela();

            Tabela tbGuias = new Tabela("Guias", "Codigo int(11)", true);
            string[] Guias = { "CodDocumento int(11)", "CodPosto int(11)", "DataEntrega datetime", "Observacao Text", "status int(11)", "CodFactura int(11)" };
            tbGuias.addCampo(Guias);
            tbGuias.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbGuias.addChaveEstrangeira("CodPosto", "EntidadesAgencia", "Codigo");
            tbGuias.gravarTabela();

            Tabela tabela_Cores = new Tabela("Cores", "Codigo int(11)", true);
            string[] Campos_Cores = { "Descricao varchar(100)" };
            tabela_Cores.addCampo(Campos_Cores);
            tabela_Cores.addUnique("Descricao", "Cores");
            tabela_Cores.gravarTabela();

            Tabela tabela_Tecidos = new Tabela("Tecidos", "Codigo int(11)", true);
            string[] Campos_Tecidos = { "Descricao varchar(100)" };
            tabela_Tecidos.addCampo(Campos_Tecidos);
            tabela_Tecidos.addUnique("Descricao", "Tecidos");
            tabela_Tecidos.gravarTabela();

            Tabela tabela_TipoPeca = new Tabela("TipoPeca", "Codigo int(11)", true);
            string[] TipoPeca = { "Descricao varchar(100)" };
            tabela_TipoPeca.addCampo(TipoPeca);
            tabela_TipoPeca.addUnique("Descricao", "TipoPeca");
            tabela_TipoPeca.gravarTabela();


            Tabela tbPecas = new Tabela("Pecas", "Codigo int(11)", true);
            string[] Pecas = { "Descricao varchar(200)", "CodTipo int(11)", "CodCor int(11)", "CodTecido int(11)" };
            tbPecas.addCampo(Pecas);
            tbPecas.addChaveEstrangeira("CodTipo", "TipoPeca", "Codigo");
            tbPecas.addChaveEstrangeira("CodCor", "Cores", "Codigo");
            tbPecas.addChaveEstrangeira("CodTecido", "Tecidos", "Codigo");
            tbPecas.gravarTabela();

            Tabela tbMovProdutos = new Tabela("MovProdutos", "codigo int(11)", true);
            string[] MovProdutos = {
                "CodDocumento int(11)",
                "CodArmazem int(11)",
                "CodHabitacao int(11)",
                "CodProduto int(11)",
                "CodBarra int(11)",
                "Descricao varchar(100)",
                "Preco decimal(18,2)",
                "Retencao decimal(18,2)",
                "Qtdade decimal(18,2)",
                "Total decimal(18,2)",
                "Custo decimal(18,2)",
                "CodEquipamento int(11)",
                "Imposto decimal(18,2)",
                "Desconto decimal(18,2)",
                "DescontoGeral decimal(18,2)",
                "CodPeca int(11)",
                "CodStock int(11)",
                "ArtigoAbstrato varchar(300)",
                "TipoImposto varchar(100)",
                "CodImposto varchar(100)",
                "DescricaoImposto varchar(550)"
            };
            tbMovProdutos.addCampo(MovProdutos);
            tbMovProdutos.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbMovProdutos.addChaveEstrangeira("CodArmazem", "Armazens", "codigo");
            tbMovProdutos.addChaveEstrangeira("CodProduto", "Produtos", "codigo");
            tbMovProdutos.addChaveEstrangeira("CodHabitacao", "Habitacoes", "Codigo");
            tbMovProdutos.addChaveEstrangeira("CodEquipamento", "Equipamento", "Codigo");
            tbMovProdutos.addChaveEstrangeira("CodStock", "ProdutoStock", "codigo");
            tbMovProdutos.gravarTabela();


            Tabela tbMovServico = new Tabela("MovServico", "Codigo int(11)", true);
            string[] MovServico = { "CodDocumento int(11)", "CodEquipamento int(11)", "CodServico int(11)", "Descricao Text", "Preco varchar(50)", "Qtdade varchar(50)", "Total varchar(50)", "CodPeca int(11)" };
            tbMovServico.addCampo(MovServico);
            tbMovServico.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovServico.addChaveEstrangeira("CodServico", "Servico", "Codigo");
            tbMovServico.addChaveEstrangeira("CodEquipamento", "Equipamento", "Codigo");
            tbMovServico.gravarTabela();

            Tabela tbLavadeira = new Tabela("Lavadeira", "Codigo int(11)", true);
            string[] Lavadeira = { "CodEntidade int(11)" };
            tbLavadeira.addCampo(Lavadeira);
            tbLavadeira.addChaveEstrangeira("CodEntidade", "Funcionarios", "IDPessoa");
            tbLavadeira.gravarTabela();


            Tabela tbServicoLavandaria = new Tabela("ServicoLavandaria", "Codigo int(11)", true);
            string[] ServicoLavandaria = { "CodDocumento int(11)", "Entrada Date", "Saida Date", "Estado varchar(50)", "CodLavadeira int(11)", "Cabide varchar(50)", "CodUsuario int(11)" };
            tbServicoLavandaria.addCampo(ServicoLavandaria);
            tbServicoLavandaria.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbServicoLavandaria.addChaveEstrangeira("CodLavadeira", "Lavadeira", "Codigo");
            tbServicoLavandaria.addChaveEstrangeira("CodUsuario", "Usuarios", "codigo");
            tbServicoLavandaria.gravarTabela();

            Tabela tbTipoSaida = new Tabela("TipoSaida", "codigo int(11)", true);
            string[] TipoSaida = { "Descricao varchar(100)" };
            tbTipoSaida.addCampo(TipoSaida);
            tbTipoSaida.addUnique("Descricao", "TipoSaida");
            tbTipoSaida.gravarTabela();

            Tabela tbNotaSaida = new Tabela("NotaSaida", "codigo int(11)", true);
            string[] NotaSaida = { "CodDocumento int(11)", "Descricao Text", "CodTipoSaida int(11)" };
            tbNotaSaida.addCampo(NotaSaida);
            tbNotaSaida.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbNotaSaida.addChaveEstrangeira("CodTipoSaida", "TipoSaida", "Codigo");
            tbNotaSaida.gravarTabela();

            Tabela tbFacturaRecibo = new Tabela("FacturaRecibo", "codigo int(11)", true);
            string[] FacturaRecibo = { "CodDocumento int(11)", "CodFactura int(11)" };
            tbFacturaRecibo.addCampo(FacturaRecibo);
            tbFacturaRecibo.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbFacturaRecibo.gravarTabela();

            Tabela tbTarefas = new Tabela("Tarefas", "codigo int(11)", true);
            string[] Tarefas = { "Descricao Text", "DataHora varchar(20)", "CodFuncionario int(11)", "CodUsuario int(11)", "Estado varchar(20)" };
            tbTarefas.addChaveEstrangeira("CodFuncionario", "Funcionarios", "IDPessoa");
            tbTarefas.addChaveEstrangeira("CodUsuario", "Usuarios", "Codigo");
            tbTarefas.addCampo(Tarefas); tbTarefas.gravarTabela();


            // Novas Tabelas Para os Pts

            Tabela tbPts = new Tabela("PTs", "codigo int(11)", true);
            string[] Pts = { "Descricao varchar(100)" };
            tbPts.addCampo(Pts);
            tbPts.addUnique("Descricao", "PTs");
            tbPts.gravarTabela();

            Tabela tbAnoPt = new Tabela("AnoPt", "codigo int(11)", true);
            string[] AnoPt = { "Descricao int(11)", "status int(11)" };
            tbAnoPt.addCampo(AnoPt);
            tbAnoPt.addUnique("Descricao", "AnoPt");
            tbAnoPt.gravarTabela();

            Tabela tbPtsBairro = new Tabela("Bairro", "codigo int(11)", true);
            string[] PtsBairro = { "Descricao varchar(100)" };
            tbPtsBairro.addCampo(PtsBairro);
            tbPtsBairro.addUnique("Descricao", "Bairro");
            tbPtsBairro.gravarTabela();

            Tabela tbDefPt = new Tabela("DefPt", "codigo int(11)", true);
            string[] DefPt = { "AnoInicial int(11)", "AnoActual int(11)", "CobrarMultaAposDia int(11)", "VencimentoAposDia int(11)", "MaxMulta decimal(18,2)" };
            tbDefPt.addCampo(DefPt);
            tbDefPt.gravarTabela();


            Tabela tbTarifasPt = new Tabela("TarifasPt", "codigo int(11)", true);
            string[] TarifasPt = { "Descricao varchar(100)", "Contrato decimal(18,2)", "Mensalidade decimal(18,2)", "CobrarMulta int(11)", "TipoMulta int(11)", "ModalidadeMulta int(11)", "ValorMulta decimal(18,2)" };
            tbTarifasPt.addCampo(TarifasPt);
            tbTarifasPt.addUnique("Descricao", "TarifasPt");
            tbTarifasPt.gravarTabela();

            Tabela tbClausulasPt = new Tabela("Clausulas", "Codigo int(11)", true);
            string[] Clausulas = { "Ordem varchar(50)", "Descricao Text" };
            tbClausulasPt.addCampo(Clausulas);
            tbClausulasPt.addUnique("Ordem", "Clausulas");
            tbClausulasPt.gravarTabela();

            Tabela tbContratoPt = new Tabela("ContratoPt", "codigo int(11)", true);
            string[] ContratoPt = { "CodDocumento int(11)", "CodPt int(11)", "CodBairro int(11)", "CodTarifa int(11)", "Referencia varchar(100)", "Casa varchar(20)", "DataInicio Date", "OBS Text", "status int(11)" };
            tbContratoPt.addCampo(ContratoPt);
            tbContratoPt.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbContratoPt.addChaveEstrangeira("CodPt", "PTs", "codigo");
            tbContratoPt.addChaveEstrangeira("CodBairro", "Bairro", "codigo");
            tbContratoPt.addChaveEstrangeira("CodTarifa", "TarifasPt", "codigo");
            tbContratoPt.gravarTabela();

            Tabela tbMensaliadadeContratoPt = new Tabela("MensaliadadeContratoPt", "codigo int(11)", true);
            string[] MensaliadadeContratoPt = { "CodContrato int(11)", "CodMensalidade int(11)", "Ano int(11)", "Descricao varchar(100)", "Valor decimal(18,2)", "Multa decimal(18,2)", "Desconto decimal(18,2)", "Total decimal(18,2)", "Vencimento Date", "status int(11)", "CodDocumento int(11)" };
            tbMensaliadadeContratoPt.addCampo(MensaliadadeContratoPt);
            tbMensaliadadeContratoPt.addUnique("CodContrato,CodMensalidade,Ano", "MensaliadadeContratoPt");
            tbMensaliadadeContratoPt.addChaveEstrangeira("CodDocumento", "Documentos", "codigo");
            tbMensaliadadeContratoPt.addChaveEstrangeira("CodContrato", "ContratoPt", "codigo");
            tbMensaliadadeContratoPt.addChaveEstrangeira("CodMensalidade", "Mensalidades", "codigo");
            tbMensaliadadeContratoPt.gravarTabela();


            // ################ TABELAS Venda extra ##########################
            

            // ################ TABELAS GINASIO ##########################

            Tabela tbGinasioAlunos = new Tabela("GinasioAlunos", "Codigo int(11)", true);
            string[] CGAlunos = { "CodEntidade int(11)", "Activo int(11)" };
            tbGinasioAlunos.addUnique("CodEntidade", "GinasioAlunos");
            tbGinasioAlunos.addChaveEstrangeira("CodEntidade", "EntidadesPessoa", "CodEntidade");
            tbGinasioAlunos.addCampo(CGAlunos);
            tbGinasioAlunos.gravarTabela();

            Tabela tbGinasioProfessores = new Tabela("GinasioProfessores", "Codigo int(11)", true);
            string[] Campos_GinasioProfessores = { "CodEntidade int(11)", "Activo int(11)" };
            tbGinasioProfessores.addUnique("CodEntidade", "GinasioProfessores");
            tbGinasioProfessores.addChaveEstrangeira("CodEntidade", "EntidadesPessoa", "CodEntidade");
            tbGinasioProfessores.addCampo(Campos_GinasioProfessores);
            tbGinasioProfessores.gravarTabela();

            Tabela tbGinasioAcessos = new Tabela("GinasioAcessos", "codigo int(11)", true);
            string[] CGinasioAcessos = { "CodAluno int(11)", "Data Date", "Hora Date" };
            tbGinasioAcessos.addChaveEstrangeira("CodAluno", "GinasioAlunos", "Codigo");
            tbGinasioAcessos.addCampo(CGinasioAcessos);
            tbGinasioAcessos.gravarTabela();

            Tabela tabela_GinasioExercicios = new Tabela("GinasioExercicios", "Codigo int(11)", true);
            string[] Campos_tabela_GinasioExercicios = { "Descricao varchar(100)" };
            tabela_GinasioExercicios.addCampo(Campos_tabela_GinasioExercicios);
            tabela_GinasioExercicios.addUnique("Descricao", "GinasioExercicios");
            tabela_GinasioExercicios.gravarTabela();

            Tabela tabela_GinasioCatraca = new Tabela("GinasioCatracas", "Codigo int(11)", true);
            string[] Campos_GinasioCatraca = { "Descricao varchar(100)", "Comando varchar(100)" };
            tabela_GinasioCatraca.addCampo(Campos_GinasioCatraca);
            tabela_GinasioCatraca.addUnique("Descricao", "GinasioCatraca");
            tabela_GinasioCatraca.gravarTabela();

            Tabela tabela_GinasioModalidades = new Tabela("GinasioModalidades", "Codigo int(11)", true);
            string[] Campos_GinasioModalidades = { "Descricao varchar(100)", "ValorMensal decimal(18,2)", "ValorDiario decimal(18,2)" };
            tabela_GinasioModalidades.addCampo(Campos_GinasioModalidades);
            tabela_GinasioModalidades.addUnique("Descricao", "GinasioModalidades");
            tabela_GinasioModalidades.gravarTabela();

            Tabela tabela_GinasioProfessorModalidades = new Tabela("GinasioProfessorModalidades", "Codigo int(11)", true);
            string[] Campos_GinasioProfessorModalidades = { "CodProfessor int(11)", "CodModalidade int(11)" };
            tabela_GinasioProfessorModalidades.addCampo(Campos_GinasioProfessorModalidades);
            tabela_GinasioProfessorModalidades.addChaveEstrangeira("CodProfessor", "GinasioProfessores", "Codigo");
            tabela_GinasioProfessorModalidades.addChaveEstrangeira("CodModalidade", "GinasioModalidades", "Codigo");
            tabela_GinasioProfessorModalidades.gravarTabela();

            Tabela tabela_GinasioTurmas = new Tabela("GinasioTurmas", "Codigo int(11)", true);
            string[] Campos_GinasioGinasioTurmas = { "Descricao varchar(100)", "CodModalidade int(11)", "Estado int(11)" };
            tabela_GinasioTurmas.addCampo(Campos_GinasioGinasioTurmas);
            tabela_GinasioModalidades.addUnique("Descricao", "GinasioTurmas");
            tabela_GinasioTurmas.addChaveEstrangeira("CodModalidade", "GinasioModalidades", "Codigo");
            tabela_GinasioTurmas.gravarTabela();

            Tabela tabela_GinasioAlunosTurmas = new Tabela("GinasioAlunosTurmas", "Codigo int(11)", true);
            string[] Campos_AlunosTurma = { "CodAluno int(11)", "CodTurma int(11)", "Activo int(11)" };
            tabela_GinasioAlunosTurmas.addCampo(Campos_AlunosTurma);
            tabela_GinasioAlunosTurmas.addChaveEstrangeira("CodAluno", "GinasioAlunos", "Codigo");
            tabela_GinasioAlunosTurmas.addChaveEstrangeira("CodTurma", "GinasioTurmas", "Codigo");
            tabela_GinasioAlunosTurmas.gravarTabela();

            Tabela tbMovPecas = new Tabela("MovPecas", "Codigo int(11)", true);
            string[] MovPecas = { "CodPeca int(11)", "CodDocumento int(11)", "Descricao varchar(200)", "Cor varchar(200)", "Tecido varchar(200)", "Tipo varchar(100)" };
            tbMovPecas.addCampo(MovPecas);
            tbMovPecas.addChaveEstrangeira("CodPeca", "Pecas", "Codigo");
            tbMovPecas.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovPecas.gravarTabela();

            // ================ Agência de Viagens =======================

            Tabela tbLegDocumento = new Tabela("LegDocumento", "Codigo int(11)", true);
            string[] LegDocumento = { "Descricao varchar(100)" };
            tbLegDocumento.addCampo(LegDocumento);
            tbLegDocumento.addUnique("Descricao", "LegDocumento"); tbLegDocumento.gravarTabela();

            Tabela tbInstituicao = new Tabela("Instituicao", "Codigo int(11)", true);
            string[] Instituicao = { "Descricao varchar(100)" };
            tbInstituicao.addCampo(Instituicao);
            tbInstituicao.addUnique("Descricao", "Instituicao"); tbInstituicao.gravarTabela();

            Tabela tbEmbaixadas = new Tabela("Embaixadas", "Codigo int(11)", true);
            string[] Embaixadas = { "Descricao varchar(100)" };
            tbEmbaixadas.addCampo(Embaixadas);
            tbEmbaixadas.addUnique("Descricao", "Embaixadas"); tbEmbaixadas.gravarTabela();
            // 
            Tabela tbSeguradora = new Tabela("Seguradora", "Codigo int(11)", true);
            string[] Seguradora = { "Descricao varchar(100)" };
            tbSeguradora.addCampo(Seguradora);
            tbSeguradora.addUnique("Descricao", "Seguradora"); tbSeguradora.gravarTabela();

            Tabela tbTransportadora = new Tabela("Transportadora", "Codigo int(11)", true);
            string[] Transportadora = { "Descricao varchar(100)" };
            tbTransportadora.addCampo(Transportadora);
            tbTransportadora.addUnique("Descricao", "Transportadora"); tbTransportadora.gravarTabela();

            Tabela tbCompraBilhete = new Tabela("CompraBilhete", "Codigo int(11)", true);
            string[] CompraBilhete = { "CodDocumento int(11)", "DataIda date", "DataVolta date", "Detalhes Text", "Companhia varchar(100)", "Origem varchar(100)", "Destino varchar(100)", "Topologia varchar(100)" };
            tbCompraBilhete.addCampo(CompraBilhete);
            tbCompraBilhete.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbCompraBilhete.gravarTabela();

            Tabela tbMovDocSeguradora = new Tabela("MovDocSeguradora", "Codigo int(11)", true);
            string[] MovDocSeguradora = { "CodDocumento int(11)", "CodSeguradora int(11)" };
            tbMovDocSeguradora.addCampo(MovDocSeguradora);
            tbMovDocSeguradora.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovDocSeguradora.addChaveEstrangeira("CodSeguradora", "Seguradora", "Codigo");
            tbMovDocSeguradora.gravarTabela();

            Tabela tbMovDocTrasportadora = new Tabela("MovDocTrasportadora", "Codigo int(11)", true);
            string[] MovDocTrasportadora = { "CodDocumento int(11)", "CodTransportadora int(11)" };
            tbMovDocTrasportadora.addCampo(MovDocTrasportadora);
            tbMovDocTrasportadora.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovDocTrasportadora.addChaveEstrangeira("CodTransportadora", "Transportadora", "Codigo");
            tbMovDocTrasportadora.gravarTabela();

            Tabela tbMovDocEmbaixada = new Tabela("MovDocEmbaixada", "Codigo int(11)", true);
            string[] MovDocEmbaixada = { "CodDocumento int(11)", "CodEmbaixada int(11)", "Observacao varchar(100)" };
            tbMovDocEmbaixada.addCampo(MovDocEmbaixada);
            tbMovDocEmbaixada.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovDocEmbaixada.addChaveEstrangeira("CodEmbaixada", "Embaixadas", "Codigo");
            tbMovDocEmbaixada.gravarTabela();

            Tabela tbMovDocInstituicao = new Tabela("MovDocInstituicao", "Codigo int(11)", true);
            string[] MovDocInstituicao = { "CodDocumento int(11)", "CodInstituicao int(11)", "Observação varchar(100)" };
            tbMovDocInstituicao.addCampo(MovDocInstituicao);
            tbMovDocInstituicao.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovDocInstituicao.addChaveEstrangeira("CodInstituicao", "Instituicao", "Codigo");
            tbMovDocInstituicao.gravarTabela();

            Tabela tbMovLegDocumentos = new Tabela("MovLegDocumentos", "Codigo int(11)", true);
            string[] MovLegDocumentos = { "CodDocumento int(11)", "CodLegDoc int(11)" };
            tbMovLegDocumentos.addCampo(MovLegDocumentos);
            tbMovLegDocumentos.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovLegDocumentos.addChaveEstrangeira("CodLegDoc", "LegDocumento", "Codigo");
            tbMovLegDocumentos.gravarTabela();


           /////////////////
            #region Hospitalar // ################ TABELAS HOSPITALAR ##########################

            Tabela tbEscala = new Tabela("Escala", "Codigo int(11)", true);
            string[] Campos_tbEscala = { "Descricao varchar(100)", "HorasSemanal int(11)" };
            tbEscala.addCampo(Campos_tbEscala);
            tbEscala.gravarTabela();

            Tabela tbMedicos = new Tabela("Medicos", "Codigo int(11)", true);
            string[] Campos_tbMedico = { "CodPessoa int(11)", "NumeroCarteira varchar(15)", "CodEscala int(11) NULL", "status int(11)" };
            tbMedicos.addCampo(Campos_tbMedico);
            tbMedicos.addChaveEstrangeira("CodPessoa", "EntidadesPessoa", "CodEntidade");
            tbMedicos.addChaveEstrangeira("CodEscala", "Escala", "Codigo");
            tbMedicos.gravarTabela();

            //tabela AreaSaude
            Tabela tbAreaSaude = new Tabela("AreaSaude", "Codigo int(11)", true);
            string[] Campos_tbAreaSaude = { "Descricao varchar(100)"};
            tbAreaSaude.addCampo(Campos_tbAreaSaude);
            tbAreaSaude.gravarTabela();

            //tabela ProfissionalSaude
            Tabela tbProfissionalSaude = new Tabela("ProfissionalSaude", "Codigo int(11)", true);
            string[] Campos_tbProfissionalSaude = { "CodEntidade int(11)", "status int(11)" };
            tbProfissionalSaude.addCampo(Campos_tbProfissionalSaude);
            tbProfissionalSaude.addChaveEstrangeira("CodEntidade", "Entidades", "Codigo");
            tbProfissionalSaude.addUnique("CodEntidade", "ProfissionalSaude");
            tbProfissionalSaude.gravarTabela();


            //tabela AreaSaudeProfissional
            Tabela tbAreaSaudeProfissional = new Tabela("AreaSaudeProfissional", "Codigo int(11)", true);
            string[] Campos_tbtbAreaSaudeProfissional = { "CodProfissionalSaude int(11)", "CodAreaSaude int(11)" };
            tbAreaSaudeProfissional.addCampo(Campos_tbtbAreaSaudeProfissional);
            tbAreaSaudeProfissional.addChaveEstrangeira("CodProfissionalSaude", "ProfissionalSaude", "Codigo");
            tbAreaSaudeProfissional.addChaveEstrangeira("CodAreaSaude", "AreaSaude", "Codigo");
            tbAreaSaudeProfissional.gravarTabela();
            
            Tabela tbGrupoSanguineos = new Tabela("GrupoSanguineos", "Codigo int(11)", true);
            string[] Campos_tbGrupoSanguineos = { "Descricao varchar(10)" };
            tbGrupoSanguineos.addCampo(Campos_tbGrupoSanguineos);
            tbGrupoSanguineos.gravarTabela();

            Tabela tbPacientes = new Tabela("Pacientes", "Codigo int(11)", true);
            string[] Campos_tbPacientes = { "CodPessoa int(11) unique", "CodGrupoSanguineos int(11)", "status int default 1" };
            tbPacientes.addCampo(Campos_tbPacientes);
            tbPacientes.addChaveEstrangeira("CodPessoa", "EntidadesPessoa", "CodEntidade");
            tbPacientes.addChaveEstrangeira("CodGrupoSanguineos", "GrupoSanguineos", "Codigo");
            tbPacientes.gravarTabela();

            //////////////////////////////////////MILTON INTERNAMENTO/////////////////////////////////

            Tabela tbAreasHospitalar = new Tabela("AreasHospitalar", "Codigo int(11)", true);
            string[] Campos_AreasHospitalar = { "Descricao varchar(100)" };
            tbAreasHospitalar.addCampo(Campos_AreasHospitalar);
            tbAreasHospitalar.addUnique("Descricao", "AreasHospitalar");
            tbAreasHospitalar.gravarTabela();

            Tabela tbTiposQuartos = new Tabela("TiposQuartosHospitalar", "Codigo int(11)", true);
            string[] Campos_TiposQuartos = { "Descricao varchar(100)" };
            tbTiposQuartos.addCampo(Campos_TiposQuartos);
            tbTiposQuartos.addUnique("Descricao", "TiposQuartosHospitalar");
            tbTiposQuartos.gravarTabela();

            Tabela tbTiposCamas = new Tabela("TiposCamasHospitalar", "Codigo int(11)", true);
            string[] Campos_TiposCamas = { "Descricao varchar(100)" };
            tbTiposCamas.addCampo(Campos_TiposCamas);
            tbTiposCamas.addUnique("Descricao", "TiposCamasHospitalar");
            tbTiposCamas.gravarTabela();

            Tabela tbCamasHospitalar = new Tabela("CamasHospitalar", "Codigo int(11)", true);
            string[] Campo_CamasHospitalar = { "Descricao varchar(100)", "Ocupado varchar(20)", "CodTiposCamasHospitalar int(11)" };
            tbCamasHospitalar.addCampo(Campo_CamasHospitalar);
            tbCamasHospitalar.addChaveEstrangeira("CodTiposCamasHospitalar", "TiposCamasHospitalar", "Codigo");
            tbCamasHospitalar.addUnique("Descricao", "CamasHospitalar");
            tbCamasHospitalar.gravarTabela();

            Tabela TbTarifaHospitalar = new Tabela("TarifaHospitalar", "Codigo int(11)", true);
            string[] Campo_TarifaHospitalar = { "CodTiposQuartosHospitalar int(11)", "CodTiposCamasHospitalar int(11)", "TipoTarifa varchar(11)", "Descricao varchar(100)", "Horas int(11)", "Valor decimal(18,2)", "CodImposto int(11)", "CodMotivoIsencao int(11)" };
            TbTarifaHospitalar.addCampo(Campo_TarifaHospitalar);
            TbTarifaHospitalar.addChaveEstrangeira("CodTiposQuartosHospitalar", "TiposQuartosHospitalar", "Codigo");
            TbTarifaHospitalar.addChaveEstrangeira("CodTiposCamasHospitalar", "TiposCamasHospitalar", "Codigo");
            TbTarifaHospitalar.addChaveEstrangeira("CodImposto", "Imposto", "Codigo");
            TbTarifaHospitalar.addChaveEstrangeira("CodMotivoIsencao", "MotivoIsencao", "Codigo");
            TbTarifaHospitalar.addUnique("Descricao", "TarifaHospitalar");
            TbTarifaHospitalar.gravarTabela();

            Tabela TbQuartosHospitalar = new Tabela("QuartosHospitalar", "Codigo int(11)", true);
            string[] Campo_TbQuartosHospitalar = { "CodAreasHospitalar int(11)", "Descricao varchar(100)", "CodTiposQuartosHospitalar int(11)", "Manutencao varchar(20)" };
            TbQuartosHospitalar.addCampo(Campo_TbQuartosHospitalar);
            TbQuartosHospitalar.addChaveEstrangeira("CodTiposQuartosHospitalar", "TiposQuartosHospitalar", "Codigo");
            TbQuartosHospitalar.addChaveEstrangeira("CodAreasHospitalar", "AreasHospitalar", "Codigo");
            TbQuartosHospitalar.gravarTabela();

            Tabela TbCamasQuartosHospitalar = new Tabela("CamasQuartosHospitalar", "Codigo int(11)", true);
            string[] Campo_TbCamasQuartosHospitalar = { "CodQuartosHospitalar int(11)", "CodCamasHospitalar int(11)" };
            TbCamasQuartosHospitalar.addCampo(Campo_TbCamasQuartosHospitalar);
            TbCamasQuartosHospitalar.addChaveEstrangeira("CodQuartosHospitalar", "QuartosHospitalar", "Codigo");
            TbCamasQuartosHospitalar.addChaveEstrangeira("CodCamasHospitalar", "CamasHospitalar", "Codigo");
            TbCamasQuartosHospitalar.addUnique("CodCamasHospitalar", "CamasHospitalar");
            TbCamasQuartosHospitalar.gravarTabela();

            Tabela tbInternamento = new Tabela("Internamento", "Codigo int(11)", true);
            string[] Compo_Internamentos = { "CodTiposQuartosHospitalar int(11)", "CodAreasHospitalar int(11)", "Descricao varchar(100)", "CodCamasHospitalar int(11)", "Manutencao int(11)", "Venda varchar(20)", "Estado varchar(20)" };
            tbInternamento.addCampo(Compo_Internamentos);
            tbInternamento.addUnique("Descricao", "Internamento");
            tbInternamento.addChaveEstrangeira("CodTiposQuartosHospitalar", "TiposQuartosHospitalar", "Codigo");
            tbInternamento.addChaveEstrangeira("CodAreasHospitalar", "AreasHospitalar", "Codigo");
            tbInternamento.addChaveEstrangeira("CodCamasHospitalar", "CamasHospitalar", "Codigo");
            tbInternamento.gravarTabela();

            Tabela tbSeguradoraHospitalar = new Tabela("SeguradoraHospitalar", "Codigo int(11)", true);
            string[] Campos_tbSeguradora = { "Descricao varchar(100)" };
            tbSeguradoraHospitalar.addUnique("Descricao", "SeguradoraHospitalar");
            tbSeguradoraHospitalar.addCampo(Campos_tbSeguradora);
            tbSeguradoraHospitalar.gravarTabela();

            Tabela tbMovHospitalar = new Tabela("MovHospitalar", "Codigo int(11)", true);
            string[] MovHospitalar = { "CodDocumento int(11)", "CodQuartosHospitalar int(11)", "CodTarifaHospitalar int(11)", "Checkin varchar(40)",  "Horas int(11)", "Quantidade varchar(40)", "Preco varchar(40)"};
            tbMovHospitalar.addCampo(MovHospitalar);
            tbMovHospitalar.addChaveEstrangeira("CodDocumento", "Documentos", "Codigo");
            tbMovHospitalar.addChaveEstrangeira("CodQuartosHospitalar", "QuartosHospitalar", "Codigo");
            tbMovHospitalar.addChaveEstrangeira("CodTarifaHospitalar", "TarifaHospitalar", "Codigo");
            tbMovHospitalar.gravarTabela();

            ///////////////////////////////////////////////////////////// / ///////////////////////////////////////////////////////////////



            Tabela tbEspecialidades = new Tabela("Especialidades", "Codigo int(11)", true);
            string[] Campos_tbEspecialidades = { "Descricao varchar(100)" };
            tbEspecialidades.addCampo(Campos_tbEspecialidades);
            tbEspecialidades.gravarTabela();

            Tabela tbMedicosEspecialidades = new Tabela("MedicosEspecialidades", "Codigo int(11)", true);
            string[] Campos_tbMedicosEspecialidades = { "CodMedico int(11)", "CodEspecialidade int(11)" };
            tbMedicosEspecialidades.addCampo(Campos_tbMedicosEspecialidades);
            tbMedicosEspecialidades.addChaveEstrangeira("CodEspecialidade", "Especialidades", "Codigo");
            tbMedicosEspecialidades.addChaveEstrangeira("CodMedico", "Medicos", "Codigo");
            tbMedicosEspecialidades.gravarTabela();

           

            Tabela tbFarmacos = new Tabela("Farmacos", "Codigo int(11)", true);
            string[] Campos_tbFarmacos = { "Descricao varchar(100)" };
            tbFarmacos.addCampo(Campos_tbFarmacos);
            tbFarmacos.gravarTabela();

            Tabela tbTipoConsultas = new Tabela("TipoConsultas", "Codigo int(11)", true);
            string[] Campos_tbTipoConsultas = {
                "Descricao varchar(100)",
                " Valor decimal(18,2)",
                "Tempo varchar(11)",
                "CodEspecialidade int(11)",
                "CodImposto int(11)",
                "CodMotivoIsencao int(11)"
            };
            tbTipoConsultas.addCampo(Campos_tbTipoConsultas);
            tbTipoConsultas.addChaveEstrangeira("CodEspecialidade", "Especialidades", "Codigo");
            tbTipoConsultas.addChaveEstrangeira("CodImposto", "Imposto", "Codigo");
            tbTipoConsultas.addChaveEstrangeira("CodMotivoIsencao", "MotivoIsencao", "Codigo");
            tbTipoConsultas.gravarTabela();

       

            Tabela tbExamesHospitalar = new Tabela("ExamesHospitalar", "Codigo int(11)", true);
            string[] Campos_tbExamesHospitalar = {
                "Descricao varchar(100)",
                "CodImposto int(11)",
                "CodMotivoIsencao int(11)",
                "CodSubCategoria int(11)",
                "Custo decimal(18,2)",
                "Preco decimal(18,2)",
                "Lucro decimal(18,2)",
                "PrecoVenda decimal(18,2)",
                "Foto LongBlob",
                "status int(11) default 1" };
            tbExamesHospitalar.addCampo(Campos_tbExamesHospitalar);
            tbExamesHospitalar.addChaveEstrangeira("CodImposto", "Imposto", "Codigo");
            tbExamesHospitalar.addChaveEstrangeira("CodMotivoIsencao", "MotivoIsencao", "Codigo");
            tbExamesHospitalar.addChaveEstrangeira("CodSubCategoria", "SubCategoria", "Codigo");
            tbExamesHospitalar.gravarTabela();         

            Tabela tbEscalaConfig = new Tabela("EscalaConfig", "Codigo int(11)", true);
            string[] Campos_tbEscalaConfig = { "CodEscala int(11)", "CodDia int(11)", "Entrada varchar(10)", "Saida varchar(10)", "Checa int(11)" };
            tbEscalaConfig.addCampo(Campos_tbEscalaConfig);
            tbEscalaConfig.addChaveEstrangeira("CodEscala", "Escala", "Codigo");
            tbEscalaConfig.addChaveEstrangeira("CodDia", "DiasSemana", "IDDias");
            tbEscalaConfig.gravarTabela();

            Tabela tbPrioridade = new Tabela("Prioridade", "Codigo int(11)", true);
            string[] Campos_tbPrioridade = { "Descricao varchar(100)" };
            tbPrioridade.addCampo(Campos_tbPrioridade);
            tbPrioridade.gravarTabela();

            Tabela tbTipoServico = new Tabela("TipoServico", "Codigo int(11)", true);
            string[] Campos_tbTipoServico = { "Descricao varchar(100)" };
            tbTipoServico.addCampo(Campos_tbTipoServico);
            tbTipoServico.gravarTabela();

            Tabela tbAtendimentoHospitalar = new Tabela("AtendimentoHospitalar", "Codigo int(11)", true);
            string[] Campos_tbAtendimentoHospitalar = {
                "CodPaciente int(11)",
                "Data date",
                "Facturado varchar(50)",
                "status int(11)",
                "CodTipoConsulta int(11)",
                "Total decimal(18,2)",
                "CodUsuario int(11)"
            };
            tbAtendimentoHospitalar.addCampo(Campos_tbAtendimentoHospitalar);
            tbAtendimentoHospitalar.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbAtendimentoHospitalar.addChaveEstrangeira("CodTipoConsulta", "TipoConsultas", "Codigo");
            tbAtendimentoHospitalar.addChaveEstrangeira("CodUsuario", "Usuarios", "Codigo");
            tbAtendimentoHospitalar.gravarTabela();


            Tabela tbPacienteInternado = new Tabela("PacienteInternado", "Codigo int(11)", true);
            string[] PacienteInternado = {
                "CodAtendimentoHospitalar int(11)",
                "CodQuartosHospitalar int(11)",
                "CodCamasHospitalar int(11)",
                "CodTarifaHospitalar int(11)",
                "Dias int(11)",
                "DataEntrada DateTime",
                "DataSaida DateTime",
                "Valor decimal(18, 2)",
                "Total decimal(18, 2)",
                "Estado varchar(50)",
                "Facturado varchar(50)"
            };
            tbPacienteInternado.addCampo(PacienteInternado);
            tbPacienteInternado.addChaveEstrangeira("CodQuartosHospitalar", "QuartosHospitalar", "Codigo");
            tbPacienteInternado.addChaveEstrangeira("CodAtendimentoHospitalar", "AtendimentoHospitalar", "Codigo");
            tbPacienteInternado.addChaveEstrangeira("CodCamasHospitalar", "CamasHospitalar", "Codigo");
            tbPacienteInternado.addChaveEstrangeira("CodTarifaHospitalar", "TarifaHospitalar", "Codigo");
            tbPacienteInternado.gravarTabela();

            Tabela tbTriagem = new Tabela("Triagem", "Codigo int(11)", true);
            string[] Campos_tbTriagem = {
                "CodPaciente int(11)",
                "Temperatura decimal(18,2)",
                "TemperaturaArterial varchar(150)",
                "Peso decimal(18,2)",
                "FrequenciaRespiratoria decimal(18,2)",
                "FrequenciaCardiaca decimal(18,2)",
                "CodAtendimento int(11)",
                "Data date",
                "Hora varchar(5)"
            };
            tbTriagem.addCampo(Campos_tbTriagem);
            tbTriagem.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbTriagem.addChaveEstrangeira("CodAtendimento", "AtendimentoHospitalar", "Codigo");
            tbTriagem.gravarTabela();

            Tabela tbConsultaHospitalar = new Tabela("ConsultaHospitalar", "Codigo int(11)", true);
            string[] Campos_tbConsultaHospitalar = {
                "CodPaciente int(11)",
                "CodTipoConsulta int(11)",
                "Data date",
                "HoraInicial varchar(10)",
                "TempoEstimado varchar(10)",
                "ValorConsulta decimal(18,2)",
                "CodPrioridade int(11)",
                "CodTipoServico int(11)",
                "CodMedico int(11)",
                "Observacao text",
                "status int(11)",
                "CodAtendimento int(11)",
                "CodImposto int(11)",
                "CodMotivoIsencao int(11)",
                "Atendido VarChar(250)",
                "Facturado VarChar(100)",
                "Anaminizes Text",
                "QueixaPrincipal  Text",
                "EvolucaoTratamento  Text"
            };
            tbConsultaHospitalar.addCampo(Campos_tbConsultaHospitalar);
            tbConsultaHospitalar.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodTipoConsulta", "TipoConsultas", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodPrioridade", "Prioridade", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodTipoServico", "TipoServico", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodMedico", "Medicos", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodAtendimento", "AtendimentoHospitalar", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodImposto", "Imposto", "Codigo");
            tbConsultaHospitalar.addChaveEstrangeira("CodMotivoIsencao", "MotivoIsencao", "Codigo");
            tbConsultaHospitalar.gravarTabela();

            Tabela tbExamesAtendimento = new Tabela("ExamesAtendimento", "Codigo int(11)", true);
            string[] Campos_tbExamesAtendimento = {
                "CodPaciente int(11)",
                "CodExame int(11)",
                "Data date",
                "CodAtendimento int(11)",
                "CodProfissionalSaude int(11)",
                "TipoResultado text",
                "Estado text",
                "status int(11)",
                "Medico varchar(150)",
                "NumeroProcesso  varchar(150)",
                "NumeroAmostra   varchar(150)",
                "ViaDocumento  varchar(150)",
                "Unidade  varchar(150)",
                "VReferencia  varchar(150)",
                "Facturado varchar(100) default 'Não'"
            };
            tbExamesAtendimento.addCampo(Campos_tbExamesAtendimento);
            tbExamesAtendimento.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbExamesAtendimento.addChaveEstrangeira("CodExame", "ExamesHospitalar", "Codigo");
            tbExamesAtendimento.addChaveEstrangeira("CodProfissionalSaude", "ProfissionalSaude", "Codigo");
            tbExamesAtendimento.addChaveEstrangeira("CodAtendimento", "AtendimentoHospitalar", "Codigo");
            tbExamesAtendimento.gravarTabela();

            Tabela tbReceitas = new Tabela("Receitas", "Codigo int(11)", true);
            string[] Campos_tbReceitas = { "CodPaciente int(11)", "CodMedico int(11)", "CodConsulta int(11)", "Observacao text", "Data date", "CodAtendimento int(11)" };
            tbReceitas.addCampo(Campos_tbReceitas);
            tbReceitas.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbReceitas.addChaveEstrangeira("CodMedico", "Medicos", "Codigo");
            tbReceitas.addChaveEstrangeira("CodConsulta", "ConsultaHospitalar", "Codigo");
            tbReceitas.addChaveEstrangeira("CodAtendimento", "AtendimentoHospitalar", "Codigo");
            tbReceitas.gravarTabela();

            Tabela tbFarmacoReceita = new Tabela("FarmacoReceita", "Codigo int(11)", true);
            string[] Campos_tbFarmacoReceita = { "CodPaciente int(11)", "CodFarmaco int(11)", "CodReceita int(11)", "CodAtendimento int(11)" };
            tbFarmacoReceita.addCampo(Campos_tbFarmacoReceita);
            tbFarmacoReceita.addChaveEstrangeira("CodPaciente", "Pacientes", "Codigo");
            tbFarmacoReceita.addChaveEstrangeira("CodFarmaco", "Farmacos", "Codigo");
            tbFarmacoReceita.addChaveEstrangeira("CodReceita", "Receitas", "Codigo");
            tbFarmacoReceita.addChaveEstrangeira("CodAtendimento", "AtendimentoHospitalar", "Codigo");
            tbFarmacoReceita.gravarTabela();
            
            #endregion

            // ################ Tabelas Lavandarias ######################


            InserirDadosIniciais();
        }


        public void GravarOperacoes()
        {
            AdicionaOperacao("FACTURA RECIBO", "DEBITO", "CREDITO", "FR", "CLIENTE", 1, 1, 1, 0, 0, 0, 0, 0, 0, 0);  //Venda
            AdicionaOperacao("FACTURA", "DEBITO", "CREDITO", "FT", "CLIENTE", 1, 1, 1, 0, 0, 0, 0, 0, 0, 0);  //enda V
            //AdicionaOperacao("RESERVA", "ISENTO", "ISENTO", "RES", "CLIENTE", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0);
            //AdicionaOperacao("HOSPEDAGEM", "DEBITO", "CREDITO", "HOS", "CLIENTE", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0);   // Venda
            //AdicionaOperacao("INTERNAMENTO", "DEBITO", "CREDITO", "INT", "CLIENTE", 0, 0, 0, 0, 0, 1, 0, 0, 0, 0);   // INTERNAMENTO OPERAÇÃO
            //AdicionaOperacao("ACESSO A COMPUTADOR", "DEBITO", "CREDITO", "ADM", "CLIENTE", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);
            AdicionaOperacao("FACTURA PROFORMA", "ISENTO", "ISENTO", "PP", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            AdicionaOperacao("ORÇAMENTO", "ISENTO", "ISENTO", "ADM", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            AdicionaOperacao("ACERTO DE STOCK (ENTRADA)", "CREDITO", "ISENTO", "ASE", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 1, 0);
            AdicionaOperacao("ACERTO DE STOCK (SAIDA)", "DEBITO", "ISENTO", "ASS", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 1, 0);
            AdicionaOperacao("COMPRA A FORNECEDOR", "CREDITO", "DEBITO", "CF", "FORNECEDOR", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("REQUISIÇAÕ DE ARTIGOS", "ISENTO", "ISENTO", "ADM", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            //AdicionaOperacao("FOLHA DE OBRA INTERNA", "DEBITO", "DEBITO", "ADM", "FORNECEDOR", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            AdicionaOperacao("TRANSFERENCIA DE ARTIGO", "ISENTO", "ISENTO", "TP", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("CONTAGEM DE PRODUTOS", "ISENTO", "ISENTO", "CP", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("FOLHA DE SALÁRIO", "ISENTO", "DEBITO", "FS", "FUNCIONARIO", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0);
            //AdicionaOperacao("PAGAMENTO DE EMOLUMENTOS", "ISENTO", "CREDITO", "PE", "CLIENTE", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            //AdicionaOperacao("ORDEM DE SAQUE", "ISENTO", "CREDITO", "ADM", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            //AdicionaOperacao("ORDEM DE SERVIÇO", "DEBITO", "CREDITO", "OS", "CLIENTE", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);
            AdicionaOperacao("NOTA DE PAGAMENTO", "ISENTO", "DEBITO", "NP", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            AdicionaOperacao("RECIBO", "ISENTO", "CREDITO", "RG", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            AdicionaOperacao("GUIA DE ENTREGA", "DEBITO", "ISENTO", "GE", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            //AdicionaOperacao("MATRICULA/CONFIRMAÇÃO", "ISENTO", "ISENTO", "M/C", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            //AdicionaOperacao("CONTRATO DE ELECTRICIDADE", "ISENTO", "CREDITO", "CE", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 1, 0, 0);
            //AdicionaOperacao("PAGAMENTO DE MENSALIDADE", "ISENTO", "CREDITO", "PM", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 1, 0, 0);
            //AdicionaOperacao("TRANSFERÊNCIA DE VALOR", "ISENTO", "ISENTO", "TV", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            AdicionaOperacao("TRANSFERENCIA DE ARTIGO(ENTRADA)", "CREDITO", "ISENTO", "TPE", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            AdicionaOperacao("TRANSFERENCIA DE ARTIGO(SAIDA)", "DEBITO", "ISENTO", "TPS", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("REAJUSTE DE STOCK", "ISENTO", "ISENTO", "RS", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("SERVIÇOS DE LAVANDARIA", "DEBIDO", "CREDITO", "SL", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
            //AdicionaOperacao("CONTRATO DE TRANSPORTE", "ISENTO", "ISENTO", "CT", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            //AdicionaOperacao("PAGAMENTO DE TRANSPORTE", "ISENTO", "ISENTO", "PT", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            //AdicionaOperacao("SOLICITAÇÃO DE VISTOS", "ISENTO", "CREDITO", "SV", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("REGULARIZAÇÃO DE DOCUMENTOS", "ISENTO", "CREDITO", "RD", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("DESPACHO ALFANDEGARIO", "ISENTO", "CREDITO", "DA", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("VENDA DE BILHETE DE PASSAGEM", "ISENTO", "CREDITO", "VB", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("PACOTES TURISTICOS", "ISENTO", "CREDITO", "PT", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("IMPORTAÇÃO E EXPORTAÇÃO", "ISENTO", "CREDITO", "I&E", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            //AdicionaOperacao("SEGURO DE VIAGEM", "ISENTO", "CREDITO", "SV", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);


        }
        private void AdicionaOperacao(
            String Nome, 
            String MovStock, 
            String MovFinanceiro, 
            String App, 
            String Entidade, 
            int Pos, 
            int Hotel, 
            int Restaurante,
            int Cyber, 
            int Escolar,
            int Hospitalar, 
            int RH, 
            int PT, 
            int LAV,
            int Viagem)
        {
            //int Pos, int Hotel, int Restaurante, int Cyber, int Escolar, int Hospitalar, int RH, int PT
            string Sql1 = "SELECT Codigo from Operacoes where Nome Like '" + Nome + "'";
             var objectData = Conexao.ClienteSql.SELECT(Sql1);
            object ob = (DataTable)objectData;
            DataTable dt = (DataTable)ob;
            string[] campos = { "Nome", "MovStk", "MovFin", "App", "Entidade", "Pos", "Hotel", "Restaurante", "Cyber", "Escolar", "Hospitalar", "RH", "PT", "LAV", "Viagem", "Sistema" };
            Object[] valores = { Nome, MovStock, MovFinanceiro, App, Entidade, Pos, Hotel, Restaurante, Cyber, Escolar, Hospitalar, RH, PT, LAV, Viagem, 1 };

            if (dt.Rows.Count == 0)
            {
                Conexao.ClienteSql.INSERT("Operacoes", campos, valores);
                Arquivos.txt_AdicionaTexto("Log_Motor.txt", "Operação >>" + Nome + "Gravada");

            }
            else
            {
                string Criterio = "Codigo='" + dt.Rows[0]["Codigo"].ToString() + "'";

                Conexao.ClienteSql.UPDATE("Operacoes", campos, valores, Criterio);
                Arquivos.txt_AdicionaTexto("Log_Motor.txt", "Operação >>" + Nome + "Gravada");
            }
        }

        private void AdicionaRegistroTabela(
            string nomeTabela,
            string[] campos,
            object[] valores, string criterio)
        {
            string Sql1 = "SELECT * FROM " + nomeTabela + " WHERE " + criterio;
            var objectData = Conexao.ClienteSql.SELECT(Sql1);
            object ob = (DataTable)objectData;
            DataTable dt = (DataTable)ob;

            if (dt.Rows.Count == 0)
            {
                Conexao.ClienteSql.INSERT(nomeTabela, campos, valores);
                Arquivos.txt_AdicionaTexto("Log_Motor.txt", nomeTabela + " >>" + valores[0] + "Gravada");

            }
            else
            {
                Conexao.ClienteSql.UPDATE(nomeTabela, campos, valores, criterio);
                Arquivos.txt_AdicionaTexto("Log_Motor.txt", nomeTabela + " >>" + valores[0] + "Gravada");
            }
        }
        private void InserirDadosIniciais()
        {
            if (Conexao.ContaRegisto("Operacoes", null) < 1)
            {
                GravarOperacoes();
            }

            if (Conexao.ContaRegisto("Profissao", null) < 1)
            {
                String[] _Especialidades = { "SEM PROFISSAO" };

                InserirLista("Profissao", _Especialidades);
            }

            if (Conexao.ContaRegisto("Pais", null) < 1)
            {
                InserirPaises();
                Arquivos.txt_AdicionaTexto(Conexao.ClienteSql.Banco + ".txt", "Inserido os Paises");
            }

            if (Conexao.ContaRegisto("App", null) < 1)
            {
                string[] Campos = { "VersaoBd" };
                object[] Valores = { Conexao.VersaoBd };
                 Conexao.ClienteSql.INSERT("App", Campos, Valores);
            }

            if (Conexao.ContaRegisto("GrupoSanguineos", null) < 1)
            {
                string[] _GrupoSanguineos = { "A", "A+", "B+", "A-", "B", "B-", "AB-", "AB+" };
                InserirLista("GrupoSanguineos", _GrupoSanguineos);
            }


            String[] _Areas = { "ADMINISTRATIVO", "POS", "RESTAURANTE", "HOTELARIA", "RECURSOS HUMANOS", "CYBER", "ESCOLAR" };
            InserirLista("Areas", _Areas);
            Arquivos.txt_AdicionaTexto(Conexao.ClienteSql.Banco + ".txt", "Inseriu as Areas");

            string[] _Tipologia = { "SOMENTE IDA", "IDA E VOLTA" };
            InserirLista("Tipologia", _Tipologia);

            String[] TipoDocs = { "BILHETE DE IDENTIDADE", "PASSAPORTE", "CARTA DE CONDUÇAO" };
            InserirLista("TiposDocumentos", TipoDocs);
            Arquivos.txt_AdicionaTexto(Conexao.ClienteSql.Banco + ".txt", "Inseriu Tipos de Documentos");

            String[] _TipoSaida = { "CUSTO FIXO", "CUSTO VARIAVEL", "FUNCIONARIOS", "DEVOLUÇÕES", "CUSTO A FORNECEDOR", "TRANSPORTE", "ALMOÇO/ALIMENTAÇÃO", "ACERTO DE CAIXA", "OBRA", "TROCO", "PAGAMENTO DE SALARIO", "ELECTRICIDADE", "PAGAMENTO DE AGUA", "OUTROS" };
            InserirLista("TipoSaida", _TipoSaida);

            String[] _PeriodoAvaliacao = { "MENSAL", "BIMESTRAL", "TRIMESTRAL", "SEMESTRAL", "CURSO MODULAR" };
            InserirLista("PeriodoAvaliacao", _PeriodoAvaliacao);

            String[] _TipoDuracao = { "DIA", "MÊS", "ANO" };
            InserirLista("TipoDuracao", _TipoDuracao);

            String[] _EscolarTurnos = { "MANHÃ", "TARDE", "NOITE" };
            InserirLista("EscolarTurnos", _EscolarTurnos);

            if (Conexao.ContaRegisto("Mensalidades", null) < 1)
            {
                String[] _Mensalidades = { "JANEIRO", "FEVEREIRO", "MARÇO", "aBRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO" };
                InserirLista("Mensalidades", _Mensalidades);
            }

            String[] _TipoHospede = { "ADULTOS", "CRIANCAS (-3)", "CRIANCAS (3-14)", "ADOLESCENTE", "IDOSOS" };
            InserirLista("TipoHospede", _TipoHospede);

            String[] _UnidadeOS = { "DIA", "HORA", "MINUTO", "PEÇA", "EQUIPAMENTO" };
            InserirLista("UnidadeOS", _UnidadeOS);

            String[] _Garantia = { "1 DIA", "7 DIAS", "15 DIAS", "1 MÊS", "3 MESES", "6 MESES", "1 ANO" };
            InserirLista("Garantia", _Garantia);

            String[] _ModalidadeOS = { "AVULSO", "CONTRATO", "EXTRA", "GARANTIA DA LOJA", "GARANTIA DO FABRICANTE", "GARANTIA DE OUTROS", "LOCAÇÃO", "TERCEIROS" };
            InserirLista("Modalidades", _ModalidadeOS);

            String[] _LegDocumento = { "BILHETE DE IDENTIDADE", "PASSAPORT" };
            InserirLista("LegDocumento", _LegDocumento);

            String[] _Atendimento = { "TELEFONE", "BALCÃO", "ONLINE", "INSTALAÇÃO", "PREVENTIVA", "CORRETIVA", "OUTROS" };
            InserirLista("Atendimento", _Atendimento);

            String[] _TipoTarifaHospedagem = { "DIÁRIA", "POR HORA", };
            InserirLista("TipoTarifaHospedagem", _TipoTarifaHospedagem);

            String[] _TipoHabitacao = { "SIMPLES", "MASTER", "LUXO", "PRESIDENCIAL" };
            InserirLista("TiposHabitacoes", _TipoHabitacao);

            String[] _EstadoReserva = { "PENDENTE", "CANCELADA", "CHECKIN" };
            InserirLista("EstadoReservas", _EstadoReserva);


            String[] Departamento = { "FINANCEIRO", "RECURSOS HUMANOS", "TECNOLOGIAS DE INFORMACAO", "CONTROLE DE STOCK", "JURIDICO", "MARKETING", "COMPRAS", "VENDAS", "OPERACIONAL" };
            InserirLista("Departamentos", Departamento);


            String[] _Bancos = { "BANCO DE POUPANCA E CREDITO (BPC)", "BANCO DE FOMENTO ANGOLA (BFA)", "BANCO ESPIRITO SANTOS (BESA)", "BANCO AFRICANO DE INVESTIMENTO (BAI)", "BANCO ANGOLANO DE NEGOCIOS E COMERCIO (BANC)", "BANCO BAI MICRO FINANCAS (BMF)", "BANCO BIC (BIC)", "BANCO CAIXA GERAL TOTA DE ANGOLA (BCGTA)", "BANCO DE INVESTIMENTO RURAL (BIR)", "Banco Comercial Angolano (BCA)", "Banco de Comércio e Indústria (BCI)", "Banco de Negocios Internacional (BNI)", "Banco Millennium Angola (BMA)", "Banco Regional do Keve (BRK)", "Banco Privado Atlantico (BPA)", "Banco Sol (BSOL)", "Finibanco Angola (FNB)", "Standard Bank de Angola (SCBA)" };
            InserirLista("Bancos", _Bancos);

            if (Conexao.ContaRegisto("ContasBancarias", null) < 1)
            {
                string[] Campos = { "Numero" };
                object[] Valores = { "123456" };
                Conexao.ClienteSql.INSERT("ContasBancarias", Campos, Valores);
            }

            String[] Tipocontacto = { "TELEFONE", "FAX", "E-MAIL", "WEBSITE" };
            InserirLista("TipoContacto", Tipocontacto);


            #region Imposto e MotivoIsencao

            //String[] _MotivoInsecao = { "PESSOA FISICA", "PESSOA JURIDICA" };
            //InserirLista("TipoEntidade", _TipoEntidade);

            #endregion

            #region RecursosHumanos
            String[] _TipoContrato = { "Contrato de trabalho a termo certo", "Contrato de trabalho a termo incerto", "Contrato sem termo", "Contrato de trabalho de muita curta duração", "Contrato de trabalho com trabalhador estrangeiro não comunitário ou apátrida", "Contrato de trabalho a tempo parcial", "Contrato de trabalho com pluralidade de empregadores", "Contrato de trabalho intermitente", "Contrato de trabalho em comissão de serviço", "Contrato promessa de trabalho", "Contrato para prestação subordinada de tele-trabalho", "Contrato de pré-forma", "Contrato de cedência ocasional de trabalhadores" };
            InserirLista("TipoContrato", _TipoContrato);
            #endregion

            #region Generico

            String[] _Sexo = { "MASCULINO", "FEMENINO" };
            InserirLista("Sexo", _Sexo);

            String[] _EstadoCivil = { "SOLTEIRO (A)", "CASADO (A)", "DIVORCIADO (A)", "VIUVO (A)" };
            InserirLista("EstadoCivil", _EstadoCivil);
            #endregion


            #region Hoteleiro

            String[] _ItensHabitacionais = { "AR CONDICIONADO", "GELADEIRA", "VISTA PANORAMICA", "CAFETEIRA", "TELEFONE", "COMPUTADOR", "TV PLASMA", "TV RAIO CATODICO", "BANHEIRO PRIVADO", "GUARDA FATO" };
            InserirLista("ItensHabitacionais", _ItensHabitacionais);

            #endregion

            #region Escolar
            String[] _TipoProvas = { "Primeira Prova do Professor", "Segunda Prova do Professor", "Avaliação" };
            InserirLista("TipoProvas", _TipoProvas);

            #endregion



            #region Hospitalar
            if (Conexao.ContaRegisto("Especialidades", null) < 1)
            {
                String[] _Especialidades = { "CLINICA GERAL", "PEDIATRIA", "CARDIOLOGIA", "DERMATOLOGIA" };

                InserirLista("Especialidades", _Especialidades);
            }

            if (Conexao.ContaRegisto("Prioridade", null) < 1)
            {
                String[] _Especialidades = { "URGENTE", "NÃO URGENTE"};

                InserirLista("Prioridade", _Especialidades);
            }

            if (Conexao.ContaRegisto("Escala", null) < 1)
            {
                string[] Campos = { "Descricao", "HorasSemanal" };
                object[] Valores = { "NORMAL","45"};
                Conexao.ClienteSql.INSERT("Escala", Campos, Valores);

                string[] Campos2 = { "Descricao", "HorasSemanal" };
                object[] Valores2 = { "FIM DE SEMANA", "18" };
                Conexao.ClienteSql.INSERT("Escala", Campos2, Valores2);

                string[] Campos3 = { "Descricao"};
                object[] Valores3 = { "INDEFINIDA"};
                Conexao.ClienteSql.INSERT("Escala", Campos3, Valores3);
            }

            
            #endregion


            if (Conexao.ContaRegisto("DISCIPLINAS", null) < 1)
            {
                string[] disciplinas = { "MATEMÁTICA", "LÍNGUA PORTUGUESA", "HISTÓRIA", "QUÍMICA", "BIOLOGIA", "FÍSICA", "INGLÊS" };
                string[] abreviaturas = { "MAT", "LPORT", "HIST", "QCA", "BIO", "FIS", "ING" };

                for (int i = 0; i < disciplinas.Length; i++)
                {
                    string[] Campos = { "Descricao", "Abreviatura" };
                    string[] Valores = { disciplinas[i], abreviaturas[i] };
                     Conexao.ClienteSql.INSERT("Disciplinas", Campos, Valores);
                }
            }

            Tabela tbCondicoesPagamentos = new Tabela("CondicoesPagamentos", "Codigo int(11)", true);
            string[] CondicoesPagamentos = { "Descricao varchar(100)", "Dias int(11)" };
            tbCondicoesPagamentos.addCampo(CondicoesPagamentos);
            tbCondicoesPagamentos.gravarTabela();
            //            string[] DefEscola = { "Descricao varchar(50)", "DiaCobrarMulta int", "MultaObrigatoria int" };



            if (Conexao.ContaRegisto("DefEscola", null) < 1)
            {
                string[] Campos = { "Descricao", "DiaCobrarMulta", "MultaObrigatoria" };
                object[] Valores = { "Escola", 0, 0 };
                Conexao.ClienteSql.INSERT("DefEscola", Campos, Valores);

            }


            Tabela tbTipoImposto = new Tabela("TipoImposto", "Codigo int(11)", true);
            string[] Campos_tbTipoImposto = { "Sigla varchar(200)", "Descricao varchar(200)" };
            tbTipoImposto.addCampo(Campos_tbTipoImposto);
            tbTipoImposto.gravarTabela();
            if (Conexao.ContaRegisto("TipoImposto", null) < 1)
            {

                string[] Campos = { "Sigla", "Descricao" };
                object[] Valorestipo1 = { "IVA", "Imposto sobre o valor acrescentado"};
                object[] Valorestipo2 = { "IS", "Imposto do Selo" };
                object[] Valorestipo3 = { "NS", "Não Sujeição a IVA ou IS" };
                Conexao.ClienteSql.INSERT("TipoImposto", Campos, Valorestipo1);
                Conexao.ClienteSql.INSERT("TipoImposto", Campos, Valorestipo2);
                Conexao.ClienteSql.INSERT("TipoImposto", Campos, Valorestipo3);
            }
            if (Conexao.ContaRegisto("Imposto", null) < 1)
            {
                string[] Campos = { "Descricao", "Percentagem", "Sigla", "CodTipo"};
                object[] Valores_Imposto1 = { "Isento", 0, "ISE", 3};
                object[] Valores_Imposto2 = { "Taxa Normal", 14, "NOR", 1 };
                object[] Valores_Imposto3 = { "Taxa Intermédia", 14, "INT", 1 };
                object[] Valores_Imposto4 = { "Taxa Reduzida", 14, "RED", 1 };
                object[] Valores_Imposto5 = { "Outros, aplicável para os regimes especiais de IVA", 14, "OUT", 1};
                Conexao.ClienteSql.INSERT("Imposto", Campos, Valores_Imposto1);
                Conexao.ClienteSql.INSERT("Imposto", Campos, Valores_Imposto2);
                Conexao.ClienteSql.INSERT("Imposto", Campos, Valores_Imposto3);
                Conexao.ClienteSql.INSERT("Imposto", Campos, Valores_Imposto4);
                Conexao.ClienteSql.INSERT("Imposto", Campos, Valores_Imposto5);
            }


            if (Conexao.ContaRegisto("MotivoIsencao", null) < 1)
            {
                string[] Campos = { "Descricao", "Referencia" };
                object[] Valores1 = { "Regime transitório", "M00" };
                object[] Valores2 = { "Transmissão de bens e serviços não sujeita", "M02" };
                object[] Valores3 = { "IVA - Regime de não sujeição", "M04" };
                object[] Valores4 = { "Isento Artigo 12º a) do CIVA", "M10" };
                object[] Valores5 = { "Isento Artigo 12º b) do CIVA", "M11" };
                object[] Valores6 = { "Isento Artigo 12º c) do CIVA", "M12" };
                object[] Valores7 = { "Isento Artigo 12º d) do CIVA", "M13" };
                object[] Valores8 = { "Isento Artigo 12º e) do CIVA", "M14" };
                object[] Valores9 = { "Isento Artigo 12º f) do CIVA", "M15" };
                object[] Valores10 = { "Isento Artigo 12º g) do CIVA", "M16" };
                object[] Valores11 = { "Isento Artigo 12º h) do CIVA", "M17" };
                object[] Valores12 = { "Isento Artigo 12º i) do CIVA", "M18" };
                object[] Valores13 = { "Isento Artigo 12º j) do CIVA", "M19" };
                object[] Valores14 = { "Isento Artigo 12º k) do CIVA", "M20" };
                object[] Valores15 = { "Isento Artigo 15º 1 a) do CIVA", "M30" };
                object[] Valores16 = { "Isento Artigo 15º 1 b) do CIVA", "M31" };
                object[] Valores17 = { "Isento Artigo 15º 1 c) do CIVA", "M32" };
                object[] Valores18 = { "Isento Artigo 15º 1 d) do CIVA", "M33" };
                object[] Valores19 = { "Isento Artigo 15º 1 e) do CIVA", "M34" };
                object[] Valores20 = { "Isento Artigo 15º 1 f) do CIVA", "M35" };
                object[] Valores21 = { "Isento Artigo 15º 1 g) do CIVA", "M36" };
                object[] Valores22 = { "Isento Artigo 15º 1 h) do CIVA", "M37" };
                object[] Valores23 = { "Isento Artigo 15º 1 i) do CIVA", "M38" };

                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores1);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores2);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores3);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores4);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores5);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores6);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores7);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores8);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores9);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores10);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores11);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores12);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores13);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores14);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores15);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores16);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores17);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores18);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores19);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores20);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores21);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores22);
                Conexao.ClienteSql.INSERT("MotivoIsencao", Campos, Valores23);
            }



            if (Conexao.ContaRegisto("MultaEscolar", null) < 1)
            {
                string[] Campos = { "Descricao", "ValorMulta" };
                string[] Valores = { "Sem Multa", "0" };
                  Conexao.ClienteSql.INSERT("MultaEscolar", Campos, Valores);
            }

            if (Conexao.ContaRegisto("DefFactura", null) < 1)
            {
                string[] Campos = { "Detalhes", "Validade", "Decreto" };
                string[] Valores = { "Obrigado Volte Sempre", "NENHUM DIA", "NENHUM" };
                Conexao.ClienteSql.INSERT("DefFactura", Campos, Valores);
            }


            if (Conexao.ContaRegisto("DefPreco", null) < 1)
            {
                string[] Campos = { "Preco1", "Preco2", "Preco3" };
                string[] Valores = { "0", "0", "0" };
                 Conexao.ClienteSql.INSERT("DefPreco", Campos, Valores);
            }

            if (Conexao.ContaRegisto("AnoPt", null) < 1)
            {
                string[] Campos = { "Descricao", "status" };
                object[] Valores = { DateTime.Now.Year, 1 };
                 Conexao.ClienteSql.INSERT("AnoPt", Campos, Valores);
            }

            if (Conexao.ContaRegisto("MOEDAS", null) < 1)
            {
                string[] moedas = { "KWANZA", "DÓLAR AMERICANO", "EURO" };
                string[] abreviaturas = { "AKZ", "USD", "EUR" };
                string[] padrao = { "1", "0", "0" };

                for (int i = 0; i < moedas.Length; i++)
                {
                    string[] Campos = { "Descricao", "sigla", "moedapadrao" };
                    string[] Valores = { moedas[i], abreviaturas[i], padrao[i] };
                     Conexao.ClienteSql.INSERT("moedas", Campos, Valores);
                }
            }


            if (Conexao.ContaRegisto("DefPt", null) < 1)
            {
                string[] Campos = { "AnoInicial", "AnoActual", "CobrarMultaAposDia", "VencimentoAposDia", "MaxMulta" };
                object[] Valores = { DateTime.Now.Year, DateTime.Now.Year, "0", "30", "0" };
                 Conexao.ClienteSql.INSERT("DefPt", Campos, Valores);

            }

            String[] _EmolumentosEscolar = { "INSCRIÇÃO/MATRÍCULA", "MENSALIDADE JANEIRO", "MENSALIDADE FEVEREIRO", "MENSALIDADE MARÇO", "MENSALIDADE ABRIL", "MENSALIDADE MAIO", "MENSALIDADE JUNHO", "MENSALIDADE JULHO", "MENSALIDADE AGOSTO", "MENSALIDADE SETEMBRO", "MENSALIDADE OUTUBRO", "MENSALIDADE NOVEMBRO", "MENSALIDADE DEZEMBRO" };
            InserirLista("EmolumentosEscolar", _EmolumentosEscolar);

            String[] _Habilitacao = {"OUTRA", "ENSINO BÁSICO", "ENSINO SECUNDÁRIO", "BACHARELATO", "LICENCIATURA", "PÓS-GRADUAÇÃO", "MESTRADO", "DOUTORAMENTO", "ESPECIALIZAÇÃO TECNOLÓGICA" };
            InserirLista("Habilitacoes", _Habilitacao);

            String[] _Sectores = { "ILUMINAÇÃO", "MOBILIA", "CANALIZAÇÃO", "PINTURA", "GESSO", "TECTO", "TELEFONE", "COMPUTADORES", "INTERNET", "FRIGOBAR", "TELEVISÃO", "AR CONDICIONADO", "VENTILADOR", "EXAUSTOR", "ELECTRICIDADE", "TRANSPORTE", };
            InserirLista("Sectores", _Sectores);

            string[] campog = { "Descricao" };
            Object[] valoreg = { "Acesso Total" };
            Conexao.ClienteSql.INSERT("Acessos", campog, valoreg);

            // Inicio Turnos
            if (Conexao.ContaRegisto("DiasSemana", null) < 1)
            {
                string[] camposemana = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana = { "Domingo", "Sunday" };
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana, valoresemana);


                string[] camposemana2 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana2 = { " Segunda-feira", "Monday" };
                //save.setInsert(Geral.CaminhoBd, "DiasSemana", camposemana2, valoresemana2);
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana2, valoresemana2);


                string[] camposemana3 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana3 = { " Terça-feira", "Tuesday" };
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana3, valoresemana3);


                string[] camposemana4 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana4 = { " Quarta-feira", "Wednesday" };
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana4, valoresemana4);


                string[] camposemana5 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana5 = { " Quinta-feira", "Thursday" };
                //save.setInsert(Geral.CaminhoBd, "DiasSemana", camposemana5, valoresemana5);
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana5, valoresemana5);


                string[] camposemana6 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana6 = { " Sexta-feira", "Friday" };
                //save.setInsert(Geral.CaminhoBd, "DiasSemana", camposemana6, valoresemana6);
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana6, valoresemana6);


                string[] camposemana7 = { "DescricaoDias", "DayOfWeak" };
                Object[] valoresemana7 = { " Sábado", "Saturday" };
                //save.setInsert(Geral.CaminhoBd, "DiasSemana", camposemana7, valoresemana7);
                Conexao.ClienteSql.INSERT("DiasSemana", camposemana7, valoresemana7);

            }
            if (Conexao.ContaRegisto("Turno", null) < 1)
            {
                string[] campoT = { "DescricaoTurno", "HoraMensal" };
                Object[] valoresT = { "Normal", "140" };
                Conexao.ClienteSql.INSERT("Turno", campoT, valoresT);
            }

            if (Conexao.ContaRegisto("TurnoDias", null) < 1)
            {
                string[] campoT1 = { "IDTurno", "IDDia", "HoraEntrada", "HoraSaida" };
            Object[] valoresT1 = { "1", "2", "08:00", "15:00" };
            Conexao.ClienteSql.INSERT("TurnoDias", campoT1, valoresT1);
            }

            if (Conexao.ContaRegisto("TurnoDias", null) < 1)
            {
                string[] campoT2 = { "IDTurno", "IDDia", "HoraEntrada", "HoraSaida" };
                Object[] valoresT2 = { "1", "3", "08:00", "15:00" };
                Conexao.ClienteSql.INSERT("TurnoDias", campoT2, valoresT2);
            }

            if (Conexao.ContaRegisto("TurnoDias", null) < 1)
            {
                string[] campoT3 = { "IDTurno", "IDDia", "HoraEntrada", "HoraSaida" };
                Object[] valoresT3 = { "1", "4", "08:00", "15:00" };
                //save.setInsert(Geral.CaminhoBd, "TurnoDias", campoT3, valoresT3);
                Conexao.ClienteSql.INSERT("TurnoDias", campoT3, valoresT3);
            }

            if (Conexao.ContaRegisto("TurnoDias", null) < 1)
            {
                string[] campoT4 = { "IDTurno", "IDDia", "HoraEntrada", "HoraSaida" };
                Object[] valoresT4 = { "1", "5", "08:00", "15:00" };
                //save.setInsert(Geral.CaminhoBd, "TurnoDias", campoT4, valoresT4);
                Conexao.ClienteSql.INSERT("TurnoDias", campoT4, valoresT4);
            }
            if (Conexao.ContaRegisto("TurnoDias", null) < 1)
            {
                string[] campoT5 = { "IDTurno", "IDDia", "HoraEntrada", "HoraSaida" };
                Object[] valoresT5 = { "1", "6", "08:00", "15:00" };
                //save.setInsert(Geral.CaminhoBd, "TurnoDias", campoT5, valoresT5);
                Conexao.ClienteSql.INSERT("TurnoDias", campoT5, valoresT5);
            }
            //---------------------------------------------------------------------------------------------------------------------
            // adicionou comando a seguir

            if (Conexao.ContaRegisto("EscalaConfig", null) < 1)
            {
                string[] Campos = { "CodEscala", "CodDia", "Entrada", "Saida","Checa" };

                object[] Valores1 = { "2", "7", "8:00", "17:00" ,"1"};
                Conexao.ClienteSql.INSERT("EscalaConfig", Campos, Valores1);

                object[] Valores2 = { "2", "1", "8:00", "17:00", "1" };
                Conexao.ClienteSql.INSERT("EscalaConfig", Campos, Valores2);

                for (int i = 2; i < 7; i++)
                {
                    object[] Valores3 = { "1", i, "8:00", "17:00", "1" };
                    Conexao.ClienteSql.INSERT("EscalaConfig", Campos, Valores3);
                }
              
            }
            //----------------------------------------DEfinicoes Milton esta a trabalhar aqui------------------------------------------------
            if (Conexao.ContaRegisto("DefGeral", null) < 1)
            {
                string[] campoGeral = { "VenderSemStock", "HospedagemAberta", "LucroPos", "Documento", "Cliente" };
                Object[] valoresGeral = { "0", "0", "0", "0", "0" };
                Conexao.ClienteSql.INSERT("DefGeral", campoGeral, valoresGeral);
            }
       


            //string[] campof2 = { "Descricao", "Duracao" };
            //Object[] valoresf2 = { "Quinzinal", "15" };
            ////save.setInsert(Geral.CaminhoBd, "TipodeFerias", campof2, valoresf2);
            //Conexao.ClienteSql.INSERT("TipodeFerias", campof2, valoresf2);


            //string[] campof = { "Descricao", "Duracao" };
            //Object[] valoresf = { "Completa", "30" };
            ////save.setInsert(Geral.CaminhoBd, "TipodeFerias", campof, valoresf);
            //Conexao.ClienteSql.INSERT("TipodeFerias", campof, valoresf);

            if (Conexao.ContaRegisto("Camas", null) < 1)
            {

                string[] campotEntidades4 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades4 = { "SOLTEIRO", "1", "0", "0", "2", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades4, valoresEntidades4);


                string[] campotEntidades = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades = { "CASAL", "0", "1", "0", "2", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades, valoresEntidades);


                string[] campotEntidades2 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades2 = { "DUPLO SOLTEIRO", "2", "0", "0", "2", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades2, valoresEntidades2);


                string[] campotEntidades3 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades3 = { "TRIPLO SOLTEIRO", "3", "0", "0", "3", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades3, valoresEntidades3);


                string[] campotEntidades31 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades31 = { "CASAL + SOLTEIRO", "1", "1", "0", "3", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades31, valoresEntidades31);


                string[] campotEntidades311 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades311 = { "CASAL + DUPLO SOLTEIRO", "2", "1", "0", "4", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades311, valoresEntidades311);


                string[] campotEntidades3111 = { "Descricao", "Solteira", "Casal", "Berco", "MaxHospedes", "MinHospedes" };
                Object[] valoresEntidades3111 = { "CASAL + BERSARIO", "0", "1", "0", "2", "1" };
                Conexao.ClienteSql.INSERT("Camas", campotEntidades3111, valoresEntidades3111);
            }

            if (Conexao.ContaRegisto("ContasEmail", null) < 1)
            {

                string[] campotEntidades = { "Descricao", "SMTP", "Porta", "Email", "Senha" };
                Object[] valoresEntidades = { "Comercial", "smtp.live.com", 25, "comercial@hotmail.com", "minhasnha" };
                Conexao.ClienteSql.INSERT("ContasEmail", campotEntidades, valoresEntidades);


                string[] campotEntidades4 = { "Descricao", "SMTP", "Porta", "Email", "Senha" };
                Object[] valoresEntidades4 = { "Tecnico", "smtp.live.com", 25, "", "" };
                Conexao.ClienteSql.INSERT("ContasEmail", campotEntidades4, valoresEntidades4);


                string[] campotEntidades2 = { "Descricao", "SMTP", "Porta", "Email", "Senha" };
                Object[] valoresEntidades2 = { "Financeiro", "smtp.gmail.com", 25, "", "" };
                Conexao.ClienteSql.INSERT("ContasEmail", campotEntidades2, valoresEntidades2);


                string[] campotEntidades3 = { "Descricao", "SMTP", "Porta", "Email", "Senha" };
                Object[] valoresEntidades3 = { "Gerente", "smtp.mail.yahoo.com.br", 587, "", "" };
                Conexao.ClienteSql.INSERT("ContasEmail", campotEntidades3, valoresEntidades3);
            }

            if (Conexao.ContaRegisto("DefHotel", null) < 1)
            {
                string[] campotEntidades = { "Checkin", "CheckOut", "CTempo", "Automatico", "Horas", "Consumidor" };
                Object[] valoresEntidades = { "12:00", "11:00", 0, 0, 3, 0 };
                Conexao.ClienteSql.INSERT("DefHotel", campotEntidades, valoresEntidades);
            }

            //if (Conexao.ContaRegisto("TarifasAcessos", null) < 1)
            //{
            //    string[] campotAcesso = { "Descricao", "Minutos", "Valor" };
            //    Object[] valoresTacesso = { "PAUSA ", "0", "0,00" };
            //    Conexao.ClienteSql.INSERT("TarifasAcessos", campotAcesso, valoresTacesso);

            //    string[] campotAcesso2 = { "Descricao", "Minutos", "Valor" };
            //    Object[] valoresTacesso2 = { "DESPAUSA ", "0", "0,00" };
            //    Conexao.ClienteSql.INSERT("TarifasAcessos", campotAcesso2, valoresTacesso2);

            //    string[] campotAcesso3 = { "Descricao", "Minutos", "Valor" };
            //    Object[] valoresTacesso3 = { "TRANSFERENCIA ", "0", "0,00" };
            //    Conexao.ClienteSql.INSERT("TarifasAcessos", campotAcesso3, valoresTacesso3);

            //    string[] campotAcesso4 = { "Descricao", "Minutos", "Valor" };
            //    Object[] valoresTacesso4 = { "TERMINAR SESSÃO ", "0", "0,00" };
            //    Conexao.ClienteSql.INSERT("TarifasAcessos", campotAcesso4, valoresTacesso4);
            //}


            if (Conexao.ContaRegisto("CondicoesPagamentos", null) < 1)
            {
                string[] Descricoes = { "Validade Semanal", "Validade Mensal", "Validade Trimestral", "Validade Anual" };
                string[] Dias = { "7", "30", "90", "365"};

                for (int i = 0; i < Dias.Length; i++)
                {
                    string[] Campos = { "Descricao", "Dias" };
                    string[] Valores = { Descricoes[i], Dias[i] };
                    Conexao.ClienteSql.INSERT("CondicoesPagamentos", Campos, Valores);
                }
            }
            String[] _TipoEntidade = { "PESSOA FISICA", "PESSOA JURIDICA" };
            InserirLista("TipoEntidade", _TipoEntidade);
            if (Conexao.ContaRegisto("Entidades", null) < 1)
            {

                string[] campoFornecedor2 = { "Nome", "Limite", "Cliente", "status", "CodTipo" };
                Object[] valorFornecedor2 = { "ADMINISTRADOR DO SISTEMA", "999999999", 1, 1, 2};
                Conexao.ClienteSql.INSERT("Entidades", campoFornecedor2, valorFornecedor2);

                string[] campotEntidades = { "Nome", "Limite", "Cliente", "status", "CodTipo" };
                Object[] valoresEntidades = { "CLIENTE INDIFERENCIADO", "0", 1, 1, 2};
                Conexao.ClienteSql.INSERT("Entidades", campotEntidades, valoresEntidades);


                string[] campoFornecedor = { "Nome", "Limite", "Fornecedor", "status", "CodTipo" };
                Object[] valorFornecedor = { "FORNECEDOR INDIFERENCIADO", "999999999", 1, 1, 2};
                Conexao.ClienteSql.INSERT("Entidades", campoFornecedor, valorFornecedor);

                string[] campoFornecedor1 = { "Nome", "Limite", "Fornecedor", "status", "CodTipo" };
                Object[] valorFornecedor1 = { "FORNECEDOR", "999999999", 1, 1, 2 };
                Conexao.ClienteSql.INSERT("Entidades", campoFornecedor1, valorFornecedor1);
            }

            if (Conexao.ContaRegisto("Fornecedores", null) < 1)
            {
                string[] campoFornecedor = { "CodEntidade" };
                Object[] valorFornecedor = { "4" };
                Conexao.ClienteSql.INSERT("Fornecedores", campoFornecedor, valorFornecedor);
            }

            if (Conexao.ContaRegisto("AreasMesas", null) < 1)
            {
                String[] LocaisMesas = { "INTERIOR", "EXPLANADA", "FUMANTES", "N FUMANTES" };
                InserirLista("AreasMesas", LocaisMesas);
            }

            if (Conexao.ContaRegisto("Armazens", null) < 1)
            {
                String[] LocaisMesas = { "GERAL" };
                InserirLista("Armazens", LocaisMesas);
            }

            if (Conexao.ContaRegisto("AreasHabitacoes", null) < 1)
            {
                String[] LocaisMesas = { "RES DO CHAO", "1 PISO", "2 PISO", "3 PISO" };
                InserirLista("AreasHabitacoes", LocaisMesas);
            }

            if (Conexao.ContaRegisto("Mesas", null) < 1)
            {

                string[] Mesa1 = { "Descricao", "CodArea", "Cadeiras" };
                Object[] _Mesa1 = { "MESA 1", "1", "4" };
                Conexao.ClienteSql.INSERT("Mesas", Mesa1, _Mesa1);


                string[] Mesa2 = { "Descricao", "CodArea", "Cadeiras" };
                Object[] _Mesa2 = { "MESA 2", "2", "4" };
                Conexao.ClienteSql.INSERT("Mesas", Mesa2, _Mesa2);
            }

            if (Conexao.ContaRegisto("Caixas", null) < 1)
            {
                string[] Caixas = { "GERENCIA" };
                InserirLista("Caixas", Caixas);
                //{
            }

            if (Conexao.ContaRegisto("fpagamentos", null) < 1)
            {

                string[] campotPagar = { "Descricao", "Movimentar", "Sistema" };
                Object[] valorePagar = { "NUMERARIO", "CAIXA", 1 };
                Conexao.ClienteSql.INSERT("fPagamentos", campotPagar, valorePagar);
            }

            //string[] camposis = { "UrlDownload", };
            //Object[] valorsis = { "" };
            //string[] crit = { "Codigo>0", };
            //Conexao.ClienteSql.UPDATE("Sistema", camposis, valorsis, crit);

            if (Conexao.ContaRegisto("Empresa", null) < 1)
            {
                string[] campoEmpresa = {"Validou", "Telefones", "Email" };
                Object[] valorEmpresa = {"0","Telefone","E-Mail" };
                Conexao.ClienteSql.INSERT("Empresa", campoEmpresa, valorEmpresa);
            }

            if (Conexao.ContaRegisto("Perfil", null) < 1)
            {
                string[] campoy = { "Descricao", };
                Object[] valorey = { "Administrador" };
                Conexao.ClienteSql.INSERT("Perfil", campoy, valorey);

                string[] campoyx = { "CodEntidade", "Nome", "Login", "Senha", "CodPerfil", "Alterado" };
                Object[] valoreyx = { "1", "ADMINISTRADOR DO SISTEMA", "admin", UtilidadesGenericas.Encriptar("admin"), 1, false };
                 Conexao.ClienteSql.INSERT("Usuarios", campoyx, valoreyx);
            

                string[] campoyz = { "CodEntidade", "Nome", "Login", "Senha", "CodPerfil", "Alterado" };
                Object[] valoreyz = { "1", "ADMINISTRADOR DA EMPRESA", "Trevo", "Trevo", 1 , true};
                Conexao.ClienteSql.INSERT("Usuarios", campoyz, valoreyz);

            }
            // Actualizar Novos Campos

            // Actualizar o Banco de Dados
            string[] sxCampos = { "Controlar", "Especifico" };
            Object[] sxValores = { "1", "0" };
             Conexao.ClienteSql.UPDATE("Turno", sxCampos, sxValores, "Controlar is null");

            string[] sdCampos = { "Documento", "Cliente" };
            Object[] sdValores = { "0", "0" };
             Conexao.ClienteSql.UPDATE("DefGeral", sdCampos, sdValores, "Cliente is null");

            string[] syCampos = { "Automatico", "Horas", "Consumidor" };
            Object[] syValores = { 0, 3, 0 };
            Conexao.ClienteSql.UPDATE("DefHotel", syCampos, syValores, "Consumidor is null");

            string[] syCamposy = { "Decreto" };
            Object[] syValoresy = { "Nenhum" };
            Conexao.ClienteSql.UPDATE("DefFactura", syCamposy, syValoresy, "Decreto is null");

            
         

        }

        public void InserirLista(String Tabela, String[] Lista)
        {

            for (int i = 0; i < Lista.Length; i++)
            {
                try
                {

                    String[] Campos = { "Descricao" };
                    Object[] Valores = { Lista[i].ToString().ToUpper() };
                    Conexao.ClienteSql.INSERT(Tabela, Campos, Valores);
                }
                catch (Exception ex)
                {
                 //   throw new Exception(ex.Message);
                }
            }
        }
        public void InserirPaises()
        {
            List<String> GravarPaises = new List<string>();
            GravarPaises = Paises();
            for (int i = 0; i < GravarPaises.Count; i++)
            {
                try
                {

                    String[] Campos = { "Descricao" };
                    Object[] Valores = { GravarPaises[i].ToString().ToUpper() };

                  Conexao.ClienteSql.INSERT("Pais", Campos, Valores);

                }
                catch (Exception x)
                {

                    throw new Exception(x.Message);
                }
            }
        }
        public static List<string> Paises()
        {
            List<string> Paises = new List<string>();
            Paises.Add("Angola");
            Paises.Add("Africa do Sul");
            Paises.Add("Albania");
            Paises.Add("Alemanha");
            Paises.Add("Andorra");
            Paises.Add("Anguilla");
            Paises.Add("Antigua");
            Paises.Add("Arabia Saudita");
            Paises.Add("Argentina");
            Paises.Add("Armênia");
            Paises.Add("Aruba");
            Paises.Add("Australia");
            Paises.Add("Austria");
            Paises.Add("Azerbaijao");
            Paises.Add("Bahamas");
            Paises.Add("Bahrein");
            Paises.Add("Bangladesh");
            Paises.Add("Barbados");
            Paises.Add("Belgica");
            Paises.Add("Benin");
            Paises.Add("Bermudas");
            Paises.Add("Botswana");
            Paises.Add("Brasil");
            Paises.Add("Brunei");
            Paises.Add("Bulgaria");
            Paises.Add("Burkina Fasso");
            Paises.Add("butao");
            Paises.Add("Cabo Verde");
            Paises.Add("Camarões");
            Paises.Add("Cambodja");
            Paises.Add("Canadá");
            Paises.Add("Cazaquistao");
            Paises.Add("TChade");
            Paises.Add("Chile");
            Paises.Add("China");
            Paises.Add("Cidade do Vaticano");
            Paises.Add("Colômbia");
            Paises.Add("Congo Democratico");
            Paises.Add("Congo Brazaville");
            Paises.Add("Coréia do Sul");
            Paises.Add("Costa do Marfim");
            Paises.Add("Costa Rica");
            Paises.Add("Croácia");
            Paises.Add("Dinamarca");
            Paises.Add("Djibuti");
            Paises.Add("Dominica");
            Paises.Add("Estados Unidos da America");
            Paises.Add("Egipto");
            Paises.Add("El Salvador");
            Paises.Add("Emirados Árabes Unidos");
            Paises.Add("Equador");
            Paises.Add("Eritréia");
            Paises.Add("Escócia");
            Paises.Add("Eslováquia");
            Paises.Add("Eslovênia");
            Paises.Add("Espanha");
            Paises.Add("Estônia");
            Paises.Add("Etiópia");
            Paises.Add("Fiji");
            Paises.Add("Filipinas");
            Paises.Add("Finlândia");
            Paises.Add("França");
            Paises.Add("Gabao");
            Paises.Add("Gâmbia");
            Paises.Add("Gana");
            Paises.Add("Geórgia");
            Paises.Add("Gibraltar");
            Paises.Add("Granada");
            Paises.Add("Grécia");
            Paises.Add("Guadalupe");
            Paises.Add("Guam");
            Paises.Add("Guatemala");
            Paises.Add("Guiana");
            Paises.Add("Guiana Francesa");
            Paises.Add("Guiné-bissau");
            Paises.Add("Haiti");
            Paises.Add("Holanda");
            Paises.Add("Honduras");
            Paises.Add("Hong Kong");
            Paises.Add("Hungria");
            Paises.Add("Yemen");
            Paises.Add("Ilhas Cayman");
            Paises.Add("Ilhas Cook");
            Paises.Add("Ilhas Curaçao");
            Paises.Add("Ilhas Marshall");
            Paises.Add("Ilhas Turks & Caicos");
            Paises.Add("Ilhas Virgens (brit.)");
            Paises.Add("Ilhas Virgens(amer.)");
            Paises.Add("Ilhas Wallis e Futuna");
            Paises.Add("Índia");
            Paises.Add("Indonésia");
            Paises.Add("Inglaterra");
            Paises.Add("Irlanda");
            Paises.Add("Islândia");
            Paises.Add("Israel");
            Paises.Add("Itália");
            Paises.Add("Jamaica");
            Paises.Add("Japao");
            Paises.Add("Jordânia");
            Paises.Add("Kwait");
            Paises.Add("Letónia");
            Paises.Add("Líbano");
            Paises.Add("Liechtenstein");
            Paises.Add("Lituânia");
            Paises.Add("Luxemburgo");
            Paises.Add("Macau");
            Paises.Add("Macedônia");
            Paises.Add("Madagascar");
            Paises.Add("Malásia");
            Paises.Add("Malawi");
            Paises.Add("Mali");
            Paises.Add("Malta");
            Paises.Add("Marrocos");
            Paises.Add("Martinica");
            Paises.Add("Mauritânia");
            Paises.Add("Mauricias");
            Paises.Add("México");
            Paises.Add("Moldova");
            Paises.Add("Mônaco");
            Paises.Add("Montserrat");
            Paises.Add("Nepal");
            Paises.Add("Nicarágua");
            Paises.Add("Niger");
            Paises.Add("Nigéria");
            Paises.Add("Noruega");
            Paises.Add("Nova Caledônia");
            Paises.Add("Nova Zelândia");
            Paises.Add("Oma");
            Paises.Add("Palau");
            Paises.Add("Panamá");
            Paises.Add("Papua-nova Guiné");
            Paises.Add("Paquistao");
            Paises.Add("Peru");
            Paises.Add("Polinésia Francesa");
            Paises.Add("Polônia");
            Paises.Add("Porto Rico");
            Paises.Add("Portugal");
            Paises.Add("Qatar");
            Paises.Add("Quênia");
            Paises.Add("República Dominicana");
            Paises.Add("República Tcheca");
            Paises.Add("Reunion");
            Paises.Add("Romênia");
            Paises.Add("Ruanda");
            Paises.Add("Russia");
            Paises.Add("Saipan");
            Paises.Add("Samoa Americana");
            Paises.Add("Senegal");
            Paises.Add("Serra Leoa");
            Paises.Add("Seychelles");
            Paises.Add("Singapura");
            Paises.Add("Siria");
            Paises.Add("Sri Lanka");
            Paises.Add("St. Kitts & Nevis");
            Paises.Add("St. Lúcia");
            Paises.Add("St. Vincent");
            Paises.Add("Sudao do Norte");
            Paises.Add("Sudao do Sul");
            Paises.Add("Suécia");
            Paises.Add("Suiça");
            Paises.Add("Suriname");
            Paises.Add("Tailândia");
            Paises.Add("Taiwan");
            Paises.Add("Tanzânia");
            Paises.Add("Togo");
            Paises.Add("Trinidad & Tobago");
            Paises.Add("Tunísia");
            Paises.Add("Turquia");
            Paises.Add("Ucrânia");
            Paises.Add("Uganda");
            Paises.Add("Uruguai");
            Paises.Add("Venezuela");
            Paises.Add("Vietname");
            Paises.Add("Zaire");
            Paises.Add("Zâmbia");
            Paises.Add("Zimbábue");

            return Paises;
        }


        private class Tabela
        {
            string BD = null;
            string senha = null;
            public string nome = null;
            string chave = null;
            bool auto_incremento = false;
            public List<string> campos = new List<string>();

            public Tabela(string nome, string chave, bool auto_incremento, List<string> campos)
            {
                this.nome = nome;
                this.chave = chave;
                this.auto_incremento = auto_incremento;
                if (auto_incremento) chave += " auto_increment";
                this.campos = campos;
            }

            public Tabela(string nome, string chave, bool auto_incremento)
            {
                this.nome = nome;
                this.chave = chave + " primary key";
                this.auto_incremento = auto_incremento;
                if (auto_incremento) this.chave += " auto_increment";
            }

            public void addBD(string bd, string senha)
            {
                this.BD = bd;
                this.senha = senha;
            }


            public void addChaveEstrangeira(string campoLocal, string tabelaEstrangeira, string campoEstrangeira, string tipoLink)
            {
                string texto = "constraint fk_" + tabelaEstrangeira.ToLower() + "_" + campoEstrangeira + Conexao.ContaChaves + " foreign key (" + campoLocal + ") references " + tabelaEstrangeira + "(" + campoEstrangeira + ") " + tipoLink;
                campos.Add(texto);
                Conexao.ContaChaves++;
            }

            public void addChaveEstrangeira(string campoLocal, string tabelaEstrangeira, string campoEstrangeira)
            {
                string texto = "constraint fk_" + tabelaEstrangeira.ToLower() + "_" + campoEstrangeira + Conexao.ContaChaves + " foreign key (" + campoLocal + ") references " + tabelaEstrangeira + "(" + campoEstrangeira + ") ";
                campos.Add(texto);
                Conexao.ContaChaves++;
            }

            public void addUnique(string campo, string tabela)
            {
                string[] cps = campo.Split(',', ' ');
                string texto = "constraint " + campo + "_unico" + " unique (" + campo + ")";

                string cmp = "";
                if (cps.Length > 0)
                {
                    for (int i = 0; i < cps.Length; i++)
                    {
                        cmp += "_" + cps[i];
                    }
                    texto = "constraint _unico" + cmp + "_" + tabela + " unique (" + campo + ")";
                }
                campos.Add(texto);
            }

            public void addCampo(string[] campos)
            {
                for (int u = 0; u < campos.Length; u++)
                {
                    this.campos.Add(campos[u]);
                }
            }

            public bool gravarTabela()
            {
                try
                {
                    string[] campos = new string[this.campos.Count];

                    for (int i = 0; i < campos.Length; i++)
                    {
                        campos[i] = this.campos[i];
                    }

                    Object obj = Conexao.ClienteSql.CREATE_TABLE(this.nome, campos, this.chave);

                    var aux = "Table '" + this.nome + "' already exists";
                    var aux2 = "There is already an object named '"+ this.nome+"' in the database.";

                    if (obj.ToString().ToUpper().Equals(aux.ToUpper()) || (obj.ToString().ToUpper().Equals(aux2.ToUpper())))
                    {
                        Conexao.ClienteSql.ADICIONA_CAMPOS(this.nome, campos);
                    }

                    if (obj.ToString() == "Já existe um objeto com o nome" || obj.ToString() == "Já existe um objeto com o nome '" + this.nome + "' na base de dados.")
                    {
                        Conexao.ClienteSql.ADICIONA_CAMPOS(this.nome, campos);
                    }




                    string x = (string)obj;
                    Arquivos.txt_AdicionaTexto("Tabelas.txt", this.nome + ">>>" + x);


                    Conexao.ContaTabelas++;
                    return true;

                }
                catch (Exception er)
                {
                    throw new Exception(er.Message);

                }

            }

        }
    }
}
