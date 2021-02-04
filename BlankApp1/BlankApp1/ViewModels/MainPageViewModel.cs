using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BlankApp1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> Items { get; set; }

        public Command AddCommand { get; set; }
        public Command RemoveCommand { get; set; }


        private int _dynamicHeight = 30;
        public int DynamicHeight
        {
            get { return _dynamicHeight; }
            set { SetProperty(ref _dynamicHeight, value); }
        }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.Items = new ObservableCollection<string>() ;
            this.Items.CollectionChanged += (s, e) =>
                    {
                        if (this.Items.Count <= 0)
                            this.DynamicHeight = 30;
                        else
                            this.DynamicHeight = Convert.ToInt32(Math.Ceiling((double)this.Items.Count / 6) * 30);
                    };

            var cnt = 0;
            this.AddCommand = new Command(() =>
            {
                cnt++;            
                Items.Add(cnt.ToString());
            });
            this.RemoveCommand = new Command(() =>
            {
                if (Items.Count <= 0) 
                    return;
                Items.Remove(Items.LastOrDefault());
                
            });
        }

    }
}
