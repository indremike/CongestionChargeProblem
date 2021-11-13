using Application.ChargeConstants;
using Application.Input;
using System;
using System.Globalization;


namespace Application.Output
{
    public static class Receipt
    {
        public static String GetReceiptString(String input)
        {
            var vehicleInitialInfo = new VehicleDurationInCongestionZone(input);

            var lineForAM = new OutputLine(vehicleInitialInfo, MorningChargeConstants.Instance);
            var stringForAM = lineForAM.ToString();

            var lineForPM = new OutputLine(vehicleInitialInfo, DayChargeConstants.Instance);
            var stringForPM = lineForPM.ToString();

            var totalChargeLine = $"Total Charge: £{GetTotalChargeLine(lineForAM, lineForPM)}";

            return stringForAM + System.Environment.NewLine + stringForPM + System.Environment.NewLine + totalChargeLine;
        }
        private static String GetTotalChargeLine(OutputLine lineForAM, OutputLine lineForPM)
        {
            var totalCharge = Convert.ToDouble(lineForAM.Charge, CultureInfo.InvariantCulture) + Convert.ToDouble(lineForPM.Charge, CultureInfo.InvariantCulture);
            return totalCharge.ToString("0.00", CultureInfo.InvariantCulture);
        }

    }
}
