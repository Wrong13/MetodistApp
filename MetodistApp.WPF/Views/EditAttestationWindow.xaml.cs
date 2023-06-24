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

namespace MetodistApp.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для EditAttestationWindow.xaml
    /// </summary>
    public partial class EditAttestationWindow : Window
    {
        CollegeListContext db;
        public Attestation EditAttestation { get; set; }
        bool IsEdit = true;
        public EditAttestationWindow(Attestation editAttestation,bool isEdit = true)
        {
            InitializeComponent();
            db = new CollegeListContext();
            if (isEdit == true)
            {
                EditAttestation = editAttestation;
            }
            else
            {
                IsEdit = false;
                EditAttestation = new Attestation();
            }
            this.DataContext = EditAttestation;
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {
                db.Attestations.Update(EditAttestation);
            }
            else
            {
                EditAttestation.Date = DateTime.Now;
                db.Attestations.Add(EditAttestation);
            }
            await db.SaveChangesAsync();

        }
    }
}
