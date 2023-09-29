using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using finalProject.Classes;

namespace finalProject.View
{
    public partial class DogWindow : Window
    {
        List<bool> changes = new List<bool>();
        Regex ageReg = new Regex(@"^[0-9]+$");

        public bool Success { get; set; }
        public object Dog { get; set; }

        public DogWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();

            for (int i = 0; i < 4; i++)
                changes.Add(false);
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Dog = new Dog(tbDogName.Text, tbDogBreed.Text, tbDogFurColor.Text, System.Convert.ToInt32(tbDogAge.Text));
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Success = false;
            Close();
        }

        private void tbDogName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDogName.Text))
                changes[0] = true;
            else
                changes[0] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbDogAge_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDogAge.Text) && ageReg.IsMatch(tbDogAge.Text))
                changes[1] = true;
            else
                changes[1] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbDogBreed_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDogBreed.Text))
                changes[2] = true;
            else
                changes[2] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbDogFurColor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDogFurColor.Text))
                changes[3] = true;
            else
                changes[3] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }
    }
}