using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    public interface Idal
    {
        //all the Explanations and the Summaries of the func on Dal_imp
        //only Signatures

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

        #region getting list function 
        IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null);
        IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null);
        IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null);
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null);
        #endregion
    }
}

