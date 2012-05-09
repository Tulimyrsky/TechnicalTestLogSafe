using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private List<string> _task;
        private ObservableCollection<string> _todo;
        private ObservableCollection<string> _done;
        private int m_index;
        private string _text;
        private int _id = 0;

        #endregion

        #region Properties

        public ActionCommand TaskIsDone { get; private set; }
        public ActionCommand NewTask    { get; private set; }
        public ActionCommand TaskIsToDo { get; private set; }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string TaskText
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("TextTask");
                }
            }
        }

        public List<string> Task
        {
            get {return _task;}
            set
            {
                if (_task != value)
                {
                    _task = value;
                    OnPropertyChanged("Task");
                }
            }
        }

        public ObservableCollection<string> Done
        {
            get { return _done; }
            set
            {
                if (_done != value)
                {
                    _done = value;
                    OnPropertyChanged("Done");
                }
            }
        }

        public ObservableCollection<string> ToDo
        {
            get { return _todo; }
            set
            {
                if (_todo != value)
                {
                    _todo = value;
                    OnPropertyChanged("ToDo");
                }
            }
        }

        public int Index
        {
            get { return m_index; }
            set
            {
                if (m_index != value)
                {
                    m_index = value;
                    OnPropertyChanged("Index");
                }
            }
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region CTOR

        
        public ViewModel()
        {
            TaskIsDone = new ActionCommand()
            {
                Action = () =>
                {
                    if (Index > -1 && Index < ToDo.Count && !Done.Contains<String>(ToDo.ElementAt(Index)))
                    {
                        Done.Add(ToDo.ElementAt(Index));
                        ToDo.RemoveAt(Index);
                    }
                }
            };

            NewTask = new ActionCommand()
            {
                Action = () =>
                {
                    if (TaskText != "" && TaskText != null && !ToDo.Contains<String>(TaskText))
                    {
                        Task t = new Task(Id, TaskText);
                        ToDo.Add(t.Content);
                        Id += 1;
                    }
                }
            };

            TaskIsToDo = new ActionCommand()
            {
                Action = () =>
                {
                    if (Index > -1 && Index < Done.Count && !ToDo.Contains<String>(Done.ElementAt(Index)))
                    {
                        ToDo.Add(Done.ElementAt(Index));
                        Done.RemoveAt(Index);
                    }
                }
            };


            _task = new List<string>();
            _done = new ObservableCollection<string>();
            _todo = new ObservableCollection<string>();

            Initialze();
        }

        #endregion

        #region Method


        public void Initialze()
        {
            TaskMgr.Initialize();

            Task = (from el in TaskMgr.Tasks select el.Content).ToList();

            for (int i = 0; i < Task.Count; ++i)
            {
                ToDo.Add(Task.ElementAt(i));
                Id += 1;
            }
        }


        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion


    }
}
