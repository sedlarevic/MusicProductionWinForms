using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public abstract class BaseSO
    {

        protected Broker broker;
        public object Result;
        public BaseSO()
        {
            broker = new Broker();
        }

        public void ExecuteTemplate(object parameter = null)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation(parameter);

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw ex;
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        protected abstract void ExecuteConcreteOperation(object parameter = null);


    }
}
