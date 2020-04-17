using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using calculator.Classes;

namespace calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {

       
        public Test()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //number = Id;
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<calculate>();
                var calculates = conn.Table<calculate>().ToList();
                ValuesListView.ItemsSource = calculates;
            }

        }

    }
}