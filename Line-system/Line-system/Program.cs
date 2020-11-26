using System;
using System.IO;
using System.Net.Mail;
using Line_system.Controller;
using Line_system.UI;
using Line_system.Users;

namespace Line_system
{
    class Program
    {
        static void Main(string[] args)
        {
            ILineSystem lineSystem = new LineSystem();
            ILineSystemUI lineSystemUi = new LineSystemCLI();
            LineSystemController lineSystemController = new LineSystemController(lineSystem, lineSystemUi);
        }
    }
}