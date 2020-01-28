using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchTests
{
    class TestRailData
    {
        private string result_id;
        private string test_run_id;


        public TestRailData (string result_id, string test_run_id)
        {
            this.result_id = result_id;
            this.test_run_id = test_run_id;
        }

        public string Result_id { get; set; }

        public string Test_run_id { get; set; }
    }

    
}
