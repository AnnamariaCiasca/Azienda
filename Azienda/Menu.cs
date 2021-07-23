using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
  public  class Menu
    {
        public static void Start()
        {
            char continua;

            do
            {
                int scelta = 0;

                Console.WriteLine("***********************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digita 1 per Visualizzare tutti gli impiegati");
                Console.WriteLine("Digita 2 per Mostrare gli impiegati di un settore");
                Console.WriteLine("Digita 3 per Inserire un nuovo impiegato");
                Console.WriteLine("Digita 4 per Eliminare un impiegato");
                Console.WriteLine("Digita 5 per Visualizzare gli impiegati con stipendio maggiore di quello inserito");
                Console.WriteLine("Digita 6 per Visualizzare gli impiegati con una certa Skill");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("***********************************************");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 6)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                        Gestionale.MostraImpiegati();  //ok
                        break;

                    case 2:
                        Gestionale.MostraImpiegatiSettore(); //ok
                        break;

                    case 3:
                        Gestionale.InserisciImpiegato();  
                        break;

                    case 4:
                        Gestionale.EliminaImpiegato();   //ok
                        break;

                    case 5:
                        Gestionale.MostraImpiegatiStipendio(); //ok
                        break;

                    case 6:
                        Gestionale.MostraImpiegatiSkill();
                        break;

                    default:
                        break;

                }



                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nVuoi continuare? Se sì, digita s");
                continua = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");


            } while (continua == 's' || continua == 'S');
        }
    }
}
