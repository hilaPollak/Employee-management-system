using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    public class Dal_imp: Idal
    {
        #region Nanny

        /// <summary>
        /// This function get nanny and add her for NannyList
        /// </summary>
        /// <param name="n"> The nanny that need to add to NannyList</param>
        public void AddNanny(Nanny n)
        {
            if (n == null)
                return;
            if (FindNanny(n.Id) != null)// the nanny already exist
            {
                throw new Exception("this nanny already exist");
            }
            if (n.Password != n.CheckPassword)
                throw new Exception("incompatible password, check if the passwords do not match");
            int counter = 0;
            for (int i = 0; i < 6; i++)//check if the nanny detials does not legal
            {
                if (n.workHours[1, i] < n.workHours[0, i])// end hour smallest then start hour
                    throw new Exception("there is an end hour that smaller than start hour ");
                if (n.workDays[i] == false)//checks if the nanny doesnt work in the day
                    counter++;
            }
            if (counter == 6)//illegal detials
                throw new Exception("there are no days to keeping");
            DataSource.NannyList.Add(n);// add nanny to DataSource
        }

        /// <summary>
        /// This function get nanny id and remove her from NannyList
        /// </summary>
        /// <param name="id">The id of the nanny to delete</param>
        /// <returns>True if this nanny delete success</returns>
        public bool DeleteNanny(int id)
        {
            Nanny n = FindNanny(id);
            if (n == null)//if the nanny does not exist
                throw new Exception("this nanny does not exist");
            IEnumerable<Contract> help = GetAllContract(c => c.NannyID == id);//all the contract that the nanny sign in
            if (help.ToList().Count != 0)//cant remove nanny in contract
                throw new Exception("this nanny is in a contract");
            return DataSource.NannyList.Remove(n);// remove nanny to DataSource
        }

        /// <summary>
        /// This function get nanny and update her in NannyList
        /// </summary>
        /// <param name="n">The nanny that need to update</param>
        public void UpDateNanny(Nanny n)
        {
            if (n == null)//if the nanny does not exist
                throw new Exception("this nanny does not exist");
            int index = DataSource.NannyList.FindIndex(nhelp => nhelp.Id == n.Id);//find the index of the nanny in ihe Nanny List
            if (index == -1)//if the nanny does not exist
                throw new Exception("this nanny is not exist");
            int counter = 0;
            for (int i = 0; i < 6; i++)//check the nanny detials illegal
            {
                if (n.workHours[1, i] < n.workHours[0, i])//illegal details
                    throw new Exception("there is an end hour that smaller than start hour ");
                if (n.workDays[i] == false)//checks if the nanny doesnt work in the day
                    counter++;
            }
            if (counter == 6)//illegal details
                throw new Exception("there are no days to keeping");
            DataSource.NannyList[index] = n;//// update nanny on DataSource
        }

        /// <summary>
        /// This function get nanny id and search the nanny in NannyList.
        /// </summary>
        /// <param name="id"> The id of the nanny to search</param>
        /// <returns>The nanny that id it's her id </returns>
        public Nanny FindNanny(int id)
        {
            Nanny n = DataSource.NannyList.FirstOrDefault(h => h.Id == id);//The nanny that id it's her id
            return n;
        }
        #endregion

        #region Mother

        /// <summary>
        /// This function get mother and add her for MotherList
        /// </summary>
        /// <param name="m">The mother that need to add</param>
        public void AddMother(Mother m)
        {
            if (m == null)
                return;
            if (FindMother(m.Id) != null)// the nanny already exist
            {
                throw new Exception("this mother already exist");
            }
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (m.workTimePerDay[1, i] < m.workTimePerDay[0, i])//end hour smaller than start hour
                    throw new Exception("there is an end hour that smaller than start hour ");
                if (m.workDays[i] == false)//checks if the mother doesnt need keeping in the day
                    counter++;
            }
            if (counter == 6)//if the detials of the mother illegal
                throw new Exception("there are no days to keeping");
            if(m.Password!=m.CheckPassword)
                throw new Exception("incompatible password, check if the passwords do not match");
            DataSource.MotherList.Add(m);// add Mother to DataSource
        }


        /// <summary>
        /// This function get mother id and remove her from MotherList
        /// </summary>
        /// <param name="id">The id of the nanny to delete</param>
        /// <returns>True if this mother delete success</returns>
        public void DeleteMother(int id)
        {
            Mother m = FindMother(id);
            if (m == null)//if this mother does not exist
                throw new Exception("this mother is not exist");
            IEnumerable<Child> help = GetAllChild(ch => ch.IdMother == id);//get all mother children
            if (help.ToList().Count != 0)//can not delete mother if she has a child
                throw new Exception("this mother has a child");
           
        }


        /// <summary>
        /// This function get mother and update her in MotherList
        /// </summary>
        /// <param name="m">The mother that need to update</param>
        public void UpDateMother(Mother m)
        {
            if (m == null)
                throw new Exception("this mother does not exist");
            int index = DataSource.MotherList.FindIndex(mom => mom.Id == m.Id);//find the index of the mother in ihe MotherList
            if (index == -1)//if the mother does not exist
                throw new Exception("this mother does not exist");
            int counter = 0;
            for (int i = 0; i < 6; i++)//end hour smaller than start hour
            {
                if (m.workDays[i] == false)//checks if the mother doesnt need keeping in the day
                    counter++;
            }
            if (counter == 6)//illegal detials
                throw new Exception("there are no days to keeping");
            DataSource.MotherList[index] = m;// update Mother on DataSource
        }


        /// <summary>
        /// This function get mother id and search the nanny in NannyList.
        /// </summary>
        /// <param name="id"> The id of the nother to search</param>
        /// <returns>The mother that id it's her id </returns>
        public Mother FindMother(int id)
        {
            Mother m = DataSource.MotherList.FirstOrDefault(h => h.Id == id);
            return m;//The mother that id it's her id
        }
        #endregion

        #region Child

        /// <summary>
        /// This function get child and add him for ChildList
        /// </summary>
        /// <param name="c"> The child that need to add to NannyList</param>
        public void AddChild(Child c)
        {
            if (c == null)
                return;
            if (FindChild(c.Id) != null)//if the child exist
            {
                throw new Exception("this child already exist");
            }
            if (FindMother(c.IdMother) == null)//if the child does not have a mother
                throw new Exception("this child does not have a mother");

            DataSource.ChildList.Add(c);// add child to DataSource
        }


        /// <summary>
        /// This function get child id and remove him from ChildList
        /// </summary>
        /// <param name="id">The id of the child to delete</param>
        /// <returns>True if this child delete success</returns>
        public bool DeleteChild(int id)
        {
            Child c = FindChild(id);
            if (c == null)//if the child does not exist
                throw new Exception("this child does not exist");
            IEnumerable<Contract> help = GetAllContract(chelp => chelp.ChildID == id);//all the contract of the child 
            if (help.ToList().Count != 0)//cant remove a child that sign in contract
                throw new Exception("this child is in a contract");
            return DataSource.ChildList.Remove(c);// delete child from DataSource
        }

        /// <summary>
        /// This function get child and update him in ChildList
        /// </summary>
        /// <param name="c">The child that need to update</param>
        public void UpDateChild(Child c)
        {
            if (c == null)
                throw new Exception("this child is not exist");
            int index = DataSource.ChildList.FindIndex(ch => ch.Id == c.Id);//find the index of the child in ihe ChildList
            if (index == -1)//if the child does not exist
                throw new Exception("this child is not exist");
            DataSource.ChildList[index] = c;// update child of DataSource
        }

        /// <summary>
        /// This function get child id and search the child in ChildList.
        /// </summary>
        /// <param name="id"> The id of the child to search</param>
        /// <returns>The child that id it's his id </returns>
        public Child FindChild(int id)
        {
            Child c = DataSource.ChildList.FirstOrDefault(h => h.Id == id);
            return c;//The child that id it's his id 
        }
        #endregion

        #region Contract

        /// <summary>
        /// This function get a contract and add it to ContractList
        /// </summary>
        /// <param name="c">The contract to add</param
        public void AddContract(Contract c)
        {
            if (c == null)
                return;
            Child ch = FindChild(c.ChildID);// find the child according the id in contract
            Nanny nanny = FindNanny(c.NannyID);// find the nanny according the id in contract
            if (ch == null || GetAllMother(mo => mo.Id == ch.IdMother).ToList().Count == 0 || FindNanny(c.NannyID) == null)
                //cant add contract that child/nanny does not exist
                throw new Exception("the child or the nanny of this contract does not exist");
            if (DataSource.ContractList.FirstOrDefault(co => (co.NannyID == c.NannyID && co.ChildID == c.ChildID)) != null)
                //cant add contract if it already exist
                throw new Exception("the child already has a contract with this nanny");
            if (c.EndContract < c.StartContract)
                //if the detials of the contract illegal
                throw new Exception("in this contract the end Date is little then start Date");
            if (((DateTime.Now - ch.DateOfBirth).Days / 30 < nanny.MinMonthesAge || (DateTime.Now - ch.DateOfBirth).Days / 30 > nanny.MaxMonthesAge))
                //if the child that sign in contract not in the range of age of nanny
                throw new Exception("the child is not in the range age of the nanny");
            c.Code = Contract.staticNumOFContract++;//the num of contract grow up 1
            DataSource.ContractList.Add(c);// add contract to DataSource
            nanny.NumOfChildren++;//more 1 child for the nanny
        }


        /// <summary>
        /// This function get a number of contract and remove this contract from ContractList
        /// </summary>
        /// <param name="code">The code of contract to delete</param>
        /// <returns>True if the contract delete success</returns>
        public bool DeleteContract(int code)
        {
            Contract c = FindContract(code);// find the contract according the code
            if (c == null)
                throw new Exception("this contract does not exist");
            Nanny nanny = FindNanny(c.NannyID);// find the mother according the id in contract
            if (nanny == null)
                throw new Exception("the nanny does not exist");
            nanny.NumOfChildren--;//less 1 child for the nanny
            return DataSource.ContractList.Remove(c);//delete contract from DataSource
        }

        /// <summary>
        /// This function get a contract and update this contract in ContractList
        /// </summary>
        /// <param name="c">The contract to update</param>
        public void UpDateContract(Contract c)
        {
            if (c == null)
                throw new Exception("this contract does not exist");
            int index = DataSource.ContractList.FindIndex(co => co.Code == c.Code);// find the index of the contract in the contractList
            if (index == -1)//if the contract does not exist
                throw new Exception("this contract does not exist");
            if (c.EndContract < c.StartContract)//if the detials of the contract illegal
                throw new Exception("in this contract the end Date is little then start Date");
            Child ch = FindChild(c.ChildID);// find the child according the id in contract
            Nanny nanny = FindNanny(c.NannyID);// find the mother according the id in contract
            if (ch == null || GetAllMother(mo => mo.Id == ch.IdMother).ToList().Count == 0 || FindNanny(c.NannyID) == null)
                //can not update contract that one of the people that sign does not exist
                throw new Exception("the child or the nanny of this contract does not exist");
            if (((DateTime.Now - ch.DateOfBirth).Days / 30 < nanny.MinMonthesAge || (DateTime.Now - ch.DateOfBirth).Days / 30 > nanny.MaxMonthesAge))
                //if the child that sign in contract not in the range of age of nanny
                throw new Exception("the child is not in the range age of the nanny");
            DataSource.ContractList[index] = c;//update contract in DataSource
        }


        /// <summary>
        /// This function get number of contract and search that contract
        /// </summary>
        /// <param name="code">The code of contract to search</param>
        /// <returns>Contract if this contract exist</returns>
        public Contract FindContract(int code)
        {
            Contract c = DataSource.ContractList.FirstOrDefault(h => h.Code == code);
            return c;//The contract that code it's his code
        }
        #endregion

        #region getting function

        /// <summary>
        /// This function get predicate and need to find all the contracts that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the contracts are checked by it</param>
        /// <returns>IEnumerable of all the contracts that the predicate true for them</returns>
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.ContractList.AsEnumerable<Contract>();
            return DataSource.ContractList.Where(predicate).AsEnumerable<Contract>();
        }


        /// <summary>
        /// This function get predicate and need to find all the children that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the children are checked by it</param>
        /// <returns>IEnumerable of all the children that the predicate true for them</returns>
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.ChildList;
            return DataSource.ChildList.Where(predicate);
        }


        /// <summary>
        /// This function get predicate and need to find all the Mothers that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the Mothers are checked by it</param>
        /// <returns>IEnumerable of all the Mothers that the predicate true for them</returns>
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.MotherList;
            return DataSource.MotherList.Where(predicate);
        }


        /// <summary>
        /// This function get predicate and need to find all the nannies that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the nannies are checked by it</param>
        /// <returns>IEnumerable of all the nannies that the predicate true for them</returns>
        public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.NannyList;
            return DataSource.NannyList.Where(predicate);
        }
        #endregion
    }
}
