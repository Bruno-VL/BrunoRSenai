using APIJogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogame.Interfaces
{
    interface IJogadorRepository
    {
        Jogador Cadastrar(Jogador c);
        List<Jogador> LerTodos();
        Jogo BuscarPorId(int id);
        Jogo Alterar(int id, Jogador c);
        void Excluir(int id);
    }
}
