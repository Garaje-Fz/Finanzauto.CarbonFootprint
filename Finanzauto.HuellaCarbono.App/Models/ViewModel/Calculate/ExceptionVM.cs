using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.App.Models.ViewModel.Calculate
{
    public class ExceptionVM
    {
        public string description { get; set; }
        public List<YearVM> Anios { get; set; }
    }
}
