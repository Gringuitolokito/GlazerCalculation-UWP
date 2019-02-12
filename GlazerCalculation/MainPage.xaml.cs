using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GlazerCalculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {       

        public MainPage()
        {
            this.InitializeComponent();

            //populate tintcolor com-box 
            var tintColor = new List<MainPage.TintColor>();
            tintColor = Enum.GetValues(typeof(MainPage.TintColor))
                .Cast<MainPage.TintColor>()
                .ToList();
            cbTintColor.ItemsSource = tintColor;
                         
            //foreach (var item in cbTintColor.Items) {                 
              //  var comboBoxItem = (ComboBoxItem)item;
                //comboBoxItem.Background = Color;
                //comboBoxItem.Background = new SolidColorBrush();
            //}


            //set it to none
            cbTintColor.SelectedIndex = -1;
        }

        public enum TintColor
        {
            Black,
            Blue,
            Brown
        }

        public TintColor SelectedTintColor { get; set; }

        private void Quantity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                tbSliderValue.Text = slider.Value.ToString();
            }
        }

        private void TintColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var comboBox = (ComboBox)sender;
            //var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            //selectedItem.Background electedItem.Content.ToString();            
            //cbTintColor.Opacity = SelectedTintColor;           

        }

        private void Calculate_Btn(object sender, RoutedEventArgs e)
        {
            TimeStamp.Text = DateTime.Now.ToString("MMMM dd yyyy");

            double width = Convert.ToDouble(tbWidthString.Text);
            double height = Convert.ToDouble(tbHeightString.Text);

            double woodLength = 2 * (width + height) * 3.25;

            wl.Text = "The length of the wood is " + woodLength.ToString() + " feet";

            double glassArea = 2 * (width * height);

            ga.Text = "The area of the glass is " + glassArea.ToString() + " square metres";

            tbWidthString.IsEnabled = false;
            tbHeightString.IsEnabled = false;
            cbTintColor.IsEnabled = false;
            qSlider.IsEnabled = false;
            //wl.IsReadOnly = true;
            //ga.IsReadOnly = true;
            CalcBtn.Visibility = Visibility.Collapsed;
            ResetBtn.Visibility = Visibility.Visible;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeStamp.Text = "...";
            tbWidthString.Text = String.Empty;
            tbHeightString.Text = String.Empty;
            wl.Text = "...";
            ga.Text = "...";
            cbTintColor.SelectedIndex = -1;
            tbWidthString.IsEnabled = true;
            tbHeightString.IsEnabled = true;
            cbTintColor.IsEnabled = true;
            qSlider.IsEnabled = true;
            qSlider.Value = 0;
            tbSliderValue.Text = "...";
            CalcBtn.Visibility = Visibility.Visible;
            ResetBtn.Visibility = Visibility.Collapsed;

        }

        private async void ErrPopUp(String message)
        {
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }

        private void Width_Validation(object sender, TextChangedEventArgs e)
        {
            var widthTextBox = sender as TextBox;
            
            if (int.TryParse(widthTextBox.Text, out int WidthInput) == false && widthTextBox.Text.Length != 0)
            {
                ErrPopUp("Please enter a number.");
                widthTextBox.Text = String.Empty;             
            }

        }

        private void Height_Validation(object sender, TextChangedEventArgs e)
        {
            var heightTextBox = sender as TextBox;
           
            if (int.TryParse(heightTextBox.Text, out int WidthInput) == false && heightTextBox.Text.Length != 0)
            {
                ErrPopUp("Please enter a number.");
                heightTextBox.Text = String.Empty;
                
            }
        }
    }
}