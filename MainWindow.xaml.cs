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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Entity_Framework___WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbMagomEntities db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new dbMagomEntities();
            dataGridView1.ItemsSource = db.Status.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Status status = new Status();
                status.id = Convert.ToInt32(txt_id.Text);
                status.Name = txt_Name.Text;
                status.Gender = comboBoxGender.Text;
                status.Status1 = comboBoxStatus.Text;
                db.Status.Add(status);  
                db.SaveChanges();
                dataGridView1.ItemsSource = db.Status.ToList();
                MessageBox.Show("Добавление прошло успешно!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int update = Convert.ToInt32(txt_id.Text);
                var NewLine = db.Status.Where(w => w.id == update).FirstOrDefault();
                NewLine.Name = txt_Name.Text;
                NewLine.Gender = comboBoxGender.Text;
                NewLine.Status1 = comboBoxStatus.Text;
                db.SaveChanges();
                dataGridView1.ItemsSource = db.Status.ToList();
                MessageBox.Show("Изменение прошло успешно!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int delete = Convert.ToInt32(txt_id.Text);
                var hzhz = db.Status.Where(w => w.id == delete).FirstOrDefault();
                db.Status.Remove(hzhz);
                db.SaveChanges();
                dataGridView1.ItemsSource = db.Status.ToList();
                MessageBox.Show("Удаление прошло успешно!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
