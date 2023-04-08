using Microsoft.Extensions.Caching.Memory;
using Model.Attributes;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public static class FunctionFactory
    {
        private static Dictionary<FunctionTypeEnum, Func<Function>> factoryDict = null;
        private static readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private static readonly object _cacheLock = new object();

        public static Dictionary<FunctionTypeEnum, Func<Function>> GetFunctions(IEnumerable<int> functionIds = null)
        {
            if(factoryDict == null)
            {
                factoryDict = new Dictionary<FunctionTypeEnum, Func<Function>>();

                var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Function)));
                var enums = Enum.GetValues(typeof(FunctionTypeEnum));

                foreach (var enumValue in enums)
                {
                    var type = types.FirstOrDefault(t => t.GetCustomAttribute<FunctionTypeAttribute>()?.FunctionType == (FunctionTypeEnum)enumValue);

                    var function = type != null ? Activator.CreateInstance(type) as Function : null;
                    factoryDict.Add((FunctionTypeEnum)enumValue, () => function);
                }

                _cache.Set("factoryDict", factoryDict);
            }

            return factoryDict;
        }

        public static Function CreateFunctionFactory(FunctionTypeEnum functionType)
        {
            lock (_cacheLock)
            {
                if (_cache.TryGetValue("factoryDict", out factoryDict))
                {
                    if (!factoryDict.TryGetValue(functionType, out var factory))
                    {
                        throw new ArgumentException("Invalid function type");
                    }

                    return factory();
                }

                throw new ArgumentException("No data available");
            }
        }
    }
}
