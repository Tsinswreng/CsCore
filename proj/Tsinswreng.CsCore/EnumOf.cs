namespace Tsinswreng.CsCore;

public class EnumOf :Attribute{
	public Type? EnumType { get; set; }
	public EnumOf(Type? EnumType){
		this.EnumType = EnumType;
	}
}
