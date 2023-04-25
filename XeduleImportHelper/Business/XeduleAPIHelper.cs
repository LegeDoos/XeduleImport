﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public XeduleAPIHelper(int personId)
        {
            if (personId == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(personId));
            }
            this.personId = personId;

            int fromYear = DateTime.Now.Month < 8 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
            fromDate = $"{fromYear}-08-01";
            toDate = $"{fromYear+1}-08-01";
        }

        public XeduleAPIHelper(DateTime fromDate, DateTime toDate, int personId) : this(personId)
        {
            this.fromDate = fromDate.ToString("yyyy-MM-dd");
            this.toDate = toDate.ToString("yyyy-MM-dd");
        }

        public string CallAPI()
        {
            string url = $"https://zuyd.myx.nl/api/InternetCalendar?start={fromDate}&end={toDate}&atnId={personId}";
          
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {BearerToken}";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return result;
            }

            return $"{httpResponse.StatusCode}";
        }

    }
}