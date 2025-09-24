using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    // Implementação usando EF Core
    public class EstudanteRepositorio : IEstudanteRepositorio
    {
        private readonly EstudanteDbContext _context;

        public EstudanteRepositorio(EstudanteDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            _context.SaveChanges();
        }

        public List<Estudante> ListarTodos()
        {
            return _context.Estudantes.ToList();
        }

        public Estudante ObterPorId(int id)
        {
            // Usar Find é otimizado para busca por chave primária
            return _context.Estudantes.Find(id);
        }

        public void Atualizar(Estudante estudante)
        {
            // Marca a entidade como modificada
            _context.Entry(estudante).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var estudante = ObterPorId(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                _context.SaveChanges();
            }
        }
    }
}
