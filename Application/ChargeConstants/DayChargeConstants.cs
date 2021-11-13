
using Application.Interfaces;
using System;

namespace Application.ChargeConstants
{
    public sealed class DayChargeConstants : IChargeConstants
    {
        public double Charge { get { return 2.5; } }
        public int StartHour { get { return 12; } }
        public int EndHour { get { return 19; } }
        public string Rate { get { return "PM"; } }

        private static readonly DayChargeConstants instance = new DayChargeConstants();
        static DayChargeConstants()
        {
        }
        private DayChargeConstants()
        {
        }
        public static DayChargeConstants Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
