using System;
using System.IO;
using Line_system.CLI;
using Line_system.UI;
using Line_system.Users;

namespace Line_system
{
    class Program
    {
        static void Main(string[] args)
        {
            ILineSystem lineSystem = new LineSystem();
            ILineSystemUI lineSystemUi = new LineSystemUI();
            LineSystemCLI lineSystemCli = new LineSystemCLI(lineSystem, lineSystemUi);
            
        }
    }
}