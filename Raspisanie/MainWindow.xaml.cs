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
namespace Raspisanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadOut();
        }

        private void Evolve(string a)
        {
            Connection.On(0);
            SqlCommand cmd = new SqlCommand(a, Connection.MyConnection);
            cmd.ExecuteNonQuery();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Books");
            dataadp.Fill(dt);
            resp_grid.ItemsSource = dt.DefaultView;
            Connection.Off();
        }

        private void LoadOut()
        {
            string query = "select daysOfWeek.title as 'День недели',  cabinet.name as 'Кабинет', predmet.name as 'Предмет', groups.fullName as 'Группа', para.p_start as 'Начало', teachers.firstName as 'Преподаватель' from rasp inner join daysOfWeek on daysOfWeek.id=rasp.day_id inner join cabinet on cabinet.id=rasp.cab_id inner join predmet on predmet.id = rasp.predmet_id inner join groups on groups.id = rasp.group_id inner join para on para.id = rasp.para_id inner join teachers on teachers.id = rasp.teacher_id";
            Evolve(query);
        }
    }
}
