using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Course.Models
{
    public class TabElement : ReactiveObject
    {
        string header;
        public string Header
        {
            get 
            {
                return header; 
            }
            set
            {
                this.RaiseAndSetIfChanged(ref header, value);
            }
        }

        ObservableCollection<string> tabs;
        public ObservableCollection<string> Tabs
        {
            get
            {
                return tabs;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref tabs, value);
            }
        }
        
        public TabElement(string name = "", ObservableCollection<string> new_tabs = null)
        {
            this.header = name;
            this.Tabs = new_tabs;
        }
    }
}
