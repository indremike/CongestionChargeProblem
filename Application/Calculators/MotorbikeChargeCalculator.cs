using Application.Interfaces;
using System;


namespace Application.Calculators
{
    public class MotorbikeChargeCalculator : ChargeCalculator
    {
        public const double FlatRate = 1.0;

        public override (double, TimeSpan) CalculateChargeAndDurationForOneDay(DateTime enteringDate, DateTime exitingDate, IChargeConstants constants)
        {
            var duration = new TimeSpan(hours: 0, minutes:0, seconds: 0);
            if (enteringDate.Hour < constants.StartHour)
                enteringDate = new DateTime(enteringDate.Date.Year, enteringDate.Date.Month, enteringDate.Date.Day, constants.StartHour, 0, 0);

            if (exitingDate.Hour >= constants.EndHour)
                exitingDate = new DateTime(exitingDate.Date.Year, exitingDate.Date.Month, exitingDate.Date.Day, constants.EndHour, 0, 0);


            if (IsWeekday(enteringDate) && IsInInterval(enteringDate, exitingDate, constants))
            {
                exitingDate = exitingDate.AddDays(-exitingDate.Day);
                enteringDate = enteringDate.AddDays(-enteringDate.Day);
                duration = exitingDate.Subtract(enteringDate);
                return (duration.Hours * FlatRate + (duration.Minutes / 60.0) * FlatRate, duration);

            }
            return (0.0, duration);

        }
    }
}
