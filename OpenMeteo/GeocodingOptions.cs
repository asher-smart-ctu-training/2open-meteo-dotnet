﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class GeocodingOptions
    {
        public string Name { get; }
        public string Language { get; }
        public string Format { get; }
        public int Count { get; }

        public GeocodingOptions(string city, string language, string format, int count)
        {
            Name = city;
            Language = language;
            Format = format;
            Count = count;
        }

        public GeocodingOptions(string city)
        {
            Name = city;
            Language = "en";
            Format = "json";
            Count = 100;
        }
    }
}
