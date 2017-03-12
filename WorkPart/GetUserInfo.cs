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
        static List<IdentityReference> GroupList = new List<IdentityReference>();
        public static List<string> Getgroups(out string name)
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            IdentityReferenceCollection t = currentUser.Groups;
            List<string> groups = new List<string>();
            foreach (IdentityReference i in t)
            {
                groups.Add(new SecurityIdentifier(i.Value).Translate(typeof(NTAccount)).ToString());
                GroupList.Add(i);
            }
            name = currentUser.Name;
            return groups;
        }

        public static bool AddUserToLocalGroup(string userName="testfortest")
        {
            DirectoryEntry userGroup = null;
          
            try
            {
                string groupPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, "DDD");
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
                System.Windows.Forms.MessageBox.Show("Mistake");
                return false;
            }
            finally
            {
                if (null != userGroup) userGroup.Dispose();
            }
        }

        public static bool DeleteUserFromLocalGroup(string userName, int listNumber)
        {
            DirectoryEntry userGroup = null;
            string groupName = new SecurityIdentifier(GroupList[listNumber].Value).Translate(typeof(NTAccount)).ToString();
            try
            {
                string groupPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, groupName);
                userGroup = new DirectoryEntry(groupPath);
                if ((null == userGroup) || (true == String.IsNullOrEmpty(userGroup.SchemaClassName)) || (0 != String.Compare(userGroup.SchemaClassName, "group", true, CultureInfo.CurrentUICulture)))
                    return false;

                String userPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},user", Environment.MachineName, userName);
                userGroup.Invoke("Delete", new object[] { userPath });
                userGroup.CommitChanges();

                return true;
            }

            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Mistake");
                return false;
            }
            finally
            {
                if (null != userGroup) userGroup.Dispose();
            }
        }
    }
}
