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
    public partial class KanbanView : UserControl
    {
        public KanbanView()
        {
            InitializeComponent();
        }

        // Bổ sung hàm xử lý khi bấm nút "+ Thêm công việc"
        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            var taskDetail = new TaskDetailWindow();
            taskDetail.ShowDialog();
        }
    }
}
