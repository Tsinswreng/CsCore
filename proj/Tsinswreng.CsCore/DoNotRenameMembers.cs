using System.Diagnostics;

namespace Tsinswreng.CsCore;
[Conditional("COMPILE_TIME_ONLY")]
public class DoNotRenameMembers : Attribute{
	public str Message{get;} = "";
	public DoNotRenameMembers(str Message){
		this.Message = Message;
	}

	public DoNotRenameMembers(){}
}
