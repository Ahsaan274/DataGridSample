using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample
{
    public class ViewModel : NotificationObject
    {
        public ObservableCollection<string> CustomerNames { get; set; }
        public string[] Customers = new string[] { "Adams", "Tim", "Rooney", "Andrew", "Harry" };

        OrderInfoRepository order;
        public ViewModel()
        {
            this.CustomerNames = Customers.ToObservableCollection();
            SetRowstoGenerate(20);
        }

        #region ItemsSource

        private ObservableCollection<OrderInfo> ordersInfo;
        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion
    }

    public class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
