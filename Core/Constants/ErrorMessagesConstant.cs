﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Constants
{
    public class ErrorMessagesConstant
    {
        public const string ProbabilityAMinValueErrorMsg = "P(A) is less than the minimum value: ";
        public const string ProbabilityAMaxValueErrorMsg = "P(A) is greater than the maximum value: ";
        public const string ProbabilityBMinValueErrorMsg = "P(B) is less than the minimum value: ";
        public const string ProbabilityBMaxValueErrorMsg = "P(B) is greater than the maximum value: ";
        public const string EmptyFieldErrorMessage = "Field(s) marked with * is mandatory";
        public const string InvalidFunctionSelectedErrorMsg = "Function selected is invalid";
        public const string DecimalPrecisionWarning = "Warning: Only 28 digit precision used for calculation. Result might not be accurate!";
    }
}
