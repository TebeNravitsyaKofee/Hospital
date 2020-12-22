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
    public partial class zapis : Window
    {
        public zapis()
        {
            InitializeComponent();
            doc_dg.ItemsSource = admin.doc.ToList();
        }
        HospitalDBEntities admin = new HospitalDBEntities();

        private void doc_dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doc a = doc_dg.SelectedItem as doc;
            Get.doc_id = a.id_doc;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Get.date = Convert.ToDateTime(date_tb.Text);
            Get.time = time_tb.Text;
            ReceptionWindow a = new ReceptionWindow();
            list b = new list
            {
                id_doc = Get.doc_id,
                id_person = Get.person_id,
                a_date = Get.date,
                time = Get.time
            }; 
            admin.list.Add(b);
            admin.SaveChanges();
            a.dg2();
            this.Close();
        }
    }
}
