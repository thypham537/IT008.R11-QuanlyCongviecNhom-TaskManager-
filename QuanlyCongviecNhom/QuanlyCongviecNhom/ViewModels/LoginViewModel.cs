using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanlyCongviecNhom.Data;
using QuanlyCongviecNhom.Helpers;
using QuanlyCongviecNhom.Services;

namespace QuanlyCongviecNhom.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _usernameOrEmail;
        public string UsernameOrEmail
        {
            get => _usernameOrEmail;
            set { _usernameOrEmail = value; OnPropertyChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox?.Password ?? string.Empty;

            if (string.IsNullOrWhiteSpace(UsernameOrEmail) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage = "Vui lòng nhập đầy đủ tài khoản và mật khẩu.";
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            using (var db = new AppDbContext())
            {
                // Kiểm tra khớp Username (hoặc Email) và Password đã băm
                var user = db.Users.FirstOrDefault(u =>
                    (u.TenUser == UsernameOrEmail || u.Email == UsernameOrEmail)
                    && u.Password == hashedPassword);

                if (user == null)
                {
                    ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu!";
                    return;
                }

                // 1. Lưu vào UserSession dùng chung cho toàn app
                UserSession.CurrentUser = user;

                // 2. Mở MainWindow và đóng LoginWindow
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // Tìm và đóng cửa sổ Login hiện tại
                Application.Current.Windows.OfType<Window>()
                    .FirstOrDefault(w => w is Views.LoginWindow)?.Close();
            }
        }
    }
}