namespace UniversityIot.UI.Mvvm
{
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    /// Container for View - ViewModel mappings. Very simple version.
    /// </summary>
    public class ViewViewModelRegister
    {
        private readonly Dictionary<Type, Type> viewModelByView = new Dictionary<Type, Type>();

        public void Register<TView, TViewModel>()
            where TViewModel : BaseViewModel
            where TView : Page
        {
            Type viewModelType = typeof(TViewModel);
            Type viewType = typeof(TView);
            this.viewModelByView.Add(viewModelType, viewType);
        }

        public Page GetViewFor<TViewModel>(TViewModel viewModel)
            where TViewModel : BaseViewModel
        {
            Type viewType = this.viewModelByView[viewModel.GetType()];
            var view = (Page)Activator.CreateInstance(viewType);
            view.BindingContext = viewModel;

            return view;
        }
    }
}