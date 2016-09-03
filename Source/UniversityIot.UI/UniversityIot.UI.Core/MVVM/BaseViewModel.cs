using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniversityIot.UI.Core.Annotations;

namespace UniversityIot.UI.Core.MVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // TODO
        public INavigationService NavigationService => DraftContainer.NavigationService;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
