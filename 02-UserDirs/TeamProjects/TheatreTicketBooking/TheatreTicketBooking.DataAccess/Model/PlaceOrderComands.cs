using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TheatreTicketBooking.DataAccess.Model
{
    public class PlaceOrderCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">DateTime - order date</param>
        public void Execute(object parameter)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">DateTime - order date</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return ((DateTime)parameter) > DateTime.Today;
        }

        public event EventHandler CanExecuteChanged;
    }
}
