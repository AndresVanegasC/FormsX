using DevAzt.FormsX.ApplicationModel.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevAzt.FormsX.ApplicationModel.Programming.SimpleAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StandarLogin : ContentPage
    {
        private LoginModel _model;
        public StandarLogin(LoginModel model)
        {
            InitializeComponent();
            BindingContext = model;
            model.Page = this;
            _model = model;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _model.OnLoginClick(new Dictionary<string, string>
            {
                { _model.EntryOne, EntryOne.Text ?? "" },
                { _model.EntryTwo, EntryTwo.Text ?? "" }
            });
        }

        public async void ProgressAction(AsyncCommand command)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                StackProgress.IsVisible = true;
                GridContent.IsVisible = false;
            });

            if (command != null)
            {
                await command.ExecuteAsync(null);
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                StackProgress.IsVisible = false;
                GridContent.IsVisible = true;
            });
        }
    }
}
