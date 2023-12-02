using DataMunging.DTO;

namespace DataMunging.Service
{
    public interface IMungingService
    {
        ResponseDto SmallestSpreadDayTemp();
        ResponseDto LeaguesForAndAgainst();
    }
}
