using DevExpress.XtraBars.Ribbon;
using  Folha.Domain.Enuns.Genericos;

namespace Folha.Domain.Helpers
{
    public class FormBase<T> : RibbonForm where T : class, new()
    {
        protected CRUD TipoOperacao { get; set; }

        protected T Entidade { get; set; } 
        public virtual void EditarEntity(T entidade)
        {
            TipoOperacao = CRUD.Edição;
            Entidade = entidade;
            ShowDialog();
        }
    }
}
