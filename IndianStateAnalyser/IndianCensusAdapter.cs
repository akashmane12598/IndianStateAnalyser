using IndianStateAnalyser.DTO;
using IndianStateAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateAnalyser
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeader)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeader);

            foreach(String data in censusData)
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contains wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                }

                string[] column = data.Split(",");

                if (csvFilePath.Contains("IndiaStateCode.csv"))
                {
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                }

                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                {
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
                }
            }

            return dataMap.ToDictionary(p=>p.Key, p=>p.Value);
        }
    }
}
