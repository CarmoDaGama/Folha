using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Ficalizacao
{
    public  interface ISaftApp
    {
        void PreencherSaftHeader(DateTime dateStart, DateTime dateEnd);
        void PreencheSaftMaster(DateTime dateStart, DateTime dateEnd);
        void PreencheSaftMasterSourceDocuments(DateTime dateStart, DateTime dateEnd);
        void GerarSaft(DateTime dateStart, DateTime dateEnd, string caminho, string nomeFicheiro);

    }
}
