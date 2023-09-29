using System.Xml.Serialization;
using System;

namespace finalProject.Classes
{
    [Serializable]
    [XmlInclude(typeof(Cat)), XmlInclude(typeof(Dog)), XmlInclude(typeof(Animal))]
    public class Dog : Animal
    {
        public Dog() : base()
        {

        }

        public Dog(string name, string breed, string furColor, int age): base(name, breed, furColor, age)
        {

        }

        public override string Feed(Food food)
        {
            this.fullness += (int)food;
            this.happiness += (food == Food.Vegetable) ? -4 :
                (food == Food.Fish) ? 1 :
                (food == Food.Meat) ? 4 :
                (food == Food.Feed) ? 2 : 0;

            if (this.fullness > 25)
            {
                this.fullness -= 10;
                return $"{Name} puked because you gave it too much food";
            }

            return (this.fullness >= 20) ? $"{Name} is full and happy so their tail is wagging" :
                 $"{Name} ate {food} and {((food == Food.Vegetable) ? "didnt quite liked" : "liked it")}";
        }

        public override string Play(Games game)
        {
            this.happiness += (game == Games.Walk) ? 5 :
                (game == Games.Fetch) ? 6 :
                (game == Games.Mouse) ? -5 :
                (game == Games.Ball) ? 3 : 0;

            return (this.happiness < 5) ? $"{Name} isn't happy. {((game == Games.Mouse) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                (this.happiness < 15) ? $"{Name} is a lil bit happy. {((game == Games.Mouse) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                (this.happiness > 30) ? $"{Name} is happy but exosted. {((game == Games.Mouse) ? $"Didn't liked {game}" : $"Liked {game}")}" :
                $"{Name} is happy and wagging it's tail. {((game == Games.Mouse) ? $"Didn't liked {game}" : $"Liked {game}")}";
        }

        public override string ToString()
        {
            return $"This dogs name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Breed: {Breed}\n" +
                $"Color of fur: {FurColor}\n" +
                $"{Name} happiness: {Happiness} {((Happiness >= 10) ? "and tail is wagging" : "")}\n" +
                $"{Name} fullness: {Fullness} {((Fullness == 20) ? "dog is full" : (Fullness > 20) ? "cat is too full please don't feed or it will puke" : "")}";
        }
    }
}