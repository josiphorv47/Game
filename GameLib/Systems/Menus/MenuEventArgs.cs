namespace GameLib.Systems.Menus
{
    public class MenuEventArgs
    {
        public Menu Menu { get; }

        public MenuEventArgs(Menu requestedMenu)
        {
            Menu = requestedMenu;
        }
    }
}