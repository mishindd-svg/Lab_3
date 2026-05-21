using System;

namespace Lab_5
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract long GetSize();

        public virtual void Add(FileSystemItem item)
        {
            throw new InvalidOperationException();
        }

        public virtual void Remove(FileSystemItem item)
        {
            throw new InvalidOperationException();
        }

        public virtual FileSystemItem GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}