using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public class LoadAllDirectorsSO : BaseSO
    {
        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            if (parameter.GetType() == typeof(SearchValue))
                Result = broker.Search<Director>((SearchValue)parameter);
        }
    }
}
