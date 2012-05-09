using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace Model
{
    public static class TaskMgr
    {
        #region Properties

        public static Collection<Task> Tasks    { get; private set; }
        public static Collection<Task> Done     { get; private set; }

        #endregion

        #region Methods

        public static void Initialize()
        {
            Tasks = new Collection<Task>();
            Done = new Collection<Task>();
            string videoFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            Tasks.Add(new Task(1, "Première tache"));
            Tasks.Add(new Task(2, "Première tadche"));
            Tasks.Add(new Task(2, "Première tacezrhe"));
            Tasks.Add(new Task(4, "Première tfache"));
        }

        #endregion
    }
}
