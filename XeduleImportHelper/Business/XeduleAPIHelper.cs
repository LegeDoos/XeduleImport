using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace XeduleImportHelper.Business
{
    public class XeduleAPIHelper
    {
        readonly string fromDate = string.Empty;
        readonly string toDate = string.Empty;
        readonly int personId;

        public string BearerToken  { private get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public XeduleAPIHelper()
        {
            int fromYear = DateTime.Now.Month < 8 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
            fromDate = $"{fromYear}-08-01";
            toDate = $"{fromYear + 1}-08-01";
        }

        public XeduleAPIHelper(int personId) : this()
        {
            if (personId == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(personId));
            }
            this.personId = personId;
        }

        public XeduleAPIHelper(DateTime fromDate, DateTime toDate, int personId) : this(personId)
        {
            this.fromDate = fromDate.ToString("yyyy-MM-dd");
            this.toDate = toDate.ToString("yyyy-MM-dd");
        }

        public async Task<string> CallAPIForSchedule()
        {
            string url = $"https://zuyd.myx.nl/api/InternetCalendar?start={fromDate}&end={toDate}&atnId={personId}";
            return await CallApiAsync(url);
        }

        public async Task<string> CallApiForPeeps()
        {
            return await CallApiAsync($"https://zuyd.myx.nl/api/Attendee/Type/Teacher");
        }

        private static readonly HttpClient httpClient = new HttpClient();

        private async Task<string> CallApiAsync(string url)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {BearerToken}");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}
