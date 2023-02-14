using Finanzauto.HuellaCarbono.Domain.Common;
using System.Data;

namespace Finanzauto.HuellaCarbono.Domain
{
    public class user : Ordering
    {
        public int Id { get; set; }
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrUserName { get; set; }
        public string usrEmail { get; set; }
        public string usrPassword { get; set; }
        public bool State { get; set; }
        public DateTime DateCreate  { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
