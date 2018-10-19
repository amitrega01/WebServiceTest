using System;
using WebApplication1;

namespace ConsoleApp1
{
    class Program
    {
        public static WebService1 ws { get; set; }
        static void Main(string[] args)
        {
            ws = new WebService1();

            Menu();


        }

        public static void Menu()
        {
            Console.WriteLine("#########################");
            Console.WriteLine("1.\tWypisz wszystkich");
            Console.WriteLine("2.\tZnajdz po ID");
            Console.WriteLine("3.\tZnajdz po nazwisku");
            Console.WriteLine("4.\tDodaj osobe");
            Console.WriteLine("5.\tZaktualizuj osobe");
            Console.WriteLine("6.\tUsun po ID");
            Console.WriteLine("0.\tWyjscie");
            Console.Write("Wybór: ");
            var wybor = Console.ReadLine();
            Console.Clear();
            switch (wybor)
            {
                case "1":
                    {
                        Console.WriteLine(ws.GetAllPeopleText());
                        break;
                    }
                case "2":
                    {
                        Console.Write("ID:\t");
                        var ID = Convert.ToInt32(Console.ReadLine());
                        var temp = ws.GetPersonByID(ID);
                        Console.WriteLine(temp.ToString());
                        break;
                    }
                case "3":
                    {
                        Console.Write("Nazwisko:\t");
                        var lastName = Console.ReadLine();
                        var temp = ws.GetPersonByLastName(lastName);
                        foreach (var item in temp)
                            Console.WriteLine(item.ToString());
                        break;
                    }
                case "4":
                    {
                        Person temp = new Person();
                        Console.Write("ID:\t");
                        temp.ID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Imie:\t");
                        temp.FirstName = Console.ReadLine();
                        Console.Write("Nazwisko:\t");
                        temp.LastName = Console.ReadLine();
                        var res = ws.Create(temp);
                        if (res)
                            Console.WriteLine("Dodano pomyślnie");
                        else Console.WriteLine("Taki ID juz istnieje");
                        break;
                    }
                case "5":
                    {
                        Console.Write("ID:\t");
                        var ID = Convert.ToInt32(Console.ReadLine());
                        var temp = ws.GetPersonByID(ID);
                        if (temp!=null)

                        {

                            Console.Write("Nowe imie:\t");
                            temp.FirstName = Console.ReadLine();
                            Console.Write("Nowe nazwisko:\t");
                            temp.LastName = Console.ReadLine();
                            ws.Update(temp);
                        }
                        else Console.WriteLine("Nie ma takiej osoby o tym ID!!!!lmao");
                        break;
                    }
                case "6":
                    {
                        Console.Write("ID:\t");
                        var ID = Convert.ToInt32(Console.ReadLine());
                        if (ws.Delete(ID))
                            Console.WriteLine( "Usunieto!" );
                        else Console.WriteLine("Nie usunięto! Złe id?3");
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            Menu();
        }

    }
}
