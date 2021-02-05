using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Reminder.Storage.WebApi.Core;
using System.Net;
using System.Linq;
using System.Text;

namespace Reminder.Storage.WebApi.Client
{
    public class ReminderStorageWebApiClient : IReminderStorage
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseWebApiUrl;

        public ReminderStorageWebApiClient(string baseWebApiUrl)
        {
            if (baseWebApiUrl == null)
            {
                throw new ArgumentNullException(
                    nameof(baseWebApiUrl));

                _baseWebApiUrl = baseWebApiUrl.TrimEnd('/') + '/';
                _httpClient = new HttpClient();
            }


        }
        public void Add(ReminderItem reminderItem)
        {
            HttpResponseMessage response = CallWebApi(
           HttpMethod.Post,
           string.Empty,
           new ReminderItemAddModel(reminderItem));

            //// prepare URL
            //string relativeUrl = string.Empty;

            ////prepare request
            //var request = new HttpRequestMessage(
            //    HttpMethod.Post, _baseWebApiUrl + relativeUrl);

            ////add headers
            //request.Headers.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("*/*"));

            ////prepare model
            //var model = new ReminderItemAddModel(reminderItem);

            ////prepare Request BODY
            //var content = JsonConvert.SerializeObject(model);
            //request.Content = new StringContent(
            //    content,
            //    Encoding.UTF8,
            //    "application/json");

            ////send Request and get REsponse
            //HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult();


            
            //if (response.StatusCode == HttpStatusCode.NotFound)
            //    throw CreateException(response);

            // check rESPONSE STATUS CODES
            if (response.StatusCode != HttpStatusCode.Created)
                throw CreateException(response);

            //read response body
            //parse response model
            //return the result


        }

        public void Update(ReminderItem reminderItem)
        {
            HttpResponseMessage response = CallWebApi(
               HttpMethod.Put,
               reminderItem.Id.ToString(),
               new ReminderItemUpdateModel(reminderItem));

            // check rESPONSE STATUS CODES
            if (response.StatusCode != HttpStatusCode.NoContent)
                throw CreateException(response); 
        }

        public ReminderItem Get(Guid id)
        {
            HttpResponseMessage response = CallWebApi(
                HttpMethod.Get,
                id.ToString());

            //// prepare URL
            //string relativeUrl = id.ToString();

            ////prepare request
            //var request = new HttpRequestMessage(
            //    HttpMethod.Get, _baseWebApiUrl + relativeUrl);

            ////add headers
            //request.Headers.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("*/*"));

            ////prepare model
            ////prepare Request BODY

            ////send Request and get REsponse
            //HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult();

            // check rESPONSE STATUS CODES
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                throw CreateException(response);

            //read response body
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            //parse response model
            ReminderItemGetModel model =
             JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

            if (model == null)
                throw new Exception("Bodu cannot be parsed as ReminderItemGetModel. ");

            //return the result
            return model.ToReminderItem();
        }

        public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int count = -1, int startPosition = 0)
        {
            HttpResponseMessage response = CallWebApi(
           HttpMethod.Get,
           string.Empty);

            //const string relativeUrl = "";

            //var request = new HttpRequestMessage(
            //    HttpMethod.Get, _baseWebApiUrl + relativeUrl);

            //request.Headers.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("*/*"));

            //HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw CreateException(response);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            List<ReminderItemGetModel> list =
             JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

            if (list == null)
                throw new Exception("Bodu cannot be parsed as List<ReminderItemGetModel>");

            return list
                .Select(m => m.ToReminderItem())
                .ToList();
        }


        private Exception CreateException(HttpResponseMessage response)
        {
            return new Exception(
                $"Status code: {response.StatusCode}\n" +
                $"Conent:\n{response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");
        }

        private HttpResponseMessage CallWebApi(
          HttpMethod httpMethod,
          string relativeUrl,
          object model = null)
        {


            var request = new HttpRequestMessage(
              httpMethod, _baseWebApiUrl + relativeUrl);

            request.Headers.Accept.Add(
              new MediaTypeWithQualityHeaderValue("*/*"));

            if (model != null)
            {
                string content = JsonConvert.SerializeObject(model);
                request.Content = new StringContent(
                    content,
                    Encoding.UTF8,
                    "application/json");
            }


            return _httpClient.SendAsync(request).GetAwaiter().GetResult();
        }
 
    }
}
