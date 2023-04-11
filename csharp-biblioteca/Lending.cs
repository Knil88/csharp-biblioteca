using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Lending
    {
        public User User { get; }
        public string PeriodFrom { get; }
        public string PeriodTo { get; set; }

        public Document Document { get; set; }
        public Lending(string periodfrom, string periodto, Document document, User user)
        {
            PeriodFrom = periodfrom;
            PeriodTo = periodto;
            Document = document;
            User = user;
        }
    }
}