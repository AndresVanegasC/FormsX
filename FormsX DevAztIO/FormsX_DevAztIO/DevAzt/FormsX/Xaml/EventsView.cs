using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.Xaml
{
    public interface IEventsView<T>
    {
        /// <summary>
        /// Evento Tapped para la vista
        /// </summary>
        event EventHandler<T> Tapped;

        /// <summary>
        /// Método a ejecutar cuando se realize la acción Tapped
        /// </summary>
        /// <param name="obj"></param>
        void OnTapped(T obj);
    }
}
