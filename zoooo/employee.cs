using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace zoooo
{
    public class Employee
    {
        private string _name;
        private string _surname;
        private string _workinghours;
        private string _id;
        private string _animal;

        

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

        public string Animal
        {
            get
            {
                return _animal;
            }

            set
            {
                _animal = value;
            }
        }

        public Employee(string name, string surname, string workinghours, string id, string animal)
        {
            _name = name;
            _surname = surname;
            _workinghours = workinghours;
            _id = id;
            _animal = animal;
        }
       
        public Employee()
        {
        }

        public string Postingemployee
        {
            get
            {
                return $"{_id} -  {_name} - {_surname} - {_workinghours} - {_animal}";
            }
        }



    }
}