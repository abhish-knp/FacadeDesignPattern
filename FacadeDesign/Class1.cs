using System;

namespace FacadeDesignPattern
{
    public abstract class Emplyoee
    {
        public abstract Emplyoee Clone();
        public String Name { get; set; }
        public String Role { get; set; }
    }
    /// <summary>
    /// summary added
    /// </summary>
    public class Typist : Emplyoee
    {
        public int WordsPerMinute { get; set; }
        public override Emplyoee Clone()
        {
            //throw new NotImplementedException();
            return (Emplyoee)MemberwiseClone();
        }


        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}wpm", Name, Role, WordsPerMinute);
        }
    }

    public class Developer : Emplyoee
    {
        public string PreferredLanguage { get; set; }
        public override Emplyoee Clone()
        {
            //throw new NotImplementedException();
            return (Emplyoee)MemberwiseClone();
        }


        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}wpm", Name, Role, PreferredLanguage);
        }
    }

}
