using System.Linq;
using UnrealSharp;
namespace Dumper
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameName = "FSD-Win64-Shipping";
            var process = System.Diagnostics.Process.GetProcesses().FirstOrDefault(p => p.ProcessName.Contains(gameName) && p.MainWindowHandle != System.IntPtr.Zero);
            new UnrealEngine(new Memory(process)).UpdateAddresses();
            //UnrealEngine.Instance.DumpSdk();
            UnrealEngine.Instance.DumpSdk(@"");
        }
    }
}
