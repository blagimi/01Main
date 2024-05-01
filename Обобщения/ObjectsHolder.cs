using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Обобщения
{
    internal class ObjectsHolder<T>
    {
        public List<T> MassiveItem { get; set; }
        public void AddItem(T[] array)
        {
            MassiveItem.AddRange(array);
        }
        public void DeleteItem(T item)
        {
            MassiveItem.Remove(item);
        }
        public T GetElement(int index)
        {
            return MassiveItem[index];
        }
        public int GetLength()
        {
            return MassiveItem.Count;
        }
        public ObjectsHolder()
        { }
        public ObjectsHolder(List<T> massiveItem)
        {
            MassiveItem = massiveItem;
        }
    }
}
