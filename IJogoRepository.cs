using APIJogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogame.Interfaces
{
    interface IJogoRepository
    {
        Jogo Cadastrar(Jogo v);
        List<Jogo> LerTodos();
        Jogo BuscarPorId(int id);
        Jogo Alterar(int id, Jogo v);
        void Excluir(int id);

    }
}
