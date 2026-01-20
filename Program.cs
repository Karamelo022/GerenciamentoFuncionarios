using System;
using System.Globalization;
using System.Collections.Generic;

namespace GerenciamentoFuncionarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos funcionarios serão cadastrado: ");
            int n = int.Parse(Console.ReadLine());

            List<Funcionarios> funcionarios = new List<Funcionarios>();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Funcionarios #{i}: ");

                Console.Write("Id: ");
                int id1 = int.Parse(Console.ReadLine());

                bool idExiste = false;
                foreach (Funcionarios f in funcionarios)
                {
                    if (f.Id == id1)
                    {
                        idExiste = true; break;
                    }

                }

                if (idExiste)
                {
                    Console.Write("Id já existe! Tente novamente.");
                    i--; 
                    continue;
                }

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Sálario: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Funcionarios func = new Funcionarios(id1, nome, salario);
                funcionarios.Add(func);

            }

            Console.Write("Insira o ID do funcionário que receberá o aumento salarial: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Entre com a porcentagem: ");
            double porcent = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Funcionarios funcEncontrado = null;
            foreach (Funcionarios f in funcionarios)
            {
                if (f.Id == id) 
                {
                    funcEncontrado = f;
                    break;
                }
            }

            
            if (funcEncontrado != null)
            {
               
                funcEncontrado.AumentarSalario(porcent);
                Console.WriteLine("Aumento aplicado com sucesso!");
            }
            else
            {
                Console.WriteLine("Esse ID não existe!");
            }

            Console.WriteLine("\nLista atualizada de funcionários:");
            foreach (Funcionarios f in funcionarios)
            {
                Console.WriteLine($"{f.Id}, {f.Nome}, {f.Salario:F2}");
            }

           
        }
    }
}
