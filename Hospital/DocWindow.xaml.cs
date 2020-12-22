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
    public partial class DocWindow : Window
    {
        public DocWindow()
        {
            string name, surname, lastname;
            InitializeComponent();
            doc b = admin.doc.Where(c => c.id_doc ==Get.doc_id).SingleOrDefault();
            name = b.name;
            surname = b.surname;
            lastname = b.last_name;
            doc_tb.Text = ($"{surname} {name} {lastname}");

            list_dg(dg);
        }
        HospitalDBEntities admin = new HospitalDBEntities();

        public void list_dg(DataGrid data)
        {
            data.ItemsSource = admin.list.ToList();
        }

        private void list_datag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list a = dg.SelectedItem as list;
            if (a == null) { return; }

            c_tb.Text = a.course_name;
            n_tb.Text = a.notes;

            admin.SaveChanges();
            list_dg(dg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list a = dg.SelectedItem as list;
            try
            {
                a.course_name = c_tb.Text;
            }
            catch (System.FormatException)
            {

            }

            try
            {
                a.notes = n_tb.Text;
            }
            catch (System.FormatException)
            {

            }

            admin.SaveChanges();
            list_dg(dg);
        }
    }
}
