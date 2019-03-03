using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
    public class DataSource
    {
        //Here data are saved
        //Only DAL has access

        private static List<Nanny> nannyList = new List<Nanny>();
        public static List<Nanny> NannyList
        { get { return nannyList; } set { nannyList = value; } }

        
       private static List<Mother> motherList = new List<Mother>();
       public static List<Mother> MotherList
       { get { return motherList; } set { motherList = value; } }


        private static List<Child> childList = new List<Child>();
        public static List<Child> ChildList
        { get { return childList; } set { childList = value; } }


        private static List<Contract> contractList = new List<Contract>();
        public static List<Contract> ContractList
        { get { return contractList; } set { contractList = value; } }

    }
}
