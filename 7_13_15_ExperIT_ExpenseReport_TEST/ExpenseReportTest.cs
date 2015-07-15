using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_13_15_ExperIT_ExpenseReport_TEST
{
    class ExpenseReportTest
    {


        [Fact]

        public void NumberDividedByThree()
        {

            var ourTest = new _7_13_15_ExperIT_ExpenseReport.ExpenseReportTest();


            string answer = ourTest.DoTheThing(3);


            Assert.Equal("Fizz", answer);
        }






    }
}
