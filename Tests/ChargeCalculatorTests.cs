using Application.Calculators;
using Application.ChargeConstants;
using Application.Input;
using Xunit;

namespace Tests
{
    public class ChargeCalculatorTests
    {
        [Theory]
        [InlineData("Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", "0.00")]
        public void CalculateCorrectMotorbikeMorningCharge(string input, string output)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var motorbike = new MotorbikeChargeCalculator();
            var charge = motorbike.CalculateChargeAndDuration(vehicleDuration, MorningChargeConstants.Instance);

            Assert.Equal(output, charge.Item1);


        }

        [Theory]
        [InlineData("Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", "0", "0")]
        public void CalculateCorrectMotorbikeMorningDuration(string input, string outputHours, string outputMinutes)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var motorbike = new MotorbikeChargeCalculator();
            var duration = motorbike.CalculateChargeAndDuration(vehicleDuration, MorningChargeConstants.Instance);

            Assert.Equal((outputHours, outputMinutes), (duration.Item2, duration.Item3));


        }
        [Theory]
        [InlineData("Car: 24/04/2008 11:32 - 24/04/2008 14:42", "0.90")]
        [InlineData("Van: 25/04/2008 10:23 - 28/04/2008 09:02", "7.30")]
        public void CalculateCorrectCarMorningCharge(string input, string output)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var car = new CarChargeCalculator();
            var charge = car.CalculateChargeAndDuration(vehicleDuration, MorningChargeConstants.Instance);

            Assert.Equal(output, charge.Item1);

        }
        [Theory]
        [InlineData("Car: 24/04/2008 11:32 - 24/04/2008 14:42", "0", "28")]
        [InlineData("Van: 25/04/2008 10:23 - 28/04/2008 09:02", "3", "39")]
        public void CalculateCorrectCarMorningDuration(string input, string outputHours, string outputMinutes)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var car = new CarChargeCalculator();
            var duration = car.CalculateChargeAndDuration(vehicleDuration, MorningChargeConstants.Instance);

            Assert.Equal((outputHours, outputMinutes), (duration.Item2, duration.Item3));

        }

        [Theory]
        [InlineData("Car: 24/04/2008 11:32 - 24/04/2008 14:42", "6.70")]
        [InlineData("Van: 25/04/2008 10:23 - 28/04/2008 09:02", "17.50")]
        public void CalculateCorrectCarEveningCharge(string input, string output)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var car = new CarChargeCalculator();

            var charge = car.CalculateChargeAndDuration(vehicleDuration, DayChargeConstants.Instance);
            

            Assert.Equal(output, charge.Item1);


        }

        [Theory]
        [InlineData("Car: 24/04/2008 11:32 - 24/04/2008 14:42", "2", "42")]
        [InlineData("Van: 25/04/2008 10:23 - 28/04/2008 09:02", "7", "0")]
        public void CalculateCorrectCarEveningDuration(string input, string outputHours, string outputMinutes)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);
            var car = new CarChargeCalculator();

            var duration = car.CalculateChargeAndDuration(vehicleDuration, DayChargeConstants.Instance);

            Assert.Equal((outputHours, outputMinutes), (duration.Item2, duration.Item3));

        }

        [Theory]
        [InlineData("Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", "2.00")]
        public void CalculateCorrectMotorbikeEveningCharge(string input, string output)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);

            var motorbike = new MotorbikeChargeCalculator();

            var charge = motorbike.CalculateChargeAndDuration(vehicleDuration, DayChargeConstants.Instance);


            Assert.Equal(output, charge.Item1);

        }

        [Theory]
        [InlineData("Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11", "2", "0")]
        public void CalculateCorrectMotorbikeEveningDuration(string input, string outputHours, string outputMinutes)
        {
            var vehicleDuration = new VehicleDurationInCongestionZone(input);

            var motorbike = new MotorbikeChargeCalculator();

            var duration = motorbike.CalculateChargeAndDuration(vehicleDuration, DayChargeConstants.Instance);


            Assert.Equal((outputHours, outputMinutes), (duration.Item2, duration.Item3));

        }

    }
}
