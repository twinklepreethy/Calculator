using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class FunctionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public FunctionTypeEnum Type { get; set; }
    }
}
