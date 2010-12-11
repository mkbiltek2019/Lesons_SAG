using System;

namespace ChocoPlanet.Business
{
    public static class DateTimeUtility
    {
        public static string GetFormattedDate(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToLongDateString() : "Не задано";
        }
    }
}