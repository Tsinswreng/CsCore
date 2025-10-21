namespace Tsinswreng.CsCore;


public partial interface I_ToSerialized{
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
	//pure fn
	public obj? ToSerialized(obj? Obj){
		return Obj;
	}
#endif
}

public partial interface I_ToDeSerialized{
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
	//pure fn
	public obj? ToDeSerialized(obj? Obj){
		return Obj;
	}
#endif
}

public partial interface IDictSerializable
	:I_ToSerialized
	,I_ToDeSerialized
{

}


/// <summary>
/// 自封裝之值類型需叶斯接口、㕥便序列化時免包一層{"Value": xxx}
/// </summary>
/// <typeparam name="T"></typeparam>
public partial interface I_ValueObj{
	public obj? ValueObj{get;set;}
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
#endif
}


public partial interface I_Value<T>:I_ValueObj{
	public T Value{get;set;}
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
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

