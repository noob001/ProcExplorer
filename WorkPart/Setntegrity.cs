using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Management;
using zmland.Win32;
using System.Security.Principal;

namespace WorkPart
{


    enum MANDATORY_LEVEL
    {
        MandatoryLevelUntrusted = 0,
        MandatoryLevelLow,
        MandatoryLevelMedium,
        MandatoryLevelHigh,
        MandatoryLevelSystem,
        MandatoryLevelSecureProcess,
        MandatoryLevelCount
    };
    







    public partial class GetProcInformation
    {
        public bool SetProcessIntegrityLevel(int integrityLvl = (0x00000000))
        {
            bool isok = false;
            int IL = -1;
            IntPtr hToken = IntPtr.Zero;
            uint cbTokenIL = 0;
            IntPtr pTokenIL = IntPtr.Zero;

            try
            {
                if (!OpenProcessToken(ProcList[ProcNumber].Handle, TokenAccessLevels.Query, out hToken))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0, out cbTokenIL))
                {
                    int error = Marshal.GetLastWin32Error();
                    if (error != ERROR_INSUFFICIENT_BUFFER)
                    {

                        throw new Win32Exception(error);
                    }
                }

                pTokenIL = Marshal.AllocHGlobal((int)cbTokenIL);
                if (pTokenIL == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenIL, cbTokenIL, out cbTokenIL))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                

                SetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenIL, cbTokenIL);

            }


            finally
            {

                if (hToken != null)
                {
                    CloseHandle(hToken);
                    hToken = IntPtr.Zero;
                }
                if (pTokenIL != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenIL);
                    pTokenIL = IntPtr.Zero;
                    cbTokenIL = 0;
                }
            }
            return isok;
        }
    }
}
