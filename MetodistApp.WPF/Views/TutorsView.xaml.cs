using MetodistApp.WPF.ViewModel;
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

namespace MetodistApp.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для TutorsView.xaml
    /// </summary>
    public partial class TutorsView : Page
    {
        public TutorsView()
        {
            InitializeComponent();
            this.DataContext = new MainVm();
        }
    }
}
