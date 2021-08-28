using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("feac2b07-016a-4f4c-8259-5a722f2d530e"), new Jogo{ Id = Guid.Parse("feac2b07-016a-4f4c-8259-5a722f2d530e"), Nome = "Fifa 19", Produtora = "EA", Preco = 200} },
            {Guid.Parse("e1061822-d3e0-47e4-845b-217f36660a01"), new Jogo{ Id = Guid.Parse("e1061822-d3e0-47e4-845b-217f36660a01"), Nome = "GTA", Produtora = "RockStar", Preco = 99} },
            {Guid.Parse("5d562faf-7de3-4c9c-90b3-a5fbc40d7d2f"), new Jogo{ Id = Guid.Parse("5d562faf-7de3-4c9c-90b3-a5fbc40d7d2f"), Nome = "Diablo 3", Produtora = "Blizzard", Preco = 150 } },
            {Guid.Parse("a593dfec-8432-4d85-abe6-45d65b25ec13"), new Jogo{ Id = Guid.Parse("a593dfec-8432-4d85-abe6-45d65b25ec13"), Nome = "Uncharted 4", Produtora = "Naughty Dog", Preco = 49 } },
            {Guid.Parse("34b44b97-04c4-466b-b418-9f5a591f6943"), new Jogo{ Id = Guid.Parse("34b44b97-04c4-466b-b418-9f5a591f6943"), Nome = "Skyrim", Produtora = "Bethesda", Preco = 460 } },
            {Guid.Parse("4dff0355-d7ca-4507-9c86-6c1aa6c699c4"), new Jogo{ Id = Guid.Parse("4dff0355-d7ca-4507-9c86-6c1aa6c699c4"), Nome = "Left 4 Dead 2", Produtora = "Valve", Preco = 15 } }
        };

        public Task<List<Jogo>>Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult(new Jogo());

            return Task.FromResult(jogos[id]);    
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }

        public Task<List<Jogo>> ObterJogosMaisCarosBaratos(char opcao, int qtd)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tuple<string, double>>> ObterQtdJogosPorProdutora()
        {
            throw new NotImplementedException();
        }
    }
}
