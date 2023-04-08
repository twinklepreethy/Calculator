using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    public enum FunctionTypeEnum
    {
        [Description("CombinedWith: P(A)P(B)")]
        CombinedWith = 1,

        [Description("Either: P(A) + P(B) – P(A)P(B)")]
        Either = 2
    }
}
