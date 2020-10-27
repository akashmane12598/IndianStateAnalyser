using IndianStateAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCSVData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                /*case (CensusAnalyser.Country.USA):
                    return new USCensusAdapter.LoadCensusData(csvFilePath, dataHeaders);*/
                default:
                    throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
