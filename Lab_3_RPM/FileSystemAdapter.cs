using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5
{
    public class FileSystemAdapter : IFileSystem
    {
        private Folder root;

        public FileSystemAdapter(Folder root)
        {
            this.root = root;
        }

        public List<string> ListItems(string path)
        {
            List<string> result = new List<string>();

            foreach (var item in root.GetItems())
            {
                result.Add(item.Name);
            }

            return result;
        }

        public byte[] ReadFile(string path)
        {
            foreach (var item in root.GetItems())
            {
                if (item.Name == path && item is FileItem)
                {
                    return Encoding.UTF8.GetBytes("file data");
                }
            }

            throw new Exception("Файл не найден");
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine("Запись в файл: " + path);
        }

        public void DeleteItem(string path)
        {
            FileSystemItem found = null;

            foreach (var item in root.GetItems())
            {
                if (item.Name == path)
                {
                    found = item;
                    break;
                }
            }

            if (found != null)
            {
                root.Remove(found);
            }
        }
    }
}