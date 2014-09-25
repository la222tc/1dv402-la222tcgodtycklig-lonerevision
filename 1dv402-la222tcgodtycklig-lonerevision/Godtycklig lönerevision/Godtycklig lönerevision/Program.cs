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
                    amountOfSalaries = ReadInt("Ange antalet löner att mata in: ");         //Skickar med det som står i parantes till ReadInt
                    Console.WriteLine();

                    if (amountOfSalaries < 2)                                               // om ammountOfSalaries är mindre än 2 så körs if satsen och kastar ett 
                    {                                                                       // undantag som fångas upp av catch och så körs den koden
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst 2 löner för att kunna göra en beräkning!");
                        Console.ResetColor();
                        Console.WriteLine();

                        throw new Exception();
                    }


                    else
                    {
                       ProcessSalaries(amountOfSalaries);                                   //tar med ammountOfSalaries till metoden ProcessSalaries
                    }

                    Console.WriteLine();

                }

                catch (Exception)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tryck på valfri tangent för ny beräkning - Ecs avslutar");
                    Console.ResetColor();

                    ConsoleKeyInfo cki = Console.ReadKey(true);                             // kollar vilken knapp som blir intryckt och kör om programmet 
                    if(cki.Key == ConsoleKey.Escape)                                        // om inte Escape knappen blir intryckt, då avslutas det
                    {
                        return;
                    }
                                                                                                                                                                                              
                }

            }
            

        }
        static void ProcessSalaries(int count)
        {
            
            int[] salaries;                                                                // Skapar en tom array
            int[] unsortedSalaries;                                                        // Skapar en tom array
            int medianSalary;
            int avrageSalary;
            int salarySpread;
            int maxSalary;
            int minimumSalary;
           

            salaries = new int [count];                                                     // Lägger till det värdet som count har till salaries
            unsortedSalaries = new int[count];                                              // Lägger till det värdet som count har till unsortedSalaries

            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));       // Loopar igenom arrayen och skickar det i parantes till ReadInt
                                                                                            // Plussar på 1 till i för varje gång loopen kör igenom
                unsortedSalaries[i] = salaries[i];                                          // Lägger till salaries arrayen till en ny array för att spara arrayen som
                                                                                            // den är just nu till senare
            }

            

            Array.Sort(salaries);

            avrageSalary = (int)salaries.Average();

            maxSalary = salaries.Max();
            minimumSalary = salaries.Min();

            salarySpread = maxSalary - minimumSalary;

            int mSalary = count / 2;

            

            if(count % 2 == 0)                                                              // Kollar om det är jämt antal eller inte
            {
                medianSalary = (salaries[mSalary - 1] + salaries[mSalary]) / 2;             // Det är jämt antal och plussar ihop de 2 mellersta värderna i arrayen och
            }                                                                               // dividerar dom på 2
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

            for (int i = 0; i <= count; i++)
            {
                Console.Write("  {0,5}   ", unsortedSalaries[i]);                           // Skriver ut de osorterade värderna i arrayen och justerar så att  
                                                                                            // de olika värden hamnar bra under varran
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
                
            }

            Console.WriteLine();
                
            throw new Exception();                                                          // Kastar ett nytt undantag som tas upp av catch så får användaren
                                                                                            // chans att välja om han vill göra en ny beraäkning eller inte
        }

        static int ReadInt(string prompt)
        {

            int value;

            while (true)
            {
                string str = "";
                try
                {


                    Console.Write(prompt);
                    str = Console.ReadLine();
                    value = int.Parse(str);                                  // Skriver ut stringen som följer med och låter användaren skriva in 
                                                                                            // ett värde
                    if (value < 1)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;  
                        Console.WriteLine("Skriv in ett värde som är högre än 0.");
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
                    Console.WriteLine("Fel format! {0} Försök igen.", str);
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
             return value;                                                                  // Returnerar värdet som användaren skrev in
               
        }
    }
}