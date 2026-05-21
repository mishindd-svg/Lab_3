using System.Collections.Generic;

namespace Lab_5
{
    public class Folder : FileSystemItem
    {
        private List<FileSystemItem> items = new List<FileSystemItem>();

        public Folder(string name) : base(name) { }

        public override long GetSize()
        {
            long total = 0;

            foreach (var item in items)
            {
                total += item.GetSize();
            }

            return total;
        }

        public override void Add(FileSystemItem item)
        {
            items.Add(item);
        }

        public override void Remove(FileSystemItem item)
        {
            items.Remove(item);
        }

        public override FileSystemItem GetChild(int index)
        {
            return items[index];
        }

        public List<FileSystemItem> GetItems()
        {
            return items;
        }
    }
}