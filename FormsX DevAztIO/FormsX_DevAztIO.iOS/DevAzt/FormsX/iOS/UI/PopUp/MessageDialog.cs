using System;
using System.Collections.Generic;
using DevAzt.FormsX.UI.PopUp;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Patrimonio.iOS;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(DevAzt.FormsX.iOS.UI.PopUp.MessageDialog))]
namespace DevAzt.FormsX.iOS.UI.PopUp
{
    public class MessageDialog : IMessageDialog
    {
        private int _max = 0;
        public int Max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
            }
        }

        private string _alertbuttontext = "";
        public string AlertButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_alertbuttontext))
                {
                    _alertbuttontext = "Aceptar";
                }
                return _alertbuttontext;
            }
            set
            {
                _alertbuttontext = value;
            }
        }

        private string _primarybuttontext;
        public string PrimaryButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_primarybuttontext))
                {
                    _primarybuttontext = "Si";
                }
                return _primarybuttontext;
            }
            set
            {
                _primarybuttontext = value;
            }
        }

        private string _secondarybuttontext;
        public string SecondaryButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_secondarybuttontext))
                {
                    _secondarybuttontext = "No";
                }
                return _secondarybuttontext;
            }
            set
            {
                _secondarybuttontext = value;
            }
        }

        private string _cancelButtonText;
        public string CancelButtonText
        {
            get
            {
                if (string.IsNullOrEmpty(_cancelButtonText))
                {
                    _secondarybuttontext = "Cancelar";
                }
                return _secondarybuttontext;
            }
            set
            {
                _cancelButtonText = value;
            }
        }

        public string Message
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        private ProgressDialog Dialogo
        {
            get;
            set;
        }


        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id { get; set; }

        public event EventHandler<AlertClose> AlertCloseComplete;
        public event EventHandler<ConfirmDialogResult> ConfirmDialogComplete;
        public event EventHandler<SimpleListDialogResult> SimpleListDialogComplete;
        public event EventHandler<SliderDialogResult> SliderDialogResult;
        public event EventHandler<EntryDialogResult> EntryDialogResult;

        private void OnAlertCloseComplete(AlertClose result)
        {
            if (AlertCloseComplete != null)
            {
                AlertCloseComplete.Invoke(this, result);
            }
        }

        private void OnConfirmDialogComplete(ConfirmDialogResult result)
        {
            if (ConfirmDialogComplete != null)
            {
                ConfirmDialogComplete.Invoke(this, result);
            }
        }

        private void OnSimpleListDialogComplete(SimpleListDialogResult result)
        {
            if (SimpleListDialogComplete != null)
            {
                SimpleListDialogComplete.Invoke(this, result);
            }
        }

        private void OnSliderDialogResult(SliderDialogResult result)
        {
            if (SliderDialogResult != null)
            {
                SliderDialogResult.Invoke(this, result);
            }
        }

        private void OnEntryDialogResult(EntryDialogResult result)
        {
            if (EntryDialogResult != null)
            {
                EntryDialogResult.Invoke(this, result);
            }
        }

        private void Alert_Dismissed(object sender, UIButtonEventArgs e)
        {
            if (_currenthread != null)
            {
                _currenthread.Abort();
                _currenthread = null;
            }
            OnAlertCloseComplete(new AlertClose());
        }

        private void Alert_Canceled(object sender, EventArgs e)
        {
            OnAlertCloseComplete(new AlertClose());
        }
        
        private System.Threading.Thread _currenthread;
        public void ShowProgressDialog()
        {
            /*
            var bounds = UIScreen.MainScreen.Bounds;
            Dialogo = new ProgressDialog(bounds, Message);
            AppDelegate appdelegate = (AppDelegate) UIApplication.SharedApplication.Delegate;
            var rootController = appdelegate.GetWindow().RootViewController.ChildViewControllers[0].ChildViewControllers[1].ChildViewControllers[0];
            rootController.View.Add(Dialogo);
            */
            if (string.IsNullOrEmpty(Title))
            {
                Title = "Cargando";
            }
            if (string.IsNullOrEmpty(Message))
            {
                Message = "Espere por favor";
            }

            var progressalert = new UIAlertView(Title, Message, null, AlertButtonText);
            progressalert.Dismissed += Alert_Dismissed;
            progressalert.Canceled += Alert_Canceled; 
            progressalert.Show();

            _currenthread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                int i = 0;
                string message = Message;
                while (true)
                {
                    if (i == 0)
                    {
                        message = Message + "   ";
                    }
                    else if (i == 1)
                    {
                        message = Message + ".  ";
                    }
                    else if (i == 2)
                    {
                        message = Message + ".. ";
                    }
                    else if (i == 3)
                    {
                        message = Message + "...";
                        i = -1;
                    }
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        progressalert.Message = message;
                    });
                    i++;
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
            }));
            _currenthread.Start();
        }

        public void Hide()
        {
            if (Dialogo != null)
            {
                Dialogo.Hide();
            }
        }

        public void ShowAlert()
        {
            UIAlertView alert = new UIAlertView(Title, Message, null, AlertButtonText);
            alert.Dismissed += Alert_Dismissed;
            alert.Show();
        }
        
        public void ShowConfirmDialog()
        {
            UIAlertView alertconfirm = new UIAlertView(Title, Message, null, SecondaryButtonText, PrimaryButtonText);
            alertconfirm.Clicked += AlertConfirm_Clicked;
            alertconfirm.Canceled += Alert_Canceled;
            alertconfirm.Dismissed += Alert_Dismissed;
            alertconfirm.Show();
        }

        private void AlertConfirm_Clicked(object sender, UIButtonEventArgs e)
        {
            var uialert = sender as UIAlertView;
            if (e.ButtonIndex == uialert.CancelButtonIndex)
            {
                OnConfirmDialogComplete(new ConfirmDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id));
            }
            else
            {
                OnConfirmDialogComplete(new ConfirmDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id));
            }
        }

        private string EntryValue { get; set; }
        public void ShowEntryDialog()
        {
            UIAlertView alert = new UIAlertView(Title, Message, null, SecondaryButtonText, PrimaryButtonText)
            {
                AlertViewStyle = UIAlertViewStyle.SecureTextInput
            };
            alert.GetTextField(0).Placeholder = "Password";
            alert.GetTextField(0).EditingChanged += (sender, args) => 
            {
                var uitextfield = sender as UITextField;
                if (uitextfield != null)
                {
                     EntryValue = uitextfield.Text;
                }
            };
            alert.Clicked += AlertEntry_Clicked;
            alert.Canceled += Alert_Canceled;
            alert.Dismissed += Alert_Dismissed;
            alert.Show();
        }
        
        private void AlertEntry_Clicked(object sender, UIButtonEventArgs e)
        {
            var uialert = sender as UIAlertView;
            if(e.ButtonIndex == uialert.CancelButtonIndex)
            {
                OnEntryDialogResult(new EntryDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id, string.Empty));
            }
            else
            {
                OnEntryDialogResult(new EntryDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id, EntryValue));
            }
        }
        
        public void ShowSimpleListDialog(List<string> items)
        {
            throw new NotImplementedException();
        }

        public void ShowSliderDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowToast()
        {
            UIAlertView alert = new UIAlertView(Title, Message, null, AlertButtonText);
            alert.Dismissed += Alert_Dismissed;
            alert.Show();
        }
    }
}

