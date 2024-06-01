using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public abstract class Controller
    {
        protected string[] GetStrStatus(string data)
        {
            string[] arrStrStatus = Regex.Split(data, "\r\n");
            Array.Resize(ref arrStrStatus, arrStrStatus.Length - 1);
            return arrStrStatus;
        }

    }
}
