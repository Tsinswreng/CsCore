namespace Tsinswreng.CsCore;


public class DoNotRename : Attribute{
	public str Message{get;} = "";
	public DoNotRename(str Message){
		this.Message = Message;
	}

	public DoNotRename(){}
}
