using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
   public class Stagista : Impiegato

    { 

        public int DurataStage { get; set; }


        public Stagista(string nome, string cognome, string codFiscale, SettoreEnum settore, decimal stipendioMensile, List<Skill> skills, int durataStage)
                        : base(nome, cognome, codFiscale, settore, 600, skills)
        {
            this.DurataStage = durataStage;
        }

        public new decimal CalcoloStipendio()   //ho inserito new per nascondere membro ereditato
        {
            return StipendioMensile = 600;
        }

        public Stagista()
        {

        }
    
    }
}
