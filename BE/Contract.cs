using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public static int staticNumOFContract = 111;// global, the nomber of the contracts
        public int Code { get; set; }//code of the contract, 8 numbers
        public int NannyID { get; set; }
        public int ChildID { get; set; }
        public bool IntroductoryMeeting { get; set; }//if they had Introductory Meeting
        public bool SignContract { get; set; }// if they sign the contract
        public double SalaryForHour { get; set; }
        public double SalaryForMonth { get; set; }
        public EnumPayment TypeOfPayment {get; set; }//the type of the payment- mounth/ hour
        public DateTime StartContract { get; set; }// the start of the deal
        public DateTime EndContract { get; set; }// the end of the deal
        public DateTime[,] WorkHours { get; set; }
        public override string ToString()
        {
            EnumDays day;
            string s = BE.ToString.ToStringProperty(this);
            s += "WorkHours:\n";
            for (int i = 0; i < 6; i++)
            {
                if (WorkHours[0, i] != WorkHours[1, i])
                {
                    day = (EnumDays)i;
                    s += day.ToString() + ": from " + WorkHours[0, i].Hour.ToString() + ":" + WorkHours[0, i].Minute.ToString();
                    s += " to " + WorkHours[1, i].Hour.ToString() + ":" + WorkHours[1, i].Minute.ToString() + " ";
                }
            }
            s += "\n";
            return s;
        }
        public Contract()//copy constructor
        {
            WorkHours = new DateTime[2, 6];
        }
    }
}
