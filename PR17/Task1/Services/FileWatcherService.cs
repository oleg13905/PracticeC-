using System;
using System.IO;
using System.Windows;

namespace CrmDemo.Services
{
    public class FileWatcherService : IDisposable
    {
        private FileSystemWatcher _watcher;
        private readonly string _watchPath;
        private readonly Action<string, WatcherChangeTypes> _onChanged;

        public FileWatcherService(string path, Action<string, WatcherChangeTypes> onChanged)
        {
            _watchPath = path;
            _onChanged = onChanged;
            StartWatching();
        }

        private void StartWatching()
        {
            string directory = Path.GetDirectoryName(_watchPath);
            string fileName = Path.GetFileName(_watchPath);

            if (string.IsNullOrEmpty(directory))
                return;

            _watcher = new FileSystemWatcher(directory, fileName);
            _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.CreationTime;
            _watcher.EnableRaisingEvents = true;

            _watcher.Changed += OnFileChanged;
            _watcher.Created += OnFileChanged;
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _onChanged?.Invoke(e.FullPath, e.ChangeType);
            });
        }

        public void Dispose()
        {
            _watcher?.Dispose();
        }
    }
}