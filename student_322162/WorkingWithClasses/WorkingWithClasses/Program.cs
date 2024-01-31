namespace WorkingWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Дима", 24);

        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

}
