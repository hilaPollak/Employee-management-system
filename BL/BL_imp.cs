using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi;
using System.Configuration;
using GoogleMapsApi.Entities.Directions.Response;
using BE;
using System.Threading;


namespace BL
{

    public class BL_imp : IBL
    {
        DAL.Idal dal;

        #region constructor
        public BL_imp()//ctor
        {
            dal = DAL.factory_dal.GetDal();
            init();
        }
        public void init()
       {
            //add example for xaml windows


            //DateTime d = new DateTime(2000, 1, 1, 8, 30, 0);
            //bool[] helpkeepingDays = new bool[6] { true, true, false, true, true, true };
            //DateTime[,] helpworkHours = new DateTime[2, 6];
            //for (int i = 0; i < 6; i++)//time of work
            //{
            //    helpworkHours[0, i] = new DateTime(2000, 1, 1, 8, 0, 0);//start work
            //    helpworkHours[1, i] = new DateTime(2000, 1, 1, 17, 10, 0);//end work
            //}
            //this.AddNanny(new Nanny(2433)
            //{
            //    Name = "Hila",
            //    LastName = "Shamay",
            //    DateOfBirth = new DateTime(1997, 4, 4),
            //    Phone = "0503434343",
            //    Address = "HaRav Uziel Jerusalem Israel",
            //    Elevator = false,
            //    Floor = 1,
            //    Seniority = 2,
            //    NumOfChildren = 0,
            //    MaxChildrens = 3,
            //    MinMonthesAge = 4,
            //    MaxMonthesAge = 30,
            //    SalaryByHour = false,
            //    SalaryForHour = 130,
            //    SalaryForMonth = 2000,
            //    workDays = helpkeepingDays,
            //    workHours = helpworkHours,
            //    Tmt = true,
            //    Recommendations = "",
            //    Password = "1234",
            //    CheckPassword = "1234"



            //});


            //bool[] helpkeepingDays1 = new bool[6] { true, true, false, true, true, false };
            //DateTime[,] helpworkHours1 = new DateTime[2, 6];
            //for (int i = 0; i < 6; i++)//time of work
            //{
            //    helpworkHours1[0, i] = new DateTime(2000, 1, 1, 9, 0, 0);
            //    helpworkHours1[1, i] = new DateTime(2000, 1, 1, 16, 10, 0);
            //}

            //this.AddMother(new Mother(9097)
            //{
            //    Name = "Orit",
            //    LastName = "Frankel",
            //    Phone = "0508787878",
            //    Address = "Yafo Center Jerusalem Israel",
            //    AddressForNanny = "Yafo Center Jerusalem Israel",
            //    workDays = helpkeepingDays1,
            //    workTimePerDay = helpworkHours1,
            //    Comments = "my child need a lovely nanny",
            //    Password = "orit",
            //    CheckPassword = "orit"
            //});


            //this.AddChild(new Child(1943, 9097)
            //{
            //    Name = "Moshe",
            //    DateOfBirth = new DateTime(2017, 1, 3),
            //    HasSpecialNeeds = true,
            //    SpecialNeeds = "Allergic to peanuts"
            //});

            //this.AddContract(new Contract
            //{
            //    NannyID = 2433,
            //    ChildID = 1943,
            //    IntroductoryMeeting = true,
            //    SignContract = true,
            //    TypeOfPayment = (EnumPayment)1,
            //    StartContract = new DateTime(2017, 12, 12),
            //    EndContract = new DateTime(2018, 12, 12),


            //});

            //this.AddNanny(new Nanny(167)
            //{
            //    Name = "Roni",
            //    LastName = "Dalumi",
            //    DateOfBirth = new DateTime(1997, 6, 11),
            //    Phone = "0535732453",
            //    Address = "Yasmin,Kiryat Shmona,Israel",
            //    Elevator = true,
            //    Floor = 3,
            //    Seniority = 2,
            //    NumOfChildren = 0,
            //    MaxChildrens = 6,
            //    MinMonthesAge = 10,
            //    MaxMonthesAge = 31,
            //    SalaryByHour = true,
            //    SalaryForHour = 40,
            //    SalaryForMonth = 2000,
            //    workDays = helpkeepingDays,
            //    workHours = helpworkHours,
            //    Tmt = false,
            //    Recommendations = "",
            //    Password = "1111",
            //    CheckPassword = "1111"
            //});

            //this.AddNanny(new Nanny(2087)
            //{
            //    Name = "Eden",
            //    LastName = " Ben Zaken",
            //    DateOfBirth = new DateTime(1982, 5, 6),
            //    Phone = "0504564564",
            //    Address = "Aviv,Eilat,Israel",
            //    Elevator = false,
            //    Floor = 3,
            //    Seniority = 10,
            //    NumOfChildren = 0,
            //    MaxChildrens = 10,
            //    MinMonthesAge = 10,
            //    MaxMonthesAge = 46,
            //    SalaryByHour = true,
            //    SalaryForHour = 70,
            //    SalaryForMonth = 2000,
            //    workDays = helpkeepingDays1,
            //    workHours = helpworkHours1,
            //    Tmt = false,
            //    Recommendations = "",
            //    Password = "shoshana",
            //    CheckPassword = "shoshana"
            //});
            //bool[] helpkeepingDays2 = new bool[6] { false, true, false, true, true, false };
            //DateTime[,] helpworkHours2 = new DateTime[2, 6];
            //for (int i = 0; i < 6; i++)
            //{
            //    helpworkHours2[0, i] = new DateTime(2000, 1, 1, 8, 0, 0);
            //    helpworkHours2[1, i] = new DateTime(2000, 1, 1, 16, 0, 0);
            //}

            //this.AddMother(new Mother(8169)
            //{
            //    Name = "Shiri",
            //    LastName = "Maimon",
            //    Phone = "0501231231",
            //    Address = "kasuto ,Jerusalem,Israel",
            //    AddressForNanny = "Dizengoff,Tel Aviv,Israel",
            //    workDays = helpkeepingDays2,
            //    workTimePerDay = helpworkHours2,
            //    Comments = "my child need to eat every 1 hour",
            //    Password = "xxx",
            //    CheckPassword = "xxx"
            //});

            //this.AddChild(new Child(1800, 8169)
            //{
            //    Name = "Dani",
            //    DateOfBirth = new DateTime(2016, 7, 10),
            //    HasSpecialNeeds = true,
            //    SpecialNeeds = "need to eat every 1 hour"
            //});

            //this.AddChild(new Child(1823, 8169)
            //{
            //    Name = "Gadi",
            //    DateOfBirth = new DateTime(2018, 9, 3),
            //    HasSpecialNeeds = true,
            //    SpecialNeeds = "need love"
            //});

            //this.AddContract(new Contract
            //{
            //    NannyID = 2087,
            //    ChildID = 1800,
            //    IntroductoryMeeting = true,
            //    SignContract = true,
            //    TypeOfPayment = (EnumPayment)1,
            //    StartContract = new DateTime(2017, 05, 12),
            //    EndContract = new DateTime(2018, 12, 12)
            //});

            //this.AddChild(new Child(9887, 8169)
            //{
            //    Name = "David",
            //    DateOfBirth = new DateTime(2016, 12, 12),
            //    HasSpecialNeeds = false,
            //    SpecialNeeds = ""
            //});
            //this.AddContract(new Contract
            //{
            //    NannyID = 2087,
            //    ChildID = 9887,
            //    IntroductoryMeeting = true,
            //    SignContract = true,
            //    TypeOfPayment = (EnumPayment)1,
            //    StartContract = new DateTime(2017, 12, 12),
            //    EndContract = new DateTime(2018, 6, 12)
            //});

            //this.AddMother(new Mother(6655)
            //{
            //    Name = "Jane",
            //    LastName = "Bordeaue",
            //    Phone = "0507897897",
            //    Address = "shachal,Jerusalem,Israel",
            //    AddressForNanny = "Kanfey Nesharim,Jerusalem,Israel",
            //    workDays = helpkeepingDays2,
            //    workTimePerDay = helpworkHours2,
            //    Comments = "my child need to sleep between 14:00 to 16:00",
            //    Password = "einav",
            //    CheckPassword = "einav"
            //});
            //this.AddChild(new Child(2224, 6655)
            //{
            //    Name = "David",
            //    DateOfBirth = new DateTime(2015, 7, 10),
            //    HasSpecialNeeds = false,
            //    SpecialNeeds = ""
            //});

        }


        #endregion

        #region GoogleMaps
        static string API_KEY = ConfigurationSettings.AppSettings.Get("googleApiKey");
        /// <summary>
        /// calculate the distance between 2 adresses
        /// </summary>
        /// <param name="source">when coming</param>
        /// <param name="dest">were going</param>
        /// <returns></returns>
        public int CalcDistance(string source, string dest)
        {

            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;

        }

        /// <summary>
        /// Get autocomplete results as you type
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            //Set a request to which we enter the beginning of the string and Api
            GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request
                = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest();
            request.ApiKey = API_KEY;
            request.Input = str;
            var response = GoogleMaps.PlaceAutocomplete.Query(request);//insert to response
            foreach (var item in response.Results)//add the response to the list 
            {
                result.Add(item.Description);
            }
            return result;
        }
        /// <summary>
        /// retuen the distance between 2 places
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public double distance(string source, string destination)
        {
            try
            {
                return CalcDistance(source, destination);
            }
            catch
            {
                throw new Exception("Distance calculation failed");
            }
        }
        #endregion
    

    #region getting list function 

    /// This function search all the nannies that predicate is true for them
    /// </summary>
    /// <param name="predicate">The predicate that all the nannies be checked by it</param>
    /// <returns>IEnumerable of all nannies that predicate is true for them</returns>
    public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null) { return (dal.GetAllNanny(predicate)); }

        /// <summary>
        /// This function search all the mothers that predicate is true for them
        /// </summary>
        /// <param name="predicate">The predicate that all the mothers be checked by it </param>
        /// <returns>IEnumerable of all mothers that predicate is true for them </returns>
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null) { return dal.GetAllMother(predicate); }

        /// <summary>
        /// This function get predicate and need to find all the children that this predicate true for them
        /// </summary>
        /// <param name="predicate">The predicate that all the children be checked by it</param>
        /// <returns>IEnumerable of all the childrens that the predicate true for them</returns>
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null) { return dal.GetAllChild(predicate); }


        /// <summary>
        /// This function get predicate and need to find all the Contracts that this predicate true for them
        /// </summary>
        /// <param name="predicate">The predicate that all the Contracts be checked by it</param>
        /// <returns>IEnumerable of all the Contracts that the predicate true for them</returns>
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null) { return dal.GetAllContract(predicate); }
        #endregion

        #region Nanny

        /// <summary>
        /// This function get nanny and  add her for NannyList by dal
        /// </summary>
        /// <param name="n"> The nanny that need to be added to NannyList</param>
        public void AddNanny(Nanny n)
        {
            if ((DateTime.Now - n.DateOfBirth).Days / 365 < 18)// nanny under 18 years
                throw new Exception(" nanny under 18 years old\n");
         
            dal.AddNanny(n);
        }


        /// <summary>
        /// This function get nanny id and need to remove her from NannyList by DAL
        /// </summary>
        /// <param name="id">The id of the nanny to delete</param>
        /// <returns>True if this nanny delete sucsses</returns>
        public bool DeleteNanny(int id)
        {
            return (dal.DeleteNanny(id));
        }


        /// <summary>
        /// This function get nanny and need to update her in NannyList by DAL
        /// </summary>
        /// <param name="n">The nanny that need to be updated</param>
        public void UpDateNanny(Nanny n)
        {
            if ((DateTime.Now - n.DateOfBirth).Days / 365 < 18)// nanny  under 18 years 
                throw new Exception(" nanny under 18 years old\n");
           
            dal.UpDateNanny(n);
            List<Contract> lc = GetAllContract(co => co.NannyID == n.Id).ToList();
            foreach (var item in lc)//updates all the contracts that the nanny is in them
            {
                if (item == null)
                    break;
                UpDateContract(item);
            }
        }


        /// <summary>
        /// This function get nanny id and search the nanny in NannyList by DAL
        /// </summary>
        /// <param name="id"> The id of the nanny to search</param>
        /// <returns>The nanny that id it's her id if she exist </returns>
        public Nanny FindNanny(int id)
        {
            return (dal.FindNanny(id));
        }
        #endregion

        #region Mother

        /// <summary>
        /// This function get mother and need to add her for MotherList by DAL
        /// </summary>
        /// <param name="m">The mother that need to be added</param>
        public void AddMother(Mother m)
        {
            dal.AddMother(m);
        }


        /// <summary>
        /// This function get id of mother and need to remove her from MotherList by DAL
        /// </summary>
        /// <param name="id">The id of the mother to delete</param>
        /// <returns>True if this mother delete sucsses</returns>
        public void DeleteMother(int id)
        {
             dal.DeleteMother(id);
        }


        /// <summary>
        /// This function get mother and need to update her in MotherList by DAL
        /// </summary>
        /// <param name="m">The mother that need to update</param>
        public void UpDateMother(Mother m)
        {
            try
            { 
                dal.UpDateMother(m);
                List<Contract> lc = GetAllContract(co => FindChild(co.ChildID).IdMother == m.Id).ToList();
                foreach (var item in lc)//updates all the contracts that the mother is in them
                {
                    if (item == null)
                        break;
                    UpDateContract(item);
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// This function get mother id and search that mother in the MotherList by DAL.
        /// </summary>
        /// <param name="id">The id of the mother to search</param>
        /// <returns>The mother that id it's her id</returns>
        public Mother FindMother(int id)
        {
            return dal.FindMother(id);
        }

        #endregion

        #region Child

        /// <summary>
        /// This function get child and add him for ChildList by DAL
        /// </summary>
        /// <param name="child">The child to add</param>
        public void AddChild(Child child)
        {
            dal.AddChild(child);
        }


        /// <summary>
        /// This function get child id and need to delete this child from ChildList by DAL
        /// </summary>
        /// <param name="id">The child to delete</param>
        /// <returns>True if this child delete success</returns>
        public bool DeleteChild(int id)
        {
            return dal.DeleteChild(id);
        }


        /// <summary>
        /// This function get child and need to update this child in ChildList by DAL
        /// </summary>
        /// <param name="child">The child to update</param>
        public void UpDateChild(Child child)
        {
            dal.UpDateChild(child);
        }


        /// <summary>
        /// This function get child id find this child.
        /// </summary>
        /// <param name="id">The id of the child to search</param>
        /// <returns>Child if the child exist</returns>
        public Child FindChild(int id)
        {
            return (dal.FindChild(id));
        }
        #endregion

        #region Contract

        /// <summary>
        /// This function get a number of contract and remove this contract from ContractList by DAL
        /// </summary>
        /// <param name="code">The code of contract to delete</param>
        /// <returns>True if the contract delete success</returns>
        public bool DeleteContract(int code)
        {
            return (dal.DeleteContract(code));
        }


        /// <summary>
        /// This function gets number of contract and searches that contract
        /// </summary>
        /// <param name="code">The code of contract to search</param>
        /// <returns>Contract if this contract exist</returns>
        public Contract FindContract(int code)
        {
            return dal.FindContract(code);
        }


        /// <summary>
        /// This function get a contract and need to add it to ContractList by DAL
        /// </summary>
        /// <param name="c">The contract to add</param>
        public void AddContract(Contract c)
        {
            if (c == null)
                return;
            Child ch = FindChild(c.ChildID);// find the child according the id in contract
            Mother m = FindMother(ch.IdMother);// find the mother according the id in contract
            Nanny n = FindNanny(c.NannyID);// find the nanny according the id in contract
            if (n != null)
            {
                if (n.MaxChildrens <= n.NumOfChildren)//if the nanny already has max children 
                    throw new Exception("the nanny can not get more children\n");
               
                if ((DateTime.Now - ch.DateOfBirth).Days / 30 < 3)//the child is under 3 muonthes
                    throw new Exception("ERROR- the child is under 3 monthes old\n");

                int countDays = 0;//sum all the days that are success in the contract
                int count = 0;//sum all the days that are false in the contract

                for (int i = 0; i < 6; i++)//inserts the hours to the contract, the hours that in the mother hours and in the nanny hours
                {
                    if (m.workDays[i] && n.workDays[i])//need keeping in each day
                    {
                        countDays++;
                        if (m.workTimePerDay[0, i] < n.workHours[0, i])//mother wants ending earlier
                            c.WorkHours[0, i] = n.workHours[0, i];//like nanny
                        else
                            c.WorkHours[0, i] = m.workTimePerDay[0, i];//like mother

                        if (m.workTimePerDay[1, i] > n.workHours[1, i])//mother wants ending later
                            c.WorkHours[1, i] = n.workHours[1, i];// like nanny
                        else
                            c.WorkHours[1, i] = m.workTimePerDay[1, i];//like mother
                        if (c.WorkHours[1, i] < c.WorkHours[0, i])
                        //if in this day there are no equal hours, *the contract will not be exist*
                        {
                            c.WorkHours[0, i] = c.WorkHours[1, i];//the start hour will be the end hour
                            count++;//sum all the days that are false in the contract
                        }

                    }

                }
                n.NumOfChildren++;
                UpDateNanny(n);
                if (count == countDays)// no any day that with equal hours betweem mother and nanny 
                    throw new Exception("can not add this contract (problem with adjusting hours)\n ");
                float hours = 0;
                for (int i = 0; i < 6; i++)//sum of the hours that in the contract to concluse salary in the contract
                {
                    TimeSpan t = c.WorkHours[1, i] - c.WorkHours[0, i];// concluse time by hour
                    hours += t.Hours;
                    hours += (float)(t.Minutes / (60.0));
                    hours += (float)(t.Seconds / (3600.0));
                }
                c.SalaryForMonth = CalculateSalary(c);//salary for mounth
                c.SalaryForHour = c.SalaryForMonth / (hours * 4);//salary for hour
                if (n.SalaryByHour)//nanny works per hour
                    c.TypeOfPayment = (EnumPayment)0;
                else//nanny works per mounth
                    c.TypeOfPayment = (EnumPayment)1;
            }
        

            dal.AddContract(c);//add the contract
            if (GetAllBrothers(c) != null)// the child has brother
            {
                List<Child> temp = GetAllBrothers(c).ToList();
                Contract tempContract = null;
                for (int i = 0; i < temp.Count; i++)
               //get all the brothers of the child in contract  that had contract with the same nanny and update their contract
                {
                    tempContract = (GetAllContract().ToList()).FirstOrDefault(co => (co.ChildID == temp[i].Id && co.NannyID == c.NannyID));
                    UpDateContract(tempContract);
                }
            }
        }


        /// <summary>
        /// This function get a contract and need to update this contract in ContractList by DAL
        /// </summary>
        /// <param name="c">The contract to update</param>
        public void UpDateContract(Contract c)
        {
            if (c == null)
                return;
            Nanny n = FindNanny(c.NannyID);// find the nanny according the id in contract
            Child ch = FindChild(c.ChildID);// find the mother according the id in contract
            Mother m = FindMother(ch.IdMother);// find the child according the id in contract
            if ((DateTime.Now - ch.DateOfBirth).Days / 30 < 3)//the child is under 3 monthes
                throw new Exception("ERROR- the child is under 3 monthes old\n");
            int counter = 0;
            for (int i = 0; i < 6; i++)//inserts the hours to the contract, the hours that in the mother hours and in the nanny hours
             // like AddContract- see remarks
            {
                if (m.workDays[i] && n.workDays[i])
                {
                    if (m.workTimePerDay[0, i] < n.workHours[0, i])//mother wants earlier
                        c.WorkHours[0, i] = n.workHours[0, i];
                    else
                        c.WorkHours[0, i] = m.workTimePerDay[0, i];
                    if (m.workTimePerDay[1, i] > n.workHours[1, i])//mother wants later
                        c.WorkHours[1, i] = n.workHours[1, i];
                    else
                        c.WorkHours[1, i] = m.workTimePerDay[1, i];
                    if (c.WorkHours[1, i] < c.WorkHours[0, i])//if in this day there are no equal hours- the contract will not be exist
                    //
                    {
                        c.WorkHours[0, i] = c.WorkHours[1, i];
                        counter++;//sum all the days that are false in the contract
                    }

                }

            }
            // like AddContract- see remarks
            if (counter == 6)//if there are no any day that with equal hours 
                throw new Exception("can not add this contract (problem with adjusting hours)\n");
            float hours = 0;
            for (int i = 0; i < 6; i++)
            {
                TimeSpan t = c.WorkHours[1, i] - c.WorkHours[0, i];
                hours += t.Hours;
                hours += (float)(t.Minutes / (60.0));
                hours += (float)(t.Seconds / (3600.0));
            }
            c.SalaryForMonth = CalculateSalary(c);//salary for month
            c.SalaryForHour = c.SalaryForMonth / (hours * 4);//salary for hour
            if (n.SalaryByHour)//nanny works per hour
                c.TypeOfPayment = (EnumPayment)0;
            else//nanny works per month
                c.TypeOfPayment = (EnumPayment)1;
            dal.UpDateContract(c);
        }

        #endregion

        #region Groping


        /// <summary>
        /// This function grouping all the nannies by their min or max children age
        /// </summary>
        /// <param name="max">If true, grouping by the max children age.else, grouping by the min children age </param>
        /// <param name="order">If true, grouping in order by the max or min children age.else, grouping without any order</param>
        /// <returns>IEnumerable of all the grouping</returns>
        public IEnumerable<IGrouping<float, Nanny>> GroupingNannyByAge(bool max, bool order = false)
        //the first group can be 3 month and jump by 3 month. 
        {
            IEnumerable<IGrouping<float, Nanny>> ageGroups = null;
            if (order && !max)//need order, grouping by min children age
            {
                ageGroups = from w in GetAllNanny()
                            orderby w.MinMonthesAge
                            group w by (float)((int)(w.MinMonthesAge / 3) * 3);
            }
            if (!order && !max)// do not need order, grouping by min children age
            {
                ageGroups = from w in GetAllNanny()
                            group w by (float)((int)(w.MinMonthesAge / 3) * 3);
            }
            if (order && max)//need order, grouping by max children age
            {
                ageGroups = from w in GetAllNanny()
                            orderby w.MaxMonthesAge
                            group w by (float)((int)(w.MaxMonthesAge / 3) * 3);
            }
            if (!order && max)//do not need order, grouping by max children age
            {
                ageGroups = from w in GetAllNanny()
                            group w by (float)((int)(w.MaxMonthesAge / 3) * 3);
            }
            return ageGroups;

        }


        /// <summary>
        /// This function grouping all the nannies by their distance(km) from mother request address
        /// </summary>
        /// <param name="order">If it's true, grouping with order by distance.else,do not need any order</param>
        /// <returns>IEnumerable of all the grouping</returns>
        public IEnumerable<IGrouping<int, Contract>> GroupingOfDistance(bool order)
        {
            IEnumerable<IGrouping<int, Contract>> grouping;
            if (order)//according to order
            {
                grouping = from w in GetAllContract()
                           let m = FindMother(FindChild(w.ChildID).IdMother)
                           let dis = distance(m.Address, FindNanny(w.NannyID).Address)
                           orderby dis
                           group w by (((int)dis / 5) + 1) * 5;
            }

            else
            {
                grouping = from w in GetAllContract()
                           let m = FindMother(FindChild(w.ChildID).IdMother)
                           group w by (((int)distance(m.Address, FindNanny(w.NannyID).Address) / 5) + 1) * 5;
            }
            return grouping;
        }

        #endregion


        /// <summary>
        /// This function get contract and search all the brother of the child  that in the same nanny
        /// </summary>
        /// <param name="c">The contract that the child is in it, and the func searches brotheres of it's child</param>
        /// <returns>IEnummerable of all the brother of the child that in this contract that in the same nanny</returns>
        public IEnumerable<Child> GetAllBrothers(Contract c)
        {
            //the child of the contract never will be in the result. 
            {
                if (c == null)
                    return null;
                Child ch = FindChild(c.ChildID);// find the child according the id in contract
                Mother m = FindMother(ch.IdMother);// find the mother according the id in contract
                Nanny n = FindNanny(c.NannyID);// find the nanny according the id in contract
                IEnumerable<Child> brothers = GetAllChild(chHELP => (chHELP.IdMother == chHELP.IdMother) && chHELP.Id != chHELP.Id);
                //all the brothers without child
                IEnumerable<Contract> nannyContracts = GetAllContract(co => co.NannyID == c.NannyID);
                //all the contract that nanny is in them
                return from nc in nannyContracts//all the brothers of this child that are in the same nanny
                       from b in brothers
                       where nc.ChildID == b.Id// the same brother
                       select b;
            }
        }


        /// <summary>
        /// This function calculate the salary for month  
        /// </summary>
        /// <param name="c">The contract that need a salary Calculate </param>
        /// <returns>The salary for month according contract details</returns>
        public float CalculateSalary(Contract c)
        {
            if (c == null)
                return 0;
            int numOfBrothers = 0;
            Child ch = FindChild(c.ChildID);// find the child according the id in contract
            Mother m = FindMother(ch.IdMother);// find the mother according the id in contract
            Nanny n = FindNanny(c.NannyID);// find the nanny according the id in contract
            IEnumerable<Child> brothers = GetAllBrothers(c);//all the brother without the child in the contract
            if (brothers != null)
            {
                List<Child> lst = brothers.ToList<Child>().ToList();//to list
                numOfBrothers = (lst.Count);//num of brothers
            }
            float hours = 0;
            float salary = 0;
            if (n.SalaryByHour)//if the nanny get salery per hour
            {
                for (int i = 0; i < 6; i++)//sum of  the hours that nanny work to mother
                {
                    if (m.workDays[i] && n.workDays[i])
                    {
                        TimeSpan t = c.WorkHours[1, i] - c.WorkHours[0, i];
                        hours += t.Hours;
                        hours += (float)(t.Minutes / (60.0));// to hour
                        hours += (float)(t.Seconds / (3600.0));// to hour
                    }
                }
                salary = hours * (n.SalaryForHour) * 4;//the money for month without any reduction(if the nanny take per hour)
            }
            else
                salary = n.SalaryForMonth;//the money for month without any reduction(if the nanny take per month)
            return (float)(1 - 0.02 * numOfBrothers) * salary;//return the salary with reduction 
        }


        /// <summary>
        /// This function checks if the nanny hours and days match to the mother's requests
        /// </summary>
        /// <param name="mother">The mother that the nanny need to be match for her</param>
        /// <param name="nanny">The nanny that the function checkes matching between her mother</param>
        /// <returns>True if the nanny match to mother requests </returns>
        public bool CheckMatch(Mother mother, Nanny nanny)
        {
            if (nanny == null || mother == null)
                throw new Exception("mother or nanny does not exist\n");
            for (int i = 0; i < 6; i++)//check matching
            {
                if (mother.workDays[i] == true)// only cases that mother wants this day (i)
                {
                    if (mother.workDays[i] == true && nanny.workDays[i] == false)//if the mother wants a day that the nanny does not work 
                        return false;
                    if (mother.workTimePerDay[0, i] < nanny.workHours[0, i])//if the mother wants a hour that the nanny does not work 
                        return false;
                    if (mother.workTimePerDay[1, i] > nanny.workHours[1, i])//if the mother wants a hour that the nanny does not work 
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        /// This function searches for the 5 most close to the mother's wanted hours
        /// </summary>
        /// <param name="m">The mother that nannies need to be close for her requests</param>
        /// <returns>Ienumerable for the 5 most close nannies</returns>
        public IEnumerable<Nanny> Get5BestMatchNannies(Mother m)//maybe less than 5, if the nannies list shorter
        {
            if (m == null)
                throw new Exception("the mother does not exist\n");
            IEnumerable<Nanny> match = GetAllWantedNannies(m);//by the mother hours
            if (match.ToList().Count != 0)
                //if there are nanny that works in all the hours that the mother wants 
                return match;//returns IEnumerable of those nannies

            //if there are no nannies with a perfect matching;
            var v = from item in GetAllNanny()
            //v will contain all the nannies order by the func preferNanny, that calculates number of hours that the mother wanted
                    orderby PreferNanny(m, item)
                    select item;

            List<Nanny> help = v.ToList<Nanny>();
            for (int i = 5; i < help.Count; i++)//takes the 5 best match nannies
            {
                help.Remove(help[i]);
            }
            return (help.AsEnumerable());//5 best nannies

        }


        /// <summary>
        /// This function searches for all the nannies that match to mother's wanted hours
        /// </summary>
        /// <param name="m">The mother that the nannies need to be match for her</param>
        /// <returns>IEnumerable of all the match nannies</returns>
        public IEnumerable<Nanny> GetAllWantedNannies(Mother m)
        {
            if (m == null)
                throw new Exception("the mother does not exist\n");
            return GetAllNanny(na => CheckMatch(m, na));//help by match function
        }


        /// <summary>
        /// This function calculates the num of hours that the mother need a nanny but this spesific nanny can not work in those hours
        /// </summary>
        /// <param name="mother">The mother that need nanny for spesific hours</param>
        /// <param name="nanny">The nanny that for her it calculate the hours</param>
        /// <returns>Num of hours that the mother need a nanny but this spesific nanny can not work in those hours</returns>
        public float PreferNanny(Mother mother, Nanny nanny)
        {
            if (nanny == null || mother == null)
                throw new Exception("Mother or nanny does not exist\n");
            float sum = 0;
            TimeSpan t;
            for (int i = 0; i < 6; i++)//calculates the hours
            {
                if (mother.workDays[i] == true)// mother needs nanny in this day
                {
                    if (nanny.workDays[i] == false)
                    // nanny does not work in this
                    {
                        t = mother.workTimePerDay[1, i] - mother.workTimePerDay[0, i];// takes all the hours of the mother
                        sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                    }
                    else// the mother needs nanny in this day and the nanny work in this day  
                    {
                        if ((mother.workTimePerDay[1, i] < nanny.workHours[0, i]) || (mother.workTimePerDay[0, i] > nanny.workHours[1, i]))
                        //if there is no any common hours between the nanny and the mother
                        {//takes all the hours of the mother
                            t = mother.workTimePerDay[1, i] - mother.workTimePerDay[0, i];
                            sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                        }
                        else//any common hour between the nanny and the mother
                        {
                            if (mother.workTimePerDay[0, i] > nanny.workHours[0, i] && mother.workTimePerDay[1, i] > nanny.workHours[1, i])
                            //if the nanny starts before the mother and finish after the mother finish
                            
                            {
                                t = mother.workTimePerDay[1, i] - nanny.workHours[1, i];
                                sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                            }
                            if (mother.workTimePerDay[0, i] < nanny.workHours[0, i] && mother.workTimePerDay[1, i] < nanny.workHours[1, i])
                            //if the mother starts before the nanny and finish after the nanny start and before the nanny finish
                            {
                                t = mother.workTimePerDay[0, i] - nanny.workHours[0, i];
                                sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                            }
                            if (mother.workTimePerDay[0, i] >= nanny.workHours[0, i] && mother.workTimePerDay[1, i] <= nanny.workHours[1, i])
                            //if the hours of the nanny contains the hours of the mother
                            {
                                t = mother.workTimePerDay[1, i] - mother.workTimePerDay[0, i];
                                sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                            }
                            if (mother.workTimePerDay[0, i] < nanny.workHours[0, i] && mother.workTimePerDay[1, i] > nanny.workHours[1, i])
                            //if the hours of the mother contains the hours of the nanny
                            {
                                t = mother.workTimePerDay[1, i] - mother.workTimePerDay[0, i] - (nanny.workHours[1, i] - nanny.workHours[0, i]);
                                sum += t.Hours + (float)(t.Minutes / 60.0) + (float)(t.Seconds / 3600.0);
                            }

                        }
                    }
                }
            }
            return sum;
        }
      


        /// <summary>
        /// This function search for all close nannies by distance from mother that small from 60km
        /// </summary>
        /// <param name="m">The mother it searches close nannies </param>
        /// <returns>IEnumerable of all close nannies</returns>
        public IEnumerable<Nanny> CloseNannies(Mother m)
        {
            if (m == null)
                throw new Exception("the mother does not exist\n");
            string address;
            
            address = m.AddressForNanny;//contains the address that the mother wants for the nanny,

            if (m.AddressForNanny == null)
                address = m.Address;// if it is empty it will contain the address of the mother

            List<Nanny> listNanny = new List<Nanny>();
            foreach (Nanny item in GetAllNanny())//go over all the nanny
            {
                if (distance(item.Address, address) <=6000)
                {
                    listNanny.Add(item);
                }
            }
            return listNanny;
        }


        /// <summary>
        /// This function searches for all the childen that do not have a nanny
        /// </summary>
        /// <returns>IEnumerable of all the children that do not have a nanny</returns>
        public IEnumerable<Child> GetAllChildWithoutNanny()
        {
            List<Child> ch = GetAllChild().ToList<Child>();//all the children by list
            foreach (var item in GetAllContract())//remove from ch the child that his id sign in contract
            {
                ch.RemoveAll(child => child.Id == item.ChildID);
            }
            return (ch.AsEnumerable<Child>());
        }


        /// <summary>
        /// This function searches for all the nannies that have vacation by Tamat Office
        /// </summary>
        /// <returns>IEnumerable of all the nannies that have vacation by Tamat Office</returns>
        public IEnumerable<Nanny> GetAllTMTNannies()
        {
            var v = from a in GetAllNanny()
                    where a.Tmt == false
                    select a;
            return v;
        }


        /// <summary>
        /// This function searches for all the contracts that a spesific (predicate) true for them
        /// </summary>
        /// <param name="predicate">The predicate that all the contracts be checked by it</param>
        /// <returns>IEnumerable of all the contracts that a spesific delegate(predicate) true for them</returns>
        public IEnumerable<Contract> GetAllContractByDelegate(Func<Contract, bool> predicate)
        {
            return (GetAllContract(predicate));
        }


        /// <summary>
        /// This function searches for the number of all the contracts that a spesific predicate true for them
        /// </summary>
        /// <param name="predicate">The predicate that all the contracts  be checked by it</param>
        /// <returns>The number of all the contracts that a spesific delegate(predicate) true for them</returns>
        public int GetNumContractByDelegate(Func<Contract, bool> predicate)
        {
            return (GetAllContract(predicate).ToList<Contract>().Count);
        }


        #region OurFunc


        /// <summary>
        /// This function calculates the number of days that left to the end the contract
        /// </summary>
        /// <param name="c">The contract that it calculate the number of days that left to the end for </param>
        /// <returns>The number of days that left </returns>
        public int DaysToEndOfContract(Contract c)
        {
            if (c == null)
                throw new Exception("the contract does not exist\n");
            return ((c.EndContract - DateTime.Now).Days);
        }


        /// <summary>
        /// This function search for all the children of the nanny
        /// </summary>
        /// <param name="n">The nanny it search all children for</param>
        /// <returns>IEnumerable of all the children of nanny</returns>
        public IEnumerable<Child> GetAllChildOfNanny(Nanny n)
        {
            if (n == null)
                throw new Exception("the nanny does not exist\n");
            return from a in GetAllContract(co => co.NannyID == n.Id)// same id's child of nanny and contract
                   select FindChild(a.ChildID);//get the child by id
        }

        /// <summary>
        /// This function creates a string that describe the nanny's seniorities
        /// </summary>
        /// <returns> string of seniority</returns>
        public string NannysSeniority()
        {
            string s = "";
            var nannysSeniority = GetAllNanny();
            foreach (var item in nannysSeniority)
            {
                s += " Nanny's name: " + item.Name + " " + item.LastName + "Seniority: " + item.Seniority + "years \n";
            }
            return s;
        }


        /// <summary>
        /// This function creates a string that describe all the names of the mothers their children with the nanny,and their Phones
        /// </summary>
        /// <param name="n">The nanny it creates string for</param>
        /// <returns>String that describe all the names of the mothers their children are took care by nanny,and their Phones</returns>
        public string MothersPhones(Nanny n)
        {
            if (n == null)
                throw new Exception("the nanny does not exist\n");
            string s = "";
            var MothersPhones = GetAllContract(co => co.NannyID == n.Id);//all the contracts that the nanny sign
            foreach (var item in MothersPhones)
            {
                s += "Mother of " + FindChild(item.ChildID).Name + " " + FindChild(item.ChildID).LastName + " :";
                s += FindMother(FindChild(item.ChildID).IdMother).Phone + "\n";
            }
            return s;
        }


        /// <summary>
        /// This function search for all the children of nanny that have a birthday in this month
        /// </summary>
        /// <param name="n">The nanny it search birthday children for</param>
        /// <returns>IEnumerable of all the children of spesific nanny  that have a birthday in this month</returns>
        public IEnumerable<Child> GetAllMonthBirthdayChild(Nanny n)
        {
            if (n == null)
                throw new Exception("the nanny does not exist\n");
            return (from a in GetAllContract(co => co.NannyID == n.Id)
                    where (FindChild(a.ChildID).DateOfBirth.Month == DateTime.Now.Month)// born in this month
                    select FindChild(a.ChildID));
        }


        /// <summary>
        /// This function creates a string that describe all the names of the children that have special needs,and their needs.
        /// </summary>
        /// <param name="n">The nanny it's create a string for</param>
        /// <returns>String of all the children that has special needs names and their special needs</returns>
        public string ChildSpecialNeeds(Nanny n)
        {
            if (n == null)
                throw new Exception("the nanny does not exist\n");
            string s = "";
            var SpecialNeeds = from a in GetAllContract(co => co.NannyID == n.Id)
                               where (FindChild(a.ChildID).HasSpecialNeeds)
                               select a;
            foreach (var item in SpecialNeeds)
            {
                s += (FindChild(item.ChildID)).Name + ": " + (FindChild(item.ChildID)).SpecialNeeds + "\n";
            }
            return s;
        }

       

        #endregion

    }
}





