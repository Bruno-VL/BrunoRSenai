using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogame.Domains
{
    public class Jogo : BaseDomain
    {
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public DateTime DataLanç { get; set; }
    }
}
