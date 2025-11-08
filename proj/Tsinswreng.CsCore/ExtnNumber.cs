namespace Tsinswreng.CsCore;

public static class ExtnNumber{
	public static i32 ToI32(this i64 I64) => (i32)I64;
	public static i32 ToI32(this u64 I64) => (i32)I64;
}
