
public class MultiplyingInterceptor : IDynamicInterceptor
{
	public void Intercept(IInvocation invocation)
	{
		invocation.ReturnValue = ((int)invocation.Arguments[0]) * ((int)invocation.Arguments[1]);
	}
}