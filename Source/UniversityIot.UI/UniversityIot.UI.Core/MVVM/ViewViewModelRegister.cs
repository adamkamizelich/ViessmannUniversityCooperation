using System;
using System.Collections.Generic;
using UniversityIot.UI.Core.ViewModels;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.MVVM
{
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
            Type view = this.viewModelByView[viewModel.GetType()];
            return (Page)Activator.CreateInstance(view);
        }
    }
}