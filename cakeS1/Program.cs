using System.Text;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            var order = new Order();
            order.GetOrder();
            Console.WriteLine("Спасибо за заказ! Если хотите сделать ещё один, нажмите ESC");
            var key = Console.ReadKey();
            if (key.Key != ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}