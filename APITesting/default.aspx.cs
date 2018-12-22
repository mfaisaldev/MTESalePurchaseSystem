using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace APITesting
{
    public partial class _default : System.Web.UI.Page
    {
        
        protected async void btn_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(txtApiURL.Text);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("").Result;
                txtResponseCode.Text = response.StatusCode.ToString();
                var json = await response.Content.ReadAsAsync<JObject>();
                txtResponseBody.Text = json.ToString();
            }
            catch (Exception ex)
            {
                txtResponseBody.Text = ex.Message;
                txtResponseCode.Text = "ERROR";
            }
        }

        protected async void btnPOST_Click(object sender, EventArgs e)
        {
            try
            {


                using (var client = new HttpClient())
                {
                    var uri = new Uri(txtApiURL1.Text.ToString());
                    var stringContent = new StringContent(txtRequest1.Text.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, stringContent);
                    txtResponseCode1.Text = response.StatusCode.ToString();
                    var json1 = await response.Content.ReadAsAsync<string>();
                    txtResponseBody1.Text = json1.ToString();
                }
            }
            catch (Exception ex)
            {
                txtResponseBody1.Text = ex.Message;
                txtResponseCode1.Text = "ERROR";
            }
        }

        protected async void btnPUT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var stringContent = new StringContent(txtRequest2.Text.ToString(), Encoding.UTF8, "application/json");
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(txtApiURL2.Text.ToString()),
                        Content = stringContent,
                    };
                    var response = await client.SendAsync(request);
                    txtResponseCode2.Text = response.StatusCode.ToString();
                    var json1 = await response.Content.ReadAsAsync<JObject>();
                    txtResponseBody2.Text = json1.ToString();
                }
            }
            catch (Exception ex)
            {
                txtResponseBody2.Text = ex.Message;
                txtResponseCode2.Text = "ERROR";
            }
        }
    }
}