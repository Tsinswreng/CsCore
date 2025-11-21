namespace Tsinswreng.CsCore;
using System.Collections;


/// <summary>
/// Most used extension
/// </summary>
public static class Extn{
	extension<TArg, TRtn>(TArg){
		public static TRtn operator|(TArg Arg, Func<TArg, TRtn> Fn){
			return Fn(Arg);
		}
	}
	public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items) {
		foreach (var item in items) {
			list.Add(item);
		}
	}
	public static void Sort<T>(this IList<T> list, Comparison<T> comparison){
		if (list == null) throw new ArgumentNullException(nameof(list));
		if (comparison == null) throw new ArgumentNullException(nameof(comparison));

		// ArrayList.Adapter 能把 IList 包装成 ArrayList，然后 ArrayList.Sort 可以调用 IComparer
		ArrayList.Adapter((IList)list).Sort(new ComparisonComparer<T>(comparison));
	}

	private class ComparisonComparer<T> : IComparer{
		private readonly Comparison<T> _comparison;
		public ComparisonComparer(Comparison<T> comparison){
			_comparison = comparison ?? throw new ArgumentNullException(nameof(comparison));
		}

		public int Compare(object x, object y){
			return _comparison((T)x, (T)y);
		}
	}

	public static IList<T> AsOrToList<T>(
		this IEnumerable<T> z
	){
		if(z is IList<T> list){
			return list;
		}
		return new List<T>(z);
	}


	/// <summary>
	/// Case sensitive
	/// </summary>
	/// <typeparam name="TEnum"></typeparam>
	/// <param name="z"></param>
	/// <param name="o"></param>
	/// <returns></returns>
	public static bool Eq<TEnum>(
		this TEnum z,
		TEnum o
	)where TEnum : struct, Enum
	{
		return z.Equals(o);
	}

	/// <summary>
	/// Case sensitive
	/// </summary>
	/// <typeparam name="TEnum"></typeparam>
	/// <param name="z"></param>
	/// <param name="o"></param>
	/// <returns></returns>
	public static bool Eq<TEnum>(
		this TEnum z,
		str o
	)where TEnum : struct, Enum
	{
		return z.ToString() == o;
	}

	public static bool Eq(this Enum z, obj o){
		if(z.Equals(o)){
			return true;
		}
		if(o is str s && s == z.ToString()){
			return true;
		}
		return false;
	}

#if NET5_0_OR_GREATER
	extension<T>(IAsyncEnumerable<T> z){
		public static async IAsyncEnumerable<T> Empty(){
			yield break;
		}
	}

	public static IAsyncEnumerable<T> OrEmpty<T>(this IAsyncEnumerable<T>? z){
		return z ?? IAsyncEnumerable<T>.Empty();
	}
#endif

}
