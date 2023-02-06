using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Auth.Models
{
    public class Tokens
    {
        public int usrId { get; set; }
        public string tknId { get; set; }
        public string usrDomainName { get; set; }
        public int rolId { get; set; }
        public string rolDescription { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
