using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Manager : Impiegato

    {
        public int OreStraordinario { get; set; }
        public  decimal StipendioBase { get; set; }


        public Manager(string nome, string cognome, string codFiscale, SettoreEnum settore, decimal stipendioMensile, List<Skill> skills, int oreStraordinario, decimal stipendioBase)
                        : base(nome, cognome, codFiscale, settore, stipendioMensile, skills)
        {
            this.OreStraordinario = oreStraordinario;
            this.StipendioBase = stipendioBase;
        }

        public static decimal CalcoloStipendio(int oreStraordinario, decimal stipendioBase)   
        {
            return StipendioMensile = stipendioBase + (oreStraordinario * 10);
        }

        public Manager()
        {

        }

    }
}