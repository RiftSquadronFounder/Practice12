using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice12
{
    public class TaskClass : INotifyPropertyChanged
    {
        private string taskName_ = "-";
        private DateTime taskDate_ = DateTime.Today;
        private string taskDescription_ = "-";
        private bool isFinished = false;

        public event PropertyChangedEventHandler? PropertyChanged;


        public TaskClass()
        {
            this.taskName_ = "Задача";
            this.taskDate_ = DateTime.Today;
            this.taskDescription_ = "Нет описания";
            this.isFinished = false;
        }

        public TaskClass(string name, DateTime date, string description)
        {

            if (name != null && name.Trim() != "")
            {
                this.taskName_ = name;
            }
            else { this.taskName_ = "Задача"; }
            try
            {
                this.taskDate_ = date;
            }
            catch
            {
                this.taskDate_ = DateTime.Today;
            }
            if (description != null && description.Trim() != "")
            {
                this.taskDescription_ = description;
            }
            else { this.taskDescription_ = "Нет описания"; }
            this.isFinished = false;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name { get { return this.taskName_; } set { this.taskName_ = value; OnPropertyChanged(nameof(Name)); } }
        public DateTime Date { get { return this.taskDate_; } set { this.taskDate_ = value; OnPropertyChanged(nameof(Name)); } }
        public string Description { get { return this.taskDescription_; } set { this.taskDescription_ = value; OnPropertyChanged(nameof(Name)); } }
        public bool IsFinished { get { return this.isFinished; } set { this.isFinished = value; OnPropertyChanged(nameof(Name)); } }

    }
}
