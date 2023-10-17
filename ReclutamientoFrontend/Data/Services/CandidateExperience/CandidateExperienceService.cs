using Newtonsoft.Json;
using ReclutamientoFrontend.Data.Models.Candidate;
using ReclutamientoFrontend.Data.Models.CandidateExperience;

namespace ReclutamientoFrontend.Data.Services.CandidateExperience
{
    public class CandidateExperienceService
    {
        private readonly HttpClient httpClient;
        private readonly string apiName = "api/Experiencia/";

        public CandidateExperienceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CandidatoExperienciaModel>> GetAllExperiencia()
        {
            var httpResponse = await httpClient.GetAsync(apiName);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<List<CandidatoExperienciaModel>>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return new List<CandidatoExperienciaModel>();
        }

        public async Task<CandidatoExperienciaModel> GetExperienciaById(int id)
        {
            var httpResponse = await httpClient.GetAsync(apiName + id);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<CandidatoExperienciaModel>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return new CandidatoExperienciaModel();
        }

        public async Task<bool> DeleteExperiencia(int id)
        {
            var httpResponse = await httpClient.DeleteAsync(apiName + id);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return false;
        }

        public async Task<bool> UpdateExperiencia(int id, CandidatoExperienciaModel candidato)
        {
            var httpResponse = await httpClient.PutAsJsonAsync(apiName + id, candidato);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseData = JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
                return responseData;
            }
            return false;
        }

        public async Task<bool> CreateExperiencia(CandidatoExperienciaCreateModel candidato)
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
