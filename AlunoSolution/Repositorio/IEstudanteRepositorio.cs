using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorio
{
    public interface IEstudanteRepositorio
    {
        void Adicionar(Estudante estudante);
        List<Estudante> ListarTodos();
        Estudante ObterPorId(int id);
        void Atualizar(Estudante estudante);
        void Remover(int id);
    }
}
