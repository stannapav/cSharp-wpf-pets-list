using System.Xml.Serialization;
using System;

namespace finalProject.Classes
{
    [Serializable]
    [XmlInclude(typeof(Cat)), XmlInclude(typeof(Dog)), XmlInclude(typeof(Animal))]
    public class Cat : Animal
    {
        public Cat() : base()
        {

        }

        public Cat(string name, string breed, string furColor, int age) : base(name, breed, furColor, age)
        {

        }

        public override string Feed(Food food)
        {
            this.fullness += (int)food;
            this.happiness += (food == Food.Vegetable) ? -4 :
                (food == Food.Fish) ? 4 :
                (food == Food.Meat) ? 3 :
                (food == Food.Feed) ? 1 : 0;

            if (this.fullness > 20)
            {
                this.fullness -= 10;
                return $"{Name} puked because you gave it too much food";
            }

            return (this.fullness >= 15) ? $"{Name} is full and happy so their are purring" :
                $"{Name} ate {food} and {((food == Food.Vegetable) ? "didnt quite liked" : "liked it")}";
        }

        public override string Play(Games game)
        {
            this.happiness += (game == Games.Walk) ? -1 :
                (game == Games.Fetch) ? -4 :
                (game == Games.Mouse) ? 7 :
                (game == Games.Ball) ? 5 : 0;

            return (this.happiness < 5) ? $"{Name} isn't happy. {((game == Games.Fetch || game == Games.Walk) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                (this.happiness < 15) ? $"{Name} is a lil bit happy. {((game == Games.Fetch || game == Games.Walk) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                (this.happiness > 30) ? $"{Name} is happy but exosted. {((game == Games.Fetch || game == Games.Walk) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                $"{Name} is happy and purring. {((game == Games.Fetch || game == Games.Walk) ? $"Didn't liked {game}" : $"Liked {game}")}";
        }

        public override string ToString()
        {
            return $"This cats name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Breed: {Breed}\n" +
                $"Color of fur: {FurColor}\n" +
                $"{Name} happiness: {Happiness} {((Happiness >= 10) ? "and is purring" : "")}\n" +
                $"{Name} fullness: {Fullness} {((Fullness == 15) ? "cat is full" : (Fullness > 15) ? "cat is too full\nplease don't feed or it will puke" : "")}";
        }
    }
}