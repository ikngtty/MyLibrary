using System;
using System.Linq;

namespace Ikngtty.MyLibrary.Utility
{
	public static class StringUtility
	{
		public static string Repeat(this string text, uint repeatCount)
		{
			return string.Concat(Enumerable.Repeat(text, (int)repeatCount));
		}
	}
}
