using System;

namespace Lab_5
{
    class Program
    {
        static void Main()
        {
            Folder root = new Folder("root");

            FileItem file1 = new FileItem("file1.txt", 100);
            FileItem file2 = new FileItem("file2.txt", 200);

            Folder folder1 = new Folder("docs");
            folder1.Add(new FileItem("doc1.txt", 300));

            root.Add(file1);
            root.Add(file2);
            root.Add(folder1);

            Console.WriteLine("Размер корневой папки: " + root.GetSize());

            IFileSystem localFS = new FileSystemAdapter(root);
            IFileSystem cloudFS = new FileSystemAdapter(new Folder("cloud"));

            SyncFacade facade = new SyncFacade(localFS, cloudFS);
            facade.SyncFolder("/", "/");
            facade.Backup("/", "/backup");
        }
    }
}