using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchTests
{
    class AuthTestRail
    {
        private string t_url;
        private string user = "";
        private string password = "";


        public AuthTestRail(string t_url)
        {
            this.t_url = t_url;
        }

        public string T_utl { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
}
