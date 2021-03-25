using System;

namespace revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObteopcaoUsuarior();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: adicionar aluno
                        Console.WriteLine("Informa o nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno: ");

                         if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                         {
                            aluno.Nota = nota;                             
                         }
                         else
                         {
                             throw new ArgumentException("Valo de nota deve ser decimal");
                         }

                         alunos[indiceAluno] = aluno;
                         indiceAluno ++;

                        break;


                    case "2":
                        //TODO: Listar aluno

                        foreach (var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome)){
                            Console.WriteLine($"Aluno:{a.Nome} - Nota:{a.Nota}");
                            }
                        }

                        break;


                    case "3":
                        //TODO: Calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        Console.WriteLine($"Media Geral: {mediaGeral}");
                        Conceito conceitoGeral;

                        if (mediaGeral < 3)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 5)
                        {
                            conceitoGeral = Conceito.D;
                        }

                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }

                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }

                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} - Conceito: {conceitoGeral}");

                        break;

                    default:
                        //mostra que o valor informado esta fora do range de opçoes
                        throw new ArgumentOutOfRangeException();
                }


                opcaoUsuario = ObteopcaoUsuarior();

            }
        }

        private static string ObteopcaoUsuarior()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Inserir um novo aluno");
            Console.WriteLine("2-Listar Alunos");
            Console.WriteLine("3- Calcular media geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
