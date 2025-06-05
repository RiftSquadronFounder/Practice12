using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice12
{
    public class TaskClass
    {
        private string taskName_ = "-";
        private DateTime taskDate_ = DateTime.Today;
        private string taskDescription_ = "-";
        private bool isFinished = false;
        public TaskClass()
        {
            this.taskName_ = "Задача";
            this.taskDate_ = DateTime.Today;
            this.taskDescription_ = "Нет описания";
            this.isFinished = false;
        }

        public TaskClass(string name, DateTime date, string description)
        {
            int a=9;

            int b = 10;

            a = b = 15;


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


        public string Name { get { return this.taskName_; } set { this.taskName_ = value; } }
        public DateTime Date { get { return this.taskDate_; } set { this.taskDate_ = value; } }
        public string Description { get { return this.taskDescription_; } set { this.taskDescription_ = value; } }
        public bool IsFinished { get { return this.isFinished; } set { this.isFinished = value; } }

    }
}
