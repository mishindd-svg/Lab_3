using System;

namespace Lab_5
{
    public class SyncFacade
    {
        private IFileSystem sourceFS;
        private IFileSystem targetFS;

        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            sourceFS = source;
            targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            var items = sourceFS.ListItems(sourcePath);

            foreach (var item in items)
            {
                var data = sourceFS.ReadFile(item);
                targetFS.WriteFile(item, data);
            }

            Console.WriteLine("Синхронизация завершена.");
        }

        public void Backup(string sourcePath, string backupPath)
        {
            SyncFolder(sourcePath, backupPath);
            Console.WriteLine("Резервное копирование завершено.");
        }
    }
}