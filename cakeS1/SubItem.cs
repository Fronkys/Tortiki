using System.Text;
using System.Threading.Tasks;

namespace cakeS1
{


    internal class SubItem
    {
        public string Text { get; set; }
        public int Price { get; set; }

        public SubItem(string text, int price)
        {
            this.Text = text;
            this.Price = price;
        }

    }
}
