namespace cakeS1
{
    internal class MenuItem
    {
        private readonly string text;
        private readonly Dictionary<string, SubItem> subItems;

        public MenuItem(string text, Dictionary<string, SubItem> subItems)
        {
            this.text = text;
            this.subItems = subItems;
        }

        public string Text => text;

        internal Dictionary<string, SubItem> SubItems => subItems;
    }
}
