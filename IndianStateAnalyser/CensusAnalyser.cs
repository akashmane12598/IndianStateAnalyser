using IndianStateAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateAnalyser
{
    //This is the main class. In UnitTest, this class method is called
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, USA, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCSVData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

    }
}
