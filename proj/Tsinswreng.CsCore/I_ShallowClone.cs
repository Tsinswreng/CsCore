namespace Tsinswreng.CsCore;


public interface I_ShallowCloneSelf{
	public object ShallowCloneSelf()
#if Impl
	{
		return MemberwiseClone();
	}
#else
	;
#endif
}
