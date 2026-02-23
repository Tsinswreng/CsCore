using System.Diagnostics;

namespace Tsinswreng.CsCore;

/*
typst風格
[Doc(@$"
#Sum[]
#Param[{nameof(DbDict)}][]
#TParam[{nameof(T)}]
#Rtn[{nameof(T)}][]
")]


[Doc(@$"
#Sum[]
#Params([],[])
#TParams([],[])
#Rtn[]
")]
 */
[AttributeUsage(AttributeTargets.All, AllowMultiple =true)]
[Conditional("COMPILE_TIME_ONLY")]
public partial class Doc : Attribute{
	public str? Summary{get;set;}
	public Doc(str Summary){
		this.Summary = Summary;
	}
}
