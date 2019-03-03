using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  

    public class Mother
    {
        private int id;
        public int Id
        {
            get { return id; }
            private set
            {
                if (value < 0)
                    throw new Exception("this id is not legal");
                id = value;
            }
        }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string AddressForNanny { get; set; }//where the nanny came from
        public bool[] workDays;
        public double[,] workTimePerDay;
        public string Comments { get; set; }//if there are

        public override string ToString()
        {
            return "id:" + Id + " name:" + Name + LastName;
        }


    }

    public class Child
    {
        public int Id { get; set; }
        public int MotherId { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool HasSpecialNeeds { get; set; }
        public string SpecialNeeds { get; set; }

        public override string ToString()
        {
            return "id:" + Id + " mother id:" + MotherId + " name:" + Name + LastName;
        }
        public bool Under3Mounth { get; set; }
    }

    public class Contract
    {
        public int Code { get; set; }//8 numbers
        public int NannyID { get; set; }
        public int MotherID { get; set; }
        public int ChildID { get; set; }
        public bool IntroductoryMeeting { get; set; }
        public bool SignContract { get; set; }
        public double SalaryForHour { get; set; }
        public double SalaryForMounth { get; set; }
        public char MonthOrHour { get; set; }//m or h
        public DateTime StartContract { get; set; }
        public DateTime EndContract { get; set; }

        public override string ToString()
        {
            return "contract code:" + Code + " nanny id:" + NannyID + " child id:" + ChildID;
        }
    }
}
