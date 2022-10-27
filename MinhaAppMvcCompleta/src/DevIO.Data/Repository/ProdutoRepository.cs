using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Retorna um Produto com seus Fornecedores
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Retorna uma lista com todos os Produtos e seus Fornecedores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _context.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna uma lista de Produtos de um Fornecedor específico
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
