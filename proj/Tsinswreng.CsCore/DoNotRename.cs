using System.Diagnostics;

namespace Tsinswreng.CsCore;

[Conditional("COMPILE_TIME_ONLY")]
public class DoNotRename : Attribute{
	public str Message{get;} = "";
	public DoNotRename(str Message){
		this.Message = Message;
	}

	public DoNotRename(){}
}
