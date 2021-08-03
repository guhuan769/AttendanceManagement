using AttendanceRESTful.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        #region Get
#if true
        [TestMethod]
        public void GetTestMethod1()
        {

            //get��ʽ
            var id = "1";
            string result = "";
            HttpResponseMessage response;
            using (HttpClient httpClient = new HttpClient())
            {
                //"https://localhost:44300/api/" + "TodoItems" + "/" + id
                //response = httpClient.GetAsync("https://localhost:44300/api/" + "TodoItems" + "?Id=" + id).Result;
                response = httpClient.GetAsync($"https://localhost:44342/api/TodoItems/{id}").Result;
                //Http��Ӧ�ɹ�
                //response = httpClient.GetAsync("https://localhost:44300/api/" + "TodoItems" + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    //��ȡwebapi�ӿ�����
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            if (result != "")
            {
                //��jsonת��ʵ��
                var tempList = JsonConvert.DeserializeObject<TodoItem>(result);
            }
            ////post��ʽ
            ////����
            //var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            //response = httpClient.PostAsync("��http�ӿڵ�ַ/" + "������/", content).Result;
            ////ȷ��Http��Ӧ�ɹ�
            //if (response.IsSuccessStatusCode)
            //{
            //    result = response.Content.ReadAsStringAsync().Result;
            //}

        }

#endif
        #endregion

        #region Put
        [TestMethod]
        public void PutTestMethod1()
        {

            //get��ʽ
            var id = "1";
            string result = "";
            HttpResponseMessage response;
            using (HttpClient httpClient = new HttpClient())
            {
                TodoItem todoItem = new TodoItem { Id = 1, IsComplete = true, Name = "name" };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(todoItem), Encoding.UTF8, "application/json");
                //"https://localhost:44300/api/" + "TodoItems" + "/" + id
                //response = httpClient.GetAsync("https://localhost:44300/api/" + "TodoItems" + "?Id=" + id).Result;
                response = httpClient.PutAsync($"https://localhost:44342/api/TodoItems/{id}", content).Result;
                //Http��Ӧ�ɹ�
                //response = httpClient.GetAsync("https://localhost:44300/api/" + "TodoItems" + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    //��ȡwebapi�ӿ�����
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            if (result != "")
            {
                //��jsonת��ʵ��
                var tempList = JsonConvert.DeserializeObject<TodoItem>(result);
            }
            ////post��ʽ
            ////����
            //var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            //response = httpClient.PostAsync("��http�ӿڵ�ַ/" + "������/", content).Result;
            ////ȷ��Http��Ӧ�ɹ�
            //if (response.IsSuccessStatusCode)
            //{
            //    result = response.Content.ReadAsStringAsync().Result;
            //}

        }
        #endregion

    }
}
