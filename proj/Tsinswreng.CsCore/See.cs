namespace Tsinswreng.CsCore;

[AttributeUsage(AttributeTargets.All)]
public partial class See : Attribute{
	public str Name{get;set;}
	public See(str Name){
		this.Name = Name;
	}
}
