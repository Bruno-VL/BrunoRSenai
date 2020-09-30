using ApiBoletim.Context;
using ApiBoletim.Domain;
using ApiBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {

        //Chamando Classe de Connexão do Banco
        BoletimContext conexao = new BoletimContext();

        //Objeto para executar os comandos do banco
        SqlCommand cmd = new SqlCommand();
        private object alunos;

        public Aluno Alterar(int id, Aluno a)
        {
            cmd.Connection = conexao.Conectar():

            cmd.CommandText = "UPDATE Aluno SET " +
                "Nome  = @nome " +
                "Ra = @ra " +
                "Idade = @idade WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.Ra);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.Parameters.AddWithValue("@id", id);
            
            conexao.Desconectar();
            return a;
        }

        internal Aluno Cadastrar(object a)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id,", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while(dados.Read())
            {
                a.IdAluno = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.Ra = dados.GetValue(2).ToString();
                a.IdAluno = Convert.ToInt32(dados.GetValue(3));
            }
            
            conexao.Desconectar();

            return a;
        }

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, Ra, Idade) " +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.Ra);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Aluno> LerTodos()
        {
            //Abrir
            cmd.Connection = conexao.Conectar();

            //Preparar Query
            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            //Lista

            List<Aluno> alunos = new List<Aluno>();

            while(dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        Ra = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3))
                    }

                );
            }

            //Fechar
            conexao.Desconectar();

            return alunos;
        }
    }
}
