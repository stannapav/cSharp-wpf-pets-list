using finalProject.Classes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace finalProject.View
{
    public partial class PlayWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        Animal animal;
        bool wantToPlay;
        Regex exostedMask = new Regex("exosted");

        private int happiness;

        public int Happiness
        {
            get { return happiness; }
            set { happiness = value; }
        }

        private string txtPlay;

        public string TxtPlay
        {
            get { return txtPlay; }
            set
            {
                txtPlay = value;
                OnPropertyChanged();
            }
        }

        public PlayWindow(Window parentWindow,
            string animalType, string animalName, string animalBreed, string animalFurColor, int animalAge, int animalHappiness)
        {
            DataContext = this;
            Owner = parentWindow;
            if (animalType == "cat")
                animal = new Cat(animalName, animalBreed, animalFurColor, animalAge);
            else
                animal = new Dog(animalName, animalBreed, animalFurColor, animalAge);

            animal.Happiness = animalHappiness;
            Happiness = animal.Happiness;

            TxtPlay = (Happiness < 5) ? $"{animal.Name} isn't happy" :
                (Happiness < 15) ? $"{animal.Name} is a lil bit happy" : 
                (Happiness > 30) ? $"{animal.Name} is happy but exosted" : $"{animal.Name} is happy";

            wantToPlay = (Happiness <= 30) ? true : false;

            InitializeComponent();
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnFetch_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Games.Fetch);
        }

        private void btnMouse_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Games.Mouse);
        }

        private void btnWalk_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Games.Walk);
        }

        private void btnBall_Click(object sender, RoutedEventArgs e)
        {
            btnFeedFunc(Games.Ball);
        }

        private void btnFeedFunc(Games game)
        {
            if (wantToPlay)
            {
                TxtPlay = animal.Play(game);
                Happiness = animal.Happiness;
                TxtPlay += $"\nHappiness: {Happiness}";
                wantToPlay = (exostedMask.IsMatch(TxtPlay)) ? false : true;
            }
            else
            {
                TxtPlay = $"{animal.Name} don't want to play";
                btnFetch.IsEnabled = false;
                btnBall.IsEnabled = false;
                btnMouse.IsEnabled = false;
                btnWalk.IsEnabled = false;
            }
        }
    }
}