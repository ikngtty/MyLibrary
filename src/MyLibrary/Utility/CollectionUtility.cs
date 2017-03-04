using System;
using System.Collections.Generic;
using System.Linq;
using Ikngtty.MyLibrary.Collections;

namespace Ikngtty.MyLibrary.Utility
{
	public static class CollectionUtility
	{
		#region GroupByAdjacently
		
		/// <summary>
		/// A method like <see cref="System.Linq.Enumerable.GroupBy"/>.
		/// </summary>
		/// <remarks>
		/// When a source is as follows:
		/// 1,1,2,2,1,1
		/// 
		/// , in <see cref="System.Linq.Enumerable.GroupBy"/> it is grouped as follows:
		/// {1,1,1,1},{2,2}
		/// 
		/// , but in this method as follows:
		/// {1,1},{2,2},{1,1}
		/// </remarks>
		public static List<Grouping<TKey, TSource>> GroupByAdjacently<TSource, TKey>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				EqualityComparer<TKey>.Default
			);
		}
		
		public static List<Grouping<TKey, TSource>> GroupByAdjacently<TSource, TKey>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				sourceItem => sourceItem,
				comparer
			);
		}
		
		public static List<Grouping<TKey, TElement>> GroupByAdjacently<TSource, TKey, TElement>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				elementSelector,
				EqualityComparer<TKey>.Default
			);
		}
		
		public static List<Grouping<TKey, TElement>> GroupByAdjacently<TSource, TKey, TElement>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector,
			IEqualityComparer<TKey> comparer
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				elementSelector,
				(key, elements) => new Grouping<TKey, TElement>() { Key = key, Elements = elements },
				comparer
			);
		}
		
		public static List<TResult> GroupByAdjacently<TSource, TKey, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TKey, List<TSource>, TResult> resultSelector
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				resultSelector,
				EqualityComparer<TKey>.Default
			);
		}
		
		public static List<TResult> GroupByAdjacently<TSource, TKey, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TKey, List<TSource>, TResult> resultSelector,
			IEqualityComparer<TKey> comparer
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				sourceItem => sourceItem,
				resultSelector,
				comparer
			);
		}
		
		public static List<TResult> GroupByAdjacently<TSource, TKey, TElement, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector,
			Func<TKey, List<TElement>, TResult> resultSelector
		)
		{
			return GroupByAdjacently(
				source,
				keySelector,
				elementSelector,
				resultSelector,
				EqualityComparer<TKey>.Default
			);
		}
		
		public static List<TResult> GroupByAdjacently<TSource, TKey, TElement, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector,
			Func<TKey, List<TElement>, TResult> resultSelector,
			IEqualityComparer<TKey> comparer
		)
		{
			List<TResult> results = new List<TResult>();
			if (!source.Any())
			{
				return results;
			}
			
			TSource firstSourceItem = source.First();
			TKey firstKey = keySelector(firstSourceItem);
			TElement firstElement = elementSelector(firstSourceItem);
			
			TKey previousKey = firstKey;
			List<TElement> elements = new List<TElement>();
			elements.Add(firstElement);
			
			foreach (TSource sourceItem in source.Skip(1))
			{
				TKey key = keySelector(sourceItem);
				TElement element = elementSelector(sourceItem);
				
				if (!comparer.Equals(key, previousKey))
				{
					TResult result = resultSelector(previousKey, elements);
					results.Add(result);
					
					previousKey = key;
					elements = new List<TElement>();
				}
				
				elements.Add(element);
			}
			
			TResult lastResult = resultSelector(previousKey, elements);
			results.Add(lastResult);
			
			return results;
		}
		
		#endregion
	}
}
