using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using finalProject.Classes;

namespace finalProject.View
{
    public partial class CatWindow : Window
    {
        List<bool> changes = new List<bool>();
        Regex ageReg = new Regex(@"^[0-9]+$");

        public bool Success { get; set; }
        public object Cat { get; set; }

        public CatWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();

            for (int i = 0; i < 4; i++)
                changes.Add(false);
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Cat = new Cat(tbCatName.Text, tbCatBreed.Text, tbCatFurColor.Text, System.Convert.ToInt32(tbCatAge.Text));
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Success = false;
            Close();
        }

        private void tbCatName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCatName.Text))
                changes[0] = true;
            else
                changes[0] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbCatAge_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCatAge.Text) && ageReg.IsMatch(tbCatAge.Text))
                changes[1] = true;
            else
                changes[1] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbCatBreed_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCatBreed.Text))
                changes[2] = true;
            else
                changes[2] = false;

            if (changes[0] == true && changes[1] == true && changes[2] == true && changes[3] == true)
                btnDone.IsEnabled = true;
            else
                btnDone.IsEnabled = false;
        }

        private void tbCatFurColor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCatFurColor.Text))
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