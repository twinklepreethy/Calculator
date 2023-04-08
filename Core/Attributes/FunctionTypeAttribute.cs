using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Attributes
{
    public class FunctionTypeAttribute : Attribute
    {
        public FunctionTypeEnum FunctionType { get; }

        public FunctionTypeAttribute(FunctionTypeEnum functionType)
        {
            FunctionType = functionType;
        }
    }
}
