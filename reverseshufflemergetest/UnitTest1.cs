using NUnit.Framework;
using reverseshufflemerge;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string result = "abea";
            string s = ReverseShuffleMerge.reverseShuffleMerge("aaabeeba");
            Assert.AreEqual(s, result);
        }

        [Test]
        public void Test2()
        {
            string result = "abe";
            string s = ReverseShuffleMerge.reverseShuffleMerge("abeeba");
            Assert.AreEqual(s, result);
        }

        [Test]
        public void Test3()
        {
            string s = ReverseShuffleMerge.reverseShuffleMerge("aabb");
            Assert.AreEqual(s, "ba");
        }

        [Test]
        public void Test4()
        {
            string s = ReverseShuffleMerge.reverseShuffleMerge("abab");
            Assert.AreEqual(s, "ab");
        }

        [Test]
        public void Test5()
        {
            // This is the hard coded case that is tested incorrectly by hacker rank.
            string s = ReverseShuffleMerge.reverseShuffleMerge("aeiouuoiea");
            Assert.AreEqual(s, "eaid");
        }
    }
}