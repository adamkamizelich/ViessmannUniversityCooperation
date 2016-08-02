namespace UniversityIot.VitoControlApi.Http.Attributes
{
    using System;

    /// <summary>
    /// Estrella route prefix 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IgnoreQueryBindingAttribute : Attribute
    {
    }
}