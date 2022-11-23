using System;
internal class Program
{
    static void Main(string[] args)
    {
        var User = Anketa();
        ShowData(User);
        Console.ReadKey();
    }
    private static (string Name, string LastName, int Age, bool HavePets, int NumPets, string[] Pets, int FavColorsNum, string[] FavColors) Anketa()
    {
        (string Name, string LastName, int Age, bool HavePets, int NumPets, string[] Pets, int FavColorsNum, string[] FavColors) User;

        Console.WriteLine("Введите ваше имя: ");
        User.Name = Console.ReadLine();

        int number;
        while (User.Name.Length == 0 || int.TryParse(User.Name, out number) == true)
        {
            Console.WriteLine("Ошибка! \nВведите имя: ");
            User.Name = Console.ReadLine();
        }

        Console.WriteLine("Введите вашу фамилию: ");
        User.LastName = Console.ReadLine();

        while (User.LastName.Length == 0 || int.TryParse(User.LastName, out number) == true)
        {
            Console.WriteLine("Ошибка! \nВведите фамилию:");
            User.LastName = Console.ReadLine();
        }

        string result;
        do
        {
            Console.WriteLine("Введите ваш возраст цифрами: ");
            result = Console.ReadLine();

        } while (CheckNum(result, out number));


        User.Age = number;
        
        do
        {
            Console.WriteLine("Есть ли у вас питомцы? Да / Нет: ");
            result = Console.ReadLine();
        } while (result != "Да" && result != "Нет" && result != "да" && result != "нет");

        User.NumPets = 0;
        int ammount = 0;
        if (result == "Да" || result == "да")
        {
            User.HavePets = true;

            do
            {
                Console.WriteLine("Введите количество питомцев: ");
                result = Console.ReadLine();

            } while (CheckNum(result, out ammount));
            
        }
            else
            {
                User.HavePets = false;
            }
        User.NumPets = ammount;
        User.Pets = GetPetNames(ammount);

        do
            {
                Console.WriteLine("Сколько у вас любимых цветов: ");
                result = Console.ReadLine();

            } while (CheckNum(result, out ammount));

            User.FavColorsNum = ammount;

            User.FavColors = GetFavColors(ammount);
            return User;
        }


        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            corrnumber = 0;
            return true;
        }

    static string[] GetPetNames(int ammount)
    {
        
        var result = new string[ammount];
        for (int k = 0; k < result.Length; k++)

        {
            Console.WriteLine("Как их зовут?");
            do
            {
                result[k] = Console.ReadLine();
                k++;
            } while (k < result.Length);
        }
        return result;
    }
    static string[] GetFavColors(int ammount)
        { 
            var result = new string[ammount];
            Console.WriteLine("Назовите любимые цвет(а)");
        for (int k = 0; k < result.Length; k++)
            {
                do
                {
                    result[k] = Console.ReadLine();
                    k++;

                } while (k < result.Length);
            } 
          
        return result;

        }


    static void ShowData((string Name, string LastName, int Age, bool HavePets, int NumPets, string[] Pets, int FavColorsNum, string[] FavColors) Tuple)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("__ВАША АНКЕТА__");
        Console.WriteLine("Ваше имя: " + Tuple.Name);
        Console.WriteLine("Ваша фамилия: " + Tuple.LastName);
        Console.WriteLine("Ваш возраст: " + Tuple.Age);

        if (Tuple.HavePets)
        {
            
            Console.WriteLine("Наличие питомцев: да");
            Console.WriteLine("Питомцы: " + String.Join(", ", Tuple.Pets));
        }

        else

        {
            Console.WriteLine("Наличие питомцев: нет");
        }

        {

            Console.WriteLine("Ваши любимые цвета: " + String.Join(", ", Tuple.FavColors));
        }

    }
        
}

