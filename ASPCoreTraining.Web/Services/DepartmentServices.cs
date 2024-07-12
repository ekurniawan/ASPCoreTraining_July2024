using ASPCoreTraining.Web.Models;
using System.Text.Json;

namespace ASPCoreTraining.Web.Services
{
    public class DepartmentServices : IDepartment
    {
        private readonly HttpClient _httpClient;
        public DepartmentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7072/");
        }

        public Task<Department> Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            List<Department> departments = new List<Department>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/Departments");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve departments");
                }
                string content = await response.Content.ReadAsStringAsync();
                departments = JsonSerializer.Deserialize<List<Department>>(content);
                if (departments == null)
                {
                    throw new Exception("Cannot retrieve departments");
                }
                return departments;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public Task<Department> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
