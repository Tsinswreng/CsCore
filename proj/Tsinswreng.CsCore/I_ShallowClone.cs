namespace Tsinswreng.CsCore;


public partial interface I_ShallowCloneSelf{
	public object ShallowCloneSelf()
#if Impl
	{
		return MemberwiseClone();
	}
#else
	;
#endif
}
