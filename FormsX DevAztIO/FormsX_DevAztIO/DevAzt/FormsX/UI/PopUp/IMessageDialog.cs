
using System;
using DevAzt.FormsX.UI.PopUp;
using System.Collections.Generic;

namespace DevAzt.FormsX.UI.PopUp
{
    public interface IMessageDialog
    {
        string AlertButtonText { get; set; }
        string CancelButtonText { get; set; }
        IntPtr Handle { get; }
        int Id { get; set; }
        int Max { get; set; }
        string Message { get; set; }
        string PrimaryButtonText { get; set; }
        string SecondaryButtonText { get; set; }
        string Title { get; set; }

        event EventHandler<AlertClose> AlertCloseComplete;
        event EventHandler<ConfirmDialogResult> ConfirmDialogComplete;
        event EventHandler<SimpleListDialogResult> SimpleListDialogComplete;
        event EventHandler<SliderDialogResult> SliderDialogResult;
        event EventHandler<EntryDialogResult> EntryDialogResult;

        void Hide();
        void ShowAlert();
        void ShowConfirmDialog();
        void ShowEntryDialog();
        void ShowProgressDialog();
        void ShowSimpleListDialog(List<string> items);
        void ShowSliderDialog();
        void ShowToast();
    }
}