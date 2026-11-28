using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanlyCongviecNhom.Views
{
    public partial class TaskDetailWindow : Window
    {
        public TaskDetailWindow()
        {
            InitializeComponent();
        }

        // Bổ sung hàm cho phép giữ chuột kéo cửa sổ di chuyển
        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        // Bổ sung hàm khi bấm nút Hủy hoặc nút X đóng cửa sổ
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Bổ sung hàm khi bấm nút Lưu công việc
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Tạm thời đóng popup (sau này bạn C sẽ gắn logic lưu DB vào đây)
            this.Close();
        }
    }
}
