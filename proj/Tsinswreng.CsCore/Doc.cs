namespace Tsinswreng.CsCore;

[AttributeUsage(AttributeTargets.All)]
public partial class Doc : Attribute{
	public str? Summary{get;set;}
	public Doc(str Summary){
		this.Summary = Summary;
	}
}
