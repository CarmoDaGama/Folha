using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.Enuns.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Folha.Domain.Enuns.Genericos;
using System.Threading;
using System.Data;

namespace Folha.Domain.Helpers
{
    public static class UtilidadesGenericas
    {
        public static Form frmInicial { get; set; }
        public static Image ImagemVazia;
        public static decimal UmDolarEmKWZ { get; set; } = 300.00m;
        public static bool EstadoTurnoSistema { get; set; } = false;
        public static bool Alterou{ get; set; } = false;
        public static int UsuarioCodigo { get; set; }
        public static string NomeUsuario { get; set; }
        public static string NomeEntidade { get; set; }
        public static int CodigoTurno { get; set; }
        public static string UsuarioPerfil { get; set; }
        public static int UsuarioPerfilCodigo { get; set; }
        public static string UsuarioPerfilNome{ get; set; }
        public static List<string> ListaAcesso { get; set; }
        public static string Moeda { get; set; } = "AKZ";
        public static bool UsuarioAlterado { get; set; }
        public static string MesagemTest { get; set; }
        public static string RegistrarEmpresa { get; set; }
        public static int LarguraPai { get;  set; }
        public static int AlturaPai { get; set; }
        public static bool PermitirVenderSemStock { get; set; }
        public static string SenhaUser { get; set; }
        public static string LoginUser { get; set; }

        public static class ConexaoCorrente
        {
            public static string Servidor { get; set; } 
            public static string DataBase { get; set; }
            public static int Porta { get; set; }
            public static  ETipoBancoDados tipoBancoDados { get; set; }
            public static  string Usuario { get; set; }
            public static  string Senha { get; set; }
        }

        public static bool ValidarEmCredito(decimal stockMax, decimal qtdEntrar, string nomeEntidade)
        {
            if (PermitirVenderSemStock)
            {
                return true;
            }
            if (qtdEntrar > stockMax)
            {
                MsgShow(
                    "Erro",
                    "Quantidade maxima do " + nomeEntidade + " é " + stockMax,
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            return true;
        }

        public static string GetSenhaEncriptada()
        {
            return Encriptar(SenhaUser);
        } 
        public static bool ValidarEmDebito(decimal qtdLimite, decimal qtdSair, string nomeEntidade)
        {

            if (PermitirVenderSemStock)
            {
                return true;
            }
            if (qtdLimite <= 0)
            {

                MsgShow(nomeEntidade + " com insuficiente de stock");
                return false;
            }
            else if (qtdSair > qtdLimite)
            {
                MsgShow("Erro", "Quantidade do "+nomeEntidade+" tem de ser Menor ou iqual que " + qtdLimite, MessageBoxIcon.Error, MessageBoxButtons.OK);

                return false;
            }
            return true;
        }

        public static void ChamarNoPrincipal(Form form)
        {
            frmInicial.GetType().GetMethod("ChamarFormAqui").Invoke(frmInicial, new object[] { form });
        }
        public static class Busca
        {

            //variaveis Global
            public static bool Alterou { get; set; }
            public static bool VerificaConsultorio { get; set; }

            public static bool Entrou { get; set; }
            public static bool ModoLista { get; set; }
            public static string CodNovoArmazem { get; set; }


            public static bool Editar { get; set; }
            public static string Codigo { get; set; }
            public static string CodMedicoNovo { get; set; }
            public static string CodPaceinteNovo { get; set; }
            public static string CodigoDocumento { get; set; }
            public static string Descricao { get; set; }
            public static string CodigoConsultaNova { get; set; }
            public static string Quantidade { get; set; }
            public static decimal QuantidadeNova { get; set; }
            public static string Dias { get; set; }
            public static string Tipo { get; set; }

            public static string Entidade { get; set; }
            public static string FormNome { get; set; }
            public static Double Numerario { get; set; }
            //Banco
            public static string CodConta { get; set; }
            

            //Variaveis para o internamento
            public static int CodQuartoHospitalar { get; set; }
            public static int CodTarifaHospitalar { get; set; }
            public static int CodCamaHospitalar { get; set; }
            public static string QuantidadeHospitalar { get; set; }
            public static decimal ValorTarifa { get; set; }
            public static string CodCosulta { get; set; }



            //Categoria
            public static string Vender { get; set; }
            //Imposto
            public static string Percentagem { get; set; }

            //Transferencia
            public static string Origem { get; set; }
            public static string Destino { get; set; }
            public static string Stock { get; set; }

            //Venda
            public static bool FecharVenda { get; set; }

            //Acesso
            public static string Acessos { get; set; }
            public static string CodProduto { get; set; }



            //Produto
            public static string TipoStock { get; set; }
            public static string PermitVenda { get; set; }
            public static string Familia { get; set; }
            public static int CodArmazem { get; set; }
            public static string QuantidadeMAx { get; set; }
            public static string QuantidadeMin { get; set; }
            public static int CodArmazemDestino { get; set; }

            public static string NomeArmazem { get; set; }
            public static string Custo { get; set; }
            public static string Imposto { get; set; }
            public static string Preco1 { get; set; }
            public static string Preco2 { get; set; }
            public static string Preco3 { get; set; }
            public static string Rentencao { get; set; }

            public static decimal Desconto { get; set; }


        }

        public static decimal SomarTotal(string nomeColuna, DataTable table)
        {
            var total = 0.0m;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                total += Convert.ToDecimal(table.Rows[i][nomeColuna]);
            }
            return total;
        }

        public static void ValidarDataFimDataInicio(DateEdit dtInicio, DateEdit dtFim)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFim.EditValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;
        }

        public static class DadosEmpresa
        {
            public static string businessName;
            public static int codigo { get; set; }
            public static string Nome { get; set; } = "Grupo Kambaz, Lda";
            public static string NIF { get; set; }
            public static string Morada { get; set; }
            public static string Telefones { get; set; }
            public static string WebSite { get; set; }
            public static string Email { get; set; }
            public static byte[] Logotipo { get; set; }
            public static string Pais { get; set; }
            public static string Cidade { get; set; }
            public static string Endereco { get; set; }
            public static int Validou { get; set; }
            public static string Slogan { get; set; }

            public static string Responsavel { get; set; }
            public static string TipoEmpresa { get; set; }
        }
        public static int GetIntervaloDeDia(DateTime dataInicio, DateTime dataFim)
        {
            int intervaloDias = 0;
            var time = dataFim.Subtract(dataInicio);
            intervaloDias = time.Days;
            return intervaloDias;
        }

        public static int GetIntervaloDeAno (DateTime datAno , DateTime dataActual)
        {
            var time = dataActual.Subtract(datAno);
            return (int) (time.TotalDays / 365);
        }

        public static DateTime GetDataVencimento(int intervaloDias)
        {
            var timeSubtract = new TimeSpan(
                -intervaloDias, 0, 0, 0, 0
                );
            var dataVencimento = DateTime.Now.Subtract(timeSubtract);
            return dataVencimento;
        }
        public static bool IntervaloDeDiaValido(DateTime dataInicio, DateTime dataFim)
        {
            return GetIntervaloDeDia(dataInicio, dataFim) < 0;
        }
        public static DateTime GetDataFormatoCorreto(DateTime data, string strHora)
        {
            int hora = 0, minuno = 0, segundo = 0;
            var spHora = strHora.Split(':');
            if (!Equals(spHora, null) && spHora.Length > 1)
            {
                hora = int.Parse(spHora[0]);
                minuno = int.Parse(spHora[1]);
            }
            segundo = data.Second;
            return new DateTime(data.Year, data.Month, data.Day, hora, minuno, segundo);
        }
        public static string GetNomeLimpo(string descricao)
        {
            var spNome = descricao.Split('?');
            return !Equals(spNome, null) && spNome.Length > 1 ? spNome[0].Trim() : descricao;
        }
        public static void MsgShow(string mensagem)
        {
            MsgShow("NOTIFIÇÃO", mensagem, MessageBoxIcon.Information, MessageBoxButtons.OK);
        }
        public static bool MsgShow(string titulo, string mensagem, MessageBoxIcon icon, MessageBoxButtons botao)
        {
            return new frmAlerta().chamarNotificacao(titulo, mensagem, icon, botao);
        }

        public static string GetDescricaoFooter(DateTime data, string hora, string codAGT, decimal total, string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                return GetDescricaoFooter(data, hora, codAGT, total);
            }
            else
            {
                return GetDescricaoFooter(hash);
            }
        }
        public static string GetDescricaoFooter(DateTime data, string hora, string codAGT, decimal total)
        {
            //1, 11, 21, 31
            string dadosdoHash = GetDadosHash(data, hora , codAGT, total);
            var strHash = GerarHash(dadosdoHash);
            var posicoesDoHash = strHash[0] + "" + strHash[10] + "" + strHash[20] + "" + strHash[30];
            int length = strHash.Length;
            string descricao = posicoesDoHash.ToUpper() + " - Processado por software validado nº 0000/AGT/" + DateTime.Now.Year + "   FOLHA ERP";
            return descricao;
        }
        public static string GetDescricaoFooterSemHash(DateTime data, string hora, string codAGT, decimal total)
        {
            //1, 11, 21, 31
            string dadosdoHash = GetDadosHash(data, hora, codAGT, total);
            //var strHash = GerarHash(dadosdoHash);
            //var posicoesDoHash = strHash[0] + "" + strHash[10] + "" + strHash[20] + "" + strHash[30];
            //int length = strHash.Length;
            string descricao = "Processado por software validado nº 0000/AGT/" + DateTime.Now.Year + "   FOLHA ERP";
            return descricao;
        }
        public static string GetDescricaoFooter(string strHash)
        {
            //1, 11, 21, 31
            var posicoesDoHash = strHash[0] + "" + strHash[10] + "" + strHash[20] + "" + strHash[30];
            int length = strHash.Length;
            string descricao = posicoesDoHash.ToUpper() + " - Processado por software validado nº 0000/AGT/" + DateTime.Now.Year + "   FOLHA ERP";
            return descricao;
        }
        public static string GetDadosHash(DateTime data, string hora, string codAGT, decimal total)
        {
            var extData = GetDataFormatoCorreto(data, hora);
            return extData.ToString("yyyy-MM-dd") + ";" + extData.ToString("yyyy-MM-ddThh:mm:ss") + ";" + codAGT + ";" + total + ";" + "";
        }
        public static void MsgShow(string mensagem, MessageBoxIcon icon)
        {
            MessageBox.Show(
                mensagem,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                icon
            );
        }
        public static bool EntidadeValida<Entity>(Entity entity)
        {
            if (Equals(entity, null))
                return false;
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower() == "CodEmpresa".ToLower())
                {
                    continue;
                }
                var value = property.GetValue(entity);
                if (Equals(value, null) || 
                    Equals(value, "Nenhum") ||
                    Equals(value, "nenhum") ||
                    Equals(value, "Nenhuma") ||
                    Equals(value, "nenhuma") ||
                    string.IsNullOrEmpty(value.ToString()))
                {
                    return false;
                }
            }
            return true;

        }
        public static bool TemAcesso(string Acesso)
        {
            if (int.Parse(UsuarioPerfil.ToString()) == 1) return true;
            else
            {
                bool Res = false;

                for (int i = 0; i < ListaAcesso.Count - 1; i++)
                {

                    string _Acesso = Strings.Left(ListaAcesso[i].Trim().ToUpper(), ListaAcesso[i].ToString().Trim().Length - 1);

                    int _Valor = 0;
                    if (!string.IsNullOrEmpty(ListaAcesso[i]) && ListaAcesso[i] != "\n")
                    {
                        _Valor = int.Parse(Strings.Right(ListaAcesso[i], 1));
                    }
                    if (!string.IsNullOrEmpty(_Acesso) && (Acesso.Trim().ToUpper() == _Acesso.Trim().ToUpper()) && _Valor == 1) Res = true;

                    //MessageBox.Show("Acesso:" + Acesso + "\n" + "AcessoSistema:" + _Acesso);
                }

                return Res;
            }
        }
        public static bool TemAcessoRemover(string Acesso)
        {
            if (int.Parse(UsuarioPerfil.ToString()) == 1) return true;
            else
            {
                bool Res = false;

                for (int i = 0; i < ListaAcesso.Count - 1; i++)
                {

                    string _Acesso = Strings.Left(ListaAcesso[i].Trim().ToUpper(), ListaAcesso[i].ToString().Trim().Length - 1);
                    int _Valor = int.Parse(Strings.Right(ListaAcesso[i], 1));

                    if (Acesso.Trim().ToUpper() == _Acesso.Trim().ToUpper() && _Valor == 1) Res = true;

                    //MessageBox.Show("Acesso:" + Acesso + "\n" + "AcessoSistema:" + _Acesso);
                }

                return Res;
            }
        }
        public static List<T> newInstanceThisList<T>(List<T> list) where T : class, new()
        {
            var newList = new List<T>();
            newList.AddRange(list);

            return newList;
        }
        public static GridHitInfo GetGridHitInfo(object objGridView, Point mousePosition)
        {
            GridView view = (GridView)objGridView;
            Point pt = view.GridControl.PointToClient(mousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);

            return info;
        }
        public static int GetGridIndexCurrent(object objGridView, Point mousePosition)
        {
            return GetGridHitInfo(objGridView, mousePosition).RowHandle;
        }
        public static void showFormInPanel<Type>(Panel panel, Type form)
        {
            panel.Controls.Clear();
            form.GetType().GetProperty("TopLevel").SetValue(form, false);
            panel.Controls.GetType().GetMethod("Add").Invoke(panel.Controls, new object[] { form });
            panel.Controls[0].Show();
            //Thread.Sleep(1000);
            form.GetType().GetProperty("Dock").SetValue(form, DockStyle.Fill);
         
        }

        public static decimal GetValorCambio(decimal valor)
        {
            switch (Moeda.ToUpper())
            {
                case "USD":
                    return valor / UmDolarEmKWZ;

                default:
                    return valor;
            }
        }

        public static TypeEntity InEnum(string strTipoEntidade)
        {
            switch (strTipoEntidade)
            {
                case "CLIENTE":
                    return TypeEntity.CLIENTE;

                case "FORNECEDOR":
                    return TypeEntity.FORNECEDOR;

                case "FUNCIONARIO":
                    return TypeEntity.FUNCIONARIO;

                case "FR":
                    return TypeEntity.FR;

                case "ISENTO":
                    return TypeEntity.ISENTO;

                default:
                    return TypeEntity.ISENTO;

            }
        }

        public static bool ListaNula<T>(List<T> Lista) where T : class, new()
        {
            return Equals(Lista, null) || Lista.Count == 0;
        }

        public static TipoMov InEnumMov(string strTipoEntidade)
        {
            switch (strTipoEntidade)
            {
                case "CREDITO": 
                    return TipoMov.CREDITO;

                case "DEBITO":
                    return TipoMov.DEBITO;

                case "ISENTO":
                    return TipoMov.ISENTO;

                default:
                    return TipoMov.ISENTO;

            }
        }
        public static TipoEstadoDocumento InEnumStdDoc(string strTipoEntidade)
        {
            switch (strTipoEntidade)
            {
                case "ABERTO":
                    return TipoEstadoDocumento.ABERTO;

                case "PENDENTE":
                    return TipoEstadoDocumento.PENDENTE;

                case "FECHADO":
                    return TipoEstadoDocumento.FECHADO;

                case "ANULADO":
                    return TipoEstadoDocumento.ANULADO;

                default:
                    return TipoEstadoDocumento.FECHADO;

            }
        }
        public static void ClearComponents(Control.ControlCollection  fields)
        {
            foreach (Control control in fields)
                if (control.GetType().Name.Contains("TextEdit"))
                    control.Text = "";
                else if (control.GetType().Name.Contains("ComboBoxEdit"))
                    (control as ComboBoxEdit).SelectedIndex = -1;
        }
        public static decimal CalcularTotal(decimal preco, decimal qtd, decimal imposto, decimal desconto)
        {
            var total = 0.0m;
            var precoComImposto = CalcularPrecoComImposto(imposto, preco);
            decimal precoComImpostoComDesconto = precoComImposto - CalcularPrecoComDesconto(desconto, preco);
            total = qtd * precoComImpostoComDesconto;
            return total;
        }
        public static decimal CalcularPrecoComImposto(decimal imposto, decimal preco)
        {
            return (preco + (preco * ((decimal)imposto / 100)));
        }
        public static decimal CalcularPrecoComDesconto(decimal desconto, decimal preco)
        {
            return ((preco * ((decimal)desconto / 100)));
        }
        public static class CalculosFinanceiros
        {
            public static string ConverterMoeda(Object Valor, Object taxaCambio, bool venda)
            {
                try
                {
                    if (!venda) return (Convert.ToDouble(Valor) / Convert.ToDouble(taxaCambio)).ToString("N3");
                    return (Convert.ToDouble(Valor) * Convert.ToDouble(taxaCambio)).ToString("N3");
                }
                catch (Exception)
                {
                    return null;
                }
            }
            public static bool IsNumeric(string num)
            {
                try
                {
                    double x = Convert.ToDouble(num);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static NavigationPage NavegarNoFrame(object sender, Control.ControlCollection navigationFrameControls)
        {
            var namePage = (sender as AccordionControlElement).Name.Replace("btn", "page");
            return (NavigationPage)navigationFrameControls[namePage];
        }
        public static string GetNameNavegarNoFrame(object sender)
        {
            var namePage = (sender as AccordionControlElement).Name.Replace("btn", string.Empty);
            return namePage;
        }

       
        private static string escreva_parte(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

        public static bool TemCesteza(string mensagem)
        {
            return MsgShow("QUESTãO", mensagem, MessageBoxIcon.Question, MessageBoxButtons.YesNo);
        }
        public static bool TemCestezaEliminarRegistro()
        {
            return TemCesteza("Tem certeza que pretende eliminar este resgistro?");
        }

        public static string Decimal_Extenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;

                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);

                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";

                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                        {
                            if (Moeda.Equals("USD"))
                            {
                                valor_por_extenso += " DOLAR";
                            }
                            else
                            {
                                valor_por_extenso += " KWANZA";
                            }
                        }
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            if (Moeda.Equals("USD"))
                            {
                                valor_por_extenso += " DOLARES";
                            }
                            else
                            {
                                valor_por_extenso += " KWANZAS";
                            }

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " E ";
                    }

                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " CENTIMOS";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " CENTIMOS";
                }
                return valor_por_extenso;
            }
        }

        public static decimal GetTotalNaLista<T>(List<T> lista, string nomeCampo) where T : class, new()
        {
            decimal total = 0.0m;
            foreach (var item in lista)
            {
                var valor = item.GetType().GetProperty(nomeCampo).GetValue(item);
                total += Convert.ToDecimal(valor);
            }
            return total;
        }

        private static void CriarFicheiro(string file, string dados)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            StreamWriter writeH;
            writeH = File.CreateText(file);
            if (!string.IsNullOrEmpty(dados))
            {
                writeH.Write(dados);
            }
            writeH.Close();
        }
        private static string GetChavePrivada()
        {
            return "-----BEGIN RSA PRIVATE KEY-----"
                    +"\nMIICXAIBAAKBgQDTCB6Hy4c2qCdNnl8KYeyltzcsPwiybiK2s0rbLJK6PBafZvAg"
                    +"\nosh2Kttil1vqbTD74lCE8+yn0FYPi8mlZFodZPl8ohPXBBwW8nRCj/aBOlBuZeQV"
                    +"\naIT7tev36GCVpuVCkQ/44HFtDx+s+HaQA+5ojy/1leChVjxZymWjnbbt1QIDAQAB"
                    +"\nAoGBAMuuLHl4kXrJdZXO44BL33JakZ/c/vHopwybpAZC0SN614LmgaGeO8kBuFlC"
                    +"\nKW7sELksR/bqz2FxDX9Xtjoxz16JT4QTt2+vRjaxVyctLHQJbaB5nK1D8nMu9okM"
                    +"\nnaaoH1IELGetVpwpKbx7IgU0t0kSa07rLAyqARqc4KCTOoOBAkEA/ODspxymaANp"
                    +"\n7iKH5cBbjchNPr8nyP3GSyMNoYJtr9EFqCHXcocxtw6YtmE4lw/SH0FbsH7p4lCF"
                    +"\nDAwK2rWORQJBANWi9kvIEzlxX7Wkjnn8o9dPzzVzTWB1SH91fJPZrtFkUJTJqHXY"
                    +"\npRLFeraAm0DA134i1jBbEmJwOD9aS4i84lECQE3nhUCeZO2aT6IbZT50mj/9uz5f"
                    +"\naYRUGii/rc1Z/yyw+ksn0dXorHo2tvlIzkRLjXIvkm23S5p7L+HcO+PRFvkCQDIP"
                    +"\nfsFhP8f9Hh1VUyGYptfkVrzCqQYKVZOwdyG6J7HfXNaQro321y+f4NJ1LmwtBBIF"
                    +"\nncU1AgjZHQUTZpHDGRECQDvjQs+oHcodHcJYkNh6vVJ1J154pGtevZMsmxR2Jxbk"
                    +"\nUpsDGK1eCKAtsAZpX+8mQIMOuSf8zs7XYjhY6+Sf0N0="
                    +"\n-----END RSA PRIVATE KEY-----";
        }
        private static string GetChavePublica()
        {
            return "-----BEGIN PUBLIC KEY-----"
                    +"\nMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDTCB6Hy4c2qCdNnl8KYeyltzcs"
                    +"\nPwiybiK2s0rbLJK6PBafZvAgosh2Kttil1vqbTD74lCE8+yn0FYPi8mlZFodZPl8"
                    +"\nohPXBBwW8nRCj/aBOlBuZeQVaIT7tev36GCVpuVCkQ/44HFtDx+s+HaQA+5ojy/1"
                    +"\nleChVjxZymWjnbbt1QIDAQAB"
                    +"\n-----END PUBLIC KEY-----";
        }
        public static string GerarHash(string dados)
        {

            string caminho = Application.StartupPath + "\\Folha_hash";
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }

            string hashNameFile = "hash";
            string file = caminho + "\\" + hashNameFile + ".txt";
            string fileResulHash = caminho + "\\" + hashNameFile + ".b64";

            // ======================= Criar o ficheiro ==========================================
            CriarFicheiro(file, dados);
            if (!File.Exists(caminho + @"\Key_Private.pem"))
            {
                CriarFicheiro(caminho + @"\Key_Private.pem", GetChavePrivada());
            }
            if (!File.Exists(caminho + @"\Key_Public.pem"))
            {
                CriarFicheiro(caminho + @"\Key_Public.pem", GetChavePublica());
            }
            // ======================= End Criar o ficheiro ==========================================
            string executavelSSL = "\"" + Application.StartupPath + "\\OpenSSL-Win64\\bin\\openssl.exe\"";
            if (!File.Exists(Application.StartupPath + "\\OpenSSL-Win64\\bin\\openssl.exe"))
            {
                executavelSSL = "\"C:\\Program Files\\OpenSSL-Win64\\bin\\openssl.exe\"";
            }
            // ---------------------------------- CMD Proccess --------------------------------------------------------------------
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true; // Não preciso
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + caminho); // Recebe o caminho da pasta criada em documentos para que toda operação seja feita lá
            cmd.StandardInput.WriteLine(executavelSSL + " dgst -sha1 -sign Key_Private.pem -out " + hashNameFile + ".sha1 " + hashNameFile + ".txt");
            cmd.StandardInput.WriteLine(executavelSSL + " enc -base64 -in " + hashNameFile + ".sha1 -out " + hashNameFile + ".b64 -A");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            // ---------------------------------- END CMD Proccess --------------------------------------------------------------------

            StreamReader readH = File.OpenText(fileResulHash);

            string hashGerada = readH.ReadToEnd();
            readH.Close();
            EliminarFicheirosHash (caminho + "\\" + hashNameFile);
            return hashGerada;
        }

        private static void EliminarFicheirosHash(string hashNameFile)
        {
            if (File.Exists(hashNameFile +".txt"))
                File.Delete(hashNameFile + ".txt");
            
            if (File.Exists(hashNameFile + ".sha1"))
                File.Delete(hashNameFile + ".sha1");

            if (File.Exists(hashNameFile + ".b64"))
                File.Delete(hashNameFile + ".b64");
        }

        private static bool NaoChaves()
        {
            string executavelSSL = "C:\\Program Files\\OpenSSL-Win64\\bin\\";
            return !File.Exists(executavelSSL + "ChavePrivada.pem") || !File.Exists(executavelSSL + "ChavePublica.pem");
        }

        private static void GerarChaves()
        {
            //"C:\Program Files\OpenSSL-Win64\bin\openssl.exe"
            string executavelSSL = "\"C:\\Program Files\\OpenSSL-Win64\\bin\\openssl.exe\"";
            /***/string caminho = Application.StartupPath + "\\Folha_hash";
            // ---------------------------------- CMD Proccess --------------------------------------------------------------------
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true; // Não preciso
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();


            cmd.StandardInput.WriteLine("cd " + caminho);
            string codigoGerarChavePrivada = " genrsa -out ChavePrivada.pem";
            cmd.StandardInput.WriteLine(executavelSSL + codigoGerarChavePrivada);
            string codigoGerarChavePublica = " rsa -in ChavePrivada.pem -out ChavePublica.pem -outform PEM –pubout"; // Recebe o caminho da pasta criada em documentos para que toda operação seja feita lá
            cmd.StandardInput.WriteLine(executavelSSL + codigoGerarChavePublica);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        private static void GerarChavePubica()
        {
            string executavelSSLt = "\"C:\\Program Files\\OpenSSL-Win64\\bin\\openssl.exe\"";
            /**string caminho = Application.StartupPath + "\\Folha_hash";
            // ---------------------------------- CMD Proccess --------------------------------------------------------------------
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true; // Não preciso
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();


            cmd.StandardInput.WriteLine("cd " + caminho);
            string codigoGerarChavePrivada = " genrsa -out ChavePrivada.pem";
            cmd.StandardInput.WriteLine(executavelSSLt + codigoGerarChavePrivada); // Recebe o caminho da pasta criada em documentos para que toda operação seja feita lá
            cmd.StandardInput.WriteLine(executavelSSLt + codigoGerarChavePublica);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();*/
            string caminhoFile = Application.StartupPath + "\\Folha_hash" + "\\ScriptGerarChavePublica.bat";
            string codigoGerarChavePublica = " rsa -in ChavePrivada.pem -out ChavePublica.pem -outform PEM –pubout";
            CriarFicheiro(caminhoFile, executavelSSLt + codigoGerarChavePublica);
            Process.Start(caminhoFile);
        }

        //Tranferencia


        //DEFINIÇÕES GERAIS
        public static bool MostrarImposto;
        public static bool Incluir10Porcento;
        public static bool VenderProdutossemStock;
        public static bool ObrigatorioComissionario;
        public static bool ImprimirComissionarios;
        public static bool VariasLinhas;
        public static bool FecharTurnoComHospedagemAberta;
        public static bool CalcularLucroApartirdoPosto;
        public static bool AdicionarDiariaAutomatica;
        public static bool UsarConsumidorFinalNaHospedagem;
        public static bool ObrigrDocumentoNaHospedagem;
        public static bool SolicitaroClientenaFactura;
        public static bool MultaPt;
        public static int DuracaoVencimento;
        public static int AnoInicio;
        public static int CobrarMultaAposDia;
        public static double MaxMulta;

        //

        public static bool TemPOS = false;
        public static bool TemRH = false;
        public static bool TemHotel = false;
        public static bool TemRestaurante = false;
        public static bool TemEscolar = false;
        public static bool TemServico = false;
        public static bool TemCyber = false;
        public static bool TemAcademia = false;
        public static bool TemHospitalar = false;
        public static bool TemFrotas = false;
        public static bool TemSeguranca = false;
        public static bool Pausa;
        public static bool TemPT = false;
        public static bool TemLavandaria = false;
        public static bool TemViagem = false;

        public static string MudarEmitidoDocumento(string emitido)
        {
            {
                switch (emitido)
                {

                    case "Não Imprimido":
                        return "Original";

                    case "Original":
                        return "Duplicado";

                    case "Duplicado":
                        return "Duplicado";

                    default:
                        return  "Original";
                }
            }
        }
        

        // Criptografia de Banco de Dados

        public static string Encriptar(string texto)
        {
            try
            {

                string key = "qualityinfosolutions"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {

            }
            return texto;
        }
        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception x)
            {
                return x.Message;
            }
            return textoEncriptado;
        }

    }
}
