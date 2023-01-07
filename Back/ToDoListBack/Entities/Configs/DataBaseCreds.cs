using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configs
{
    //"Host=192.168.133.128;Port=5432;Database=Test1;Username=postgres;Password=123qwe45asd"
    

    public class DataBaseCreds
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
