using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public class AddProjectSO : BaseSO 
    {
        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            if (parameter.GetType() == typeof(Project))
                Result = broker.Add((Project)parameter);
        }
    }
}
