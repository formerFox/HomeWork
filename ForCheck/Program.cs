//6.6.2
using System.Xml.Linq;
using System;

class User
{
    private int age;
    private string login;
    private string mail;

    public int Age
    {
        get { return age; }

        set
        {
            if (value < 18) Console.WriteLine("Возраст должен быть не меньше 18");
            else age = value;
        }
    }
    public string Login
    {
        get { return login; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3) Console.WriteLine("Login должен быть не менее 3 символов");
            else login = value;
        }
    }
    public string Mail
    {
        get { return mail; }
        set
        {
            if (!string.IsNullOrEmpty(value) && !value.Contains("@")) Console.WriteLine("Почта не соответствует Почта не соответствует формату");
            else login = value;
        }
    }
}