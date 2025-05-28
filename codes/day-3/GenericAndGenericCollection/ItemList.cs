using System.Collections;

namespace GenericAndGenericCollection
{
    //Type parameter -> TIem
    internal class ItemList<TItem> : IEnumerable<TItem> where TItem : class, new()
    {
        TItem[] items;
        int index = 0;

        public ItemList() => items = new TItem[4];

        public int Capacity => items.Length;
        public int Count => index;

        public void Add(TItem item)
        {
            if (index == items.Length)
            {
                TItem[] tem = new TItem[items.Length * 2];
                items.CopyTo(tem, 0);
                items = tem;
            }
            items[index] = item;
            index++;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TItem this[int i]
        {
            set => items[i] = value;
            get => items[i];
        }
    }
}
