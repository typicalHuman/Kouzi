using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class NavigateArgs
    { 
        public NavigateArgs(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
