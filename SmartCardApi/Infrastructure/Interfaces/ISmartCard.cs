using SmartCardApi.DataGroups;

namespace SmartCardApi.Infrastructure.Interfaces
{
    public interface ISmartCard
    {
        DG1 DG1();
        DG2 DG2();
        DG7 DG7();
        DG11 DG11();
        DG12 DG12();
        CardSecurity CardSecurity();
    }
}
