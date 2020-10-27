using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateAnalyser.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public CensusDTO(StateCodeDAO stateCodeDAO)
        {

        }

        public CensusDTO(CensusDataDAO censusDataDAO)
        {

        }


    }
}
