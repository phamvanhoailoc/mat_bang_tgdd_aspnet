using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace WebAPI_project_banhang.Lib.Utils
{
    public class RageDate
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
    }
}
