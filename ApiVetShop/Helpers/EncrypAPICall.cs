using ConsoleApp1;
using System.IO;

namespace ApiVetShop.Helpers
{
    public class EncrypAPICall
    {
        private HttpClient client = new HttpClient();

        private string CreatePath(string text)
        {
            return "http://localhost:8090/encryp?text=" + text;
        }
        public async Task<ResponseEncryp> GetEncrypt (string text)
        {
            var ResponseModel = new ResponseEncryp();
            HttpResponseMessage response = await client.GetAsync(CreatePath(text));
            if (response.IsSuccessStatusCode)
            {
                ResponseModel = await response.Content.ReadFromJsonAsync<ResponseEncryp>();
            }
            return ResponseModel;

        }
    }
}
