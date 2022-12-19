using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace daaamn
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
        public Zakaz()
        {
            InitializeComponent();
            b1.Content = "Активные\n заказы";
            b2.Content = "Завершенные\n заказы";
            b3.Content = "Кассовый\n отчёт";
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            activity.Visibility=Visibility.Visible;
            finish.Visibility=Visibility.Collapsed;
            start_box.Visibility=Visibility.Collapsed;
            otzet.Visibility=Visibility.Collapsed;
            status_box.Text = "Активные";
            Update1();
        }

        private void Update1()
        {
            var ListZakaz=App.bd.sotrydnic.Where(p=>p.login==App.login_user && p.last_vhod=="В работе").ToList();
            activity.ItemsSource= ListZakaz;
        }

        private void activity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            activity.Visibility=Visibility.Collapsed;
            finish.Visibility=Visibility.Visible;
            start_box.Visibility=Visibility.Collapsed;
            otzet.Visibility=Visibility.Collapsed;
            status_box.Text = "Завершенные";
            Update2();
        }

        private void Update2()
        {
            var ListZakaz = App.bd.sotrydnic.Where(p => p.login == App.login_user && p.last_vhod == "В работе").ToList();
            finish.ItemsSource = ListZakaz;
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            int summ = 0;

            activity.Visibility=Visibility.Collapsed;
            finish.Visibility=Visibility.Collapsed;
            otzet.Visibility=Visibility.Visible;
            start_box.Visibility=Visibility.Collapsed;
            start_box.Text = "Кассовый отчет";


            List<string> pricelist = new List<string>();
            foreach(var i in App.bd.yslygi.Where(p=>p.price==App.bd.sotrydnic).ToList())
            {
                summ = (int)(summ + i.price);

            }
        }
    }
}
