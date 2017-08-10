using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsX_DevAztIO.DevAzt.FormsX.Helpers
{
    public static class CarouselPageHelper
    {

        public static void SelectedIndex(this CarouselPage carouselPage, int index)
        {
            if (index > -1 && index < carouselPage.Children.Count)
            {
                carouselPage.CurrentPage = carouselPage.Children[index];
            }
        }

        public static void Next(this CarouselPage carouselPage, Action notifyend = null)
        {
            var pageCount = carouselPage.Children.Count;
            if (pageCount < 2)
                return;

            var index = carouselPage.Children.IndexOf(carouselPage.CurrentPage);
            index++;
            if (index >= pageCount)
            {
                if (notifyend != null)
                {
                    notifyend.Invoke();
                }
                else
                {
                    index = 0;
                }
            }

            if (index < pageCount)
            {
                carouselPage.CurrentPage = carouselPage.Children[index];
            }
        }

        public static void Back(this CarouselPage carouselPage, Action notifyend = null)
        {
            var pageCount = carouselPage.Children.Count;
            var index = carouselPage.Children.IndexOf(carouselPage.CurrentPage);
            index--;
            if (index < 0)
            {
                if (notifyend != null)
                {
                    notifyend.Invoke();
                }
                else
                {
                    index = pageCount - 1;
                }
            }

            if (index > -1)
            {
                carouselPage.CurrentPage = carouselPage.Children[index];
            }
        }
    }
}
