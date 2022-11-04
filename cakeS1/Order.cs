using cakeS1;
using System.Xml.Linq;

internal class Order
{
    private Dictionary<string, SubItem> choices = new Dictionary<string, SubItem>();
    private readonly Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>
    {

        {"Форма",
        new MenuItem("Форма", new Dictionary<string, SubItem>
        {
            {"Круг" , new SubItem("Круг", 500) },
            {"Квадрат",new SubItem("Квадрат", 500)      },
            {"Прямоугольник",new SubItem("Прямоугольник", 500)  },
            {"Сердечко",new SubItem("Сердечко", 700) },
        }) } ,

        {"Вкус коржей",
        new MenuItem("Вкус коржей", new Dictionary<string, SubItem>
        {
            {"Ванильный", new SubItem("Ванильный", 100)  } ,
            {"Шоколадный", new SubItem("Шоколадный", 100) } ,
            {"Карамельный", new SubItem("Карамельный", 150)} ,
            {"Ягодный", new SubItem("Ягодный", 200)    } ,
            {"Кокосовый", new SubItem("Кокосовый", 250) } ,
        }) },

        {"Количество коржей",
        new MenuItem("Количество коржей", new Dictionary<string, SubItem>
        {
            {"Один-корж", new SubItem("Один-корж", 100)  } ,
            {"Два-коржа", new SubItem("Два-коржа", 200) } ,
            {"Три-коржа", new SubItem("Три-коржа", 300)} ,
            {"Четыре-коржа", new SubItem("Четыре-коржа", 400)    } ,
            {"Пять-коржей", new SubItem("Пять-коржей", 500) } ,
        }) },

        {"Размер торта",
        new MenuItem("Размер торта", new Dictionary<string, SubItem>
        {
        {"Маленький", new SubItem("Маленький", 1000) },
        {"Средний", new SubItem("Средний", 1200) },
        {"Большой", new SubItem("Большой", 2000) },

        }) },

         {"Глазурь",
        new MenuItem("Глазурь", new Dictionary<string, SubItem>
        {
        {"Шоколадная", new SubItem("Шоколадная", 100) },
        {"Малиновая", new SubItem("Малиновая", 100) },
        {"Банановая", new SubItem("Банановая", 100) },

        }) },

          {"Декор",
        new MenuItem("Декор", new Dictionary<string, SubItem>
        {
        {"Шоколадная", new SubItem("Шоколадная", 100) },
        {"Ягодная", new SubItem("Ягодная", 100) },
        {"Кремовая", new SubItem("Кремовая", 100) },

        }) },

        {"конец заказа",
        new MenuItem("конец заказа", new Dictionary<string, SubItem>()) },
    };

    public void GetOrder()
    {
        var menu = new Menu(menuItems.Select(m => m.Key).ToArray());
        while (true)
        {
            var (item, exit) = menu.MainLoop(this);
            if (exit)
            {

                return;
            }
            if (item == "конец заказа")
            {
                Save();
                return;
            }
            ChooseMenuItem(menuItems[item]);

        }
    }

    private void Save()
    {
        using (var saver = new StreamWriter("orders.txt", new FileStreamOptions { Mode = FileMode.Append, Access = FileAccess.Write }))
        {
            saver.WriteLine("заказ от " + DateTime.Now);
            saver.Write("\t\t");
            saver.WriteLine(String.Join("; ", choices.Values.Select(x => x.Text + " - " + x.Price)));
            saver.WriteLine("price: " + GetPrice());
        }
    }


    private void ChooseMenuItem(MenuItem menuItem)
    {
        var menu = new Menu(menuItem.SubItems.Select(kv => kv.Key + " " + kv.Value.Price).ToArray());
        while (true)
        {
            var (item, exit) = menu.MainLoop(null);
            if (exit)
            {
                return;
            }
            var key = item.Split()[0];
            ChooseMenuSubItem(menuItem.Text, menuItem.SubItems[key]);
            return;
        }
    }


    private void ChooseMenuSubItem(string item, SubItem subItem)
    {
        choices[item] = subItem;
    }

    internal string GetDescription()
    {
        return string.Join("; ", choices.Select(c => c.Value.Text + " " + c.Value.Price));
        //var r = new List<string>();
        //foreach (var c in choices)
        //{
        //    r.Add(c.Value.Text + " " + c.Value.Price);
        //}
        //return string.Join("; ", r);
    }

    internal int GetPrice()
    {
        return choices.Sum(c => c.Value.Price);
    }
}