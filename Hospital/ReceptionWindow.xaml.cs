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

namespace Hospital
{
    /// <summary>
    /// </summary>
    public partial class ReceptionWindow : Window
    {
        public ReceptionWindow()
        {
            InitializeComponent();
            dg(reg_dg);
            list_dg(l_dg);
            dg2();
            if(Get.admin!=1)
            {
                doc_edit_b.Visibility = Visibility.Hidden;
                edit_b.Visibility = Visibility.Hidden;
            }
        }
        HospitalDBEntities admin = new HospitalDBEntities();

        public int person_id;

        public void dg2()
        {
            list_datag.ItemsSource = admin.list.ToList();
        }
        public void dg(DataGrid data)
        {
            data.ItemsSource = admin.person.ToList();
        }
        public void list_dg(DataGrid data)
        {
             data.ItemsSource = admin.reception.ToList(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            person a = new person
            {
                name = name_tb.Text,
                surname = surname_tb.Text,
                last_name = last_name_tb.Text,
                b_date = date_dp.SelectedDate,
                adress = adress_tb.Text,
                p_num = num_tb.Text,
                b_type = blood_type_tb.Text,
                insurance_c = ins_tb.Text,
                insurance_num = Int64.Parse(ins_n_tb.Text)
            };
            admin.person.Add(a);
            admin.SaveChanges();
            dg(reg_dg);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            person ts = reg_dg.SelectedItem as person;
            if (ts == null) return;
            admin.person.Remove(ts);
            admin.SaveChanges();
            dg(reg_dg);
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            person ts = reg_dg.SelectedItem as person;
            person_id = ts.id_person;

            reception a = new reception
            {
                id_person = person_id,

            };
            admin.reception.Add(a);
            admin.SaveChanges();
            list_dg(l_dg);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            reception a = l_dg.SelectedItem as reception;
            try
            {
                a.r_date = Convert.ToDateTime(d_p_tb.Text);
            }
            catch (System.FormatException)
            {

            }

            try
            {
                a.l_date = Convert.ToDateTime(d_v_tb.Text);
            }
            catch(System.FormatException)
            {
            
            }
            try
            {
                a.room_num = Int32.Parse(r_num_tb.Text);
            }
            catch(System.FormatException)
            {

            }
            admin.SaveChanges();
            list_dg(l_dg);
        }

        private void reg_dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            person a = reg_dg.SelectedItem as person;
            if (a == null) { return; }

            name_tb.Text= a.name;
            surname_tb.Text=a.surname;
            last_name_tb.Text= a.last_name;
            date_dp.SelectedDate = a.b_date;
            adress_tb.Text = a.adress;
            num_tb.Text = a.p_num;
            blood_type_tb.Text = a.b_type;
            ins_tb.Text = a.insurance_c;
            ins_n_tb.Text = a.insurance_num.ToString();

            admin.SaveChanges();
            dg(reg_dg);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            reception ts = l_dg.SelectedItem as reception;
            if (ts == null) return;
            admin.reception.Remove(ts);
            admin.SaveChanges();
            list_dg(l_dg);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            person a = reg_dg.SelectedItem as person;
            if (a == null) { return; }

            a.name = name_tb.Text;
            a.surname = surname_tb.Text;
            a.last_name = last_name_tb.Text;
            a.b_date = date_dp.SelectedDate;
            a.adress = adress_tb.Text;
            a.p_num = num_tb.Text;
            a.b_type = blood_type_tb.Text;
            a.insurance_c = ins_tb.Text;
            a.insurance_num = Int32.Parse(ins_n_tb.Text);
            
            admin.SaveChanges();
            dg(reg_dg);
        }



        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            person a = reg_dg.SelectedItem as person;
            Get.person_id = a.id_person;
            zapis b = new zapis();
            b.Show();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            list_datag.ItemsSource = admin.list.ToList();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            list ts = list_datag.SelectedItem as list;
            if (ts == null) return;
            admin.list.Remove(ts);
            admin.SaveChanges();
            list_datag.ItemsSource = admin.list.ToList();
        }


        private void Window_Activated(object sender, EventArgs e)
        {
            dg2();
        }

        private void doc_edit_b_Click(object sender, RoutedEventArgs e)
        {
            EditWindow a = new EditWindow();
            a.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            list a = list_datag.SelectedItem as list;
            if (a == null) { return; }
            admin.SaveChanges();
            list_datag.ItemsSource = admin.list.ToList();
        }
    }
}
