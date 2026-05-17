namespace Tsinswreng.CsCore;

using System.Collections;

[Doc("Most used extension")]
public static class Extn {
	extension<TArg, TRtn>(TArg) {
		[Doc(@$"pipe operator")]
		public static TRtn operator |(TArg Arg, Func<TArg, TRtn> Fn) {
			return Fn(Arg);
		}
	}

	[Doc(@$"simple writing style for Batch add")]
	public static void AddRange<T>(this ICollection<T> C, IEnumerable<T> Items) {
		if (C is List<T> l) {
			l.AddRange(Items);
			return;
		}
		foreach (var item in Items) {
			C.Add(item);
		}
	}

	[Doc(@$"JS style .sort((a,b)=>a-b)")]
	public static void Sort<T>(this IList<T> list, Comparison<T> comparison) {
		if (list == null) throw new ArgumentNullException(nameof(list));
		if (comparison == null) throw new ArgumentNullException(nameof(comparison));

		// ArrayList.Adapter 能把 IList 包装成 ArrayList，然后 ArrayList.Sort 可以调用 IComparer
		ArrayList.Adapter((IList)list).Sort(new ComparisonComparer<T>(comparison));
	}

	private class ComparisonComparer<T> : IComparer {
		private readonly Comparison<T> _comparison;
		public ComparisonComparer(Comparison<T> comparison) {
			_comparison = comparison ?? throw new ArgumentNullException(nameof(comparison));
		}

		public int Compare(object x, object y) {
			return _comparison((T)x, (T)y);
		}
	}

	[Doc(@$"substitute of `ToList()`.
	can avoid unnecessary copying when the source is already a list.
	")]
	public static IList<T> AsOrToList<T>(
		this IEnumerable<T> z
	) {
		if (z is IList<T> list) {
			return list;
		}
		return new List<T>(z);
	}

	[Doc(@$"null-safe Equals")]
	public static bool EqObj(
		this obj? z,
		obj? Other
	) {
		if (z is null) {
			if (Other is null) {
				return true;
			}
			return false;
		}
		return z.Equals(Other);
	}


	[Doc(@$"Enum comparison, the right operand can be a string(Case sensitive)")]
	public static bool Eq<TEnum>(
		this TEnum z,
		str o
	) where TEnum : struct, Enum {
		return z.ToString() == o;
	}

	[Doc(@$"Enum comparison, the right operand can be a string(Case sensitive) or an enum value.")]
	public static bool Eq(this Enum z, obj o) {
		if (z.Equals(o)) {
			return true;
		}
		if (o is str s && s == z.ToString()) {
			return true;
		}
		return false;
	}
	
	[Doc(@$"Enum comparison, the right operand can be a string(Case sensitive) or an enum value or null.")]
	public static bool Eq<TEnum>(
		this TEnum z,
		TEnum? o
	) where TEnum : struct, Enum {
		return z.Equals(o);
	}

#if NET5_0_OR_GREATER
	extension<T>(IAsyncEnumerable<T> z){
		[Doc(@$"Get an empty `IAsyncEnumerable<T>`")]
		public static async IAsyncEnumerable<T> Empty(){
			yield break;
		}
	}

	[Doc(@$"null-coalescing for `IAsyncEnumerable<T>?`")]
	public static IAsyncEnumerable<T> OrEmpty<T>(this IAsyncEnumerable<T>? z){
		return z ?? IAsyncEnumerable<T>.Empty();
	}
#endif

	extension<K, V>(IDictionary<K, V> z) {
		[Doc(@"`Dictionary<,>` originally has this
		but `IDictionary<,>` does not.")]
		public V GetValueOrDefault(K key, V defaultValue) {
			if (z.TryGetValue(key, out var value)) {
				return value;
			}
			return defaultValue;
		}
	}

}
