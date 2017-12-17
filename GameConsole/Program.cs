using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Systems.Menus;
using GameConsole.Helpers;
using System.Diagnostics;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            MenuSystem menu = new MenuSystem();

            //Main Menu
            Menu main = new Menu("Main Menu", null,
                new MenuItem("Play Game", () => Console.WriteLine("Play")),
                new MenuItem("Load Game", () => menu.PrintMenu("Load Menu")),
                new MenuItem("Options", () => menu.PrintMenu("Options Menu")),
                new MenuItem("Quit", () => Environment.Exit(0))
            );

            //Load Menu
            Menu load = new Menu("Load Menu", main,
                new MenuItem("Slot 1", () => Console.WriteLine("Slot 1")),
                new MenuItem("Slot 2", () => Console.WriteLine("Slot 2")),
                new MenuItem("Back to Main Menu", () => menu.PrintMenu("Main Menu"))
            );

            //Options Menu
            Menu options = new Menu("Options Menu", main,
                new MenuItem("Graphics", () => Console.WriteLine("Resolution: XxX")),
                new MenuItem("Key bindings", () => Console.WriteLine("Bindings")),
                new MenuItem("Back to Main Menu", () => menu.PrintMenu("Main Menu"))
            );

            //Add Menus to MenuSystem
            menu.AddMenu(main);
            menu.AddMenu(load);
            menu.AddMenu(options);

            //Subscribe to Event to allow the menus to be printed
            menu.Print += (object sender, MenuEventArgs e) => 
            {
                Console.Clear();

                int choice = Utils.ChooseOption(e.Menu.Items, true);

                e.Menu.Items.ElementAt(choice).Action();
            };

            //Print Main Menu to start
            menu.PrintMenu("Main Menu");
        }
    }
}
