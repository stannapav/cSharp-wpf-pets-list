using finalProject.Classes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace finalProject.View
{
    public partial class FeedWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        Animal animal;
        bool wantToEat;
        Regex pukeMask = new Regex("puke");

        private int fullness;

        public int Fullness
        {
            get { return fullness; }
            set { fullness = value; }
        }

        private int happiness;

        public int Happiness
        {
            get { return happiness; }
            set { happiness = value; }
        }

        private string txtFeed;

        public string TxtFeed
        {
            get { return txtFeed; }
            set 
            { 
                txtFeed = value;
                OnPropertyChanged();
            }
        }

        public FeedWindow(Window parentWindow,
            string animalType, string animalName, string animalBreed, string animalFurColor, int animalAge, int animalHappiness, int animalFullness)
        {
            DataContext = this;
            Owner = parentWindow;
            if(animalType == "cat")
                animal = new Cat(animalName, animalBreed, animalFurColor, animalAge);
            else
                animal = new Dog(animalName, animalBreed, animalFurColor, animalAge);

            animal.Fullness = animalFullness;
            animal.Happiness = animalHappiness;
            Fullness = animal.Fullness;
            Happiness = animal.Happiness;

            TxtFeed = (Fullness < 5) ? $"{animal.Name} is hungry" :
                (Fullness < 15 && animalType == "cat") ? $"{animal.Name} still not full" :
                (Fullness < 20 && animalType == "dog") ? $"{animal.Name} still not full" : $"{animal.Name} full";

            wantToEat = (Fullness < 15 && animalType == "cat") ? true : 
                (Fullness < 20 && animalType == "dog")? true : false;
            
            InitializeComponent();
        }

        private void btnFeed_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Food.Feed);
        }

        private void btnMeat_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Food.Meat);
        }

        private void btnFish_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Food.Fish);
        }

        private void btnVegetable_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Food.Vegetable);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnFeedFunc(Food food)
        {
            if (wantToEat)
            {
                TxtFeed = animal.Feed(food);
                Fullness = animal.Fullness;
                Happiness = animal.Happiness;
                TxtFeed += $"\nFullness: {Fullness}";
                wantToEat = (pukeMask.IsMatch(TxtFeed)) ? false : true;
            }
            else
            {
                TxtFeed = $"{animal.Name} don't want to eat";
                btnVegetable.IsEnabled = false;
                btnFeed.IsEnabled = false;
                btnMeat.IsEnabled = false;
                btnFish.IsEnabled = false;
            }
        }
    }
}