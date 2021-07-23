using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
   public class Skill
    {
        public int Code { get; set; }
        public String Descrizione { get; set; }

        public Skill(int code, string descrizione)
        {

            this.Code = code;
            this.Descrizione = descrizione;
        }

        public Skill()
        {

        }
    }
}
