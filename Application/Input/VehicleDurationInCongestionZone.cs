using System;

namespace Application.Input
{
    public class VehicleDurationInCongestionZone
    {
        public String VehicleType { get; set; }
        public DateTime EnteringDate { get; set; }
        public DateTime ExitingDate { get; set; }

        public VehicleDurationInCongestionZone(String input) {
            this.VehicleType = InputSplitter.getVehicleType(input);
            this.EnteringDate = InputSplitter.getEnteringDate(input);
            this.ExitingDate = InputSplitter.getExitingDate(input);
        }

    }
}
