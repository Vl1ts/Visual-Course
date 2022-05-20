using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace Course.Models
{
    public class Request : ReactiveObject
    {
        string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref title, value);
            }
        }

        public Request(string new_title = "Request")
        {
            if(new_title.Length > 8)
            {
                new_title = new_title.Substring(0, 8);
            }

            Title = new_title;
        }
    }
}
