using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zadatak_1.Model;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for PanPizzaWindow.xaml
    /// </summary>
    public partial class PanPizzaWindow : Window
    {
        PanPizzaViewModel pvm = new PanPizzaViewModel();

        public PanPizzaWindow()
        {
            InitializeComponent();
            DataContext = pvm;
            BuyBtn.IsEnabled = false;
        }

        private void RemoveIngredient(object sender, RoutedEventArgs e)
        {
            pvm.ChosenIngredients.Remove(pvm.Ingredient);
        }

        private void CalculateAmount(object sender, RoutedEventArgs e)
        {
            if (pvm.ChosenIngredients.Count != 0 && SizeCMB.Text != "")
            {
                BuyBtn.IsEnabled = true;
                SizeCMB.IsEnabled = false;
                IngredientCMB.IsEnabled = false;

                pvm.AddToCart();
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("You must chose pizza size and at least one ingredient. Please try again.", "Notification");
            }
        }

        private void PurchaseBtn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Thank you for buying our pizza!", "Notification");
            pvm = new PanPizzaViewModel();
            DataContext = pvm;
            SizeCMB.IsEnabled = true;
            IngredientCMB.IsEnabled = true;
            BuyBtn.IsEnabled = false;
        }

        private void ClearDemand(object sender, RoutedEventArgs e)
        {
            pvm = new PanPizzaViewModel();
            DataContext = pvm;
            SizeCMB.IsEnabled = true;
            IngredientCMB.IsEnabled = true;
            BuyBtn.IsEnabled = false;
        }

        private void SendSMS(object sender, RoutedEventArgs e)
        {
        }

    }
}
