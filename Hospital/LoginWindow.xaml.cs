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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        HospitalDBEntities a = new HospitalDBEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doc b = a.doc.Where(c => c.login == login_tb.Text && c.password == password_tb.Text).SingleOrDefault();
            try
            { 
                Get.doc_id = b.id_doc;
            }
            catch(System.NullReferenceException)
            {
                Get.doc_id = 1;
            }

            if(b == null)
            {
                MessageBox.Show("Ошибка, повторите введение логина и пароля");
            }
            else if(b.login == "admin" && b.password == "admin")
            {
                Get.admin = 1;
                ReceptionWindow a = new ReceptionWindow();
                a.Show();
                this.Close();
            }
            else if(b.id_position == 1)
            {
                ReceptionWindow a = new ReceptionWindow();
                a.Show();
                this.Close();
            }
            else
            {
                DocWindow a = new DocWindow();
                a.Show();
                this.Close();
            }

        }
    }
}
