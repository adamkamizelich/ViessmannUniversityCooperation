namespace UniversityIot.UI.Mvvm
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using UniversityIot.UI.Core.Annotations;

    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}