namespace MiniERP.Classes
{
    class ListBoxItem
    {
        public string windowName { get; }
        public System.Windows.Forms.Form bindWindow { get; }

        public int windowCount { get; }

        public ListBoxItem(string windowName, System.Windows.Forms.Form bindWindow, int windowCount)
        {
            this.windowName = windowName;
            this.bindWindow = bindWindow;
            this.windowCount = windowCount;
        }
    }
}
