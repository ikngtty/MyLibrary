using System;
using NUnit.Framework;
using Ikngtty.MyLibrary.Utility;

namespace Ikngtty.MyLibraryTest.Utility
{
	[TestFixture]
	public class StringUtilityTest
	{
		[Test]
		public void RepeatTest()
		{
			Assert.AreEqual("hogehogehoge", "hoge".Repeat(3));
			Assert.AreEqual("", "hoge".Repeat(0));
		}
	}
}
