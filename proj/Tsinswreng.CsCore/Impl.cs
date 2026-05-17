using System.Diagnostics;

namespace Tsinswreng.CsCore;

[AttributeUsage(AttributeTargets.All)]
[Conditional("COMPILE_TIME_ONLY")]
[Doc(@$"Implemention mark, especially for implementing interface")]
public partial class Impl : Attribute{
	public Type? ParentType { get; }
	public Type[]? ParentTypes{get;set;}
	public Impl(Type? Type = null) {
		this.ParentType = Type;
	}
	public Impl(Type[]? Types){
		this.ParentTypes = Types;
	}
}
