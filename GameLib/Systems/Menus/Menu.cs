using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Systems.Menus
{
    public class Menu
    {
        private ISet<MenuItem> items = new HashSet<MenuItem>();

        #region Properties

        public Menu Parent { get; set; }
        public string Name { get; } //UNIQUE

        public ISet<MenuItem> Items => new HashSet<MenuItem>(items);

        #endregion

        #region Constructors

        public Menu(string name, Menu parent = null)
        {
            Name = name;

            Parent = parent;
        }

        public Menu(string name, IEnumerable<MenuItem> menuItems, Menu parent = null)
            : this(name, parent)
        {
            items = new HashSet<MenuItem>(menuItems);
        }

        public Menu(string name, Menu parent = null, params MenuItem[] menuItems)
            : this(name, parent)
        {
            items = new HashSet<MenuItem>(menuItems);
        }

        #endregion

        #region Methods

        public bool AddMenuItem(MenuItem menuItem) => items.Add(menuItem);
        public bool RemoveMenuItem(MenuItem menuItem) => items.Remove(menuItem);

        #region Object Overrides

        public override bool Equals(object obj) => obj is Menu menu && menu.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();

        #endregion

        #endregion
    }
}
