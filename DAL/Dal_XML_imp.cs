using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Xml.Linq;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Reflection;




namespace DAL
{
    class Dal_XML_imp : Idal
    {


        XElement ChildrenRoot;//creat space for data
        string ChildrenPath = "..//..//..//XML//ChildXML.xml";

        XElement NannyRoot;//creat space for data
        string NannyPath = "..//..//..//XML//NannyXML.xml";

        XElement MotherRoot;//creat space for data
        string MotherPath = "..//..//..//XML//MotherXML.xml";

        XElement ContractRoot;//creat space for data
        string ContractPath = "..//..//..//XML// ContractXML.xml";

        XElement Code;//creat space for data
        string CodePath = "..//..//..//XML// CodeXML.xml";

        /// <summary>
        /// this func check if the file exist- if he is he will open and the data load
       /// else new file will create
        /// </summary>
        public Dal_XML_imp()
        {
            if (!File.Exists(CodePath))//doesnt exist
                CreateFile();

            else//exist
                LoadData();
        }
        /// <summary>
        /// the file will open and the data load
        /// </summary>
        private void LoadData()//static function
        {
            try
            {
                ChildrenRoot = XElement.Load(ChildrenPath);//from child path
                NannyRoot = XElement.Load(NannyPath);//from nanny path
                MotherRoot = XElement.Load(MotherPath);//from mother path
                ContractRoot = XElement.Load(ContractPath);//from contract path
                Code = XElement.Load(CodePath);//from code path
            }
            catch 
            {
                throw new Exception("loaded file fail ");
            }

           
        }

        /// <summary>
        /// if the file exist new file will create
        /// </summary>
        private void CreateFile()
        {
            ChildrenRoot = new XElement("children");//for child
            ChildrenRoot.Save(ChildrenPath);

            NannyRoot = new XElement("nannies");//for nanny
            NannyRoot.Save(NannyPath);

            MotherRoot = new XElement("mothers");//for mother
            MotherRoot.Save(MotherPath);

            ContractRoot = new XElement("contracts");//for contract
            ContractRoot.Save(ContractPath);

            Code = new XElement("codes");//for code
            Code.Add(new XElement("code", 111));//restart the code in 111
            Code.Save(CodePath);
        }


        ///=================================================



        #region Nanny

        /// <summary>
        /// this func get nanny and convert to xml
        /// </summary>
        XElement convertNannyToXML(Nanny n)
        {
            if (n == null)//no nanny
                return null;
            XElement NannyElement = new XElement("nanny");//create new exelment
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())//convert all the property to xml
            {
                if(item.Name != "workHours" && item.Name != "workDays")//2,6- do it by self
                    NannyElement.Add(new XElement(item.Name, item.GetValue(n, null)));
            }
            //-----------------------------------
            // convert the array and the matrix to xml
            if (n.workDays == null)
                return null;
            string result = "";
            if (n.workDays != null)
            {
                int size = n.workDays.GetLength(0);//size of array

                result += "" + size;//to string
                for (int i = 0; i < size; i++)
                    result += "," + n.workDays[i];
            }
            NannyElement.Add(new XElement("workDays", result));//add exelement

            //-----------------------------
            if (n.workHours == null)
                return null;
            result = "";
            if (n.workHours != null)
            {
                int sizeA = n.workHours.GetLength(0);//size of matrix
                int sizeB = n.workHours.GetLength(1);//size of matrix
                result += "" + sizeA + "," + sizeB;//to string
                for (int i = 0; i < sizeA; i++)
                    for (int j = 0; j < sizeB; j++)
                        result += "," + n.workHours[i, j];
            }
            NannyElement.Add(new XElement("workHours", result));//add exelement
            return NannyElement;
        }

        /// <summary>
        /// this func get xelement and convert to nanny
        /// </summary>
        /// <param name="ex"> the ex element </param>
        /// <returns>nanny</returns>
        Nanny convertXMLTONanny(XElement ex)
        {
            if (ex == null)
            {
                return null;
            }
            Nanny n = new Nanny();
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())//convert all properties
            {
               if(item.Name!= "workHours" && item.Name != "workDays")
                { 
                    TypeConverter type = TypeDescriptor.GetConverter(item.PropertyType);
                    object convertValue = type.ConvertFromString(ex.Element(item.Name).Value);
                    item.SetValue(n, convertValue);//set the properties on nanny
                }

            }
            //---------------------------------------------
            //convert array and matrix
            string value = ex.Element("workDays").Value;//get array as sting
            string[] values1 = value.Split(',');
            int size = int.Parse(values1[0]);//convert to int
           
            n.workDays = new bool[size];
            int index1 = 1;
            for (int i = 0; i < size; i++)
                n.workDays[i] = bool.Parse(values1[index1++]);//update proprtie in nanny

            //--------------------------------------------
            value = ex.Element("workHours").Value;//get matrix as string
            string[] values = value.Split(',');
            int sizeA = int.Parse(values[0]);
            int sizeB = int.Parse(values[1]);
            n.workHours = new DateTime[sizeA, sizeB];//convert to date time
            int index = 2;
            for (int i = 0; i < sizeA; i++)
                 for (int j = 0; j < sizeB; j++)
                    n.workHours[i, j] = DateTime.Parse(values[index++]);//update proprtie in nanny
            return n;
        }


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
            NannyRoot.Add(convertNannyToXML(n));// add child to file
            NannyRoot.Save(NannyPath);//save file
        }

        /// <summary>
        /// This function get nanny id and remove her from NannyList
        /// </summary>
        /// <param name="id">The id of the nanny to delete</param>
        /// <returns>True if this nanny delete success</returns>
        public bool DeleteNanny(int id)
        {
            XElement n = ((from e in NannyRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            if (n == null)//if the nanny does not exist
                throw new Exception("this nanny does not exist");
            
            n.Remove();// delete nanny from file
            NannyRoot.Save(NannyPath);//save file
            return true;
        }

        /// <summary>
        /// This function get nanny and update her in NannyList
        /// </summary>
        /// <param name="n">The nanny that need to update</param>
        public void UpDateNanny(Nanny n)
        {
            XElement temp = ((from e in NannyRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == n.Id)
                              select e).FirstOrDefault());
            if (n == null)//if the nanny does not exist
                throw new Exception("this nanny does not exist");
            Nanny ntemp = FindNanny(n.Id);
            if (ntemp==null)//if the nanny does not exist
                throw new Exception("this nanny is not exist if file");
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
            temp.ReplaceWith(convertNannyToXML(n)); // update child of file
            NannyRoot.Save(NannyPath);//save file
        }

        /// <summary>
        /// This function get nanny id and search the nanny in NannyList.
        /// </summary>
        /// <param name="id"> The id of the nanny to search</param>
        /// <returns>The nanny that id it's her id </returns>
        public Nanny FindNanny(int id)
        {
            XElement temp = ((from e in NannyRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            return convertXMLTONanny(temp);//The child that id it's his id 
        }
        #endregion

        #region Mother

        /// <summary>
        /// this func get mother and convert to xml
        /// </summary>
        /// 
        XElement convertMotherToXML(Mother m)
        {
            if (m == null)//mother don exist
                return null;
            XElement MotherElement = new XElement("mother");
            foreach (PropertyInfo item in typeof(Mother).GetProperties())//convert all the propertis of mother to xml
            {
                if (item.Name != "workTimePerDay")//2,6 we will do it
                    MotherElement.Add(new XElement(item.Name, item.GetValue(m, null)));//convert
            }
            //--------------------------------------------------------------
            //convert array 
            if (m.workDays == null)
                return null;
            string result = "";
            if (m.workDays != null)
            {
                int size = m.workDays.GetLength(0);//get size of array

                result += "" + size;//convert to string all the properties
                for (int i = 0; i < size; i++)
                    result += "," + m.workDays[i];
            }
            MotherElement.Add(new XElement("workDays", result));//conver to xml
            //----------------------------------------------------------
            //convert matrix
            if (m.workTimePerDay == null)
                return null;
            result = "";
            if (m.workTimePerDay != null)
            {
                int sizeA = m.workTimePerDay.GetLength(0);//get size
                int sizeB = m.workTimePerDay.GetLength(1);
                result += "" + sizeA + "," + sizeB;
                for (int i = 0; i < sizeA; i++)
                    for (int j = 0; j < sizeB; j++)
                        result += "," + m.workTimePerDay[i, j];//convert to string
            }
            MotherElement.Add(new XElement("workTimePerDay", result));//convert to xml
            return MotherElement;
        }
        /// <summary>
        /// this func get xelement and convert to nother
        /// </summary>
        /// <param name="ex"> the ex element </param>
        /// <returns>mother</returns>
        Mother convertXMLTOMother(XElement ex)
        {
            if (ex == null)
            {
                return null;
            }
            Mother m = new Mother();
            foreach (PropertyInfo item in typeof(Mother).GetProperties())//convert the properties to mother
            {
                if (item.Name != "workTimePerDay")//we will do it
                {
                    TypeConverter type = TypeDescriptor.GetConverter(item.PropertyType);
                    object convertValue = type.ConvertFromString(ex.Element(item.Name).Value);
                    item.SetValue(m, convertValue);//update the mother
                }

            }
            //---------------------------------------------
            //conver array
            string value = ex.Element("workDays").Value;
            string[] values1 = value.Split(',');
            int size = int.Parse(values1[0]);

            m.workDays = new bool[size];
            int index1 = 1;
            for (int i = 0; i < size; i++)
                m.workDays[i] = bool.Parse(values1[index1++]);//convert to int

            //--------------------------------------------
            //convert matrix
            value = ex.Element("workTimePerDay").Value;
            string[] values = value.Split(',');
            int sizeA = int.Parse(values[0]);
            int sizeB = int.Parse(values[1]);
            m.workTimePerDay = new DateTime[sizeA, sizeB];
            int index = 2;
            for (int i = 0; i < sizeA; i++)
                for (int j = 0; j < sizeB; j++)
                   m.workTimePerDay[i, j] = DateTime.Parse(values[index++]);//conver to date time
            return m;
        }

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
            if (m.Password != m.CheckPassword)
                throw new Exception("incompatible password, check if the passwords do not match");
            MotherRoot.Add(convertMotherToXML(m));// add Mother to file
            MotherRoot.Save(MotherPath);//save file
        }


        /// <summary>
        /// This function get mother id and remove her from MotherList
        /// </summary>
        /// <param name="id">The id of the nanny to delete</param>
        /// <returns>True if this mother delete success</returns>
        public void DeleteMother(int id)
        {
            LoadData();
            XElement m = ((from e in MotherRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());

            if (m == null)//if this mother does not exist
                throw new Exception("this mother is not exist");
           
            m.Remove(); // delete mother from file
            MotherRoot.Save(MotherPath);//save file
           
        }


        /// <summary>
        /// This function get mother and update her in MotherList
        /// </summary>
        /// <param name="m">The mother that need to update</param>
        public void UpDateMother(Mother m)
        {
            XElement temp = ((from e in MotherRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == m.Id)
                              select e).FirstOrDefault());
            if (m == null)
                throw new Exception("this mother does not exist");
            Mother mtemp = FindMother(m.Id);
            if (mtemp==null)//if the mother does not exist
                throw new Exception("this mother does not exist in file");
            int counter = 0;
            for (int i = 0; i < 6; i++)//end hour smaller than start hour
            {
                if (m.workDays[i] == false)//checks if the mother doesnt need keeping in the day
                    counter++;
            }
            if (counter == 6)//illegal detials
                throw new Exception("there are no days to keeping");
            temp.ReplaceWith(convertMotherToXML(m)); // update mother of file
            MotherRoot.Save(MotherPath);//save file
        }


        /// <summary>
        /// This function get mother id and search the nanny in NannyList.
        /// </summary>
        /// <param name="id"> The id of the nother to search</param>
        /// <returns>The mother that id it's her id </returns>
        public Mother FindMother(int id)
        {
            XElement temp = ((from e in MotherRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            return convertXMLTOMother(temp);//The mother that id it's his id 
        }
        #endregion

        #region Child


        /// <summary>
        /// this func get child and convert to xml
        /// </summary>
        XElement convertChildToXML(Child c)
        {
            if (c == null)
                return null;
            XElement ChildElement = new XElement("child");//create new xelement
            foreach (PropertyInfo item in typeof(Child).GetProperties())//convert all properties
            {
                ChildElement.Add(new XElement(item.Name, item.GetValue(c, null)));
            }
            return ChildElement;
        }

        /// <summary>
        /// this func get xelement and convert to child
        /// </summary>
        /// <param name="ex"> the ex element </param>
        /// <returns>child</returns>
        Child convertXMLTOChild(XElement ex)
        {
            if (ex == null)
            {
                return null;
            }
            Child c = new Child();
            foreach (PropertyInfo item in typeof(Child).GetProperties())//convert all properties
            {
                TypeConverter type = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = type.ConvertFromString(ex.Element(item.Name).Value);
                item.SetValue(c, convertValue);//set the properties on child
            }
            return c;
        }


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
            ChildrenRoot.Add(convertChildToXML(c));// add child to file
            ChildrenRoot.Save(ChildrenPath);//save file

        }


        /// <summary>
        /// This function get child id and remove him from ChildList
        /// </summary>
        /// <param name="id">The id of the child to delete</param>
        /// <returns>True if this child delete success</returns>
        public bool DeleteChild(int id)
        {
            XElement temp = ((from e in ChildrenRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            if (temp == null)//if the child does not exist
                throw new Exception("this child does not exist");
           
            temp.Remove();// delete child from file
            ChildrenRoot.Save(ChildrenPath);//save file
            return true;
        }

        /// <summary>
        /// This function get child and update him in ChildList
        /// </summary>
        /// <param name="c">The child that need to update</param>
        public void UpDateChild(Child c)
        {
            XElement temp = ((from e in ChildrenRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == c.Id)
                              select e).FirstOrDefault());
            if (c == null)
                throw new Exception("this child is not exist");
            Child ctemp = FindChild(c.Id);
            if (ctemp == null)
                throw new Exception("this child is not exist in the file");
            temp.ReplaceWith(convertChildToXML(c)); // update child of file
            ChildrenRoot.Save(ChildrenPath);//save file
        }

        /// <summary>
        /// This function get child id and search the child in ChildList.
        /// </summary>
        /// <param name="id"> The id of the child to search</param>
        /// <returns>The child that id it's his id </returns>
        public Child FindChild(int id)
        {
            XElement temp = ((from e in ChildrenRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            return convertXMLTOChild(temp);//The child that id it's his id 
        }
        public XElement findChildXML(int id)
        {
            XElement temp = ((from e in ChildrenRoot.Elements()
                              where (Convert.ToInt32(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            return temp;
        }
        #endregion

        #region Contract

        /// <summary>
        /// this func get contract and convert to xml
        /// </summary>
        XElement convertContractToXML(Contract c)
        {
            if (c == null)
                return null;
            XElement ContractElement = new XElement("contract");//create new root
            foreach (PropertyInfo item in typeof(Contract).GetProperties())//convert all the property to xml
            {
                if (item.Name != "WorkHours")//2,6 do it by self
                    ContractElement.Add(new XElement(item.Name, item.GetValue(c, null)));
            }
            // convert the matrix to xml
            if (c.WorkHours == null)
                return null;
            string result = "";
            if (c.WorkHours != null)
            {
                int sizeA = c.WorkHours.GetLength(0);//size of matrix
                int sizeB = c.WorkHours.GetLength(1);//size of matrix
                result += "" + sizeA + "," + sizeB;//to string
                for (int i = 0; i < sizeA; i++)
                    for (int j = 0; j < sizeB; j++)
                        result += "," + c.WorkHours[i, j];
            }
            ContractElement.Add(new XElement("WorkHours", result));//add exelement
            return ContractElement;
        }

        /// <summary>
        /// this func get xelement and convert to contract
        /// </summary>
        /// <param name="ex"> the ex element </param>
        /// <returns>contract</returns>
        Contract convertXMLTOContract(XElement ex)
        {
            if (ex == null)
            {
                return null;
            }
            Contract c = new Contract();
            foreach (PropertyInfo item in typeof(Contract).GetProperties())//convert all properties
            {
                if (item.Name != "WorkHours")
                {
                    TypeConverter type = TypeDescriptor.GetConverter(item.PropertyType);
                    object convertValue = type.ConvertFromString(ex.Element(item.Name).Value);
                    item.SetValue(c, convertValue);//set the properties on contract
                }

            }
            string value = ex.Element("WorkHours").Value;//get matrix as string
            string[] values = value.Split(',');
            int sizeA = int.Parse(values[0]);
            int sizeB = int.Parse(values[1]);
            c.WorkHours = new DateTime[sizeA, sizeB];//convert to date time
            int index = 2;// to the valus array
            for (int i = 0; i < sizeA; i++)
                for (int j = 0; j < sizeB; j++)
                    c.WorkHours[i, j] = DateTime.Parse(values[index++]);//set the property on contract
            return c;
        }

        /// <summary>
        /// this func convert code to xml
        /// </summary>
        XElement convertCodeToXML(int n, string kind)
        {
            XElement code = new XElement(kind, n);
            return code;
        }

        /// <summary>
        /// this func get xelement and convert to code
        /// </summary>
        /// <param name="ex"> the ex element </param>
        /// <returns>code</returns>
        int convertXMLToCode(XElement x, string kind)
        {
            int code = Convert.ToInt32(x.Element(kind).Value);
            return code;
        }


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
            //cant add contract that child/nanny does not exist
            if (ch == null)
                throw new Exception("the child does not exist");
            if (nanny == null)
                throw new Exception("the nanny does not exist");
            if (GetAllMother(mo => mo.Id == ch.IdMother)==null)
                throw new Exception("the mother does not exist");
            
            if (GetAllContract(co => (co.NannyID == nanny.Id && co.ChildID == ch.Id)).Count() != 0)
                //cant add contract if it already exist
                throw new Exception("the child already has a contract with this nanny");
            if (c.EndContract < c.StartContract)
                //if the detials of the contract illegal
                throw new Exception("in this contract the end Date is little then start Date");
            if (((DateTime.Now - ch.DateOfBirth).Days / 30 < nanny.MinMonthesAge || (DateTime.Now - ch.DateOfBirth).Days / 30 > nanny.MaxMonthesAge))
                //if the child that sign in contract not in the range of age of nanny
                throw new Exception("the child is not in the range age of the nanny");
            LoadData();
            c.Code = Convert.ToInt32(Code.Element("code").Value);

            ContractRoot.Add(convertContractToXML(c));// add contract to file
            ContractRoot.Save(ContractPath);//save file
        
            XElement newCode = new XElement("code",c.Code+1);
            Code.Element("code").ReplaceWith(newCode);
            Code.Save(CodePath);//save file

        }


        /// <summary>
        /// This function get a number of contract and remove this contract from ContractList
        /// </summary>
        /// <param name="code">The code of contract to delete</param>
        /// <returns>True if the contract delete success</returns>
        public bool DeleteContract(int code)
        {
            XElement temp = ((from e in ContractRoot.Elements()
                              where (Convert.ToInt32(e.Element("Code").Value) == code )
                              select e).FirstOrDefault());
            Contract c = FindContract(code);// find the contract according the code
            if (c == null)
                throw new Exception("this contract does not exist");
            Nanny nanny = FindNanny(c.NannyID);// find the mother according the id in contract
            if (nanny == null)
                throw new Exception("the nanny does not exist");
            if (nanny.NumOfChildren > 0)
                nanny.NumOfChildren--;//less 1 child for the nanny
            else
                throw new Exception("nanny do not have children");
            temp.Remove(); // delete contract from file
            ContractRoot.Save(ContractPath);//save file
            return true;
        }

        /// <summary>
        /// This function get a contract and update this contract in ContractList
        /// </summary>
        /// <param name="c">The contract to update</param>
        public void UpDateContract(Contract c)
        {
            XElement temp = ((from e in ContractRoot.Elements()
                              where (Convert.ToInt32(e.Element("Code").Value) == c.Code)
                              select e).FirstOrDefault());
            if (c == null)
                throw new Exception("this contract does not exist");
            Contract ctemp = FindContract(c.Code);
            if (ctemp == null)
                throw new Exception("this contract is not exist in the file");
            if (c.EndContract < c.StartContract)//if the detials of the contract illegal
                throw new Exception("in this contract the end Date is little then start Date");
            Child ch = FindChild(c.ChildID);// find the child according the id in contract
            Nanny nanny = FindNanny(c.NannyID);// find the mother according the id in contract
            //if (ch == null || GetAllMother(mo => mo.Id == ch.IdMother).ToList().Count == 0 || FindNanny(c.NannyID) == null)
            //    //can not update contract that one of the people that sign does not exist
            //    throw new Exception("the child or the nanny of this contract does not exist");
            if (((DateTime.Now - ch.DateOfBirth).Days / 30 < nanny.MinMonthesAge || (DateTime.Now - ch.DateOfBirth).Days / 30 > nanny.MaxMonthesAge))
                //if the child that sign in contract not in the range of age of nanny
                throw new Exception("the child is not in the range age of the nanny");

            temp.ReplaceWith(convertContractToXML(c)); // update child of file
            ContractRoot.Save(ContractPath);//save file
        }


        /// <summary>
        /// This function get number of contract and search that contract
        /// </summary>
        /// <param name="code">The code of contract to search</param>
        /// <returns>Contract if this contract exist</returns>
        public Contract FindContract(int code)
        {
            XElement temp = ((from e in ContractRoot.Elements()
                              where (Convert.ToInt32(e.Element("Code").Value) == code)
                              select e).FirstOrDefault());
            return convertXMLTOContract(temp);//The child that id it's his id 
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
            LoadData();
            List<Contract> contracts = new List<Contract>();
            try
            {
                var items = from temp in ContractRoot.Elements()
                            select convertXMLTOContract(temp);//convert all contracts from xml
                contracts = items.ToList();//convert to list
            }
            catch
            {
                contracts = null;
            }

            if (predicate == null)
                return contracts.AsEnumerable();//return all contracts
            return contracts.Where(predicate).AsEnumerable();//return all contracts with the predicate
        }


        /// <summary>
        /// This function get predicate and need to find all the children that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the children are checked by it</param>
        /// <returns>IEnumerable of all the children that the predicate true for them</returns>
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        {
            LoadData();
            List<Child> children=new List<Child>();
            try
            {
                var items = from temp in ChildrenRoot.Elements()
                           select convertXMLTOChild(temp);//convert all children from xml
                children = items.ToList();//convert to list
            }
            catch
            {
                children = null;
            }
           
            if (predicate == null)
                return children.AsEnumerable();//return all children
            return children.Where(predicate).AsEnumerable();//return all children with the predicate
        }


        /// <summary>
        /// This function get predicate and need to find all the Mothers that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the Mothers are checked by it</param>
        /// <returns>IEnumerable of all the Mothers that the predicate true for them</returns>
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            LoadData();
            List<Mother> mothers = new List<Mother>();
            try
            {
                var items = from temp in MotherRoot.Elements()
                            select convertXMLTOMother(temp);//convert all mothers from xml
                mothers = items.ToList();//convert to list
            }
            catch
            {
                mothers = null;
            }

            if (predicate == null)
                return mothers.AsEnumerable();//return all mothers
            return mothers.Where(predicate).AsEnumerable();//return all mothers with the predicate
        }


        /// <summary>
        /// This function get predicate and need to find all the nannies that this predicate true
        /// </summary>
        /// <param name="predicate">The predicate that all the nannies are checked by it</param>
        /// <returns>IEnumerable of all the nannies that the predicate true for them</returns>
        public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        {
            LoadData();
            List<Nanny> nannies = new List<Nanny>();
            try
            {
                var items = from temp in NannyRoot.Elements()
                            select convertXMLTONanny(temp);//convert all nannies from xml
                nannies = items.ToList();//convert to list
            }
            catch
            {
                nannies = null;
            }

            if (predicate == null)
                return nannies.AsEnumerable();//return all nannies
            return nannies.Where(predicate).AsEnumerable();//return all nannies with the predicate
        }
        #endregion
    }
}
