namespace UniversityIot.VitoControlApi.Helpers
{
    using System;
    using UniversityIot.Enums;
    using UniversityIot.Messages;

    public class ValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <returns></returns>
        public string ConvertFromDevice(GatewaySetting setting, string rawValue)
        {
            switch (setting.DataType)
            {
                case SettingDataType.NoConversion:
                    return rawValue;
                case SettingDataType.Div10:
                    return (Convert.ToInt32(rawValue) / 10).ToString();
                default:
                    return rawValue;
            }
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <returns></returns>
        public string ConvertToDevice(GatewaySetting setting, string rawValue)
        {
            switch (setting.DataType)
            {
                case SettingDataType.NoConversion:
                    return rawValue;
                case SettingDataType.Div10:
                    return (Convert.ToInt32(rawValue) * 10).ToString();
                default:
                    return rawValue;
            }
        }
    }
}