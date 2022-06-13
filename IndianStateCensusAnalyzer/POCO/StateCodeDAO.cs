using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer.POCO
{
    public class StateCodeDAO
    {
        public string serialNumber;
        public string stateName;
        public string tin;
        public string stateCode;

        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = v1;
            this.stateName = v2;
            this.tin = v3;
            this.stateCode = v4;
        }
    }
}
