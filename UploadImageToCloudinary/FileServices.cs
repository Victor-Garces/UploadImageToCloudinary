using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UploadImageToCloudinary.Models;

namespace UploadImageToCloudinary
{
    static class FileServices
    {
        static readonly string BaseUrl = "http://18.213.233.39:8082/api";
        static readonly HttpClient Client = new HttpClient();

        public static async Task<Guid> GetUserId()
        {
            string uri = $"{BaseUrl}/Accounts";

            var login = new LoginRequest { Email = "victorgarcesgg@gmail.com", Password = "C0mpl3j0" };

            try
            {
                HttpResponseMessage response =
                    await Client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                var responseObject = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                return responseObject.UserId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<string> GetToken(Guid userId)
        {
            string uri = $"{BaseUrl}/Accounts/tokens";

            var tokenRequest = new TokenRequest
            {
                UserId = userId,
                RoleId = 4, 
                SchoolId = Guid.Parse("4D020F62-54B8-E811-8227-12C212B00B62"),
                Identification = Guid.Parse("B10D2878-54B8-E811-8227-12C212B00B62")
            };

            try
            {
                HttpResponseMessage response =
                    await Client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                var responseObject = JsonConvert.DeserializeObject<UserProfile>(responseBody);

                return responseObject.Token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task UploadAttachedFile(AttachedFileRequest attachedFileRequest, String token)
        {
            string uri = $"{BaseUrl}/attachments/files";

            try
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = 
                    await Client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(attachedFileRequest), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
