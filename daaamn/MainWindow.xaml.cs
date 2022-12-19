using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace daaamn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> namelist = new List<string>();
            List<string> passwordlist= new List<string>();
            List<string> rolelist= new List<string>();
            List<string> flist = new List<string>();
            List<string> loginlist=new List<string>();
            foreach(var i in App.bd.sotrydnic)
            {
                namelist.Add(i.login);
                passwordlist.Add(i.pass);
                rolelist.Add(i.dolzh);
                flist.Add(i.FIO);
                loginlist.Add(i.login);
            }
            for(int i=0; i<namelist.Count;i++ )
            {
                if (namelist[i]==login_box.Text && passwordlist[i]==password_box.Password)
                {
                    App.login_user = loginlist[i];
                    App.role_user = login_box.Text;
                    App.FIO_user = flist[i];
                    if (rolelist[i]=="0")
                    {
                        Zakaz z=new Zakaz();
                        z.Show();
                        Close();
                        break;
                    }
                    else if (rolelist[i]=="1") 
                    {
                        Administrator a = new Administrator();
                        a.Show();
                        Close();
                        break;
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
