
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAzt.FormsX.UI.PopUp;

namespace DevAzt.FormsX.UI.PopUp
{
    /// <summary>
    /// Support for Android
    /// </summary>
    public class MessageDialog : IMessageDialog
    {
        private IMessageDialog service;

        /// <summary>
        /// Support for Android
        /// </summary>
        public MessageDialog()
        {
            this.service = MessageDialog.Instance;
            this.service.AlertCloseComplete += Service_AlertCloseComplete;
            this.service.ConfirmDialogComplete += Service_ConfirmDialogComplete;
            this.service.SimpleListDialogComplete += MessageDialog_SimpleListDialogComplete;
            this.service.SliderDialogResult += MessageDialog_SliderDialogResult;
            this.service.EntryDialogResult += Service_EntryDialogResult;
        }

        private void Service_EntryDialogResult(object sender, EntryDialogResult e)
        {
            OnEntryDialogResult(e);
        }

        private void MessageDialog_SliderDialogResult(object sender, SliderDialogResult e)
        {
            OnSliderDialogResult(e);
        }

        private void MessageDialog_SimpleListDialogComplete(object sender, SimpleListDialogResult e)
        {
            OnSimpleListDialogComplete(e);
        }

        private void Service_ConfirmDialogComplete(object sender, ConfirmDialogResult e)
        {
            OnConfirmDialogComplete(e);
        }

        private void Service_AlertCloseComplete(object sender, AlertClose e)
        {
            OnAlertCloseComplete(e);
        }
        
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id { get
            {
                return service.Id;
            }
            set
            {
                service.Id = value;
            }
        }

        public string AlertButtonText { get { return service.AlertButtonText; } set { service.AlertButtonText = value; } }
        public string Message { get { return service.Message; } set { service.Message = value; } }
        public string PrimaryButtonText { get { return service.PrimaryButtonText; } set { service.PrimaryButtonText = value; } }
        public string SecondaryButtonText { get { return service.SecondaryButtonText; } set { service.SecondaryButtonText = value; } }
        public string Title { get { return service.Title; } set { service.Title = value; } }
        public string CancelButtonText { get { return service.CancelButtonText; } set { service.CancelButtonText = value; } }
        public int Max { get { return service.Max; } set { service.Max = value; } }

        public event EventHandler<AlertClose> AlertCloseComplete;
        public event EventHandler<ConfirmDialogResult> ConfirmDialogComplete;
        public event EventHandler<SimpleListDialogResult> SimpleListDialogComplete;
        public event EventHandler<SliderDialogResult> SliderDialogResult;
        public event EventHandler<EntryDialogResult> EntryDialogResult;

        private void OnAlertCloseComplete(AlertClose args)
        {
            if (AlertCloseComplete != null)
            {
                AlertCloseComplete.Invoke(this, args);
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

        /// <summary>
        /// Support for Android
        /// </summary>
        public void Hide()
        {
            service.Hide();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowAlert()
        {
            service.ShowAlert();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowConfirmDialog()
        {
            service.ShowConfirmDialog();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowProgressDialog()
        {
            service.ShowProgressDialog();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowToast()
        {
            service.ShowToast();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowSimpleListDialog(List<string> items)
        {
            service.ShowSimpleListDialog(items);
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowSliderDialog()
        {
            service.ShowSliderDialog();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public void ShowEntryDialog()
        {
            service.ShowEntryDialog();
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public static IMessageDialog Instance
        {
            get
            {
                var service = Xamarin.Forms.DependencyService.Get<IMessageDialog>();
                if (service == null) throw new NullReferenceException("El servicio IMessageDialog no puede ser null");
                return service;
            }
        }

        /// <summary>
        /// Support for Android
        /// </summary>
        public static void ShowToast(string text)
        {
            MessageDialog.Instance.Message = text;
            MessageDialog.Instance.ShowToast();
        }

    }
}
