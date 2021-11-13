using Application.Interfaces;
using System;

namespace Application.ChargeConstants
{
    public sealed class MorningChargeConstants : IChargeConstants
    {
        public double Charge { get { return 2.0; } }
        public int StartHour { get { return 7; } }
        public int EndHour { get { return 12; } }
        public string Rate { get { return "AM"; } }

        private static readonly MorningChargeConstants instance = new MorningChargeConstants();
        static MorningChargeConstants()
        {
        }
        private MorningChargeConstants()
        {
        }
        public static MorningChargeConstants Instance
        {
            get
            {
                return instance;
            }

        }
    }
}

