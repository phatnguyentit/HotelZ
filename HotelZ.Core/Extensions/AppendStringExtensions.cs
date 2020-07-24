namespace HotelZ.Core.Extensions
{
    public static class AppendStringExtensions
    {
        public static string Dll(this string file)
        {
            return $"{file}.dll";
        }

        public static string Views(this string file)
        {
            return $"{file}.Views";
        }
    }
}
