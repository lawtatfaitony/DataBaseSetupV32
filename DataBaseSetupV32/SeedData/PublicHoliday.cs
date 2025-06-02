using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseSetupV3.SeedData
{
    public class HolidayNameAndDate
    {
        public string HolidayEnName { get; set; }
        public string HolidayCnName { get; set; } 
        public DateTime HolidayDate { get; set; }
         
    }
    public class PublicHoliday
    {
        static readonly HttpClient client = new HttpClient();
        static JObject holidays;
        public static async Task<JObject> Fetch()
        {
            HttpResponseMessage response = await client.GetAsync("http://www.1823.gov.hk/common/ical/en.json");
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject result = JObject.Parse(responseBody);
            return result;
        }

        private static List<DateTime> Format(JObject data)
        {
            List<DateTime> result = new List<DateTime>();
            List<JToken> holidays = data.SelectTokens("vcalendar[0].vevent").ToList();
            foreach (JToken item in holidays[0])
            {
                dynamic start = item.Value<dynamic>("dtstart");
                string startDate = start[0];
                result.Add(DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture));
            }
            return result;
        }

        public static Task<List<HolidayNameAndDate>> GetListOfHoliday()
        {
            List<HolidayNameAndDate> listOfHolidayNameAndDate = new List<HolidayNameAndDate>();

            JObject holidaysJObject;
            holidaysJObject = Fetch().Result; 
            List<JToken> holidays = holidaysJObject.SelectTokens("vcalendar[0].vevent").ToList();
            foreach (JToken item in holidays[0])
            {
                dynamic start = item.Value<dynamic>("dtstart");
                string startDate = start[0];
                DateTime holidayDate = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                string HolidayEnName = item.Value<string>("summary");
                string holidayCnName = HolidayEnName;
                HolidayNameAndDate holidayNameAndDate = new HolidayNameAndDate
                {
                    HolidayEnName = HolidayEnName,
                    HolidayCnName = holidayCnName,
                    HolidayDate = holidayDate
                };

                listOfHolidayNameAndDate.Add(holidayNameAndDate);
            }
            return Task.FromResult(listOfHolidayNameAndDate);
        }
        public static async Task<Boolean> IsPublicHoliday(DateTime today)
        {
            Boolean result = false;
            if (holidays == null)
            {
                holidays = await Fetch();
            }
            List<DateTime> holidayList = Format(holidays);
            foreach (DateTime holiday in holidayList)
            {
                int compare = DateTime.Compare(holiday, today.Date);
                if (compare == 0)
                {
                    result = true;
                }
            }
            return result;
        } 
    }
}
