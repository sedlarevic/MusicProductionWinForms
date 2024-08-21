using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class SearchValue
    {

        //klasa u kojoj pretrazujemo
        //public Type Type { get; set; }
        public string Type {  get; set; }
        //tip parametra po kome pretrazujemo (item u combo boxu)
        public string Parameter { get; set; }

        //vrednost iz textboxa po kojoj pretrazujemo
        public object Value { get; set; }

    }
}
