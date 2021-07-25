
using Folha.Domain.Interfaces.Application.Db;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Application.Vendas;
using Folha.Driver.Application.Db;
using Folha.Driver.Application.Financeiro;
using Folha.Driver.Application.Genericos;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Application.Inventario;
using Folha.Driver.Application.Vendas;
using Folha.Driver.Repository.Data.Repositories.Entidades;
using Folha.Domain.Interfaces.Repository.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.Interfaces.Repository.Generico;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Interfaces.Repository.Vendas;
using Folha.Driver.Repository.Db;
using Folha.Driver.Repository.Financeiro;
using Folha.Driver.Repository.Genericos;
using Folha.Driver.Repository.Vendas;
using SimpleInjector;
using Folha.Driver.Repository.Inventario;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Driver.Application.Entidades;
using Folha.Driver.Repository.Data.Repositories.Financeiro;
using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Driver.Application.Escolar;
using Folha.Domain.Interfaces.Repository.Escolar;
using Folha.Driver.Repository.Escolar;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Interfaces.Repository.Sistema;
using Folha.Driver.Repository.Data.Repositories.Sistema;
using Folha.Driver.Application.Sistema;
using Folha.Driver.Repository.Data.Repositories.Inventario;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Driver.Application.Documentos;
using Folha.Domain.Interfaces.Repository.Documentos;
using Folha.Driver.Repository.Data.Repositories.Documentos;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Driver.Repository.Entidades;
using Folha.Driver.Repository.Documentos;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Driver.Repository.Hospitalar;
using Folha.Driver.Application.Hospitalar;
using Folha.Domain.Interfaces.Application.Admin;
using Folha.Driver.Application.Admin;
using Folha.Driver.Repository.Administrador;
using Folha.Driver.Repository.Admin;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Driver.Application.UtilitariosConfiguracoes;
using Folha.Driver.Repository.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Application.Inteligente;
using Folha.Driver.Application.Inteligente;
using Folha.Driver.Repository.Inteligente;
using Folha.Domain.Interfaces.Application.Empresa;
using Folha.Driver.Application.Empresa;
using Folha.Driver.Repository.Empresa;
using Folha.Domain.Interfaces.Application.Ficalizacao;
using Folha.Driver.Application.Ficalizacao;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Domain.Interfaces.Repository.Admin;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Repository.Inteligente;
using Folha.Domain.Interfaces.Repository.Empresa;

namespace Folha.Driver.Framework.IOC
{
    public class IOC
    {
        public static void RegistrarInjecao(Container container)
        {
            container.Register<IDbApp, DbApp>();
            container.Register<IDbRepository, DbRepository>();

            container.Register<IClientesApp, ClientesApp>();
            container.Register<IClientesRepository, ClientesRepository>();

            container.Register<IPaisesApp, PaisesApp>();
            container.Register<IPaisesRepository, PaisesRepository>();

            container.Register<IBancosApp, BancosApp>();
            container.Register<IBancosRepository, BancosRepository>();

            container.Register<IArmazemApp, ArmazemApp>();
            container.Register<IArmazensRepository, ArmazensRepository>();

            container.Register<ICategoriaApp, CategoriaApp>();
            container.Register<ICategoriasRepository, CategoriasRepository>();

            container.Register<IArtigosApp, ArtigoApp>();
            container.Register<IArtigosRepository, ArtigosRepository>();

            container.Register<IEntidadesApp, EntidadesApp>();
            container.Register<IEntidadesRepository, EntidadesRepository>();

            container.Register<ICaixasApp, CaixasApp>();
            container.Register<ICaixasRepository, CaixaRepository>();

            container.Register<IMoedaApp, MoedaApp>();
            container.Register<IMoedaRepository, MoedaRepository>();

            container.Register<IDisciplinaApp, DisciplinaApp>();
            container.Register<IDisciplinaRepository, DisciplinaRepository>();

            container.Register<ISalasApp, SalasApp>();
            container.Register<ISalasRepository, SalasRepository>();

            container.Register<IFPagamentosApp, FPagamentosApp>();
            container.Register<IFPagamentosRepository, FPagamentosRepository>();

            container.Register<IUsuariosApp, UsuariosApp>();
            container.Register<IUsuariosRepository, UsuariosRepository>();

            container.Register<IDocumentosApp, DocumentosApp>();
            container.Register<IDocumentosRepository, DocumentosRepository>();

            container.Register<ITurnosApp, TurnosApp>();
            container.Register<ITurnosRepository, TurnosRepository>();

            container.Register<IPagamentosApp, PagamentoApp>();
            container.Register<IPagamentosRepository, PagamentosRepository>();

            container.Register<IVendasApp, VendasApp>();
            container.Register<IVendasRepository,VendasRepository>();

            container.Register<IOperacoesApp, OperacoesApp>();
            container.Register<IOperacoesRepository, OperacoesRepository>();

            container.Register<INotasPagamentosApp, NotasPagamentosApp>();
            container.Register<INotasPagamentosRepository, NotasPagamentosRepository>();

            container.Register<IMovArtigosApp, MovArtigosApp>();
            container.Register<IMovArtigoRepository, MovArtigoRepository>();

            container.Register<ITipoSaidaApp, TipoSaidaApp>();
            container.Register<ITipoSaidaRepository, TipoSaidaRepository>();

            container.Register<ITransferenciaProdutoApp, TransferenciaProdutoApp>();
            container.Register<ITransferenciaProdutoRepository, TransferenciaProdutoRepository>();

            container.Register<IArtigoStockApp, ArtigoStockApp>();
            container.Register<IArtigoStockRepository, ArtigoStockRepository>();

            container.Register<IContaBancariaApp, ContaBancariaApp>();
            container.Register<IContaBancariaRepository, ContaBancariaRepository>();

            container.Register<IEntidadePessoaApp, EntidadePessoaApp>();
            container.Register<IEntidadePessoasRepository, EntidadePessoasRepository>();

            container.Register<IHabilitacaoApp, HabilitacaoApp>();
            container.Register<IHabilitacaoRepository, HabilitacaoRepository>();

            container.Register<IProfissaoApp, ProfissaoApp>();
            container.Register<IProfissaoRepository, ProfissaoRepository>();

            container.Register<ITipoDocumentoEntidadeApp, TipoDocumentoEntidadeApp>();
            container.Register<ITipoDocumentoEntidadeRepository, TipoDocumentoEntidadeRepository>();

            container.Register<IDocumentoEntidadeRepository, DocumentoEntidadeRepository>();

            container.Register<IMoradasRepository, MoradasRepository>();

            container.Register<IContactoRepository, ContactoRepository>();

            container.Register<ITipoContactoApp, TipoContactoApp>();
            container.Register<ITipoContactoRepository, TipoContactoRepository>();

            container.Register<IPaisApp, PaisApp>();
            container.Register<IPaisRepository, PaisRepository>();

            container.Register<IAcessoDocumentosApp, AcessoDocumentosApp>();
            container.Register<IAcessoDocumentosRepository, AcessoDocumentosRepository>();

            container.Register<IFornecedoresApp, FornecedoresApp>();
            container.Register<IFornecedoresRepository, FornecedoresRepository>();

            container.Register<IFuncionariosApp, FuncionariosApp>();
            container.Register<IFuncionariosRepository, FuncionariosRepository>();

            container.Register<ILiquidacaoDocApp, LiquidacaoDocApp>();
            container.Register<ILiquidacaoDocRepository, LiquidacaoDocRepository>();

            container.Register<ICambioApp, CambioApp>();
            container.Register<ICambioRepository, CambioRepository>();

            container.Register<ICalculosFinanceiroApp, CalculosFinanceiroApp>();
            container.Register<ICalculosRepository, CalculosRepository>();

            container.Register<IMedicosApp, MedicosApp>();
            container.Register<IMedicosRepository, MedicosRepository>();

            container.Register<IEspecialidadesApp, EspecialidadesApp>();
            container.Register<IEspecialidadesRepository, EspecialidadesRepository>();

            container.Register<IPacienteApp, PacienteApp>();
            container.Register<IPacienteRepository, PacientesRepository>();

            container.Register<IImpostoApp, ImpostoApp>();
            container.Register<IImpostoRepository, ImpostoRepository>();

            container.Register<IMotivoIsencaoApp, MotivoIsencaoApp>();
            container.Register<IMotivoIsencaoRepository, MotivoIsencaoRepository>();

            container.Register<IDefinicoesGeraisApp, DefinicoesGeraisApp>();
            container.Register<IDefinicoesGeraisRepository, DefinicoesGeraisRepository>();

            container.Register<IComissoesApp, ComissoesApp>();
            container.Register<IComissoesRepository, ComissoesRepository>();

            container.Register<INotificaoApp, NotificaoApp>();
            container.Register<INotificacaoRepository, NotificacaoRepository>();

            container.Register<ITipoConsultasApp, TipoConsultasApp>();
            container.Register<ITipoConsultasRepository, TipoConsultasRepository>();

            container.Register<IPerfilNovoApp, PerfilNovoApp>();
            container.Register<IPerfilNovoRepository, PerfisNovoRepository>();

            container.Register<IUsuarioNovoApp, UsuarioNovoApp>();
            container.Register<IUsuarioNovoRepository, UsuarioNovoRepository>();

            container.Register<IInteligenteApp, InteligenteApp>();
            container.Register<IInteligenteRepository, InteligenteRepository>();

            container.Register<ITriagemApp, TriagemApp>();
            container.Register<ITriagemRepository, TriagemRepository>();

            container.Register<IEmpresaApp, EmpresasApp>();
            container.Register<IEmpresaRepository, EmpresasRepository>();

            container.Register<IExamesHospitalarApp, ExamesHospitalarApp>();
            container.Register<IExamesHospitalarRepository, ExamesHospitalarRepository>();

            container.Register<ISubCategoriaApp, SubCategoriaApp>();
            container.Register<ISubCategoriaRepository, SubCategoriaRepository>();

            container.Register<IInternamentoApp, InternamentoApp>();
            container.Register<IInternamentoRepository, InternamentoRepository>();

            container.Register<IEscalaApp, EscalaApp>();
            container.Register<IEscalaRepository, EscalaRepository>();

            container.Register<IConsultaHospitalarApp, ConsultaHospitalarApp>();
            container.Register<IConsultaHospitalarRepository, ConsultaHospitalarRepository>();

            container.Register<IReceitasApp, ReceitasApp>();
            container.Register<IReceitasRepository, ReceitasRepository>();

            container.Register<IAtendimentoHospitalarApp, AtendimentoHospitalarApp>();
            container.Register<IAtendimentoHospitalarRepository, AtendimentoHospitalarRepository>();

            container.Register<IProfissinalSaudeApp, ProfissionalSaudeApp>();
            container.Register<IProfissinalSaudeRepository, ProfissionalSaudeRepository>();

            container.Register<ILaboratorioApp, LaboratorioApp>();
            container.Register<ILaboratorioRepository, LaboratorioRepository>();

            container.Register<ICamasHospitalarApp, CamasHospitalarApp>();
            container.Register<ICamasHospitalarRepository, CamasHospitalarRepository>();

            container.Register<IQuartosHospitalarApp, QuartosHospitalarApp>();
            container.Register<IQuartosHospitalarRepository, QuartosHospitalarRepository>();

            container.Register<ITarifaHospitalarApp, TarifaHospitalarApp>();
            container.Register<ITarifaHospitalarRepository, TarifaHospitalarRepository>();

            container.Register<IDiasSemanaApp, DiasSemanaApp>();
            container.Register<IDiasSemanaRepository, DiasSemanaRepository>();

            container.Register<IGenericoApp, GenericoApp>();
            container.Register<IGenericoRepository, GenericoRepository>();

            container.Register<IPeriodoBackupApp, PeriodoBackupApp>();
            container.Register<IPeriodoBackupRepository, PeriodoBackupRepository>();

            container.Register<ICondicoesPagamentoApp, CondicoesPagamentoApp>();
            container.Register<ICondicoesPagamentoRepository, CondicoesPagamentoRepository>();

            container.Register<IAlunosApp, AlunosApp>();
            container.Register<IAlunosRepository,AlunosRepository>();

            container.Register<ILoteArtigoApp, LoteArtigoApp>();
            container.Register<ILoteArtigoRepository, LoteArtigoRepository>();

            container.Register<ISaftApp, SaftApp>();
        }

        public static T InjectForm<T>() where T : class
        {
            Container container = new Container();
            RegistrarInjecao(container);

            T form = container.GetInstance<T>();

            return form;
           
        }
    }

   
}
