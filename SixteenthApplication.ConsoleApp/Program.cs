using System;

namespace SixteenthApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInfo = GetUserInfo();
            Console.WriteLine($"Имя пользователя : {userInfo.Name}");
            Console.WriteLine($"Фамилия пользователя : {userInfo.LastName}");
            Console.WriteLine($"Возраст пользователя : {userInfo.Age}");
            Console.WriteLine($"Питомцы пользователя : {string.Join(',', userInfo.Pets ?? new[] { "Нету" })}");
            Console.WriteLine($"Любимые цвета пользователя : {string.Join(',', userInfo.FavoriteColors ?? new[] { "Нету" })}");
            Console.ReadKey();
        }


        private static (string Name, string LastName, int Age, string[] Pets, string[] FavoriteColors) GetUserInfo()
        {
            var name = GetName();
            var lastname = GetLastName();
            var age = GetAge();
            string[] pets = null;
            if (HasPets())
            {
                var countPets = GetPetsCount();
                pets = GetPets(countPets);
            }

            var favoriteColorsCount = GetFavoriteColorsCount();
            var favoriteColors = GetFavoriteColors(favoriteColorsCount);
            return (name, lastname, age, pets, favoriteColors);
        }


        private static string GetName()
        {
            return GetNameOrLastName("Введите имя", "Введите корректное имя");
        }


        private static string GetLastName()
        {
            return GetNameOrLastName("Введите фамилию", "Введите корректную фамилию");
        }

        private static string GetNameOrLastName(string enterMsg, string errorMsg)
        {
            if (enterMsg is null) throw new ArgumentNullException(nameof(enterMsg));
            if (errorMsg is null) throw new ArgumentNullException(nameof(errorMsg));
            while (true)
            {
                Console.WriteLine(enterMsg);
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    if (name.All(char.IsLetter))
                    {
                        return name;
                    }
                }
                Console.WriteLine(errorMsg);
            }
        }

        private static int GetAge()
        {
            while (true)
            {
                Console.WriteLine("Введите возраст");
                var age = Console.ReadLine();
                if (CheckCorrectNum(age))
                {
                    return Convert.ToInt32(age);
                }
                Console.WriteLine("Введите корректный возраст");
            }
        }

        private static bool HasPets()
        {
            while (true)
            {
                Console.WriteLine("Введите 0 - если питомца нету, 1 - если есть");
                var hasPets = Console.ReadLine();
                switch (hasPets)
                {
                    case "0":
                        return false;
                    case "1":
                        return true;
                    default:
                        Console.WriteLine("Введите корректное значение");
                        continue;
                }
            }
        }

        private static int GetPetsCount()
        {
            while (true)
            {
                Console.WriteLine("Введите количество питомцев");
                var petsCount = Console.ReadLine();
                if (CheckCorrectNum(petsCount))
                {
                    return Convert.ToInt32(petsCount);
                }
                Console.WriteLine("Введите корректное количество питомцев");
            }
        }

        private static string[] GetPets(int count)
        {
            while (true)
            {
                Console.WriteLine("Введите клички питомцев через запятую");
                var pets = Console.ReadLine();
                if (pets != null)
                {
                    var petsArr = pets.Split(',');
                    if (petsArr.Length == count)
                    {
                        return petsArr;
                    }
                }
                Console.WriteLine("Введите корректное значение");
            }
        }

        private static int GetFavoriteColorsCount()
        {
            while (true)
            {
                Console.WriteLine("Введите количество любимых цветов");
                var favoriteColorsCount = Console.ReadLine();
                if (CheckCorrectNum(favoriteColorsCount))
                {
                    return Convert.ToInt32(favoriteColorsCount);
                }
                Console.WriteLine("Введите корректное количество любимых цветов");
            }
        }

        private static string[] GetFavoriteColors(int count)
        {
            while (true)
            {
                Console.WriteLine("Введите любимые цвета через запятую");
                var colors = Console.ReadLine();
                if (colors != null)
                {
                    var colorsArr = colors.Split(',');

                    if (colorsArr.Length == count)
                    {
                        return colorsArr;
                    }
                }
                Console.WriteLine("Введите корректное значение");
            }
        }

        private static bool CheckCorrectNum(string value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            if (!int.TryParse(value, out var result)) return false;
            return result > 0;
        }
    }
}
