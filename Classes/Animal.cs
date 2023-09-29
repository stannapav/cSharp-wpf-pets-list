using System;
using System.Xml.Serialization;

namespace finalProject.Classes
{
    [Serializable]
    [XmlInclude(typeof(Cat)), XmlInclude(typeof(Dog)), XmlInclude(typeof(Animal))]
    public abstract class Animal : IComparable<Animal>
    {
        protected string name;
        protected string breed;
        protected string furColor;
        protected int age;
        protected int fullness;
        protected int happiness;

        [XmlAttribute]
        public string Name 
        { 
            get { return name; }
            set {  name = value; }
        }

        [XmlAttribute]
        public string Breed 
        { 
            get { return breed; }
            set {  breed = value; }
        }

        [XmlAttribute]
        public string FurColor 
        { 
            get { return furColor; } 
            set {  furColor = value; }
        }

        [XmlAttribute]
        public int Age 
        { 
            get { return age; }
            set {  age = value; }
        }

        [XmlAttribute]
        public int Fullness 
        { 
            get { return fullness; } 
            set{ fullness = value; } 
        }

        [XmlAttribute]
        public int Happiness
        {
            get { return happiness; }
            set { happiness = value; }
        }

        public Animal()
        {
            this.name = "";
            this.breed = "";
            this.furColor = "";
            this.age = 0;
            this.fullness = 0;
            this.happiness = 0;
        }

        public Animal(string name, string breed, string furColor, int age)
        {
            this.name = name;
            this.breed = breed;
            this.furColor = furColor;
            this.age = age;
            this.fullness = 0;
            this.happiness = 0;
        }

        public abstract string Feed(Food food);

        public abstract string Play(Games game);

        public override string ToString()
        {
            return "";
        }

        int IComparable<Animal>.CompareTo(Animal other)
        {
            return this.name.Trim().ToLower().CompareTo(other.name.Trim().ToLower());
        }
    }
}