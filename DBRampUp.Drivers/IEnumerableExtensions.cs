using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBRampUp
{
	public static class IEnumerableExtensions
	{
		#region Shuffle
		private static readonly Random random = new Random();

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var array = source.ToArray();
			return ShuffleInternal(array, array.Length);
		}

		#endregion

		#region TakeRandom

		public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
		{
			var array = source.ToArray();
			return ShuffleInternal(array, Math.Min(count, array.Length)).Take(count);
		}

		#endregion

		#region ShuffleInternal

		private static IEnumerable<T> ShuffleInternal<T>(T[] array, int count)
		{
			// Durstenfeld implementation of the Fisher-Yates algorithm for an O(n) unbiased shuffle
			// starts from the beginning rather than the end so we can just shuffle the first count
			for (var n = 0; n < count; n++)
			{
				var k = random.Next(n, array.Length);
				var temp = array[n];
				array[n] = array[k];
				array[k] = temp;
			}

			return array;
		}

		#endregion
	}
}