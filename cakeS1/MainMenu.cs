using cakeS1;
using System.Net;

internal class Menu
{
    private int selectedIndex = 0;
    private string[] menuItems;

    public Menu(string[] menuItems)
    {
        this.menuItems = menuItems;
    }

    public void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine();
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.Write("->");
            }
            Console.WriteLine("\t" + menuItems[i]);
        }
    }

    public (string, bool) MainLoop(Order order)
    {
        while (true)
        {
            PrintMenu();
            if (order != null)
            {
                Console.WriteLine("Цена: " + order.GetPrice());
                Console.WriteLine("Ваш торт: " + order.GetDescription());

            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.DownArrow)
            {
                Down();
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                Up();
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return (null, true);
            }
            if (key.Key == ConsoleKey.Enter)
            {
                return (menuItems[selectedIndex], false);
            }
        }
    }



    private void Down()
    {
        selectedIndex = (selectedIndex + 1) % menuItems.Length;
    }
    private void Up()
    {
        if (selectedIndex == 0)
        {
            selectedIndex = menuItems.Length;
        }
        selectedIndex--;
    }

}