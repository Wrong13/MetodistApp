using Domain.Models;
using MetodistApp.WPF.ViewModel.AsyncCmd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetodistApp.WPF.ViewModel
{
    public class AttestationsVM : INotifyPropertyChanged
    {
        Attestation selectedAttestation;
        public Attestation SelectedAttestation
        {
            get { return selectedAttestation; }
            set { selectedAttestation = value; }
        }
        IEnumerable<Attestation> attestations;
        public IEnumerable<Attestation> Attestations
        {
            get { return attestations; }
            set { attestations = value; OnPropertyChanged(nameof(Attestations)); }
        }



        AsyncCommand editAttestation;
        AsyncCommand deleteAttestation;
        AsyncCommand addAttestation;

        MyApiClient apiClient;
        CollegeListContext db;
        public AttestationsVM()
        {
            apiClient = new MyApiClient();
            LoadTut();
            db = new CollegeListContext();
        }

        public AsyncCommand EditAttestation
        {
            get
            {
                return editAttestation ?? (editAttestation = new AsyncCommand(async () =>
                {

                    if (SelectedAttestation == null)
                    {
                        LoadTut();
                        return;
                    }
                    Views.EditAttestationWindow editAttestationWindow = new Views.EditAttestationWindow(SelectedAttestation);
                    editAttestationWindow.ShowDialog();
                    LoadTut();
                }));
            }
        }

        public AsyncCommand AddAttestation
        {
            get
            {
                return addAttestation ?? (addAttestation = new AsyncCommand(async () =>
                {
                    Views.EditAttestationWindow editAttestationWindow= new Views.EditAttestationWindow(new Attestation(), false);
                    editAttestationWindow.ShowDialog();
                    LoadTut();
                }));
            }
        }

        public AsyncCommand DeleteAttestation
        {
            get
            {
                return deleteAttestation ?? (deleteAttestation = new AsyncCommand(async () =>
                {
                    if (SelectedAttestation == null)
                        return;
                    db.Attestations.Remove(SelectedAttestation);
                    await db.SaveChangesAsync();
                    LoadTut();
                }));
            }
        }

        private async void LoadTut()
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
