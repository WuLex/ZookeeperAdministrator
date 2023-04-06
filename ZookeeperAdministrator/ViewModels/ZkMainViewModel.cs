using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ZookeeperAdministrator.ViewModels
{
    public class ZkMainViewModel : ObservableObject
    {
        private string _hostname = "localhost";
        private int _port = 2181;
        private string _output = string.Empty;
        private bool _isRunning = false;

        public string Hostname
        {
            get => _hostname;
            set => SetProperty(ref _hostname, value);
        }

        public int Port
        {
            get => _port;
            set => SetProperty(ref _port, value);
        }

        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public AsyncRelayCommand<string> ExecuteCommand { get; }

        public ZkMainViewModel()
        {
            ExecuteCommand = new AsyncRelayCommand<string>(ExecuteCommandAsync);
        }

        private async Task ExecuteCommandAsync(string command)
        {
            if (IsRunning)
            {
                return;
            }

            IsRunning = true;

            try
            {
                //var arguments = $"{command}\r\n";
                var processStartInfo = new ProcessStartInfo
                {
                    //FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nc111nt\\nc.exe"),
                    FileName = "cmd.exe",
                    WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nctool\\"),
                    Arguments = $"/c \"{command} {Hostname} {Port} \r\n\"",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardInputEncoding = Encoding.UTF8,  
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8,
                    //CreateNoWindow = true,
                };

                using var process = Process.Start(processStartInfo);
                //await process.StandardInput.WriteAsync(arguments);

                var outputBuilder = new StringBuilder();
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = await process.StandardOutput.ReadLineAsync();
                    outputBuilder.AppendLine(line);
                }

                var errorBuilder = new StringBuilder();
                while (!process.StandardError.EndOfStream)
                {
                    var line = await process.StandardError.ReadLineAsync();
                    errorBuilder.AppendLine(line);
                }

                Output = $"{outputBuilder}{errorBuilder}";
            }
            catch (IOException ex)
            {
                Output = ex.Message;
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}