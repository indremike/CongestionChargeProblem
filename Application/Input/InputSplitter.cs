using System;
using System.Globalization;


namespace Application.Input
{
    public static class InputSplitter
    {
        public static String getVehicleType(String input)
        {
            var splittedInputForVehicleType = input.Split(new[] { ':', ' ' }, 2);
            return input.Split(':')[0];
        }
        public static DateTime getEnteringDate(String input)
        {
            var str = input.Split(new string[] { ": ", " - " }, StringSplitOptions.None)[1];
            return DateTime.ParseExact(str, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        public static DateTime getExitingDate(String input)
        {
            var str = input.Split(new string[] { ": ", " - " }, StringSplitOptions.None)[2];
            return DateTime.ParseExact(str, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

    }
}
