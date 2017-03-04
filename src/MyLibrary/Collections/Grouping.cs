using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ikngtty.MyLibrary.Collections
{
	public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
	{
		public TKey Key { get; set; }
		public List<TElement> Elements { get; set; }
		
		public Grouping()
		{
			this.Elements = new List<TElement>();
		}
		
		public TElement this[int index]
		{
			get
			{
				return this.Elements[index];
			}
			set
			{
				this.Elements[index] = value;
			}
		}
		
		public IEnumerator<TElement> GetEnumerator()
		{
			return this.Elements.GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)GetEnumerator();
		}
	}
}
