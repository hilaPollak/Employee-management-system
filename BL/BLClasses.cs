using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    internal class IBL : IBL
    {
        DAL.Idal dal;
        public imp_BL()
        {
            dal = DAL.factory_dal.get_dal();
            
        }
        List<Nanny> Get_Nanny_list() { return Idal.Get_Nanny_list(); }
        List<Mother> Get_Mother_list() { return Idal.Get_Mother_list(); }
        List<Contract> Get_Contracts_list() { return Idal.Get_Contracts_list(); }
        List<Child> Get_Child_list() { return Idal.Get_Child_list(); }

        #region TO DAL
        void AddNanny(Nanny n)
        {
        }
        void DeletNanny(int id) { }
        void UpDateNanny(Nanny n) { }//copy c-tor
        Nanny FindNanny(int id) { }


        void AddMother(Mother m) { }
        void DeletMother(Mother m) { }
        void UpDateMother(Mother m) { }//copy c-tor
        Mother FindMother(int id) { }


        void AddChild(Child c) { }
        void DeletChild(Child c) { }
        void UpDateChild(Child c) { }//copy c-tor
        Child FindChild(int id) { }

        void AddContract(Contract c) { }
        void DeletContract(Contract c) { }
        void UpDateContract(Contract c) { }//copy c-tor
        Contract FindContract(int code) { }
        #endregion

        public void Check_Nanny_age(Nanny n)
        {
            DateTime today = DateTime.Now;
            DateTime temp = n.DateOfBirth.AddYears(18);
            if (temp > today)
                throw new Exception("This Nanny is too young");
        }
        public void Check_Child_age(Child c)
        {
            if(c.Under3Mounth)
                throw new Exception("This Child is too young");
        }
        public int Check_existing_brothers(Contract c)
        {
            var v = Get_Child_list().Where(t => t.MotherId == c.MotherID);
            int num = v.Count();
            if (num == 0)
                throw new Exception("the child not exist in the system");
            return num;
        }
        public float CalculateSalary (Contract contract)
        {
            if (contract == null)
                return 0;
            int numOfBrother = 0;
            Child child = FindChild(contract.ChildID);
            Mother mother = FindMother(contract.MotherID);
            Nanny nanny = FindNanny(contract.NannyID);
            IEnumerable<Child> brothers= 
        }
    }





        
    }
}

