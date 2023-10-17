using ReclutamientoFrontend.Data.Models.Candidate;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace ReclutamientoFrontend.Data.Services.Candidate
{
    public class CandidatoService
    {
        private readonly HttpClient httpClient;
        private readonly string apiName = "api/Candidato/";

        public CandidatoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CandidatoModel>> GetAllCandidatos()
        {
            var httpResponse = await httpClient.GetAsync(apiName);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<List<CandidatoModel>>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return new List<CandidatoModel>();
        }

        public async Task<CandidatoModel> GetCandidatoById(int id)
        {
            var httpResponse = await httpClient.GetAsync(apiName + id);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<CandidatoModel>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return new CandidatoModel();
        }

        public async Task<bool> DeleteCandidato(int id)
        {
            var httpResponse = await httpClient.DeleteAsync(apiName + id);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return false;
        }

        public async Task<bool> UpdateCandidato(int id, CandidatoModel candidato)
        {
            var httpResponse = await httpClient.PutAsJsonAsync(apiName + id, candidato);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return false;
        }

        public async Task<bool> CreateCandidato(CandidatoCreateModel candidato)
        {
            var httpResponse = await httpClient.PostAsJsonAsync(apiName, candidato);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return false;
        }

    }
}
