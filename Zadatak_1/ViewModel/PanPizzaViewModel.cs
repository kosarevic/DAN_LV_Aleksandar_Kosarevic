using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class PanPizzaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Ingredient> ChosenIngredients { get; set; }
        public static string PreviousSize = "";

        public PanPizzaViewModel()
        {
            ChosenIngredients = new ObservableCollection<Ingredient>();
            PanPizza = new PanPizza();
            Ingredient = new Ingredient();
        }

        private PanPizza panPizza;

        public PanPizza PanPizza
        {
            get { return panPizza; }
            set
            {
                if (panPizza != value)
                {
                    panPizza = value;
                    OnPropertyChanged("PanPizza");
                }
            }
        }

        private Ingredient ingredient;

        public Ingredient Ingredient
        {
            get { return ingredient; }
            set
            {
                if (ingredient != value)
                {
                    ingredient = value;
                    OnPropertyChanged("Ingredient");
                }
            }
        }

        private Ingredient selectedIngredient;

        public Ingredient SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                if (selectedIngredient != value)
                {
                    selectedIngredient = value;
                    OnPropertyChanged("SelectedIngredient");

                    if (!ChosenIngredients.Contains(selectedIngredient))
                    {
                        ChosenIngredients.Add(selectedIngredient);
                    }
                }
            }
        }

        private int amount;

        public int Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged("Amount");  
                }
            }
        }

        private List<string> size;

        public List<string> Size
        {
            get { return new List<string> { "Velika", "Srednja", "Mala" }; }
            set { size = value; }
        }

        private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients
        {
            get
            {
                return new List<Ingredient>
                {
                new Ingredient("Salama", 10),
                new Ingredient("Sunka", 20),
                new Ingredient("Kulen", 20),
                new Ingredient("Kecap", 5),
                new Ingredient("Majonez", 5),
                new Ingredient("Ljuta Paprika", 5),
                new Ingredient("Masline", 5),
                new Ingredient("Origano", 5),
                new Ingredient("Susam", 5),
                new Ingredient("Sir", 5)
                };
            }
            set { ingredients = value; }
        }

        public void AddToCart()
        {
            int SizeAmount = 0;

            if (PanPizza.Size == "Velika")
            {
                SizeAmount += 300;
            }
            else if (PanPizza.Size == "Srednja")
            {
                SizeAmount += 200;
            }
            else if (PanPizza.Size == "Mala")
            {
                SizeAmount += 100;
            }

            int IngredientAmount = 0;

            foreach (Ingredient i in ChosenIngredients)
            {
                IngredientAmount += i.Price;
            }

            amount = SizeAmount + IngredientAmount;
            OnPropertyChanged("Amount");
            OnPropertyChanged("Ingredient");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
