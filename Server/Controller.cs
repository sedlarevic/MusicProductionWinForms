using Common.Domain;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Server.SystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {

        private static Controller instance;

        private List<MusicProducer> activeProducers;
        public List<MusicProducer> ActiveProducers { get { return activeProducers; } set { activeProducers = value; } }
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }
        private Controller()
        {
            activeProducers = new List<MusicProducer>();
        }
        private bool ProducerLoggedIn(MusicProducer producer)
        {
            foreach (MusicProducer activeProducer in activeProducers)
            {
                if (activeProducer.Username == producer.Username && activeProducer.Password == producer.Password)
                    return true;
            }
            return false;
        }
        private object LogoutUser(MusicProducer producer)
        {
            foreach (var loggedProducer in ActiveProducers)
            {
                if (loggedProducer.Username == producer.Username && loggedProducer.Password == producer.Password)
                {
                    ActiveProducers.Remove(loggedProducer);
                    break;
                }

            }
            return null;
        }
        public object Login(LoginValue<MusicProducer> loginValue)
        {
            if (loginValue?.Value is MusicProducer musicproducer)
            {
                MusicProducer producer = loginValue.Value;
                if (!ProducerLoggedIn(producer))
                {
                    var login = new LoginSO<MusicProducer>(loginValue);
                    login.ExecuteTemplate(loginValue);
                    MusicProducer loginResult = (MusicProducer)login.Result;
                    if (loginResult == null)
                        return new Exception("Producer is not found.");
                    else
                        ActiveProducers.Add(loginResult);
                    return (MusicProducer)login.Result;
                }
                else
                {
                    return new Exception("Producer already logged in.");
                }
            }
            else
            {
                return new Exception("Producer not sent");
            }


        }
        internal object Logout(MusicProducer argument)
        {
            LogoutUser(argument);
            return null;
        }
        public object Add(object parameter)
        {              
            string nameSO = "Add" + parameter.GetType().Name + "SO";
            Type SOType = Type.GetType("Server.SystemOperations." + nameSO);
            ConstructorInfo constructor = SOType.GetConstructor(Type.EmptyTypes);
            BaseSO addSO = (BaseSO)constructor.Invoke(null);
            addSO.ExecuteTemplate(parameter);

            return addSO.Result;            
        }
        public object Edit(EditValue editValue)
        {
            Type type = Type.GetType(editValue.Type);
            string nameSO = "Edit" + type.Name + "SO";
            Type SOType = Type.GetType("Server.SystemOperations." + nameSO);
            ConstructorInfo constructor = SOType.GetConstructor(Type.EmptyTypes);
            BaseSO editSO = (BaseSO)constructor.Invoke(null);
            editSO.ExecuteTemplate(editValue);
            return editSO.Result;
        }
        public object Search(SearchValue searchValue)
        {
            Type type = Type.GetType(searchValue.Type);
            string nameSO = "Search" + type.Name + "SO";
            Type SOType = Type.GetType("Server.SystemOperations." + nameSO);
            ConstructorInfo constructor = SOType.GetConstructor(Type.EmptyTypes);
            BaseSO searchSO = (BaseSO)constructor.Invoke(null);
            searchSO.ExecuteTemplate(searchValue);

            return searchSO.Result;
        }
    }
}
