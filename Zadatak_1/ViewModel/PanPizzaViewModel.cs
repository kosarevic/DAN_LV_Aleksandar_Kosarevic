using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class PanPizzaViewModel : INotifyPropertyChanged
    {

        public PanPizzaViewModel()
        {

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



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
