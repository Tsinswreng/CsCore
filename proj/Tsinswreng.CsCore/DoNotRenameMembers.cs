namespace Tsinswreng.CsCore;

public class DoNotRenameMembers : Attribute{
	public str Message{get;} = "";
	public DoNotRenameMembers(str Message){
		this.Message = Message;
	}

	public DoNotRenameMembers(){}
}
