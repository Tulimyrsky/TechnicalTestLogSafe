using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Model
{
    public class Task
    {
        #region Properties

        public int Id
        {
            get;
            private set;
        }

        public string Content
        {
            get;
            private set;
        }

        #endregion

        #region CTOR

        public Task(int id, string content)
        {
            Id = id;
            Content = content;
        }

        #endregion
    }
}
