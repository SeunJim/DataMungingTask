using DataMunging.DTO;
using DataMunging.Helper;

namespace DataMunging.Service
{
    public class MungingService : IMungingService
    {
        private readonly IConfiguration _configuration;

        public MungingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ResponseDto LeaguesForAndAgainst()
        {
            var response = new ResponseDto();
            var readFileToRow = DataHelper.ReadFile(_configuration["FilePath:Soccer"]);
            var ClubName = string.Empty;
            int smallestgoalagainst = int.MaxValue;
            for (int index = 1; index < readFileToRow.Length; index++)
            {
                string[] currentColumns = DataHelper.SplitRow(readFileToRow[index]);
                if (currentColumns.Length >= 4)
                {
                    var club = currentColumns[0] +" "+ currentColumns[1];

                    if ( club != null)
                    {
                        var totalGoalScore = DataHelper.ConvertToInt(currentColumns[6]);
                        var totalGoalAgainst = DataHelper.ConvertToInt(currentColumns[8]);
                        if (totalGoalAgainst.HasValue && totalGoalScore.HasValue)
                        {
                            var GoalDifference = totalGoalScore - totalGoalAgainst;
                            if (GoalDifference < smallestgoalagainst)
                            {
                                ClubName = club;
                                smallestgoalagainst = DataHelper.ConvertToInt2(GoalDifference);
                            };
                        }
                    }
                }
            }
            response.Status = 200;
            response.Message = "Success";
            response.Result = $"The Club with the smallest difference in 'for' and 'against' goals is: {ClubName}";
            return response;
        }

        public ResponseDto SmallestSpreadDayTemp()
        {

            var response = new ResponseDto();
            var readFileToRow = DataHelper.ReadFile(_configuration["FilePath:Weather"]);
            int smallestSpreadDay = 0;
            int smallestSpreadTemp = int.MaxValue;
            for (int index = 2; index < readFileToRow.Length; index++)
            {
                string[] currentColumns = DataHelper.SplitRow(readFileToRow[index]);
                if (currentColumns.Length >= 4)
                {
                    var day = DataHelper.ConvertToInt(currentColumns[0]);

                    if (day.HasValue)
                    {
                        var maxTemperature = DataHelper.ConvertToInt(currentColumns[1]);
                        var minTemperature = DataHelper.ConvertToInt(currentColumns[2]);
                        if (minTemperature.HasValue && maxTemperature.HasValue)
                        {
                            var temperatureSpeed = maxTemperature - minTemperature;
                            if (temperatureSpeed < smallestSpreadTemp)
                            {
                                smallestSpreadDay = DataHelper.ConvertToInt2(day);
                                smallestSpreadTemp = DataHelper.ConvertToInt2(temperatureSpeed);

                            };
                        }
                    }
                }
            }
            response.Status = 200;
            response.Message = "Success";
            response.Result = $"Day with the smallest temperature spread: {smallestSpreadDay}";
            return response;
        }
    }
}
