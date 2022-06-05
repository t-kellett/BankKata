using System;

namespace Bank
{
    public interface IDateTimeWrapper
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
    public class DateTimeWrapper : IDateTimeWrapper { }
}