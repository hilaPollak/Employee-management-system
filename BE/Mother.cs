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
            set
            {
                if (value < 0)//nagative id
                    throw new Exception("this id is not legal");
                id = value;
            }
        }
        public string LastName { get; set; }
        
        public string Name { get; set; }
        public String Phone { get; set; }
        public string Address { get; set; }
        public string AddressForNanny { get; set; }//where the nanny came from
        public bool[] workDays;
        public DateTime[,] workTimePerDay;
        public string Comments { get; set; }//if there are

        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public override string ToString()
        {
            EnumDays day;
            string s = "";
            s += "id: " + id + "\n" + "name: " + Name + "\n" + "last name: " + LastName + "\n" + "phone: " + Phone + "\n" + "address: " + Address + "\n" + "Address For Nanny: " + AddressForNanny + "\n";

            s += "workDays:\n";
            for (int i = 0; i < 6; i++)
            {
                day = (EnumDays)i;
                s += day.ToString() + ": " + workDays[i].ToString() + " ";
            }
            s += "\nwanted WorkHours:\n";
            for (int i = 0; i < 6; i++)
            {
                if (workDays[i])
                {
                    day = (EnumDays)i;
                    s += day.ToString() + ": from ";
                    if (workTimePerDay[0, i].Hour < 10)
                        s += "0";
                    s += workTimePerDay[0, i].Hour.ToString() + ":";
                    if (workTimePerDay[0, i].Minute < 10)
                        s += "0";
                    s += workTimePerDay[0, i].Minute.ToString();
                    s += " to ";
                    if (workTimePerDay[1, i].Hour < 10)
                        s += "0";
                    s += workTimePerDay[1, i].Hour.ToString() + ":";
                    if (workTimePerDay[1, i].Minute < 10)
                        s += "0";
                    s += workTimePerDay[1, i].Minute.ToString() + "  ";
                }
            }
            s += "\n";
            s += "Comments: " + Comments + "\n"; ;
           
            return s;
        }
        public Mother(int id=0)//constructor
        {
            Id = id;
            workDays = new bool[6] { false, false, false, false, false, false };
            workTimePerDay = new DateTime[2, 6];
        }
       
    }
}
