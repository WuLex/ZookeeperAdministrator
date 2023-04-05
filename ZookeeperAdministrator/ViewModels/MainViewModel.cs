using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

            public MainViewModel()
            {
                RuokCommand = new RelayCommand(() => ExecuteCommand("ruok"));
                SrvrCommand = new RelayCommand(() => ExecuteCommand("srvr"));
                ConfCommand = new RelayCommand(() => ExecuteCommand("conf"));
                StatCommand = new RelayCommand(() => ExecuteCommand("stat"));
                MntrCommand = new RelayCommand(() => ExecuteCommand("mntr"));
            }

           private void ExecuteCommand(string cmd)
            {
                // TODO: 连接到ZooKeeper服务器并执行命令，将输出存储在Output属性中

                // 以下是模拟输出
                Output = $"Command \"{cmd}\" executed.";
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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