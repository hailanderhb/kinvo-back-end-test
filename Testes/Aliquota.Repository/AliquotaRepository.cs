using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain;
using Aliquota.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Repository
{
    public class AliquotaRepository
    {
        private readonly AliquotaContext _context;

        public AliquotaRepository()
        {
            _context = new AliquotaContext();
        }
        
        public void Criar(Aplicacao aplicacao)
        {
            _context.Aplicacoes.Add(aplicacao);
            _context.SaveChanges();
        }
        
        public Aplicacao ObterPeloNome(string nome)
        {
            return _context.Aplicacoes
                .AsNoTracking()
                .FirstOrDefault(x => x.Cliente == nome);
        }
    }
}