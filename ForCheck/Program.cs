using System.Text.RegularExpressions;
//слишком абстрактное задание
abstract class Delivery<T>
{
    public ForAdress<T> adress = new ForAdress<T>();//агрегация

    public virtual void Print() 
    {
        Console.WriteLine("Доставка");
    }
    protected abstract void Info();
}

class ForAdress <T>
{
    private T adress;
    public T Adress 
    {
        get => adress; 
        set => adress = value;
    }
}

class User
{
    public string nameUser{  get; set; }//автосвойства
    public string numberUser {  get; set; }
    public string pickPoint {  get; set; }
    public string shop {  get; set; }
    public int count;
    public int Count{ //добавление логики в свойства 
        get => count; 
        set 
        { 
            if (value < 0)
                throw new ArgumentException("Некорректный ввод!");
            count = value;
        } 
    }
    public User() { }
    public User(string nameUser, string numberUser) : this()
    { 
        this.nameUser = nameUser;
        this.numberUser = numberUser;
    }
    public User(string pickPoint) 
    { 
        this.pickPoint = pickPoint;
    }
    public User(string shop, int count)
    {
        this.shop = shop;
        this.count = count;
    }
}

class HomeDelivery : Delivery<string> //Наследование
{
    User user = new User();//Композиция
    public HomeDelivery() { }
    public HomeDelivery(string nameUser, string numberUser) //Конструктор с параметрами
    {
        user.nameUser = nameUser;
        user.numberUser = numberUser;
    }
    private string Number() //Инкапсуляция...
    {
        string pattern = @"\D";
        string target = "";
        Regex regex = new Regex(pattern);
        string result = regex.Replace(user.numberUser, target);
        return result;
    }
    public override void Print()
    {
        Console.WriteLine("Доставка на дом");
    }
    protected override void Info() 
    {
        Console.WriteLine($"Имя покупателя: {user.nameUser} \n Номер покупателя: {Number()}");//...Инкапсуляция
    }
}

class PickPointDelivery : Delivery<int>
{
    User user = new User();//Композиция
    public PickPointDelivery(string pickPoint) 
    {   
        user.pickPoint = pickPoint;
    }
    public override void Print()
    {
        Console.WriteLine("Доставка в пункт выдачи");
    }
    protected override void Info() { }
}

class ShopDelivery : Delivery<string>
{
    User user = new User();//Композиция
    public ShopDelivery(string shop, int count) 
    { 
        user.shop = shop;
        user.count = count;
    }
    public override void Print()
    {
        Console.WriteLine("Доставка в розничный магазин");
    }
    protected override void Info() { }
}

class Order<TDelivery,TStruct> where TDelivery : Delivery<string>//Обобщение...
{
    public TDelivery Delivery;//...обобщение

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.adress);
    }

    
}

public class Programm
{
    static void Main() 
    {
        Delivery<string> home = new HomeDelivery();//Полиморфизм
        home.Print();
    }
}

