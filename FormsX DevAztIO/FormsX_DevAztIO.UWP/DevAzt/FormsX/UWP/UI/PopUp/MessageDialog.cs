using System;
using System.Collections.Generic;
using DevAzt.FormsX.UI.PopUp;

using Xamarin.Forms;
using System.Threading.Tasks;
using Popups = Windows.UI.Popups;

[assembly: Xamarin.Forms.Dependency(typeof(DevAzt.FormsX.UWP.UI.PopUp.MessageDialog))]
namespace DevAzt.FormsX.UWP.UI.PopUp
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

        public IntPtr Handle
        {
            get
            {
                return default(IntPtr);
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

        public void Hide()
        {
            _dialog.Hide();
        }

        public async void ShowAlert()
        {
            Popups.MessageDialog dialog = new Popups.MessageDialog(Message, Title);
            await dialog.ShowAsync();
        }

        public void ShowConfirmDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowEntryDialog()
        {
            throw new NotImplementedException();
        }

        public ProgressDialog _dialog { get; set; }
        public async void ShowProgressDialog()
        {
            _dialog = new ProgressDialog
            {
                Accept = this.PrimaryButtonText,
                Cancel = this.SecondaryButtonText,
                Header = this.Title,
                Message = this.Message
            };
            await _dialog.ShowAsync();
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
            throw new NotImplementedException();
        }
    }
}

