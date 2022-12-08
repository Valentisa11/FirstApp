abstract class Delivery
{
    public string Address;
    protected double Price;
    public Delivery(string address)
    {
        Address = address;
    }
    public void DisplayAddress()
    {
        Console.WriteLine(Address);
    }

    //абстрактный метод
    public abstract void GetOrder();
}

class HomeDelivery : Delivery
{
    //свойства
    public int CourierID { get; set; } 
    public bool ReadyToDeliver;

    // конструктор класса с параметрами
    public HomeDelivery(string address, bool ReadyToDeliver) : base(address)
    {
        ReadyToDeliver = ReadyToDeliver;
    }
    public override void GetOrder()
    {
        Console.WriteLine("Доставка на дом.");
    }
}

class PickPointDelivery : Delivery
{
    public int PickPointID;
    public bool Delivered;

    // конструктор класса с параметрами
    public PickPointDelivery(string address, int PickPointID, bool Delivered) : base(address) 
    {
        Delivered = Delivered;
        PickPointID = PickPointID;
    }
    public override void GetOrder()
    {
        Console.WriteLine("Доставка в пункт выдачи заказов.");
    }

}

class ShopDelivery : Delivery
{
    public int ShopID;
    public bool Delivered;
    // конструктор класса с параметрами
    public ShopDelivery(string address, int ShopID, bool Delivered) : base(address) 
    {
        Delivered = Delivered;
        ShopID = ShopID;
    }
    public override void GetOrder()
    {
        Console.WriteLine("Доставка в розничный магазин.");
    }
}

class Order<TDelivery,
TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }
    public void DisplayPrice()
    {
        //использование статического элемента
        Console.WriteLine(ProductType.minPrice);
    }
}

// метод расширения
static class StringExtensions 
{
    public static char GetFirstChar(this string source)
    {
        return source[0];
    }
}
class MyArr
{
    // Координаты точки на карте
    public double x, y;

    public MyArr(double x = 0.0, double y = 0.0)
    {
        this.x = x;
        this.y = y;
    }

    // Перегружаем бинарный оператор +
    public static MyArr operator +(MyArr obj1, MyArr obj2)
    {
        MyArr arr = new MyArr();
        arr.x = obj1.x + obj2.x;
        arr.y = obj1.y + obj2.y;
        return arr;
    }

    // Перегружаем бинарный оператор - 
    public static MyArr operator -(MyArr obj1, MyArr obj2)
    {
        MyArr arr = new MyArr();
        arr.x = obj1.x - obj2.x;
        arr.y = obj1.y - obj2.y;
        return arr;
    }
}
class Product
{
    public string Type;
    public string Model;

    //обобщенный метод
    public void Display<T>(T param)
    {
        Console.WriteLine(param.ToString());
    }
}
class ProductCollection
{  
    //агрегация
    private Product[] collection;   
    public ProductCollection(Product[] collection)
    {
        this.collection = collection;
    }

    //индексатор
    public Product this[int index]
    {
        get
        {

            if (index >= 0 && index < collection.Length)
            {
                return collection[index];
            }
            else
            {
                return null;
            }
        }

        private set
        {

            if (index >= 0 && index < collection.Length)
            {
                collection[index] = value;
            }
        }
    }
}

// композиция
class ProductType 
{
    private Product product;
    //статические элементы.
    public static double minPrice = 2.0; 
    public ProductType()
    {
        product = new Product();
    }
}
abstract class Parcel
{
    public string ParcelId;
    public void DisplayId()
    {
        Console.WriteLine(ParcelId);
    }
}

//наследование обобщений
class PremiumCustomer<TParcel> : Customer<TParcel> where TParcel : Parcel 
{
    public TParcel Field;
}

//обобщение и наследование + инкапсуляция
class Customer<TParcel> where TParcel : Parcel 
{
    public TParcel Parcel;

    private string Name;
    private string LastName;
    private int age;

    //свойства с логикой
    public int Age 
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 18)
            {
                Console.WriteLine("Возраст должен быть не меньше 18");
            }
            else
            {
                age = value;
            }
        }
    }
    public string GetName()
    {
        return Name;
    }
    public string GetLastName()
    {
        return LastName;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Product obj = new Product();

        //Использование обобщенного метода
        obj.Display<string>("Тип Продукта:");
        obj.Display<int>(365);

        //использование метода расширения

        Console.WriteLine("string".GetFirstChar());

        var array = new Product[]
        {
                new Product
                {
                    Type = "Table",
                    Model = "M-2345"
                },
                new Product
                {
                    Type = "Sofa",
                    Model = "T-3256"
                },
        };
        ProductCollection collection = new ProductCollection(array);
        //индексация
        Product product = collection[1];

        // использование перегрузки операторов
        MyArr Point1 = new MyArr(5.0, 2.3);
        MyArr Point2 = new MyArr(0.5, -3.0);
        MyArr Point3 = Point1 + Point2;
        Console.WriteLine("Сумма координат на карте: " + Point3.x + " " + string.Format("{0:0.00}", Point3.y));
    }
}
