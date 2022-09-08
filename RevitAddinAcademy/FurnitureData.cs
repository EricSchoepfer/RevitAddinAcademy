using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddinAcademy
{
   public class FurnSet
    {
        public string setType { get; set; }
        public string setName { get; set; }
        public List<String> furnList { get; set; }

        public FurnSet(string _setType, string _setName, string _furnList)
        {
            setType = _setType;
            setName = _setName;
            furnList = GetFurnListFromString(_furnList);
        }

        private List<String> GetFurnListFromString(string list)
        {
            List<String> returnList = list.Split(',').ToList(); 

            return returnList;
        }
    }

    public class FurnData
    {
        public string furnName { get; set; }
        public string familyName { get; set; }
        public string typeNamee { get; set; }

        public FurnData(string _furnName, string _familyName, string _typeName)
        {
            furnName = _furnName;
            familyName = _familyName;
            typeNamee = _typeName;
        }
    }
}
