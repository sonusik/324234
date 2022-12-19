using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace daaamn
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static spsEntities bd=new spsEntities();
        public static string login_user = "";
        public static string FIO_user = "";
        public static string role_user = "";
        public static yslygi Yslygibd = new yslygi();
        public yslygi yslygi=new yslygi();
        public static int ID;
    }
}
