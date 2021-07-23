using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
   public class Tecnico : Impiegato

    {
       public decimal PagaOraria { get; set; }

        public int OreLavorate { get; set; }



        public Tecnico(string nome, string cognome, string codFiscale, SettoreEnum settore, decimal stipendioMensile, List<Skill> skills, decimal pagaOraria, int oreLavorate)
                        : base(nome, cognome, codFiscale, settore, stipendioMensile, skills)
        {
            this.PagaOraria = pagaOraria;
            this.OreLavorate = oreLavorate;
            StipendioMensile = OreLavorate * pagaOraria;
        }

        internal static decimal CalcoloStipendio(int oreLavorate, decimal pagaOraria)
        {
            return StipendioMensile = oreLavorate * pagaOraria;
        }

        public Tecnico()
        {

        }
    }
}
