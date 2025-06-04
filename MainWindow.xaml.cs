using Microsoft.Win32;
using System.Globalization;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace Practice12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TaskClass> tasks = new List<TaskClass>();
        int Checked = 0;
        public MainWindow()
        {
            InitializeComponent();

            tasks = Loaded($"{Directory.GetCurrentDirectory()}\\Files\\Saves.json");

            ListItems.ItemsSource = tasks;
            EndToDo();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Safe(tasks, $"{Directory.GetCurrentDirectory()}\\Files");
        }


        private void ButtonForAdding_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new WindowAddTask(this);
            newWindow.Show();
            EndToDo();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show( "Вы действительно хотите удалить это дело?", "КОГО ТЫ БЛИН ВЫБЕРЕШЬ?!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                var todo = (sender as Button)?.DataContext as TaskClass;
                tasks.Remove(todo);
                ListItems.Items.Refresh();
                EndToDo();
            }
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



            //for (int i = 0; i < ListItems.Items.Count; i++) {} Как сделать биндинг???
        }

        private void ToDoGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            EndToDo();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //var todo = (sender as CheckBox)?.DataContext as TaskClass;
            //todo.IsFinished = false;
            EndToDo();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //var todo = (sender as CheckBox)?.DataContext as TaskClass;
            //todo.IsFinished = true;
            EndToDo();
        }

        private void SaveButtonGui_Click(object sender, RoutedEventArgs e)
        {
            if (tasks.Count == 0) { 
                MessageBox.Show("Список пуст", "Ты что сохранять собрался?", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                SaveTxtFile();
            }
        }
        public void SaveTxtFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый файл(*.txt)| *.txt";
            saveFileDialog.DefaultDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.FileName = "Список дел.txt";
            if (saveFileDialog.ShowDialog() == true) {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < tasks.Count; i++) {
                    if (tasks[i].IsFinished)
                    {
                        stringBuilder.AppendLine($"✓{tasks[i].Name}");
                    }
                    else { stringBuilder.AppendLine($" {tasks[i].Name}"); }

                    stringBuilder.AppendLine($"\n{tasks[i].Description}");
                    stringBuilder.AppendLine($"\n{tasks[i].Date.ToShortDateString()}\n\n");
                }
                File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());
            }
        }
        public static void Safe(List<TaskClass> tasks, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (!File.Exists($"{filePath}\\Saves.json"))
            {
                File.Create($"{filePath}\\Saves.json");
            }
            try
            {
                if (tasks.Count > 0)
                {
                     

                    string json = JsonSerializer.Serialize(tasks);
                    File.WriteAllText($"{filePath}\\Saves.json", json);
                }
                else
                {
                    File.WriteAllText($"{filePath}\\Saves.json", "");
                }
            }
            catch (Exception ex) {}
        }
        public static List<TaskClass> Loaded(string filePath)
        {
            
            if (!File.Exists($"{filePath}"))
            {
                MessageBox.Show("Похоже на то, что вы открываете список дел впервые, добро пожаловать!", "Вау", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<TaskClass>>(json);
                }
                catch (Exception ex) {
                    MessageBox.Show("Ваш файл с задачами абсолютно чист!\nКак же я вам завидую...", "Вот это да", MessageBoxButton.OK, MessageBoxImage.None);
                }
            }
            return new List<TaskClass>();
        }

    }
}