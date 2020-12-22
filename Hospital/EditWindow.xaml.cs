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
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            datag();
            pos_datag();
            pos_cb.ItemsSource = admin.position.ToList();
        }
        HospitalDBEntities admin = new HospitalDBEntities();

        public void datag()
        {
            dg.ItemsSource = admin.doc.ToList();
        }
        public void pos_datag()
        {
            pos_dg.ItemsSource = admin.position.ToList();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
            datag();
            pos_datag();
            pos_cb.ItemsSource = admin.position.ToList();
        }

        private void add_b_Click(object sender, RoutedEventArgs e)
        {
            doc a = new doc
            {
                name = name_tb.Text,
                surname = surname_tb.Text,
                last_name = last_name_tb.Text,
                p_num = num_tb.Text,
                id_position = pos_cb.SelectedIndex + 1,
                login = log_tb.Text,
                password = pass_tb.Text
            };
            admin.doc.Add(a);
            admin.SaveChanges();
            datag();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doc a = dg.SelectedItem as doc;
            if (a == null) { return; }

            name_tb.Text=a.name;
            surname_tb.Text = a.surname;
            last_name_tb.Text = a.last_name;
            num_tb.Text = a.p_num;
            log_tb.Text = a.login;
            pass_tb.Text = a.password;
        }

        private void del_b_Click(object sender, RoutedEventArgs e)
        {
            doc ts = dg.SelectedItem as doc;
            if (ts == null) return;
            admin.doc.Remove(ts);
            admin.SaveChanges();
            datag();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            position a = new position
            {
                name = pos_tb.Text,
            };
            admin.position.Add(a);
            admin.SaveChanges();
            pos_datag();
            pos_cb.ItemsSource = admin.position.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            position ts = pos_dg.SelectedItem as position;
            if (ts == null) return;
            admin.position.Remove(ts);
            admin.SaveChanges();
            pos_datag();
            pos_cb.ItemsSource = admin.position.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            doc a = dg.SelectedItem as doc;
            if (a == null) { return; }

            a.name = name_tb.Text;
            a.surname = surname_tb.Text;
            a.last_name = last_name_tb.Text;
            a.p_num = num_tb.Text;
            a.login = log_tb.Text;
            a.password = pass_tb.Text;

            admin.SaveChanges();
            datag();
        }
    }
}
