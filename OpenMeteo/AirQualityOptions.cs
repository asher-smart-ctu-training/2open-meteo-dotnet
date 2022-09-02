using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class AirQualityOptions
    {
        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Longitude { get; set; }


        public HourlyOptions Hourly { get { return _hourly; } set { if (value != null) _hourly = value; } }
        public string Domains { get; set; }
        public string Timeformat { get; set; }
        public string Timezone { get; set; }
        public int Past_Days { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }

        private HourlyOptions _hourly = new HourlyOptions();

        public AirQualityOptions()
        {
            Latitude = 0;
            Longitude = 0;
            Hourly = new HourlyOptions();
            Domains = "auto";
            Timeformat = "iso8601";
            Timezone = "GMT";
            Past_Days = 0;
            Start_date = "";
            End_date = "";
        }

        public AirQualityOptions(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Hourly = new HourlyOptions();
            Domains = "auto";
            Timeformat = "iso8601";
            Timezone = "GMT";
            Past_Days = 0;
            Start_date = "";
            End_date = "";
        }

        public AirQualityOptions(float latitude, float longitude, HourlyOptions hourly, string domains, string timeformat, string timezone, int past_Days, string start_date, string end_date)
        {
            Latitude = latitude;
            Longitude = longitude;
            if (hourly != null)
                Hourly = hourly;
            Domains = domains;
            Timeformat = timeformat;
            Timezone = timezone;
            Past_Days = past_Days;
            Start_date = start_date;
            End_date = end_date;
        }

        public class HourlyOptions : IEnumerable<HourlyOptionsParameter>, ICollection<HourlyOptionsParameter>
        {
            public static HourlyOptions All { get { return new HourlyOptions((HourlyOptionsParameter[])Enum.GetValues(typeof(HourlyOptionsParameter))); } }

            public List<AirQualityOptions.HourlyOptionsParameter> Parameter { get { return new List<HourlyOptionsParameter>(_parameter); } }

            public int Count => _parameter.Count;

            public bool IsReadOnly => false;

            private readonly List<HourlyOptionsParameter> _parameter = new List<HourlyOptionsParameter>();

            public HourlyOptions(HourlyOptionsParameter parameter)
            {
                Add(parameter);
            }

            public HourlyOptions(HourlyOptionsParameter[] parameter)
            {
                Add(parameter);
            }

            public HourlyOptions()
            {

            }

            public HourlyOptionsParameter this[int index]
            {
                get { return _parameter[index]; }
                set
                {
                    _parameter[index] = value;
                }
            }

            public void Add(HourlyOptionsParameter param)
            {
                if (this._parameter.Contains(param)) return;

                _parameter.Add(param);
            }

            public void Add(HourlyOptionsParameter[] param)
            {
                foreach (HourlyOptionsParameter paramToAdd in param)
                {
                    Add(paramToAdd);
                }
            }

            public IEnumerator<HourlyOptionsParameter> GetEnumerator()
            {
                return _parameter.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public void Clear()
            {
                _parameter.Clear();
            }

            public bool Contains(HourlyOptionsParameter item)
            {
                return _parameter.Contains(item);
            }

            public void CopyTo(HourlyOptionsParameter[] array, int arrayIndex)
            {
                _parameter.CopyTo(array, arrayIndex);
            }

            public bool Remove(HourlyOptionsParameter item)
            {
                return _parameter.Remove(item);
            }
        }

        public enum HourlyOptionsParameter
        {
            pm10, 
            pm2_5, 
            carbon_monoxide, 
            nitrogen_dioxide, 
            sulphur_dioxide, 
            ozone, 
            aerosol_optical_depth, 
            dust, 
            uv_index, 
            uv_index_clear_sky, 
            alder_pollen, 
            birch_pollen, 
            grass_pollen, 
            mugwort_pollen, 
            olive_pollen, 
            ragweed_pollen
        }
    }
}