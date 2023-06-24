using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace MetodistApp.WPF
{
    public class MyApiClient
    {
        private readonly HttpClient httpClient;

        public MyApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7120/");
        }

        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            IEnumerable<Tutor> rezult = new List<Tutor>();
            try
            {
                rezult = await httpClient.GetFromJsonAsync<IEnumerable<Tutor>>("Metodist/GetTutors");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
            return rezult;
        }

        public async Task<IEnumerable<Attestation>> GetAttestations()
        {
            IEnumerable<Attestation> rezult = new List<Attestation>();
            try
            {
                rezult = await httpClient.GetFromJsonAsync<IEnumerable<Attestation>>("Metodist/GetAttestations");
            }
            catch
            {

            }
            return rezult;
        }

        public async Task<bool> DeleteTutor(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"Metodist/DeleteTutor?Id={id}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CreateTutor(Tutor tutor)
        {
            var createTutor = JsonSerializer.Serialize(tutor);
            var content = new StringContent(createTutor.ToString(),Encoding.UTF8,"application/json");

            try
            {
                await httpClient.PostAsync("Metodist/CreateTutor",content);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> EditTutor(Tutor tutor)
        {
            var editTutor = JsonSerializer.Serialize(tutor);
            var content = new StringContent(editTutor.ToString(), Encoding.UTF8, "application/json");
            try
            {
                await httpClient.PutAsync("Metodist/UpdateTutor",content);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> RemoveAttestationOnTutor(int tutorId,int attesId)
        {
            
            try
            {
                await httpClient.DeleteAsync($"/Metodist/RemoveAttestationOnTutor?tutorId={tutorId}&attesId={attesId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> AddAttestationToTutor(int tutorId,int attesId)
        {
            var content = new StringContent($"?tutorId={tutorId}&attesId={attesId}", Encoding.UTF8, "application/json");           
            try
            {
                await httpClient.PostAsync($"/Metodist/AddAttestationToTutor",content);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
