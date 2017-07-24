using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookAddIn2013
{
    internal sealed partial class Settings
    {
        private static char separator = ',';
        private static string separatorS = separator.ToString();

        public string[] _KeysProcessed
        {
            get
            {
                var k = KeysProcessed;
                return k == null ? new string[] { } : k.Split(separator);
            }
            set
            {
                KeysProcessed = String.Join(separatorS, value);
            }
        }

        public string[] _IdsCreated
        {
            get
            {
                var k = IdsCreated;
                return k == null ? new string[] { } : k.Split(separator);
            }
            set
            {
                IdsCreated = String.Join(separatorS, value);
            }
        }

    }
    
}
