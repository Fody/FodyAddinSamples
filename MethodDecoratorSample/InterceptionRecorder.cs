public static class InterceptionRecorder
{
    public static bool OnEntryCalled;
    public static bool OnExitCalled;
    public static bool OnExceptionCalled;

    public static void Clear() =>
        OnExitCalled= OnEntryCalled = OnExceptionCalled = false;
}