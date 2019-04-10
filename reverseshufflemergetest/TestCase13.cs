using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace Tests
{
    class TestCase13
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void testCase13()
        {
            var f = File.Open("../../../Files/TestCase13.txt", FileMode.Open, FileAccess.Read);
            TextReader tr = new StreamReader(f);
            string input = tr.ReadLine();
            string result = tr.ReadLine();

            string output = reverseshufflemerge.ReverseShuffleMerge.reverseShuffleMerge(input);
            Assert.AreEqual(output, result);
        }
    }
}
