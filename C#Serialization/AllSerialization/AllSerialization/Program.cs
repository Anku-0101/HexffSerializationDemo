using System;

namespace AllSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstName     = "Aman";
            person.LastName = "kumar";
            person.Age      = 22;


            string filepath = "serial.dat";

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.BinarySerialize(person, filepath);

            Person p = null;
            p =  dataSerializer.BinaryDeserialize(filepath) as Person;

            //dataSerializer.XmlSerialize(typeof(Person), person, filepath);
            //Person p = null;
            //p = dataSerializer.XmlDeserialize(typeof(Person),filepath) as Person;

            //dataSerializer.JsonSerialize(person, filepath);
            //Person p = null;
            //p = dataSerializer.JsonDeSerialize(typeof(Person), filepath) as Person;


            Console.WriteLine(p.FirstName);
            Console.WriteLine(p.LastName);
            Console.WriteLine(p.Age);

        }
    }
}
