using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CSCreateLowIntegrityProcess;

namespace WorkPart
{
    public partial class GetProcInformation
    {
        public void SetProcessIntegrityLevel(int level)
        {
            NativeHelper.SetProcessIntegrityLevel(ProcList[ProcNumber].Handle, (NativeHelper.MANDATORY_LEVEL) level);
        }
    }

    public class NativeHelper
    {
        public enum MANDATORY_LEVEL
        {
            SECURITY_MANDATORY_UNTRUSTED_RID,
            SECURITY_MANDATORY_LOW_RID,
            SECURITY_MANDATORY_MEDIUM_RID,
            SECURITY_MANDATORY_HIGH_RID,
            SECURITY_MANDATORY_SYSTEM_RID
        }

        public static bool SetProcessIntegrityLevel(IntPtr provessHandle, MANDATORY_LEVEL integrityLvl)
        {
            bool isok = false;
            SafeTokenHandle hToken = null;
            IntPtr pIntegritySid = IntPtr.Zero;
            int cbTokenInfo = 0;
            IntPtr pTokenInfo = IntPtr.Zero;

            try
            {
                if (!NativeMethod.OpenProcessToken(provessHandle,
                    NativeMethod.TOKEN_QUERY | NativeMethod.TOKEN_ADJUST_DEFAULT, out hToken))
                {
                    throw new Win32Exception();
                }

                // Create the low integrity SID.
                if (!NativeMethod.AllocateAndInitializeSid(
                    ref NativeMethod.SECURITY_MANDATORY_LABEL_AUTHORITY, 1,
                    (int) integrityLvl,
                    0, 0, 0, 0, 0, 0, 0, out pIntegritySid))
                {
                    throw new Win32Exception();
                }

                TOKEN_MANDATORY_LABEL tml;
                tml.Label.Attributes = NativeMethod.SE_GROUP_INTEGRITY;
                tml.Label.Sid = pIntegritySid;

                // Marshal the TOKEN_MANDATORY_LABEL struct to the native memory.
                cbTokenInfo = Marshal.SizeOf(tml);
                pTokenInfo = Marshal.AllocHGlobal(cbTokenInfo);
                Marshal.StructureToPtr(tml, pTokenInfo, false);

                // Set the integrity level in the access token to low.
                if (!NativeMethod.SetTokenInformation(hToken,
                    CSCreateLowIntegrityProcess.TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenInfo,
                    cbTokenInfo + NativeMethod.GetLengthSid(pIntegritySid)))
                {
                    throw new Win32Exception();
                }
                isok = true;
            }
            finally
            {
                // Centralized cleanup for all allocated resources. 
                if (hToken != null)
                {
                    hToken.Close();
                    hToken = null;
                }
                if (pIntegritySid != IntPtr.Zero)
                {
                    NativeMethod.FreeSid(pIntegritySid);
                    pIntegritySid = IntPtr.Zero;
                }
                if (pTokenInfo != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenInfo);
                    pTokenInfo = IntPtr.Zero;
                    cbTokenInfo = 0;
                }
            }
            return isok;
        }
    }
}
