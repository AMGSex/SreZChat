using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatKekis.Model;

namespace ChatKekis.Classes
{
    internal class DBconnection
    {
        public static ChatKekisSreZEntities connect = new ChatKekisSreZEntities();
    }
}
