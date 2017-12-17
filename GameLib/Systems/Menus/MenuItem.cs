using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Systems.Menus
{
    public class MenuItem
    {
        public string Name { get; }
        public Action Action { get; }

        public MenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }

        public override string ToString() => Name;
        public override bool Equals(object obj) => obj is MenuItem item && item.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
    }
}
