using FormService.WebAPI.Controllers.Requests;

namespace System;

public static class DateOnlyExtensions
{
    public static DateInfo ToDateInfo(this DateOnly dateOnly)
    {
        return new DateInfo(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }
}
