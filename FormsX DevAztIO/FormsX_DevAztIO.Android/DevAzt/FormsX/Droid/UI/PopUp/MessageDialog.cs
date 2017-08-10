using System;
using Android.App;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using DevAzt.FormsX.UI.PopUp;
using Patrimonio.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DevAzt.FormsX.Droid.UI.PopUp.MessageDialog))]
namespace DevAzt.FormsX.Droid.UI.PopUp
{
    public class MessageDialog : IMessageDialog
    {

        private Context context;
        
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
		public string AlertButtonText {
			get{
				if (string.IsNullOrEmpty(_alertbuttontext)) {
					_alertbuttontext = "Aceptar";
				}
				return _alertbuttontext;
			}
			set{
				_alertbuttontext = value;
			}
		}

		private string _primarybuttontext;
		public string PrimaryButtonText {
			get{
				if (string.IsNullOrEmpty(_primarybuttontext)) {
					_primarybuttontext = "Si";
				}
				return _primarybuttontext;
			}
			set{
				_primarybuttontext = value;
			}
		}

		private string _secondarybuttontext;
		public string SecondaryButtonText {
			get{
				if (string.IsNullOrEmpty(_secondarybuttontext)) {
					_secondarybuttontext = "No";
				}
				return _secondarybuttontext;
			}
			set{
				_secondarybuttontext = value;
			}
		}

        private string _cancelButtonText;
		public string CancelButtonText {
			get{
				if (string.IsNullOrEmpty(_cancelButtonText)) {
					_secondarybuttontext = "Cancelar";
				}
				return _secondarybuttontext;
			}
			set{
				_cancelButtonText = value;
			}
		}

		public string Message {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		private ProgressDialog Dialogo{
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


        public MessageDialog()
        {
            context = MessageDialog.Context;
        }

        public static void Show(string title){
            var context = Android.App.Application.Context;
            Toast.MakeText (context, title, ToastLength.Long).Show ();
		}

		public void ShowToast(){
            Toast.MakeText (context, Message, ToastLength.Long).Show ();
		}

		public void ShowProgressDialog(){
            // instancia del progressdialog
			Dialogo = new ProgressDialog(context);
			// asignamos un mensaje al dialogo de progreso
			Dialogo.SetMessage (Message);
            // lo hacemos anticancelable
            Dialogo.SetCancelable(false);
			// Mostramos el dialogo
			Dialogo.Show ();
		}

		public void Hide(){
			if (Dialogo != null) {
				Dialogo.Hide ();	
			}
		}

        public event EventHandler<SimpleListDialogResult> SimpleListDialogComplete;

        private ArrayAdapter<string> simplelist;

        public void ShowSimpleListDialog(List<string> items)
        {
            AlertDialog.Builder builderSingle = new AlertDialog.Builder(context);
            simplelist = new ArrayAdapter<string>(context, Android.Resource.Layout.SelectDialogSingleChoice, items);
            builderSingle.SetNeutralButton(CancelButtonText, new EventHandler<DialogClickEventArgs>(ListCancel));
            builderSingle.SetAdapter(simplelist, new EventHandler<DialogClickEventArgs>(DialogListItemSelected));
            builderSingle.SetTitle(Title);
            builderSingle.Show();
        }

        private void DialogListItemSelected(object sender, DialogClickEventArgs e)
        {
            if (simplelist != null)
            {
                string item = simplelist.GetItem(e.Which);
                if (SimpleListDialogComplete != null)
                {
                    SimpleListDialogComplete(this, new SimpleListDialogResult(CommandSelected.ItemSelected, CancelButtonText, Id, item));
                }
            }
        }

        private void ListCancel(object sender, DialogClickEventArgs e)
        {
            if (SimpleListDialogComplete != null)
            {
                SimpleListDialogComplete(this, new SimpleListDialogResult(CommandSelected.CancelButtonClicked, CancelButtonText, Id, ""));
            }
        }

        private int SliderValue { get; set; }

        public void ShowSliderDialog()
        {
            SliderValue = 0;
            AlertDialog.Builder builder = new AlertDialog.Builder(context);
            LinearLayout layout = new LinearLayout(context) { Orientation = Orientation.Vertical };
            SeekBar slider = new SeekBar(context);
            TextView cantidad = new TextView(context);
            cantidad.Text = "Numero: 0";
            if (Max > 0)
            {
                slider.Progress = 1;
                SliderValue = 1;
                cantidad.Text = "Numero: 1";
            }
            cantidad.SetPadding(50, 5, 50, 5);
            slider.Max = Max;
            slider.ProgressChanged += (s, e) =>
            {
                cantidad.Text = "Numero: " + e.Progress;
                SliderValue = e.Progress;
            };
            layout.AddView(slider);
            layout.AddView(cantidad);
            builder.SetView(layout);
            builder.SetTitle(Title);
            builder.SetPositiveButton(PrimaryButtonText, new EventHandler<DialogClickEventArgs>(SliderAccept));
            builder.SetNegativeButton(SecondaryButtonText, new EventHandler<DialogClickEventArgs>(SliderCancel));
            var dialog = builder.Create();
            builder.SetCancelable(false);
            dialog.Show();
        }

        public event EventHandler<SliderDialogResult> SliderDialogResult;

        private void OnSliderDialogResult(SliderDialogResult result)
        {
            if(SliderDialogResult != null)
            {
                SliderDialogResult.Invoke(this, result);
            }
        }

        private void SliderCancel(object sender, DialogClickEventArgs e)
        {
            OnSliderDialogResult(new SliderDialogResult(CommandSelected.SecondaryButtonClicked, SecondaryButtonText, Id, 0));
        }

        private void SliderAccept(object sender, DialogClickEventArgs e)
        {
            if(SliderValue != 0)
            {
                OnSliderDialogResult(new SliderDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id, SliderValue));
            }
        }

		public void ShowConfirmDialog(){
			AlertDialog.Builder builder = new AlertDialog.Builder(context);
			builder.SetMessage (Message);
			builder.SetTitle (Title);
            builder.SetCancelable(false);
			builder.SetPositiveButton (PrimaryButtonText, new EventHandler<DialogClickEventArgs> (PrimaryButtonClicked));
			builder.SetNegativeButton (SecondaryButtonText, new EventHandler<DialogClickEventArgs> (SecondaryButtonClicked));
			AlertDialog dialog = builder.Create();
            dialog.CancelEvent += AlertDialog_CancelEvent;
            dialog.Show();
		}

		public void ShowAlert(){
			AlertDialog.Builder builder = new AlertDialog.Builder (context);
            builder.SetMessage(Message);
            builder.SetTitle(Title);
            builder.SetCancelable(false);
            builder.SetNeutralButton(AlertButtonText, new EventHandler<DialogClickEventArgs>(AlertButtonClicked));
            AlertDialog dialog = builder.Create();
            dialog.CancelEvent += AlertDialog_CancelEvent;
            dialog.Show();
        }

		public event EventHandler<AlertClose> AlertCloseComplete;
		private void OnAlertCloseComplete(){
            if(AlertCloseComplete != null)
			    AlertCloseComplete.Invoke(null, new AlertClose());
		}

		void AlertDialog_CancelEvent (object sender, EventArgs e)
		{
            if (AlertCloseComplete != null)
                AlertCloseComplete.Invoke(null, new AlertClose());
		}

		void AlertButtonClicked (object sender, DialogClickEventArgs e)
		{
			OnAlertCloseComplete ();
		}

		private void PrimaryButtonClicked(object sender, DialogClickEventArgs e)
		{
			OnConfirmDialogComplete(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id);
		}

		private void SecondaryButtonClicked(object sender, DialogClickEventArgs e)
		{
			OnConfirmDialogComplete(CommandSelected.SecondaryButtonClicked, SecondaryButtonText, Id);
		}

		public event EventHandler<ConfirmDialogResult> ConfirmDialogComplete;
		private void OnConfirmDialogComplete(CommandSelected command, string buttontext, int id)
		{
            if(ConfirmDialogComplete != null)
            {
                ConfirmDialogComplete.Invoke(null, new ConfirmDialogResult(command, buttontext, id));
            }
		}

        #region EntryDialog

        public event EventHandler<EntryDialogResult> EntryDialogResult;
        private void OnEntryDialogResult(EntryDialogResult result)
        {
            if (EntryDialogResult != null)
            {
                EntryDialogResult.Invoke(this, result);
            }
        }
        
        private string EntryValue { get; set; }
        public static Context Context { get; set; }

        public void ShowEntryDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(context);
            LinearLayout layout = new LinearLayout(context);
            EditText box = new EditText(context);
            box.TextChanged += (sener, args) =>
            {
                EntryValue = args.Text.ToString();
            };
            layout.AddView(box);
            builder.SetView(layout);
            builder.SetTitle(Title);
            builder.SetPositiveButton(PrimaryButtonText, new EventHandler<DialogClickEventArgs>(BoxAccept));
            builder.SetNegativeButton(SecondaryButtonText, new EventHandler<DialogClickEventArgs>(BoxCancel));
            var dialog = builder.Create();
            builder.SetCancelable(false);
            dialog.Show();
        }

        private void BoxCancel(object sender, DialogClickEventArgs e)
        {
            OnEntryDialogResult(new EntryDialogResult(CommandSelected.SecondaryButtonClicked, SecondaryButtonText, Id, string.Empty));
        }

        private void BoxAccept(object sender, DialogClickEventArgs e)
        {
            OnEntryDialogResult(new EntryDialogResult(CommandSelected.PrimaryButtonClicked, PrimaryButtonText, Id, EntryValue));
        }

        #endregion
    }
}

