using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace zoooo
{
    public class Animal
    {
        private string _id;
        private string _timeforfeeding;
        private string _worker;
        private string _section; // буква и цифра
        private string _foodset; //цифра и буква
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

        public string Timeforfeeding
        {
            get
            {
                return _timeforfeeding;
            }

            set
            {
                _timeforfeeding = value;
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

        public Animal( string id, string timeforfeeding, string worker, string section, string foodset, string species)
        {
            _id = id;
            _timeforfeeding = timeforfeeding;
            _worker = worker;
            _section = section;
            _foodset = foodset;
            _species = species;
        }

        public Animal()
        { }

        public string Postinganimal
        {
            get
            {
                return $"{_id} - {_species} - {_timeforfeeding} - {_worker} - {_section} - {_foodset}";
            }
        }


    }
}