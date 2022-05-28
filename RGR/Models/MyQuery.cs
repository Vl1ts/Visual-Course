using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.ComponentModel;

namespace RGR.Models
{
    public class MyQuery: DataTable, IReactiveObject
    {

        private string queryString;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        public string QueryString
        {
            get => queryString;
            private set => queryString=value;
        }

        private void GenerateQuery()
        {
            string result = "SELECT ";

            for (int j = 0; j < Items.Count; j++)
            {
                var sel = Items[j].getSelected();
                for (int i = 0; i < sel.Count; i++)
                {
                    result += Items[j].TableName + "." + sel[i] + ", ";
                }
            }

            result = result.Substring(0, result.Length - 2);

            result += " FROM " + Items[0].getString();

            for (int i = 1; i < Items.Count; i++)
            {
                var first_table = Joins[i - 1].firstTable.TableName + "." + Joins[i - 1].firstColumn;
                var second_table = Joins[i - 1].secondTable.TableName + "." + Joins[i - 1].secondColumn;
                var table_name = Items[i].TableName;

                if (Joins[i - 1].secondTable as MyQuery != null)
                {
                    (Joins[i - 1].secondTable as MyQuery).GenerateQuery();

                    table_name = "(" + (Joins[i - 1].secondTable as MyQuery).QueryString + ") as " + table_name;
                }
                result += " JOIN " + table_name + " ON " + first_table + "=" + second_table;
            }

            if (WhereItems.Count > 0)
            {
                result += " WHERE ";
            }

            for (int i = 0; i < WhereItems.Count; i++)
            {
                var items = WhereItems[i];
                for (int j = 0; j < items.Count; j++)
                {
                    result += items[j].fromTable + items[j].OperatorW + items[j].ValueW;
                    if (j != items.Count - 1)
                    {
                        result += " OR ";
                    }
                }

                if (i != WhereItems.Count - 1)
                {
                    result += " AND ";
                }
            }

            foreach (var str in GroupItems)
            {
                result += " GROUP BY " + str;
            }

            result += ";";

            queryString = result;
        }
        public void Run()
        {
            GenerateQuery();
            Clear();
            Columns.Clear();

            DBContext.getInstance().GetQuery(QueryString, this);
        }

        
        public string QueryName
        {
            get => TableName;
            set
            {
                if(TableName != value)
                {
                    TableName = value;
                    this.RaisePropertyChanged(new PropertyChangedEventArgs("QueryName"));
                } else
                {
                    TableName = value;
                }
            }
        }
        
        public List<List<WhereItem>> WhereItems
        {
            get;
            set;
        }

        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        public List<string> GroupItems
        {
            get;
            set;
        }
        public List<JoinResult> Joins
        {
            get;
            set;
        }

        public ObservableCollection<MyQueryItem> Items
        {
            get;
            set;
        }
        public MyQuery(string name) :base()
        {
            TableName = name;

            Items = new ObservableCollection<MyQueryItem>();
            Joins = new List<JoinResult>();
            
            GroupItems = new List<string>();
            WhereItems = new List<List<WhereItem>>();
        }
    }
}
