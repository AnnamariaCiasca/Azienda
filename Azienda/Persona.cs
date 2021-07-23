using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodFiscale { get; set; }

        public Persona(string nome, string cognome, string codFiscale)
        {
           
            this.Nome = nome;
            this.Cognome = cognome;
            this.CodFiscale = codFiscale;
        }

        public Persona()
        {

        }

    }
}
