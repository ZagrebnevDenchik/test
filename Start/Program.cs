using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Путь
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string path1 = path + "\\Horoscope\\Forms";

            // Формируем команду PowerShell
            string command1 = $"gci -Recurse \"{path1}\" | Unblock-File";
            // Настраиваем процесс PowerShell
            ProcessStartInfo processInfo1 = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command1}\"",
                UseShellExecute = true, // Используем оболочку для запуска
                CreateNoWindow = false // Открываем окно PowerShell
            };
            // Запускаем процесс
            Process.Start(processInfo1);
        }
    }
}
