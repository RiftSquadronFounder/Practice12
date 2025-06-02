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

namespace Practice12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TaskClass> tasks = new List<TaskClass>();
        public MainWindow()
        {
            InitializeComponent();
            
            tasks.Add(new TaskClass("Задача", DateTime.Today, "Description", EndToDo));

            ListItems.ItemsSource = tasks;
            EndToDo();
        }
        

        private void ButtonForAdding_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new WindowAddTask(this);
            newWindow.Show();
            EndToDo();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            tasks.RemoveAt(ListItems.SelectedIndex);
            ListItems.Items.Refresh();
            EndToDo();
        }

        
        public void EndToDo() {
            int HowManyIsChecked = 0;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].IsFinished == true)
                {
                    HowManyIsChecked += 1;
                }
            }
            ProgressTextOnTasks.Text = $"{HowManyIsChecked}/{tasks.Count}";
            ProgressBarOnTasks.Maximum = tasks.Count;
            ProgressBarOnTasks.Value = HowManyIsChecked;
        }

        private void ToDoGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            EndToDo();
        }
    }
}