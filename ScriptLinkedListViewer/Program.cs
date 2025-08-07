using System;
using System.Windows.Forms;

namespace ScriptLinkedListViewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // For .NET 6–8
            Application.Run(new Form1());
        }
    }
}
