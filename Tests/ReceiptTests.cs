using Application.Output;
using System;
using Xunit;


namespace Tests
{
    public class ReceiptTests
    {
        public static readonly object[][] CorrectReceiptData =
{
            new object[] { 
                "Car: 24/04/2008 11:32 - 24/04/2008 14:42",
                $"Charge for 0h 28m (AM rate): £0.90{Environment.NewLine}Charge for 2h 42m (PM rate): £6.70{Environment.NewLine}Total Charge: £7.60"},
            new object[] { 
                "Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11",
                $"Charge for 0h 0m (AM rate): £0.00{Environment.NewLine}Charge for 2h 0m (PM rate): £2.00{Environment.NewLine}Total Charge: £2.00"},
            new object[] {
                "Van: 25/04/2008 10:23 - 28/04/2008 09:02",
                $"Charge for 3h 39m (AM rate): £7.30{Environment.NewLine}Charge for 7h 0m (PM rate): £17.50{Environment.NewLine}Total Charge: £24.80"}

        };

        [Theory, MemberData(nameof(CorrectReceiptData))]
        public void HaveCorrectReceipt(string input, string output)
        {
            var receiptString = Receipt.GetReceiptString(input);
            Assert.Equal(receiptString, output);

        }

    }
}
