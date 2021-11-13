
namespace Application.Interfaces
{
    public interface IChargeConstants
    {
        double Charge { get; }
        int StartHour { get; }
        int EndHour { get; }
        string Rate { get; }
    }
}
