using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice12
{
    /// <summary>
    /// Логика взаимодействия для ChangeTaskWindow.xaml
    /// </summary>
    public partial class ChangeTaskWindow : Window
    {
        private MainWindow ownerWindow;
        private int taskIndex_;
        public ChangeTaskWindow(MainWindow owner, TaskClass task, int taskIndex)
        {
            ownerWindow = owner;
            
            InitializeComponent();
            taskIndex_ = taskIndex;
            NameTextBoxGui.Text = task.Name;
            DescriptionGui.Text = task.Description;
            DatePickerGui.SelectedDate = task.Date;
        }

        private void ButtonForAdding_Click(object sender, RoutedEventArgs e)
        {
            ownerWindow.RewriteTask(NameTextBoxGui.Text, (DateTime)DatePickerGui.SelectedDate, DescriptionGui.Text, taskIndex_);
            ownerWindow.ListItems.Items.Refresh();
            this.Close();
        }
    }
}
