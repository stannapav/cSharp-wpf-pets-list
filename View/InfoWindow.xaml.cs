using System;
using System.IO;
using System.Windows;

namespace finalProject.View
{
    public partial class InfoWindow : Window
    {
        string AnimalType, AnimalName;
        private string animalInfo;

        public string AnimalInfo
        {
            get { return animalInfo; }
            set { animalInfo = value; }
        }

        public InfoWindow(Window parentWindow, string animal, string animalType, string animalName)
        {
            DataContext = this;
            Owner = parentWindow;
            AnimalInfo = animal;
            AnimalType = animalType;
            AnimalName = animalName;
            InitializeComponent();  
        }

        private void btnPutInFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string file = @$"E:\cSharp\Homeworks\finalProject\InfoFiles\{AnimalType}{AnimalName}.txt";
                string dir = @$"E:\cSharp\Homeworks\finalProject\InfoFiles";
                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                if (!File.Exists(file))
                {
                    FileStream fs = File.Create(file);
                    fs.Close();
                }
                    

                bool check = false;
                using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
                {
                    string allText = sr.ReadToEnd();
                    if (!allText.Contains(AnimalInfo))
                        check = true;
                    else
                        MessageBox.Show("Info is already in a file.", "Putting...", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                using (StreamWriter sw = new StreamWriter(file, false, System.Text.Encoding.Default))
                {
                    if (check)
                    {
                        sw.WriteLine(AnimalInfo);
                        MessageBox.Show("Info is in file.", "Putting...", MessageBoxButton.OK, MessageBoxImage.Information);
                    }         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}