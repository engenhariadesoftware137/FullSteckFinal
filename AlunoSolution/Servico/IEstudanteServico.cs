using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public interface IEstudanteServico
    {
        void AdicionarEstudante(Estudante estudante);
        List<Estudante> ListarTodos();
        Estudante ObterPorId(int id);
        void AtualizarEstudante(Estudante estudante);
        void RemoverEstudante(int id);
    }
}
