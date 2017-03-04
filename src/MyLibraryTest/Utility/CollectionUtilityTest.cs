using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ikngtty.MyLibrary.Collections;
using Ikngtty.MyLibrary.Utility;

namespace Ikngtty.MyLibraryTest.Utility
{
	[TestFixture]
	public class CollectionUtilityTest
	{
		[Test]
		public void GroupByAdjacentlyTest()
		{
			{
				string[] source = new string[0];
				List<Grouping<string, string>> result = source.GroupByAdjacently(item => item);
				Assert.AreEqual(0, result.Count);
			}
			
			{
				string[] source = new string[] { "abc" };
				List<Grouping<int, string>> result = source.GroupByAdjacently(item => item.Length);
				Assert.AreEqual(1, result.Count);
				{
					Grouping<int, string> resultItem = result[0];
					Assert.AreEqual(3, resultItem.Key);
					Assert.AreEqual(1, resultItem.Elements.Count);
					Assert.AreEqual("abc", resultItem[0]);
				}
			}
			
			{
				string[] source = new string[] { "a", "b", "b", "c", "c", "c", "b", "b", null, null, "a" };
				List<Grouping<string, string>> result = source.GroupByAdjacently(item => item);
				Assert.AreEqual(6, result.Count);
				{
					Grouping<string, string> resultItem = result[0];
					Assert.AreEqual("a", resultItem.Key);
					Assert.AreEqual(1, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == "a"));
				}
				{
					Grouping<string, string> resultItem = result[1];
					Assert.AreEqual("b", resultItem.Key);
					Assert.AreEqual(2, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == "b"));
				}
				{
					Grouping<string, string> resultItem = result[2];
					Assert.AreEqual("c", resultItem.Key);
					Assert.AreEqual(3, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == "c"));
				}
				{
					Grouping<string, string> resultItem = result[3];
					Assert.AreEqual("b", resultItem.Key);
					Assert.AreEqual(2, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == "b"));
				}
				{
					Grouping<string, string> resultItem = result[4];
					Assert.AreEqual(null, resultItem.Key);
					Assert.AreEqual(2, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == null));
				}
				{
					Grouping<string, string> resultItem = result[5];
					Assert.AreEqual("a", resultItem.Key);
					Assert.AreEqual(1, resultItem.Elements.Count);
					Assert.True(resultItem.Elements.All(e => e == "a"));
				}
			}
		}
	}
}
