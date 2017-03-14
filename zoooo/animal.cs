using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zoooo
{
    public class Animal
    {
        private string _id;
        private string _time4feeding;
        private string _worker;
        private string _section;
        private string _foodset;
        private string _species;

        

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

        public string Time4feeding
        {
            get
            {
                return _time4feeding;
            }

            set
            {
                _time4feeding = value;
            }
        }

        public string Worker
        {
            get
            {
                return _worker;
            }

            set
            {
                _worker = value;
            }
        }

        public string Section
        {
            get
            {
                return _section;
            }

            set
            {
                _section = value;
            }
        }

        public string Foodset
        {
            get
            {
                return _foodset;
            }

            set
            {
                _foodset = value;
            }
        }

        public string Species
        {
            get
            {
                return _species;
            }

            set
            {
                _species = value;
            }
        }

        public Animal( string id, string time4feeding, string worker, string section, string foodset, string species)
        {
            _id = id;
            _time4feeding = time4feeding;
            _worker = worker;
            _section = section;
            _foodset = foodset;
            _species = species;
        }
    }
}