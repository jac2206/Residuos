using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiduosApi.DTO
{
    public class DataError
    {
        public string Error { get; set; }
        public string Valor { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
