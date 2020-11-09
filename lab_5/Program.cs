
using System;
using System.Diagnostics;

namespace lab_5
{
    enum TVShows
    {
        Cartoon,
        Film,
        News,
        Documentary,
        History
    }

    struct History
    {
        public string length;
        public int age;
        public void Show()
        {
            Console.WriteLine($"Продолжительность: {length}; Возрастное ограничение: {age}");
        }
        public History(string length, int age)
        {
            this.length = length;
            if(age < 0)
            {
                this.age = 0;
                throw new AgeException("Возраст не может быть отрицательным");
            }
            else
            {
                this.age = age;
            }
        }
    }

    interface IAdvertisement
    {
        public void AddAdvert();
    }

    interface IDirector
    {
        void Direct();
    }


    public abstract partial class TelevisionProgram
    {
        protected string name;
        protected int lasting;
        protected string description;
        public int advert = 0;

        protected TelevisionProgram(string name, int lasting, string description)
        {
            this.name = name;
            this.lasting = lasting;
            this.description = description;
        }
        public TelevisionProgram() { }

        
    }

    public abstract class Film : TelevisionProgram
    {
        public string Year_of_creation;
        public string Country;

        public void AddAdvert()
        {
            advert++;
        }
        public virtual void Show()
        {
            Console.WriteLine("film was made in 2020");
        }

    }

    public class FeatureFilm : Film, IAdvertisement
    {

        public string Actor { get; }


        public FeatureFilm(string Year_of_creation, string Country, string actor)
        {

            this.Year_of_creation = Year_of_creation;
            this.Country = Country;
            Actor = actor;

        }



        public override void Show()
        {
            Console.WriteLine("In 2020 feauturefilm was made");
        }

        void IAdvertisement.AddAdvert()
        {
            advert++;
        }
        public override string ToString()
        {
            return name + " " + lasting + " " + description + " " + Year_of_creation + " " + Country;
        }
    }

    public class Cartoon : Film
    {
        public Cartoon(string name, int lasting, string description, string Year_of_creation, string Country)
        {
            this.name = name;
            this.lasting = lasting;
            this.description = description;
            this.Year_of_creation = Year_of_creation;
            this.Country = Country;
        }

        public override void Show()
        {
            Console.WriteLine("In 2020 cartoon was made");
        }
        public override string ToString()
        {
            return name + " " + lasting + " " + description + " " + Year_of_creation + " " + Country;
        }
    }

    public sealed class News : TelevisionProgram
    {
        public int Time;
        public News(int time, string name, int lasting, string description) : base(name, lasting, description)
        {
            if(time > 24 || time < 0)
            {
                throw new TimeException("Время неверно!");
            }
            else
            {
                Time = time;
            }
        }
        public void AddAdvert()
        {
            advert++;
        }
        public override string ToString()
        {
            return name + " " + lasting + " " + description + " " + Time;
        }
    }
     public static class Printer
    {
        public static void IAmPrinting(TelevisionProgram obj)
        {
            Console.WriteLine("Тип объекта " + obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            FeatureFilm fi = new FeatureFilm("2018", "Germany", "Actor");
            if (fi is Film)
            {
                Console.WriteLine("Film");
            }
            Cartoon car = new Cartoon("Momo", 108, "something", "2020", "Germany");
            Cartoon car_1 = new Cartoon("flu", 98, "something", "2010", "Belarus");
            News news = new News(10, "Morning", 78, "воаифовлав");
            fi.Show();

            Film g = fi as Film;
            Console.WriteLine(g.GetType());


            Printer.IAmPrinting(fi);

            TelevisionProgram[] array = new TelevisionProgram[4];
            array[0] = fi;
            array[1] = car;
            array[2] = car_1;
            array[3] = news;

            foreach (var i in array)
            {
                Console.WriteLine("-________-");
                Printer.IAmPrinting(i);
            }


            ProgramDach program = new ProgramDach();
            program.listCopy(array);
            Console.WriteLine("_________________________________");
            foreach (var item in program.FilmsDotYear("2020"))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Время в минутах: {program.Lasting()}");
            Console.WriteLine($"Количество рекламы: {program.NumberOfAdvert()}");




            //лаба 7
            int[] mass = new int[10];
            try
            {
                mass[11] = 10;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за предел массива");
            }
            try
            {
                int[] arr = new int[20000000000];
            }
            catch (OverflowException)
            {
                Console.WriteLine("Переполнение стека");
            }
            try
            {
                int asd;
                asd = int.Parse(Console.ReadLine());
                Console.WriteLine(asd);
            }
            catch (FormatException)
            {
                Console.WriteLine("Не число");
            }
            finally
            {
                Console.WriteLine("Блок Finally");
            }
            try
            {
                History history = new History("100", -2);
            }
            catch(AgeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                News news1 = new News(25, "asfs", 12, "asfafs");
            }
            catch(TimeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            string dfg = null;
            Debug.Assert(dfg != null, "This string is null");
        }


    }

}
