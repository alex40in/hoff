using System;

namespace Hoff.WebAPI.Curs
{
    public class RadiusInvalidException: Exception
    {
        public string Title { get; }

        public RadiusInvalidException()
            : this("invalid_readius_value", "Точка выходит за установленный радиус окружности")
        {
        }
        public RadiusInvalidException(string title)
            :this(null, title)
        {
        }

        public RadiusInvalidException(string message, string title)
            : base(message)
        {
            Title = title;
        }

        public RadiusInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
