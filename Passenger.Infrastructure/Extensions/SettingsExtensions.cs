﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T:new()
        {
            var section = typeof(T).Name.Replace("Settings",string.Empty);
            var configValue = new T();
            configuration.GetSection(section).Bind(configValue);

            return configValue;
        } 
    }
}
