using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public class LoginSO<T> : BaseSO where T : IEntity,new()
    {
        private readonly T value;
        //private readonly MusicProducer musicProducer;
        public LoginSO(LoginValue<T> lval)
        {
            this.value = lval.Value;
        }
        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            if (parameter is LoginValue<T> loginValue)
                Result = broker.Login(loginValue);
        }

    }
}
