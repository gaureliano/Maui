using MauiApp1.DataAccess;
using MauiApp1.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Services
{
    public interface IGerenciamentoItemsService
    {
        List<string> ListarItemsAsync();
        Task<bool> AdicionarItemAsync(string descricao);
        Task<bool> LimparItensAsync();
    }

    public class GerenciamentoItemsService : IGerenciamentoItemsService
    {
        private readonly TestDbContext dataContext;

        public GerenciamentoItemsService(TestDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<bool> AdicionarItemAsync(string descricao)
        {
            dataContext.ItemLists.Add(new ItemList { Descricao = descricao });
            dataContext.SaveChanges();
            return true;
        }

        public async Task<bool> LimparItensAsync()
        {
            var todosItens = dataContext.ItemLists.ToList();
            dataContext.RemoveRange(todosItens);
            dataContext.SaveChanges();
            return true;
        }

        public List<string> ListarItemsAsync()
        {
            List<string> list = new List<string>();
            list = dataContext.ItemLists.Select(x => x.Descricao).ToList();
            return list;
        }
    }
}
