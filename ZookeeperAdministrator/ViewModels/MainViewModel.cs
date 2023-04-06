using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ZookeeperAdministrator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _output;

        public string Output
        {
            get { return _output; }
            set { _output = value; OnPropertyChanged(); }
        }

        public ICommand RuokCommand { get; private set; }
        public ICommand SrvrCommand { get; private set; }
        public ICommand ConfCommand { get; private set; }
        public ICommand StatCommand { get; private set; }
        public ICommand MntrCommand { get; private set; }
        public ICommand WchsCommand { get; private set; }
        public ICommand DumpCommand { get; private set; }

        // 定义 ShowOtherWindowCommand 命令属性
        public ICommand ShowOtherWindowCommand => new RelayCommand(ShowOtherWindow);
        public MainViewModel()
        {
            RuokCommand = new RelayCommand(() => ExecuteCommand("ruok"));
            SrvrCommand = new RelayCommand(() => ExecuteCommand("srvr"));
            ConfCommand = new RelayCommand(() => ExecuteCommand("conf"));
            StatCommand = new RelayCommand(() => ExecuteCommand("stat"));
            MntrCommand = new RelayCommand(() => ExecuteCommand("mntr"));
            WchsCommand = new RelayCommand(() => ExecuteCommand("wchs"));
            DumpCommand = new RelayCommand(() => ExecuteCommand("dump"));
        }

        private void ExecuteCommand(string cmd)
        {
            //连接到ZooKeeper服务器并执行命令，将输出存储在Output属性中
             
            var processStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nctool\\"),
                FileName = "cmd.exe",
                Arguments = $"/c echo {cmd} | nc 127.0.0.1 2181 \r\n",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardInputEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
            };

            var process = new Process
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };

            //process.OutputDataReceived += (sender, args) =>
            //{
            //    if (!string.IsNullOrEmpty(args.Data))
            //    {
            //        Output = args.Data;
            //    }
            //};

            try
            {
                process.Start();
                Output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Output=ex.Message;
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 打开另一个窗体的方法
        private void ShowOtherWindow()
        {
            // 创建另一个窗体对象
            ZkMainWindow otherWindow = new ZkMainWindow();

            // 显示另一个窗体
            otherWindow.Show();
        }
    }

    /// <summary>
    /// `RelayCommand`是一种常见的`ICommand`实现，它包含一个可以执行的委托和一个可选的`CanExecute`委托。
    /// `CanExecute`委托用于检查命令是否可以执行。在我们的例子中，我们不需要`CanExecute`，所以我们将它设为null。
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}