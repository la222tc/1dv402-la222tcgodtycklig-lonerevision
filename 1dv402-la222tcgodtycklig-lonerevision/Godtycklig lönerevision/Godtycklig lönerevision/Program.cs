using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godtycklig_lönerevision
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int amountOfSalaries;


            while (true)
            {

                try
                {
                    amountOfSalaries = ReadInt("Ange antalet löner att mata in: ");
                    Console.WriteLine();

                    if (amountOfSalaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst 2 löner för att kunna göra en beräkning!");
                        Console.ResetColor();
                        Console.WriteLine();

                        throw new Exception();
                    }


                    else
                    {
                       ProcessSalaries(amountOfSalaries);
                    }

                    Console.WriteLine();

                }

                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tryck på valfri tangent för ny beräkning - Ecs avslutar");
                    Console.ResetColor();

                    ConsoleKeyInfo cki;
                    cki = Console.ReadKey(true);
                    if(cki.Key == ConsoleKey.Escape)
                    {
                        return;
                    }

                }

            }
            

        }
        static void ProcessSalaries(int count)
        {
            
            int[] salaries;
            int medianSalary;
            int avrageSalary;
            int salarySpread;
            int maxSalary;
            int minimumSalary;
           

            salaries = new int [count];

            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));

                
            }

            

            Array.Sort(salaries);

            avrageSalary = (int)salaries.Average();

            maxSalary = salaries.Max();
            minimumSalary = salaries.Min();

            salarySpread = maxSalary - minimumSalary;

            int mSalary = count / 2;

            

            if(count % 2 == 0)
            {
                medianSalary = (salaries[mSalary - 1] + salaries[mSalary]) / 2;
            }
            else
            {
                medianSalary = salaries[mSalary];
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Medianlön:           {0:C0}", medianSalary);
            Console.WriteLine("Medellön:            {0:C0}", avrageSalary);
            Console.WriteLine("Lönespridning:       {0:C0}", salarySpread);
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            throw new Exception();
            
        }

        static int ReadInt(string prompt)
        {

            int value;

            while (true)
            {
                try
                {


                    Console.Write(prompt);
                    value = int.Parse(Console.ReadLine());

                    if (value < 1)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;  
                        Console.WriteLine("Skriv in ett värde högre än 0.");
                        Console.ResetColor();
                        Console.WriteLine();

                    }
                    else
                    {
                        break;
                    }
                }

                catch
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format! Försök igen.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
             return value;
               
        }
    }
}