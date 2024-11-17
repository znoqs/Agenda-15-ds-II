using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvento.Models
{
    public class Evento
    {

        public String NomeEvento {  get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set;}
        public double ValorPorConvidado { get; set; }
        public int QtdConvidados { get; set; }
        public String Endereco { get; set; }
        public TimeSpan Duracao => DataTermino - DataInicio;
        public int DuracaoEmDias => (int)Duracao.TotalDays;

        public double total
        {
            get
            {
                double total = ValorPorConvidado * QtdConvidados;

                return total;
            }
        }
    }
}
