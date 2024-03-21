namespace class_Money
{
    public class Money
    {
        private int dollars;
        private int cents;

        public Money(int dollars, int cents)
        {
            this.dollars = dollars;
            this.cents = cents;
        }

        public int Cents { get; internal set; }
        public int Dollars { get; internal set; }

        public void Display()
        {
            Console.WriteLine($"Amount: {dollars}.{cents:00}");
        }

        public void SetAmount(int dollars, int cents)
        {
            this.dollars = dollars;
            this.cents = cents;
        }
    }

    public class Product
    {
        private string name;
        private Money price;

        public Product(string name, Money price)
        {
            this.name = name;
            this.price = price;
        }

        public void Display()
        {
            Console.WriteLine($"Product: {name}");
            price.Display();
        }

        public void DecreasePrice(int dollars, int cents)
        {
            int totalCents = price.Cents + price.Dollars * 100;
            int decreaseCents = cents + dollars * 100;

            totalCents -= decreaseCents;

            if (totalCents < 0)
            {
                Console.WriteLine("Price cannot be negative!");
                return;
            }

            price.SetAmount(totalCents / 100, totalCents % 100);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Money money = new Money(10, 50);
            money.Display();

            money.SetAmount(15, 75);
            money.Display();

            Product product = new Product("Apple", new Money(2, 30));
            product.Display();

            product.DecreasePrice(1, 50);
            product.Display();
        }
    }

}
