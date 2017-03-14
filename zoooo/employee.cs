using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zoooo
{
    public class Employee
    {
        private string _name;
        private string _surname;
        private string _workinghours;
        private string _id;

        

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = value;
            }
        }

        public string Workinghours
        {
            get
            {
                return _workinghours;
            }

            set
            {
                _workinghours = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public Employee(string name, string surname, string workinghours, string id)
        {
            _name = name;
            _surname = surname;
            _workinghours = workinghours;
            _id = id;
        }
    }
}