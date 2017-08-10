using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento del cuadro de diálogo de contenido está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DevAzt.FormsX.UWP.UI.PopUp
{
    public sealed partial class ProgressDialog : ContentDialog
    {
        public ProgressDialog()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        
        public string Header
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ProgressDialog), new PropertyMetadata(0));
        
        public string Accept
        {
            get { return (string)GetValue(AcceptProperty); }
            set { SetValue(AcceptProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Accept.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AcceptProperty =
            DependencyProperty.Register("Accept", typeof(string), typeof(ProgressDialog), new PropertyMetadata(0));
        
        public string Cancel
        {
            get { return (string)GetValue(CancelProperty); }
            set { SetValue(CancelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cancel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelProperty =
            DependencyProperty.Register("Cancel", typeof(string), typeof(ProgressDialog), new PropertyMetadata(0));
        
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ProgressDialog), new PropertyMetadata(0));
        
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
