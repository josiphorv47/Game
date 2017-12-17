using GameLib.Systems.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace GameWinForms
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        public GameForm()
        {
            InitializeComponent();

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
                pnlMenu.Controls.Clear();

                foreach(var item in e.Menu.Items)
                {
                    var btn = new System.Windows.Forms.Button()
                    {
                        Text = item.Name,
                        Width = this.Width - 20
                    };

                    btn.Click += (objSender, args) => item.Action();

                    pnlMenu.Controls.Add(btn);
                }
            };

            //Print Main Menu to start
            menu.PrintMenu("Main Menu");
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
