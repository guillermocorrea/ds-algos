using System;
using System.Collections.Generic;

namespace Problems.InterfaceDesign
{
    public interface IMonarchy
    {
        void Birth(string child, string parent);
        void Death(string name);
        List<string> GetOrderOfSuccession();
    }

    public class Monarchy : IMonarchy
    {
        private readonly Person _monarch;
        private readonly Dictionary<string, Person> _people;

        public Monarchy(string monarch)
        {
            _ = monarch ?? throw new ArgumentNullException(nameof(monarch));
            _monarch = new Person(monarch);
            _people = new Dictionary<string, Person>();
            _people[monarch] = _monarch;
        }

        public void Birth(string child, string parent)
        {
            if (!_people.ContainsKey(parent)) return;
            var parentRef = _people[parent];
            var newBorn = new Person(child);
            parentRef.Children.Add(newBorn);
            _people[child] = newBorn;
        }

        public void Death(string name)
        {
            if (!_people.ContainsKey(name)) return;
            var person = _people[name];
            person.IsAlive = false;
        }

        public List<string> GetOrderOfSuccession()
        {
            List<string> result = new List<string>();
            GetOrderOfSuccessionRecursive(_monarch, result);
            return result;
        }

        private void GetOrderOfSuccessionRecursive(Person current, List<string> result)
        {
            if (current.IsAlive)
                result.Add(current.Name);
            foreach (var child in current.Children)
            {
                GetOrderOfSuccessionRecursive(child, result);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public List<Person> Children { get; set; }
        public Person(string name)
        {
            Name = name;
            Children = new List<Person>();
            IsAlive = true;
        }
    }
}