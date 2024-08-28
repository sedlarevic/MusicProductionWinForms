using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public class LoadAllArtistsSO : BaseSO
    {
        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            if (parameter.GetType() == typeof(SearchValue))
                Result = broker.Search<Artist>((SearchValue)parameter);
        }
    }
}
