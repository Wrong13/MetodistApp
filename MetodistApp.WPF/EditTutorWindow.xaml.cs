using Domain.Models;
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

namespace MetodistApp.WPF
{
    /// <summary>
    /// Логика взаимодействия для EditTutorWindow.xaml
    /// </summary>
    public partial class EditTutorWindow : Window
    {
        public Tutor EditTutor { get; set; }
        public EditTutorWindow(Tutor editTutor,bool isEdit = true)
        {
            InitializeComponent();
            if (isEdit == true)
            {
                EditTutor = editTutor;
            }
            else
            {
                EditTutor = new Tutor();
            }
            this.DataContext = EditTutor;
        }
    }
}
