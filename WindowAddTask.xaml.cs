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
    /// Логика взаимодействия для WindowAddTask.xaml
    /// </summary>
    public partial class WindowAddTask : Window
    {
        private MainWindow _owner;
        public WindowAddTask(MainWindow owner)
        {
            InitializeComponent();
            _owner = owner;
        }

        private void ButtonForAdding_Click(object sender, RoutedEventArgs e)
        {
            var tasks = _owner.tasks;
            var ToDoGrid = _owner.ToDoGrid;
            DateTime date = DateTime.Today;
            try {
                date = (DateTime)DatePickerGui.SelectedDate;
            }
            catch { }
            try
            {
                tasks.Add(new TaskClass(NameTextBoxGui.Text, date, DescriptionGui.Text)); 
            }
            catch { Console.WriteLine("Задача не была добавлена, Непредвиденная ошибка"); }
            finally { ToDoGrid.Items.Refresh(); this.Close(); }
           

        }
    }
}
