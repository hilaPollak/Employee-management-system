using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)// nagative id
                    throw new Exception("this id is not legal");
                id = value;
            }
        }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Elevator { get; set; }// if she has elevator in her build
        public int Floor { get; set; }// which floor she is
        private float seniority;//ותק
        public float Seniority
        {
            get { return seniority; }
            set
            {
                if (value < 0)
                    throw new Exception("this number is not legal");
                seniority = value;
            }
        }
        private int numOfChildren;
        public int NumOfChildren//addition 
        {
            get { return numOfChildren; }
            set
            {
                if (value < 0)
                    throw new Exception("this number is not legal");
                numOfChildren = value;
            }
        }

        private int maxChildrens;
        public int MaxChildrens
        {
            get { return maxChildrens; }
            set
            {
                if (value < 0)
                    throw new Exception("this number is not legal");
                maxChildrens = value;
            }
        }

        private float minMonthesAge;// min age she ready to get
        public float MinMonthesAge
        {
            get { return minMonthesAge; }
            set
            {
                if (value < 0)
                    throw new Exception("this number is not legal");
                minMonthesAge = value;
            }
        }

        private float maxMonthesAge;
        public float MaxMonthesAge
        {

            get { return maxMonthesAge; }
            set
            {
                if (value < 0)
                    throw new Exception("this number is not legal");
                maxMonthesAge = value;
            }
        }
        public bool SalaryByHour { get; set; }// if nanny get salary by hour
        public float SalaryForHour { get; set; }
        public float SalaryForMonth { get; set; }
        public bool[] workDays;
        public DateTime[,] workHours;
        public bool Tmt { get; set; } //if nanny's Vacation are by educationOffice
        public string Recommendations { get; set; }


        public override string ToString()
        {
            EnumDays day;
            string s = "";
            s += "id: " + id + "\n" + "name: " + Name + "\n" + "last name: " + LastName + "\n" + "Date Of Birth: " + DateOfBirth + "\n" + "phone: " + Phone + "\n" + "address: " + Address + "\n";
            s += "Elevator: " + Elevator + "\n" + "Floor: " + Floor + "\n" + "seniority: " + seniority + "\n" + "num Of Children: " + numOfChildren + "\n";
            s += "max Childrens: " + maxChildrens + "\n" + "min Monthes Age: " + minMonthesAge + "\n" + "max Monthes Age: " + maxMonthesAge + "\n";
            s += "Salary By Hour: " + SalaryByHour + "\n" + "Salary For Hour: " + SalaryForHour + "\n" + "Salary For Month: " + SalaryForMonth + "\n";
            s += " workDays:\n";
            for (int i = 0; i < 6; i++)
            {
                day = (EnumDays)i;
                s += day.ToString() + ": " + workDays[i].ToString() + " ";
            }
            s += "\nworkHours:\n";
            for (int i = 0; i < 6; i++)
            {
                if (workDays[i])
                {
                    day = (EnumDays)i;
                    s += day.ToString() + ": from ";
                    if (workHours[0, i].Hour < 10)
                        s += "0";
                    s += workHours[0, i].Hour.ToString() + ":";
                    if (workHours[0, i].Minute < 10)
                        s += "0";
                    s += workHours[0, i].Minute.ToString();
                    s += " to ";
                    if (workHours[1, i].Hour < 10)
                        s += "0";
                    s += workHours[1, i].Hour.ToString() + ":";
                    if (workHours[1, i].Minute < 10)
                        s += "0";
                    s += workHours[1, i].Minute.ToString() + "  ";
                }
            }
            s += "\n";
            s += "work by TMT: " + Tmt + "\n" + "Recommendations: " + Recommendations + "\n";
            return s;
        }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public Nanny(int id=0)//copy constructor
        {
            Id = id;
            workDays = new bool[6] { false, false, false, false, false, false };
            workHours = new DateTime[2, 6];
        }
    }
}
