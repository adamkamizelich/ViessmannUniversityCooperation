namespace UniversityIot.VitoControlApi.Helpers
{
    using UniversityIot.Messages;

    public interface IValueConverter
    {
        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <returns></returns>
        string ConvertFromDevice(GatewaySetting setting, string rawValue);

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <returns></returns>
        string ConvertToDevice(GatewaySetting setting, string rawValue);
    }
}