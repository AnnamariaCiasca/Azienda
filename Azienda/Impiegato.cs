using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
  public class Impiegato : Persona
    {
        public SettoreEnum Settore { get; set; }

        public static decimal StipendioMensile { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Impiegato(string nome, string cognome, string codFiscale, SettoreEnum settore, decimal stipendioMensile, List<Skill> skills)
                        : base(nome, cognome, codFiscale)  
        {
            this.Settore = settore;
            StipendioMensile = stipendioMensile;
            this.Skills = skills;
        }

        public decimal CalcoloStipendio()
        {
         return StipendioMensile; 
        }

        public Impiegato()
        {

        }

       
    }

    public enum SettoreEnum
    {
       Vendite,
       Amministrazione,
       Sviluppo
    }
  
}
