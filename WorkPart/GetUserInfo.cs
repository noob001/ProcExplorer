using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.DirectoryServices;

namespace WorkPart
{
    public class GetUserInfo
    {
        public static List<string> Getgroups(out string name)
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            IdentityReferenceCollection t = currentUser.Groups;
            List<string> groups = new List<string>();
            foreach (IdentityReference i in t)
                groups.Add(new SecurityIdentifier(i.Value).Translate(typeof(NTAccount)).ToString());
            name = currentUser.Name;
            return groups;
        }

        public static bool AddUserToLocalGroup(string userName, string groupName)
        {
            DirectoryEntry userGroup = null;

            try
            {
                string groupPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, groupName);
                userGroup = new DirectoryEntry(groupPath);
                if ((null == userGroup) || (true == String.IsNullOrEmpty(userGroup.SchemaClassName)) || (0 != String.Compare(userGroup.SchemaClassName, "group", true, CultureInfo.CurrentUICulture)))
                    return false;

                String userPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},user", Environment.MachineName, userName);
                userGroup.Invoke("Add", new object[] { userPath });
                userGroup.CommitChanges();

                return true;
            }

            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (null != userGroup) userGroup.Dispose();
            }
        }

    }
}
