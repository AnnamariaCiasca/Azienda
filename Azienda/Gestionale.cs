using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Gestionale
    {
        static Skill sk1 = new Skill()
        {
            Code = 1,
            Descrizione = "Produttività"
        };

        static Skill sk2 = new Skill()
        {
            Code = 2,
            Descrizione = "Puntualità"
        };

        static Skill sk3 = new Skill()
        {
            Code = 3,
            Descrizione = "Problem Solving"
        };

        static Skill sk4 = new Skill()
        {
            Code = 4,
            Descrizione = "Lavoro di squadra"
        };




        static List<Impiegato> impiegati = new List<Impiegato>()
        {
        new Tecnico{Nome = "Marco", Cognome = "Rossi", CodFiscale = "MRCRSS56L75B615B", Settore = SettoreEnum.Amministrazione, Skills = {sk1, sk2}, OreLavorate = 40, PagaOraria = 90 },
        new Tecnico{Nome = "Sara", Cognome = "Verdi", CodFiscale = "SRAVRDSS23L75B4H", Settore = SettoreEnum.Sviluppo, Skills = {sk2, sk4}, OreLavorate = 40, PagaOraria = 90 },

        new Stagista{Nome = "Francesco", Cognome = "Totti", CodFiscale = "TTFRCL54M721B24L", Settore = SettoreEnum.Vendite,  Skills = {sk1, sk3, sk4}, DurataStage = 3 },
        new Stagista{Nome = "Fiona", Cognome = "Neri", CodFiscale = "FNANRCL5234LMN8H", Settore = SettoreEnum.Sviluppo,  Skills = {sk1, sk2, sk4}, DurataStage = 6 },

        new Manager{Nome = "Maria", Cognome = "Bianchi", CodFiscale = "MRBNCH567LM21B6H", Settore = SettoreEnum.Amministrazione, Skills = {sk1, sk2, sk3, sk4}, OreStraordinario = 12, StipendioBase = 1500 },
        new Manager{Nome = "Luisa", Cognome = "Pippo", CodFiscale = "LSAPPOL55B67189B", Settore = SettoreEnum.Sviluppo, Skills = {sk1, sk2, sk3, sk4}, OreStraordinario = 10, StipendioBase = 1500 },

        };



        internal static void MostraImpiegati(List<Impiegato> impiegati)
        {
           

            if (impiegati.Count > 0)
            {
                Console.WriteLine("\nEcco l'elenco degli Impiegati: \n");
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Impiegato impiegato in impiegati)
                {
                    Console.WriteLine( $"\n{count})  \tNome: {impiegato.Nome}, Cognome: {impiegato.Cognome}, Settore: {impiegato.Settore},  Stipendio: {impiegato.CalcoloStipendio()}, Skill: ");

                    count++;

                    foreach (Skill skill in impiegato.Skills)
                        Console.WriteLine(" " + skill.Descrizione);
                }
            }
            else
            {
                Console.WriteLine("Nessun impiegato");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MostraImpiegati()
        {
            MostraImpiegati(impiegati );
        }


        internal static void MostraImpiegatiSettore()
        {
            Console.WriteLine("Scegli il Settore: ");

            SettoreEnum settore = ScegliSettore();

            List<Impiegato> impiegatiFiltrati = new List<Impiegato>();

            foreach (Impiegato impiegato in impiegati)
            {
                if (impiegato.Settore == settore)
                {
                    impiegatiFiltrati.Add(impiegato);
                }
            }

            if (impiegatiFiltrati.Count > 0)
            {
                MostraImpiegati(impiegatiFiltrati);
            }
            else
            {
                Console.WriteLine($"Non sono presenti impiegati appartenenti al settore {settore}");
            }
        }

        internal static void InserisciImpiegato()

        {
            int scelta = 0;


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digita 1 per Inserire un tecnico");
            Console.WriteLine("Digita 2 per Inserire uno stagista");
            Console.WriteLine("Digita 3 per Inserire un manager");

            Console.ForegroundColor = ConsoleColor.White;


            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3)
            {
                Console.WriteLine("Inserire valore corretto!");
            }

            switch (scelta)
            {
                case 1:
                    InserisciTecnico();
                    break;

                case 2:
                    InserisciStagista();
                    break;

                case 3:
                    InserisciManager();
                    break;

                default:
                    break;

            }
        }

        public static void InserisciTecnico()
        {
            int oreLavorate = 0;
            decimal pagaOraria = 0;

            Console.WriteLine("\nInserisci nome: ");
            string nome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci cognome: ");
            string cognome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci Codice Fiscale: ");
            string codFiscale = Console.ReadLine().ToUpper();


            SettoreEnum settore = ScegliSettore();

            Console.WriteLine("\nInserisci Ore Lavorate: ");
            while (!int.TryParse(Console.ReadLine(), out oreLavorate) || oreLavorate < 0 || oreLavorate > 40)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }

            Console.WriteLine("\nInserisci paga oraria: ");
            while (!decimal.TryParse(Console.ReadLine(), out pagaOraria) || oreLavorate < 0 || oreLavorate > 100)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }
            decimal stipendio = Tecnico.CalcoloStipendio(oreLavorate, pagaOraria);

            Impiegato impiegato = new Impiegato(nome, cognome, codFiscale, settore, stipendio, null);
            impiegati.Add(impiegato);


        }

        public static void InserisciManager()
        {
            int oreStraordinario = 0;
            decimal stipendioBase = 0;

            Console.WriteLine("\nInserisci nome: ");
            string nome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci cognome: ");
            string cognome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci Codice Fiscale: ");
            string codFiscale = Console.ReadLine().ToUpper();


            SettoreEnum settore = ScegliSettore();

            Console.WriteLine("\nInserisci Ore di Straordinario: ");
            while (!int.TryParse(Console.ReadLine(), out oreStraordinario) || oreStraordinario < 0 || oreStraordinario > 20)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }

            Console.WriteLine("\nInserisci stipendio Base, min 1000, max 1500  ");
            while (!decimal.TryParse(Console.ReadLine(), out stipendioBase) || stipendioBase < 1000 || stipendioBase > 1500)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }
            decimal stipendio = Manager.CalcoloStipendio(oreStraordinario, stipendioBase);

            Impiegato impiegato = new Impiegato(nome, cognome, codFiscale, settore, stipendio, null);
            impiegati.Add(impiegato);


        }

        public static void InserisciStagista()
        {
     
            int durataStage = 0;
            string descrizione;

            Console.WriteLine("\nInserisci nome: ");
            string nome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci cognome: ");
            string cognome = Console.ReadLine().ToUpper();

            Console.WriteLine("\nInserisci Codice Fiscale: ");
            string codFiscale = Console.ReadLine().ToUpper();

            SettoreEnum settore = ScegliSettore();

           



            Console.WriteLine("\nInserisci la durata dello Stage: ");
            while (!int.TryParse(Console.ReadLine(), out durataStage) || durataStage < 0 || durataStage > 20)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }


            Impiegato impiegato = new Impiegato(nome, cognome, codFiscale, settore, 600, null );
            impiegati.Add(impiegato);


        }



        private static SettoreEnum ScegliSettore()
        {
            bool isInt = false;
            int settore = 0;
            do
            {
               
                Console.WriteLine($"\nPremi {(int)SettoreEnum.Amministrazione} per {SettoreEnum.Amministrazione}");
                Console.WriteLine($" Premi {(int)SettoreEnum.Sviluppo} per {SettoreEnum.Sviluppo}");
                Console.WriteLine($" Premi {(int)SettoreEnum.Vendite} per {SettoreEnum.Vendite}\n");

                isInt = int.TryParse(Console.ReadLine(), out settore);
            } while (!isInt || settore < 0 || settore > 2);

            return (SettoreEnum)settore;
        }


        internal static void EliminaImpiegato()
        {
            MostraImpiegati();

            Impiegato impiegatoDaEliminare = ScegliImpiegato();

            impiegati.Remove(impiegatoDaEliminare);
        }

        private static Impiegato ScegliImpiegato()
        {
            bool isInt = false;
            int num = 0;
            do
            {
                Console.WriteLine("Inserisci il numero dell'impiegato desiderato: ");
                isInt = int.TryParse(Console.ReadLine(), out num);
            } while (!isInt || num < 0 || num > impiegati.Count);

            return impiegati.ElementAt(num - 1);
        }

        internal static void MostraImpiegatiStipendio()
        {
            decimal stipendioDaVerificare = 0;
            Console.WriteLine("Inserisci stipendio: ");

            while (!decimal.TryParse(Console.ReadLine(), out stipendioDaVerificare) || stipendioDaVerificare < 0 || stipendioDaVerificare > 100)
            {
                Console.WriteLine("\nInserire valore corretto!");
            }
            
            List<Impiegato> impiegatiFiltrati = new List<Impiegato>();

            foreach (Impiegato impiegato in impiegati)
            {
                if (impiegato.CalcoloStipendio() > stipendioDaVerificare)
                {
                    impiegatiFiltrati.Add(impiegato);
                }
            }

            if (impiegatiFiltrati.Count > 0)
            {
                MostraImpiegati(impiegatiFiltrati);
            }
            else
            {
                Console.WriteLine($"Non ci sono impiegati con stipendio maggiore di {stipendioDaVerificare}");
            }
        }

        internal static void MostraImpiegatiSkill()
        {
           
        }
    }
}
  
