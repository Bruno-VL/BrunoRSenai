using APIJogame.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogame.Context
{
    public class JogoContext : DbContext
    {
        //Colocar NOME NO plural YAN PORRA
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Jogador> Jogadors { get; set; }
        public DbSet<JogoJogador> JogoJogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source =.\Sqlexpress; Initial Catalog = APIJogame; user id = sa; password = sa132");
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
