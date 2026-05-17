using System.Diagnostics.Contracts;

namespace Tsinswreng.CsCore;


/// 定義“轉成序列化裸值”時使用的鉤子。
/// 主要給值對象、強類型 ID 之類的包裝類型使用，使其在 JSON 中可直接寫成
/// `123`、`"abc"` 這樣的裸值，而不必包成 `{ "Value": ... }`。
/// 通常不單獨使用，而是與 <see cref="I_ToDeSerialized"/> 成對實作並挂在
/// <see cref="IDictSerializable"/> 上。
public partial interface I_ToSerialized{
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
	[Pure]
	/// 默認實現爲原樣返回，表示“此值可直接作爲序列化結果”。
	/// 具體類型可覆寫此方法，把自身轉成底層原始值。
	public obj? ToSerialized(obj? Obj){
		return Obj;
	}
#endif
}

/// 定義“從反序列化裸值還原目標類型”時使用的鉤子。
/// 與 <see cref="I_ToSerialized"/> 對應，用來把 JSON 讀出的原始值重新包回
/// 值對象、強類型 ID 等業務類型。
/// 通常不單獨使用，而是透過 <see cref="IDictSerializable"/> 成對出現。
public partial interface I_ToDeSerialized{
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
	[Pure]
	/// 默認實現爲原樣返回。
	/// 具體類型可覆寫此方法，把底層原始值轉回自身類型。
	public obj? ToDeSerialized(obj? Obj){
		return Obj;
	}
#endif
}

/// 聚合序列化與反序列化兩個方向的標記接口。
/// 現有用途主要是讓外部轉換器能一眼識別“這是一個可按裸值讀寫的值類型”。
/// 名字裡雖有 `Dict`，但當前主要用途其實偏向 JSON 裸值轉換，而非字典映射。
public partial interface IDictSerializable
	:I_ToSerialized
	,I_ToDeSerialized
{

}


[Doc($$"""
自封裝之值類型需叶斯接口、㕥便序列化時免包一層`{"Value": xxx}`
""")]
public partial interface I_ValueObj{
	/// 以非泛型方式暴露底層值。
	/// 適合在不知道具體 T 的場合下，統一讀寫被包裝的原始值。
	public obj? ValueObj{get;set;}
}


[Doc(@$"generic version for {nameof(I_ValueObj)}")]
public partial interface I_Value<T>:I_ValueObj{
	/// 值對象實際承載的底層值。
	public T Value{get;set;}
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
	/// 顯式把泛型值橋接到非泛型接口，讓外部可以用統一入口訪問底層值。
	obj? I_ValueObj.ValueObj{
		get{
			return Value;
		}
		set{
			Value = (T)value!;
		}
	}
#endif
}

