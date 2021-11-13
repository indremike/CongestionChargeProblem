using Application.Calculators;
using Application.Input;
using Application.Interfaces;
using System;


namespace Application.Output
{
    public class OutputLine
    {
        public string Charge { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Rate { get; set; }


        public OutputLine(VehicleDurationInCongestionZone input, IChargeConstants constants)
        {
            var charge = ("","","");
            if (input.VehicleType == "Motorbike")
            {
                var motorbike = new MotorbikeChargeCalculator();
                charge = motorbike.CalculateChargeAndDuration(input, constants);
            }
            else
            {
                var car = new CarChargeCalculator();
                charge = car.CalculateChargeAndDuration(input, constants);
            }
            this.Charge = charge.Item1;
            this.Hours = charge.Item2;
            this.Minutes = charge.Item3;

            this.Rate = constants.Rate;
            
        }
        public override String ToString()
        {

            var str = $"Charge for {Hours}h {Minutes}m ({Rate} rate): £{Charge}";
            return str;
        }
    }
}
