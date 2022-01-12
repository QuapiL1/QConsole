using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace QConsole.classes.security
{
    public class EmergencyLockout
    {
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);
        
        const int WTS_CURRENT_SESSION = -1;
        static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        public static void Lock()
        {
            if (!WTSDisconnectSession(WTS_CURRENT_SERVER_HANDLE,
                WTS_CURRENT_SESSION, false))
                throw new Win32Exception();
        }
    }
}