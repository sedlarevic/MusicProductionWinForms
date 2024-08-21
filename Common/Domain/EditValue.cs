using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class EditValue
    {
        public string Type { get; set; }
        public object OriginalValue { get; set; }
        public object EditedValue { get; set; }

    }
}
