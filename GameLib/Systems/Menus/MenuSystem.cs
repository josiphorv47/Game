using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Systems.Menus
{
    public delegate void PrintEventHandler(object sender, MenuEventArgs e);

    public class MenuSystem
    {
        private ISet<Menu> menus = new HashSet<Menu>();
        
        public ISet<Menu> Menus => new HashSet<Menu>(menus);

        public event PrintEventHandler Print;

        #region Methods

        public bool AddMenu(Menu menu) => menus.Add(menu);
        public bool RemoveMenu(Menu menu) => menus.Remove(menu);

        public void PrintMenu(string menuName)
        {
            if (menus.Count == 0) return;

            Menu requestedMenu = menus.FirstOrDefault(menu => menu.Name == menuName);

            if(requestedMenu != null)
            {
                Print(this, new MenuEventArgs(requestedMenu));
            }
        }

        #endregion
    }
}
