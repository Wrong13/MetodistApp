using Domain.Models;
using MetodistApp.WPF.ViewModel.AsyncCmd;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddAttestation.xaml
    /// </summary>
    public partial class AddAttestation : Window 
    {
        public AddAttestation(Tutor tutor)
        {
            InitializeComponent();
            this.DataContext = new AddAttestationVM(tutor);
            
        }
    }
    class AddAttestationVM : INotifyPropertyChanged
    {
        CollegeListContext db;
        MyApiClient apiClient;
        public Attestation SelectedAttestation { get; set; }
        public IEnumerable<Attestation> Attestations { get; set; }
        public Tutor tutor1 { get; set; }
        public AddAttestationVM(Tutor tutor)
        {
            apiClient = new MyApiClient();
            tutor1 = tutor;
            db = new CollegeListContext();
            LoadAttes();
        }

        AsyncCommand addAttestation { get; set; }

        public AsyncCommand AddAttestation
        {
            get
            {
                return addAttestation ?? (addAttestation = new AsyncCommand(async () =>
                {

                    if (SelectedAttestation == null)
                        return;

                    
                    tutor1.Attestations.Add(SelectedAttestation as Attestation);

                    var EditTutor = db.Tutors.Include(x => x.Attestations).Where(x => x.Id == tutor1.Id).FirstOrDefault();
                    EditTutor.Attestations.Add(SelectedAttestation);
                    db.Tutors.Update(EditTutor);

                    db.SaveChanges();
                }));
            }
        }

        private async void LoadAttes()
        {
            Attestations = await apiClient.GetAttestations();
            OnPropertyChanged(nameof(Attestations));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = " ")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

