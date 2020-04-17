using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //MainPage = new NavigationPage()
        }

        async void BtnInformation_Clicked(object sender, EventArgs e)
        {
            await BtnInformation.TranslateTo(100,0,500,Easing.BounceOut);
            await BtnInformation.TranslateTo(0,0);
            ((NavigationPage)this.Parent).PushAsync(new Information());

        }

        async void BtnProcess_Clicked(object sender, EventArgs e)
        {
            await BtnProcess.TranslateTo(100, 0, 500, Easing.BounceOut);
            await BtnProcess.TranslateTo(0, 0);
            ((NavigationPage)this.Parent).PushAsync(new Process());
        }

        async void BtnPresentarInfo_Clicked(object sender, EventArgs e)
        {
            await BtnPresentarInfo.TranslateTo(100, 0, 500, Easing.BounceOut);
            await BtnPresentarInfo.TranslateTo(0, 0);
            ((NavigationPage)this.Parent).PushAsync(new Presentation());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("info", "all good ?", "ok");
        }
    }
}
