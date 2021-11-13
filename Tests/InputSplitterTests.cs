using Application.Input;
using System;
using Xunit;

namespace Tests
{
    public class InputSplitterTests
    {
        public static readonly object[][] CorrectEnteringDateData =
        {
            new object[] { "Car: 24/04/2008 11:32 - 24/04/2008 14:42",new DateTime(2008, 4, 24, 11, 32, 0)},
            new object[] { "Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", new DateTime(2008, 4, 24, 17, 0, 0)},
            new object[] { "Van: 25/04/2008 10:23 - 28/04/2008 09:02", new DateTime(2008, 4, 25, 10, 23, 0)}

        };
        public static readonly object[][] CorrectExitingDateData =
        {
            new object[] { "Car: 24/04/2008 11:32 - 24/04/2008 14:42",new DateTime(2008, 4, 24, 14, 42, 0)},
            new object[] { "Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", new DateTime(2008, 4, 24, 22, 11, 0)},
            new object[] { "Van: 25/04/2008 10:23 - 28/04/2008 09:02", new DateTime(2008, 4, 28, 9, 2, 0)}

        };

        [Theory]
        [InlineData("Car: 24/04/2008 11:32 - 24/04/2008 14:42", "Car")]
        [InlineData("Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", "Motorbike")]
        [InlineData("Van: 25/04/2008 10:23 - 28/04/2008 09:02", "Van")]
        public void HaveCorrectVehicleType(string input, string output)
        {
            Assert.Equal(InputSplitter.getVehicleType(input), output);

        }

        [Theory, MemberData(nameof(CorrectEnteringDateData))]
        public void HaveCorrectEnteringDate(string input, DateTime output)
        {
            var enteringDatetime = InputSplitter.getEnteringDate(input);

            Assert.Equal(enteringDatetime, output);

        }

        [Theory, MemberData(nameof(CorrectExitingDateData))]
        public void HaveCorrectExitingDate(string input, DateTime output)
        {
            var exitingDatetime = InputSplitter.getExitingDate(input);

            Assert.Equal(exitingDatetime, output);

        }
    }
}
