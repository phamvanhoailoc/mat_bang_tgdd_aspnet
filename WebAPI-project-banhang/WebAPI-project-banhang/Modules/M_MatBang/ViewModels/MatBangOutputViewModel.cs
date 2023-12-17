using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MediatR;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using System.Collections.Generic;

namespace WebAPI_project_banhang.Modules.M_MatBang.ViewModels
{
    public class MatBangOutputViewModel
    {
        public List<MatBang> matbang { get; set; }
        public int TotalCount { get; set; }
    }
}
