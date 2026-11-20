using System;
using QuanlyCongviecNhom.ViewModels;

namespace QuanlyCongviecNhom.Services
{
    public class NavigationService : BaseViewModel
    {
        private BaseViewModel? _currentView;

        public BaseViewModel? CurrentView
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }

        public event Action? CurrentViewChanged;

        // Hàm chuyển sang ViewModel mới
        public void NavigateTo<TViewModel>(Func<TViewModel> createViewModel) where TViewModel : BaseViewModel
        {
            CurrentView = createViewModel();
            CurrentViewChanged?.Invoke();
        }
    }
}