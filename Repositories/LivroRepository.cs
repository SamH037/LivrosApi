using System.Collections.Generic;
using System.Linq;
using Chapter.WebApi.Contexts;
using Chapter.WebApi.Models;

namespace Chapter.WebApi.Repositories
{
    public class LivroRepository
    {
        private readonly ChapterContext _context;

        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }
        // listar livros
        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }
        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }
        // cadastrar
        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);

            _context.SaveChanges();
        }
        // alterar
        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livro.Disponivel = livro.Disponivel;
            }
        // Atualizando
            _context.Livros.Update(livroBuscado);

            _context.SaveChanges();
        }
        /// <summary>
        /// Deleta um livro existente a partir do id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            _context.Livros.Remove(livroBuscado);

            _context.SaveChanges();
        }
    }
}
