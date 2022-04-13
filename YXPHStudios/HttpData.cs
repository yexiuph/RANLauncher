using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System;

namespace YXPHStudios
{

    public class Http 
    {
        API api = new API();
        public async Task FindUserAsync(string UserName, string Password)
        {
            var httpClient = new HttpClient();
            var Payload = new Credentials
            {
                username = UserName,
                password = Password,
            };
            var PayloadData = JsonConvert.SerializeObject(Payload);
            var httpContent = new StringContent(PayloadData, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync(api.ROOTURL + "/auth/login", httpContent);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var ResponseData = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                    try { 
                        if (ResponseData.isSuccess)
                        {
                            Process.Start("Game.exe", $"/app_run U={UserName} P={Password}");
                            Application.Exit();

                        }
                        else
                        {
                            MessageBox.Show("Username or Password is incorrect", "ERROR");
                        }
                    } catch (Exception e) {
                            MessageBox.Show($"{e}");
                    }
                }
            
        }
    }
}
