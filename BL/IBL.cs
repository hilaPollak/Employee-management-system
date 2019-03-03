using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{
    public interface IBL
    {
        //all the Explanations and the Summaries of the func on BL_imp
        //only Signatures

        #region TO DAL (Mother, Child, Nanny and Contract)
        void AddNanny(Nanny n);
        bool DeleteNanny(int id);
        void UpDateNanny(Nanny n);
        Nanny FindNanny(int id);


        void AddMother(Mother m);
        void DeleteMother(int id);
        void UpDateMother(Mother m);
        Mother FindMother(int id);

        void AddChild(Child c);
        bool DeleteChild(int id);
        void UpDateChild(Child c);
        Child FindChild(int id);

        void AddContract(Contract c);
        bool DeleteContract(int code);
        void UpDateContract(Contract c);
        Contract FindContract(int code);
        #endregion

        #region getting list function  
        IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null);
        IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null);
        IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null);
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null);
        #endregion

        IEnumerable<Child> GetAllBrothers(Contract c);

        float CalculateSalary(Contract c);

        bool CheckMatch(Mother mother, Nanny nanny);

        IEnumerable<Nanny> Get5BestMatchNannies(Mother m);

        IEnumerable<Nanny> GetAllWantedNannies(Mother m);

        float PreferNanny(Mother mother, Nanny nanny);

        IEnumerable<Nanny> CloseNannies(Mother m);

        IEnumerable<Child> GetAllChildWithoutNanny();

        IEnumerable<Nanny> GetAllTMTNannies();

        IEnumerable<Contract> GetAllContractByDelegate(Func<Contract, bool> predicate);

        int GetNumContractByDelegate(Func<Contract, bool> predicate);

        #region Groping

        IEnumerable<IGrouping<float, Nanny>> GroupingNannyByAge(bool max, bool order = false);

        IEnumerable<IGrouping<int, Contract>> GroupingOfDistance(bool order);

        #endregion

        #region OurFunc

        int DaysToEndOfContract(Contract c);

        IEnumerable<Child> GetAllChildOfNanny(Nanny n);

        string MothersPhones(Nanny n);

        string NannysSeniority();

        IEnumerable<Child> GetAllMonthBirthdayChild(Nanny n);

        string ChildSpecialNeeds(Nanny n);

        #endregion
    }
}
