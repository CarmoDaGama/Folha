using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Sistema;

namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    public partial class frmAddPerfil : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IPerfilNovoApp _perfilApp;
        private readonly IOperacoesApp _OperacoesApp;

        public frmAddPerfil(IPerfilNovoApp perfilApp, IOperacoesApp operacoesApp)
        {
            InitializeComponent();
            _perfilApp = perfilApp;
            _OperacoesApp = operacoesApp;
            GerarAvoreOperacoes();
        }
        private string Gambiarra;
        private string Gambiarra1;
        private string Gambiarra2;
        private string Gambiarra3;
        private string validar = ("1234567890|!#$%&/()=?»><*^ª_:--.º|!?»`^ª[]}[}*-+^^`*");

        #region PERMIÇÃO de Acesso
    
        #endregion
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        #region Metodos
        private void GerarAvoreOperacoes()
        {
            var operacoes = _OperacoesApp.Listar("");
            var tnOperacoes = new TreeNode()
            {
                Name = "tnOperacoes",
                Text = "Operações"
            };
            foreach (var item in operacoes)
            {
                tnOperacoes.Nodes.Add(new TreeNode()
                {
                    Name = "tn" + item.APP,
                    Text = item.Nome
                });
            }
            Arvore.Nodes.Add(tnOperacoes);
        }
        public void CadatrarEdtar()
        {
            ArvoreParaTexto();
            if (UtilidadesGenericas.Busca.Editar)
            {
                try
                {
                    _perfilApp.Update(new Perfil()
                    {
                        codigo = int.Parse(txtCodigo.Text),
                        Descricao = txtDescricao.Text,
                        Acessos = txtGeral.Text.ToUpper()
                    }
                    );
                    Close();
                    UtilidadesGenericas.Busca.Editar = false;
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao Editar " + erro.Message);
                }
            }
            else
            {
                try
                {
                    _perfilApp.Insert(new Perfil()
                    {
                        Descricao = txtDescricao.Text,
                        Acessos = txtGeral.Text.ToUpper()
                    });

                    Close();
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao cadastrar " + erro.Message);
                }
            }
        }
        private void limpar()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";

        }
        #endregion

        #region Validação
        private bool isFieldsValid()
        {
            bool valid = true;

            if (txtDescricao.Text.Equals(string.Empty))
            {
                messageShow("Preencha a  Descrição");
                return false;
            }
           
            return valid;
        }
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        #endregion
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            try
            {
                CadatrarEdtar();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao cadastrar, Perfil já Existe ");
                return;
            }
            UtilidadesGenericas.Busca.Alterou = true;
            UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmPerfisAcesso>());

        }

        private void frmAddPerfil_Load(object sender, EventArgs e)
        {
            limpar();
            if (UtilidadesGenericas.Busca.Editar)
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                txtDescricao.Text = UtilidadesGenericas.Busca.Descricao;
                txtGeral.Text = UtilidadesGenericas.Busca.Acessos;
                
                string[] Listas = txtGeral.Text.Split('*');
                for (int i = 0; i < Listas.Length; i++)
                {
                    lstGeral.Items.Add(Listas[i]);
                }
                ListaParaArvore();
            }
        }
        #region Metodos do Palanca

        private int Retornaint(string checado)
        {
            if (checado.ToUpper().Equals("CHECKED")) return 1;
            else return 0;
        }
        private void ListaParaArvore()
        {

            for (int i = 0; i < lstGeral.Items.Count - 1; i++)
            {
                string x = lstGeral.Items[i].ToString();
                int valor = int.Parse(Folha.Domain.Helpers.Strings.Right(x, 1));

                string Linha = lstGeral.Items[i].ToString().Trim();

                string TestoLinha = Folha.Domain.Helpers.Strings.Left(Linha, Linha.Length - 1);
                string[] Niveis = TestoLinha.Split('#');

                int Nivel = Niveis.Length;

                if (Nivel == 1) NivelAvo(TestoLinha, valor);
                if (Nivel == 2) NivelPai(Niveis[0], Niveis[1], valor);
                if (Nivel == 3) NivelFilho(Niveis[0], Niveis[1], Niveis[2], valor);
                if (Nivel == 4) NivelNeto(Niveis[0], Niveis[1], Niveis[2], Niveis[3], valor);
            }
        }
        private void NivelAvo(string Texto, int Valor)
        {
            for (int j = 0; j < Arvore.Nodes.Count; j++)
            {
                string TextoArvore = Arvore.Nodes[j].Text;
                if (Texto.Trim().ToUpper() == TextoArvore.Trim().ToUpper())
                {
                    Arvore.Nodes[j].Checked = Convert.ToBoolean(Valor);
                }
            }
        }
        private void NivelPai(string NivelAvo, string NivelPai, int Valor)
        {
            for (int i = 0; i < Arvore.Nodes.Count; i++)
            {
                if (Arvore.Nodes[i].Text.Trim().ToUpper() == NivelAvo.Trim().ToUpper())
                {
                    for (int j = 0; j < Arvore.Nodes[i].Nodes.Count; j++)
                    {
                        if (Arvore.Nodes[i].Nodes[j].Text.Trim().ToUpper() == NivelPai.Trim().ToUpper())
                        {
                            Arvore.Nodes[i].Nodes[j].Checked = Convert.ToBoolean(Valor);
                        }
                    }
                }
            }
        }
        private void NivelFilho(string NivelAvo, string NivelPai, String NivelFilho, int Valor)
        {
            for (int i = 0; i < Arvore.Nodes.Count; i++)
            {
                if (Arvore.Nodes[i].Text.Trim().ToUpper() == NivelAvo.Trim().ToUpper())
                {
                    for (int j = 0; j < Arvore.Nodes[i].Nodes.Count; j++)
                    {
                        if (Arvore.Nodes[i].Nodes[j].Text.Trim().ToUpper() == NivelPai.Trim().ToUpper())
                        {
                            for (int k = 0; k < Arvore.Nodes[i].Nodes[j].Nodes.Count; k++)
                            {
                                if (Arvore.Nodes[i].Nodes[j].Nodes[k].Text.Trim().ToUpper() == NivelFilho.Trim().ToUpper())
                                {
                                    Arvore.Nodes[i].Nodes[j].Nodes[k].Checked = Convert.ToBoolean(Valor);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void NivelNeto(string NivelAvo, string NivelPai, String NivelFilho, string NivelNeto, int Valor)
        {
            for (int i = 0; i < Arvore.Nodes.Count; i++)
            {
                if (Arvore.Nodes[i].Text.Trim().ToUpper() == NivelAvo.Trim().ToUpper())
                {
                    for (int j = 0; j < Arvore.Nodes[i].Nodes.Count; j++)
                    {
                        if (Arvore.Nodes[i].Nodes[j].Text.Trim().ToUpper() == NivelPai.Trim().ToUpper())
                        {
                            for (int k = 0; k < Arvore.Nodes[i].Nodes[j].Nodes.Count; k++)
                            {
                                if (Arvore.Nodes[i].Nodes[j].Nodes[k].Text.Trim().ToUpper() == NivelFilho.Trim().ToUpper())
                                {
                                    for (int l = 0; l < Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                                    {
                                        if (Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Text.Trim().ToUpper() == NivelNeto.Trim().ToUpper())
                                        {
                                            Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Checked = Convert.ToBoolean(Valor);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ArvoreParaTexto()
        {
            lstGeral.Items.Clear();

            for (int i = 0; i < Arvore.Nodes.Count; i++)
            {
                string Avo = Arvore.Nodes[i].Text;
                string AvoValor = Arvore.Nodes[i].Checked.ToString();
                
                bool Valor = bool.Parse(AvoValor);
                if (Valor == true){ Gambiarra = "Checked";}
                else {Gambiarra = "Unchecked";}
                lstGeral.Items.Add(Avo + " " + Retornaint(Gambiarra) + "*");

                for (int j = 0; j < Arvore.Nodes[i].Nodes.Count; j++)
                {
                    string Pai = Arvore.Nodes[i].Nodes[j].Text;
                    string ValorPai = Arvore.Nodes[i].Nodes[j].Checked.ToString();

                    //metodo  para receber 1 
                    bool Valor1 = bool.Parse(ValorPai);
                    if (Valor1 == true) { Gambiarra1 = "Checked"; }
                    else { Gambiarra1 = "Unchecked"; }

                    lstGeral.Items.Add(Avo + "#" + Pai + " " + Retornaint(Gambiarra1) + "*");

                    for (int k = 0; k < Arvore.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        string Filho = Arvore.Nodes[i].Nodes[j].Nodes[k].Text;
                        string ValorFilho = Arvore.Nodes[i].Nodes[j].Nodes[k].Checked.ToString();

                        // metodo  para receber 1
                        bool Valor2 = bool.Parse(ValorFilho);
                        if (Valor2 == true) { Gambiarra2 = "Checked"; }
                        else { Gambiarra2 = "Unchecked"; }

                        lstGeral.Items.Add(Avo + "#" + Pai + "#" + Filho + " " + Retornaint(Gambiarra2) + "*");

                        for (int l = 0; l < Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                        {
                            string Neto = Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Text;
                            string ValorNeto = Arvore.Nodes[i].Nodes[j].Nodes[k].Nodes[l].Checked.ToString();

                            // metodo  para receber 1
                            bool Valor3 = bool.Parse(ValorNeto);
                            if (Valor3 == true) { Gambiarra3 = "Checked"; }
                            else { Gambiarra3 = "Unchecked"; }

                            lstGeral.Items.Add(Avo + "#" + Pai + "#" + Filho + "#" + Neto + " " + Retornaint(Gambiarra3) + "*");
                        }
                    }
                }
            }

            txtGeral.Clear();
            for (int i = 0; i < lstGeral.Items.Count; i++)
            {
                txtGeral.AppendText(lstGeral.Items[i].ToString() + "\n");
            }
        }

        #endregion

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validar.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtDescricao.Text = "";
            txtCodigo.Text = "";
            txtGeral.Text = "";
        }

        private void btnVerlista_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPerfisAcesso chamada = IOC.InjectForm<frmPerfisAcesso>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}