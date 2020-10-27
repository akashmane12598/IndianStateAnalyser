using IndianStateAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateAnalyser
{
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
