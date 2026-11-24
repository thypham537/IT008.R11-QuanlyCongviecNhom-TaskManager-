using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QuanlyCongviecNhom.Helpers;
using QuanlyCongviecNhom.Services;


namespace QuanlyCongviecNhom.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel? _currentView;
        public BaseViewModel? CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        // Thông tin người dùng hiển thị dưới gốc phải
        public string CurrentUserName { get; set; } = "Tên của tài khoản";
        public string CurrentUserRole { get; set; } = "Thành viên";
        public string UserAvatarLetter => string.IsNullOrEmpty(CurrentUserName) ? "U" : CurrentUserName.Substring(0, 1).ToUpper();

        // Các lệnh chuyển màn hình
        public ICommand NavigateProjectsCommand { get; }
        public ICommand NavigateTaskBoardCommand { get; }
        public ICommand NavigateCalendarCommand { get; }
        public ICommand LogoutCommand { get; }
        public MainWindowViewModel()
        {
            // Khởi tạo các Command
            NavigateProjectsCommand = new RelayCommand(_ => CurrentView = new ProjectListViewModel());
            NavigateTaskBoardCommand = new RelayCommand(_ => CurrentView = new TaskBoardViewModel());
            NavigateCalendarCommand = new RelayCommand(_ => CurrentView = new CalendarViewModel());
            LogoutCommand = new RelayCommand(_ => ExecuteLogout());
            // Mặc định khi mở app sẽ vào màn hình Danh sách Project đầu tiên
            CurrentView = new ProjectListViewModel();
        }
        private void ExecuteLogout()
        {
            // Xử lý đăng xuất (ví dụ: mở lại LoginWindow và đóng MainWindow)
            System.Windows.MessageBox.Show("Đăng xuất thành công!", "Thông báo");
        }
    }
}


