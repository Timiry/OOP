using System;
using System.Drawing;
using System.Text;

namespace builder_pattern
{
    public class Person
    {

        public string? name;
        private string? surname;
        private int? age;
        private int? height;
        private int? weight;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (name != null) sb.Append($"Имя: {name}\n");
            if (surname != null) sb.Append($"Фамилия: {surname}\n");
            if (age != null) sb.Append($"Возраст: {age}\n");
            if (height != null) sb.Append($"Рост: {height}\n");
            if (weight != null) sb.Append($"Вес: {weight}\n");
            return sb.ToString();
        }
        public class Builder
        {
            private Person newPerson;

            public Builder()
            {
                newPerson = new Person();
            }

            public Builder withName(string name)
            {
                newPerson.name = name;
                return this;
            }

            public Builder withSurname(string surname)
            {
                newPerson.surname = surname;
                return this;
            }

            public Builder withAge(int age)
            {
                newPerson.age = age;
                return this;
            }

            public Builder withHeight(int height)
            {
                newPerson.height = height;
                return this;
            }

            public Builder withWeight(int weight)
            {
                newPerson.weight = weight;
                return this;
            }

            public Person build()
            {
                return newPerson;
            }

        }
    }
}