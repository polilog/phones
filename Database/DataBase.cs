using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataBase<T>
    {
        private List<T> items;
        public List<T> Items
        {
            get { return items; }
        }

        public DataBase()
        {
            items = new List<T>();
        }

        public void Add(T obj)
        {
            items.Add(obj);
        }

        public void removeItem(T obj)
        {
            items.Remove(obj);
        }
    }
}
