using System;
using System.IO;

namespace Task4
{
    public class FileWatcher
    {
        private FileSystemWatcher watcher;
        private readonly string watchPath;
        private readonly string backupPath;

        public FileWatcher(string watchPath = ".", string backupPath = "backup")
        {
            this.watchPath = watchPath;
            this.backupPath = backupPath;

            Directory.CreateDirectory(backupPath);

            watcher = new FileSystemWatcher(watchPath);
            watcher.Changed += OnFileChanged;
            watcher.Created += OnFileCreated;
            watcher.Deleted += OnFileDeleted;
            watcher.Renamed += OnFileRenamed;

            watcher.EnableRaisingEvents = true;
            Console.WriteLine($"Отслеживание: {watchPath}");
            Console.WriteLine($"Резервные копии: {backupPath}");
            Console.WriteLine("Нажмите Ctrl+C для остановки...\n");
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"ИЗМЕНЕН: {e.Name}");
            CreateBackup(e.FullPath, e.Name);
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"СОЗДАН: {e.Name}");
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"УДАЛЕН: {e.Name}");
        }

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"ПЕРЕИМЕНОВАН: {e.OldName} → {e.Name}");
        }

        private void CreateBackup(string sourcePath, string originalName)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupName = $"{Path.GetFileNameWithoutExtension(originalName)}_{timestamp}.bak";
                string backupPathFull = Path.Combine(this.backupPath, backupName);

                File.Copy(sourcePath, backupPathFull, true);
                Console.WriteLine($"СОЗДАНА КОПИЯ: {backupName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка бэкапа: {ex.Message}");
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            Console.WriteLine("\nОтслеживание остановлено");
        }
    }

    class Program
    {
        static void Main()
        {
            FileWatcher watcher = new FileWatcher();

            Console.WriteLine("Тестируйте:");
            Console.WriteLine("1. Создайте test.txt");
            Console.WriteLine("2. Измените test.txt");
            Console.WriteLine("3. Переименуйте test.txt");
            Console.WriteLine("4. Удалите test.txt");
            Console.WriteLine("\nРезервные копии будут в папке 'backup/'");

            Console.ReadLine();
            watcher.Stop();
        }
    }
}