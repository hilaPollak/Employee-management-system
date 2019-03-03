using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
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

        private int idmother;// id of the mother
        public int IdMother
        {
            get { return idmother; }
            set
            {
                if (value < 0)//nagative id
                    throw new Exception("this id is not legal");
                idmother = value;
            }
        }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasSpecialNeeds { get; set; }// if the child has spacial needs
        public string SpecialNeeds { get; set; }//which spacial needs the child has

        public override string ToString()
        {
            return (BE.ToString.ToStringProperty(this));//class who return string with all the datas she gets.
        }
        public Child(int idChild=0, int idMother=0)//constructor
        {
            Id = idChild;
            IdMother = idMother;
        }
    }
}
