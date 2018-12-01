using CSharpKatas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CSharpKatasTests
{
    public class DiscoverPINTests
    {
        [Fact]
        public void GetPIN_Simple()
        {
            // 3845
            var discoverPIN = new DiscoverPIN();
            var result = discoverPIN.GetPIN(new string[] { "352", "384", "845", "352" });

            Assert.Equal("38452", result);
        }

        [Fact]
        public void GetPin_File()
        {
            var file = File.ReadAllLines("keylogger.txt");
            var result = new DiscoverPIN().GetPIN(file);

            Assert.Equal("73162890", result);
        }

        [Fact]
        public void GetPin_BruteForce()
        {
            var file = File.ReadAllLines("keylogger.txt");
            var result = new DiscoverPIN().BruteForce(file);

            Assert.Equal("73162890", result);
        }
    }
}
