using Common.Domain;

namespace Server.SystemOperations
{
    public class EditArtistSO : BaseSO
    {

        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            if (parameter.GetType() == typeof(EditValue))
                Result = broker.Edit<Artist>((EditValue)parameter);

        }
    }
}