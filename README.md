# Calculation README Notes


## UI Navigation
--------------------
The calculator allows the user to enter two valid probabilities between 0 and 1, and choose from two functions: CombinedWith and Either.

When View Result button is clicked, the Calculated Result will be displayed for the 2 inputs based on the selected function.

**For each calculation, a log file will be created in the path specified in the API's appsettings.json under _"LogFilePath" (e.g C:/Logs/)_ in the format _log_yyyy-MM-dd_hh-mm-ss.txt_ containing the date, type of calculation, inputs, and result. Exceptions are also logged.**



## Developer Notes
-----------------------------------------

For extending further calculation functions, a child class of ***Function.cs*** has to be created . Since db is not used, new calculation functions have to be added to the enum ***FunctionTypeEnum***. The new child class has to be mapped to the right FunctionTypeEnum via it's FunctionType Attribute.


```c#
 public enum FunctionTypeEnum
    {
        [Description("CombinedWith: P(A)P(B)")]
        CombinedWith = 1,

        [Description("Either: P(A) + P(B) – P(A)P(B)")]
        Either = 2
    }
```

![Function Class for Extension](https://github.com/twinklepreethy/Calculator/blob/main/Class%20Diagram.png)







