using System;
using System.Collections.Generic;
using System.Text;

namespace lab_5
{
    class AgeException : Exception
    {
        public AgeException()
        { }
        public AgeException(string message) : base(message)
        { }
    }

    class TimeException : Exception
    {
        public TimeException()
        { }
        public TimeException(string message) : base(message)
        { }
    }

    public abstract partial class TelevisionProgram
    {
        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Lasting
        {
            get
            {
                return lasting;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }
    }

    public class ProgramDach
    {
        public ProgramDach()
        {
            list = new List<TelevisionProgram>();
        }

        public List<TelevisionProgram> list { private set; get; }

        public void listCopy(List<TelevisionProgram> obj)
        {
            list = obj;
        }
        public void listCopy(TelevisionProgram[] obj)
        {
            list = new List<TelevisionProgram>(obj);
        }

        public void listSet(TelevisionProgram obj)
        {
            list.Add(obj);
        }

        public void listDel(TelevisionProgram obj)
        {
            list.Remove(obj);
        }

        public void listShow()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public static class Controller
    {
        public static List<TelevisionProgram> FilmsDotYear(this ProgramDach obj, string year)
        {
            ProgramDach result = new ProgramDach();
            foreach (var item in obj.list)
            {
                try
                {
                    Film f;
                    f = item as Film;
                    if (f.Year_of_creation.Equals(year)) result.listSet(item);
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result.list;
        }
        public static int NumberOfAdvert(this ProgramDach obj)
        {
            int result = 0;
            foreach (var item in obj.list)
            {
                result += item.advert;
            }
            return result;
        }

        public static int Lasting(this ProgramDach obj)
        {
            int result = 0;
            foreach (var item in obj.list)
            {
                result += item.Lasting;
            }
            return result;
        }


    }
}
