﻿
using IndianStateCensusAnalyser.POCO;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;
        public string state;
        public long population;
        public long area;
        public long density;

        public CensusDTO(StateCodeDAO stateCodeDAO)
        {
            this.srNo = stateCodeDAO.srNo;
            this.stateName = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}
