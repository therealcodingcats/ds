using System;
using System.Collections.Generic;

namespace ds
{
    public static class Collections
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> list) => list.Count == 0;
        public static bool IsEmpty<T>(this ICollection<T> list) => list.Count == 0;

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source) action.Invoke(element);
        }
    }
}