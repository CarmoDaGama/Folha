using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    public partial class frmCadMoeda : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private MoedasViewModel Moeda;
        private readonly IMoedaApp _Moeda;
        private int moedaPadrao = 0;
        private readonly IGenericoApp _GenericoApp;
        private List<MostraMoedasViewModel> LtMoedas;
        private int CodMoedaPadrao;

        public frmCadMoeda(IMoedaApp Moeda,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _Moeda = Moeda;
            _GenericoApp = GenericoApp;
        }
        public void ReceberParametros(MoedasViewModel Moeda)
        {
            this.Moeda =  Moeda;
            txtDescricao.Text = Moeda.Descricao;
            txtSigla.Text = Moeda.Sigla;
            txtCodigo.Text = Moeda.Codigo.ToString();
            if (Moeda.moedapadrao == 1) chkPadrao.Checked = true;
            ShowDialog();

        }
        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Insira uma Descricao !", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSigla.Text == "")
            {
                MessageBox.Show("Insira uma Sigla !", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _Moeda.VerificarDup("Moedas", d))
            {
                MessageBox.Show("Registo já existente.", "AVISO", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return valid;
        }
        private void MetSalva()
        {
                bool Verifica = _GenericoApp.VerificarRegisto("Moedas", "moedapadrao", moedaPadrao.ToString());

            LtMoedas = LtMoedas.Where(r => r.moedapadrao == 1).ToList();


            if (LtMoedas.Count == 1)
                CodMoedaPadrao = LtMoedas[0].Codigo;

            if (!Verifica)
            {
                _Moeda.addMoeda(new Moedas()
                {
                    Descricao = txtDescricao.Text,
                    Sigla = txtSigla.Text,
                    moedapadrao = moedaPadrao
                });
            }
            else
            {
                if (MessageBox.Show("Já existe uma moeda padrão, deseja alterar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Alterar Moeda Padrao Anterior
                    _Moeda.UpdateMoedaPadrao(new Moedas()
                    {
                        codigo = CodMoedaPadrao,
                        moedapadrao = 0
                    });

                    _Moeda.addMoeda(new Moedas()
                    {
                        Descricao = txtDescricao.Text,
                        Sigla = txtSigla.Text,
                        moedapadrao = moedaPadrao
                    });
                }
            }

        }
       
        private void MetEdit()
        {

                bool Verifica = _GenericoApp.VerificarRegisto("Moedas", "moedapadrao", moedaPadrao.ToString());
                LtMoedas = LtMoedas.Where(r => r.moedapadrao == 1).ToList();
               

                if (LtMoedas.Count==1)
                CodMoedaPadrao = LtMoedas[0].Codigo;
                if (!Verifica) 
                _Moeda.updateMoeda(new Moedas()
                {
                    codigo=int.Parse(Moeda.Codigo.ToString()),
                    Descricao = txtDescricao.Text,
                    Sigla = txtSigla.Text,
                    moedapadrao=moedaPadrao
                });
                else
                {
                   if (MessageBox.Show("Já existe uma moeda padrão, deseja alterar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Alterar Moeda Padrao Anterior
                        _Moeda.UpdateMoedaPadrao(new Moedas()
                        {
                            codigo = CodMoedaPadrao,
                            moedapadrao = 0
                        });
                        //-----------------------------
                        _Moeda.updateMoeda(new Moedas()
                        {
                            codigo = int.Parse(Moeda.Codigo.ToString()),
                            Descricao = txtDescricao.Text,
                            Sigla = txtSigla.Text,
                            moedapadrao = moedaPadrao
                        });
                    }
                        
                }
         
        }
      

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MetSalva();
            }
            else
            {
                MetEdit();
            }

            Close();
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmCadMoeda_Load(object sender, EventArgs e)
        {
            LtMoedas =(List<MostraMoedasViewModel>) _Moeda.Listar();
        }

        private void chkPadrao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPadrao.Checked) moedaPadrao = 1;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
    }
}