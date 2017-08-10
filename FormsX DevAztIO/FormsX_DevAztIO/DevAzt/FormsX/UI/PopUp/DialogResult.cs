using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.UI.PopUp
{
    public interface IDialogResult
    {
        CommandSelected CommandSelected { get; set; }
        string ButtonTextSelected { get; set; }
        int IdDialog { get; set; }
    }

    public abstract class DialogResult : IDialogResult
    {
        public CommandSelected CommandSelected
        {
            get;
            set;
        }

        public string ButtonTextSelected
        {
            get;
            set;
        }

        public int IdDialog
        {
            get;
            set;
        }
    }

    public class EntryDialogResult : DialogResult
    {
        public string Value { get; set; }

        public EntryDialogResult(CommandSelected command, string textbutton, int id, string value)
        {
            CommandSelected = command;
            ButtonTextSelected = textbutton;
            IdDialog = id;
            Value = value;
        }
    }

    public class SliderDialogResult : DialogResult
    {
        public int Value { get; set; }

        public SliderDialogResult(CommandSelected command, string textbutton, int id, int value)
        {
            CommandSelected = command;
            ButtonTextSelected = textbutton;
            IdDialog = id;
            Value = value;
        }
    }

    public class SimpleListDialogResult : DialogResult
    {
        public string ItemSelected
        {
            get;
            set;
        }

        public SimpleListDialogResult(CommandSelected command, string textbutton, int id, string elementselected)
        {
            CommandSelected = command;
            ButtonTextSelected = textbutton;
            ItemSelected = elementselected;
            IdDialog = id;
        }
    }

    public class ConfirmDialogResult : DialogResult
    {
        public ConfirmDialogResult(CommandSelected command, string textbutton, int id)
        {
            CommandSelected = command;
            ButtonTextSelected = textbutton;
            IdDialog = id;
        }
    }
}
