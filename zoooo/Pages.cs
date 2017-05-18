using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoooo
{
    class Pages
    {
        private static MainPage _mainPage = new MainPage();
        private static LoginPage _loginPage = new LoginPage();
        private static GuestPage _guestPage = new GuestPage();


        public static LoginPage LoginPage
        {
            get
            {
                return _loginPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }


        public static GuestPage GuestPage
        {
            get
            {
                return _guestPage;
            }
        }

    }
}
