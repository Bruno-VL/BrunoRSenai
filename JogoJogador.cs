using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogame.Domains
{
    public class JogoJogador : BaseDomain
    { //relacionando as Foreing KEY
        [Key]
        public Guid Id { get; set; }
        public Guid IdJogo { get; set; }

        [ForeignKey("IdJogo")]

        public Jogo Jogo { get; set; }

        // Fazemos o relacionamento da FK(IdJogador)

        public Guid IdJogador { get; set; }


        [ForeignKey("IdJogador")]

        public Jogador Jogador { get; set; }

    }
}
