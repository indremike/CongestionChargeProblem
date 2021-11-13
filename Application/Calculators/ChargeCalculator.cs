using Application.Input;
using Application.Interfaces;
using System;
using System.Globalization;

namespace Application.Calculators
{
    public abstract class ChargeCalculator
    {

        public (String, String, String) CalculateChargeAndDuration(VehicleDurationInCongestionZone input, IChargeConstants constants)
        {
            var duration = new TimeSpan(hours: 0, minutes: 0, seconds: 0);
            var days = input.ExitingDate.Day - input.EnteringDate.Day;

            var charge = 0.0;

            var day = input.EnteringDate;
            for (int i = 1; i < days; i++)
            {
                day = day.AddDays(1);

                if (IsWeekday(day))
                {
                    var chargeAndDuration = CalculateChargeAndDurationForFullDay(constants);
                    charge += chargeAndDuration.Item1;
                    duration += chargeAndDuration.Item2;
                }

            }
            if (!input.EnteringDate.Date.Equals(input.ExitingDate.Date))
            {
                var dt1 = new DateTime(input.EnteringDate.Date.Year, input.EnteringDate.Date.Month, input.EnteringDate.Date.Day, constants.EndHour, 0, 0);
                var dt2 = new DateTime(input.EnteringDate.Date.Year, input.EnteringDate.Date.Month, input.EnteringDate.Date.Day, constants.StartHour, 0, 0);

                var chargeAndDurationForFirstDay = CalculateChargeAndDurationForOneDay(input.EnteringDate, dt1, constants);
                charge += chargeAndDurationForFirstDay.Item1;
                duration += chargeAndDurationForFirstDay.Item2;

                var chargeAndDurationForLastDay = CalculateChargeAndDurationForOneDay(dt2, input.ExitingDate, constants);
                charge += chargeAndDurationForLastDay.Item1;
                duration += chargeAndDurationForLastDay.Item2;
            }
            else
            {
                var chargeAndDurationForFirstDay = CalculateChargeAndDurationForOneDay(input.EnteringDate, input.ExitingDate, constants);
                charge += chargeAndDurationForFirstDay.Item1;
                duration += chargeAndDurationForFirstDay.Item2;
            }

            return (Math.Round(charge, 1, MidpointRounding.ToZero).ToString("0.00", CultureInfo.InvariantCulture), duration.Hours.ToString(), duration.Minutes.ToString());

        }

        public (double, TimeSpan) CalculateChargeAndDurationForFullDay(IChargeConstants constants)
        {
            var duration = constants.EndHour-constants.StartHour;
            return (duration * constants.Charge, new TimeSpan(hours: duration, minutes:0, seconds:0));

        }

        public abstract (double, TimeSpan) CalculateChargeAndDurationForOneDay(DateTime enteringDate, DateTime exitingDate, IChargeConstants constants);

        public bool IsInInterval(DateTime enteringDate, DateTime exitingDate, IChargeConstants constants)
        {
            if (enteringDate.Hour >= constants.StartHour && enteringDate.Hour < constants.EndHour)
                if (exitingDate.Hour >= constants.StartHour && exitingDate.Hour <= constants.EndHour)
                    return true;
            return false;
        }
        
        public bool IsWeekday(DateTime datetime)
        {
            DayOfWeek day = datetime.DayOfWeek;
            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                return false;
            return true;

        }

        
    }
}
