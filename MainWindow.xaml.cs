using finalProject.Classes;
using finalProject.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace finalProject
{
    public enum Food { Meat = 5, Fish = 3, Feed = 6, Vegetable = 1 }
    public enum Games { Fetch, Mouse, Walk, Ball}

    public partial class MainWindow : Window
    {
        XmlSerializer xmlser = new XmlSerializer(typeof(List<Animal>));
        List<Animal> animals;

        public MainWindow()
        {
            animals = new List<Animal>();

            InitializeComponent();

            try
            {
                if (File.Exists("Animals.xml"))
                {
                    Stream serialStream = new FileStream("Animals.xml", FileMode.Open);

                    animals = xmlser.Deserialize(serialStream) as List<Animal>;
                    serialStream.Close();

                    foreach (var animal in animals)
                        lvAnimals.Items.Add(animal.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCreateCat_Click(object sender, RoutedEventArgs e)
        {
            CatWindow catWindow = new CatWindow(this);
            Opacity = 0.4;
            catWindow.ShowDialog();
            Opacity = 1;

            if (catWindow.Success)
            {
                animals.Add((Cat)catWindow.Cat);
                lvAnimals.Items.Add(animals[animals.Count - 1].Name);
            }        
        }

        private void btnCreateDog_Click(object sender, RoutedEventArgs e)
        {
            DogWindow dogWindow = new DogWindow(this);
            Opacity = 0.4;
            dogWindow.ShowDialog();
            Opacity = 1;

            if (dogWindow.Success)
            {
                animals.Add((Dog)dogWindow.Dog);
                lvAnimals.Items.Add(animals[animals.Count - 1].Name);
            }
        }

        private void btnDeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lvAnimals.SelectedIndex;

                if (index < 0)
                    throw new ApplicationException((animals.Count == 0) ? "Firstly create yourself a pet" : "Choose one of your pets");

                string animaType = (animals[animals.Count - 1].GetType() == typeof(Cat)) ? "cat" : "dog";
                string file = @$"E:\cSharp\Homeworks\finalProject\InfoFiles\{animaType}{animals[index].Name}.txt";
                if (File.Exists(file))
                {
                    File.Delete(file);
                }

                lvAnimals.Items.RemoveAt(index);
                animals.RemoveAt(index);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    string animaType = (animals[i].GetType() == typeof(Cat)) ? "cat" : "dog";
                    string file = @$"E:\cSharp\Homeworks\finalProject\InfoFiles\{animaType}{animals[i].Name}.txt";
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            lvAnimals.Items.Clear();
            animals.Clear();
        }

        private void btnFeed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lvAnimals.SelectedIndex;

                if(index < 0)
                    throw new ApplicationException((animals.Count == 0)? "Firstly create yourself a pet" : "Choose one of your pets");

                string animaType = (animals[animals.Count - 1].GetType() == typeof(Cat)) ? "cat" : "dog";
                FeedWindow feedWindow = new FeedWindow(this, animaType,
                    animals[index].Name, animals[index].Breed, animals[index].FurColor, animals[index].Age, animals[index].Happiness, animals[index].Fullness);

                Opacity = 0.4;
                feedWindow.ShowDialog();
                Opacity = 1;

                animals[index].Fullness = feedWindow.Fullness;
                animals[index].Happiness = feedWindow.Happiness;
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lvAnimals.SelectedIndex;

                if (index < 0)
                    throw new ApplicationException((animals.Count == 0) ? "Firstly create yourself a pet" : "Choose one of your pets");

                string animaType = (animals[index].GetType() == typeof(Cat)) ? "cat" : "dog";
                PlayWindow playWindow = new PlayWindow(this, animaType,
                    animals[index].Name, animals[index].Breed, animals[index].FurColor, animals[index].Age, animals[index].Happiness);

                Opacity = 0.4;
                playWindow.ShowDialog();
                Opacity = 1;

                animals[index].Happiness = playWindow.Happiness;
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = lvAnimals.SelectedIndex;

                if (index < 0)
                    throw new ApplicationException((animals.Count == 0) ? "Firstly create yourself a pet" : "Choose one of your pets");

                string animalInfo = animals[index].ToString();
                string animaType = (animals[index].GetType() == typeof(Cat)) ? "cat" : "dog";
                InfoWindow infoWindow = new InfoWindow(this, animalInfo, animaType, animals[index].Name);
                infoWindow.Show();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            animals.Sort();
            lvAnimals.Items.Clear();

            foreach (var animal in animals)
                lvAnimals.Items.Add(animal.Name);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Stream serialStream = new FileStream("Animals.xml", FileMode.Create);

                xmlser.Serialize(serialStream, animals);
                serialStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}