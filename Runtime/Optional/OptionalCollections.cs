using System.Collections.Generic;
using System.Linq;

namespace ds
{
    public static class OptionalCollections
    {
        public static Optional<V> Get<K, V>(this IReadOnlyDictionary<K, V> dictionary, K key) where V : class =>
            Optional<V>.Of(dictionary.ContainsKey(key) ? dictionary[key] : null);

        public static Optional<T> GetFirst<T>(this IEnumerable<T> source) => Optional<T>.Of(source.FirstOrDefault());
    }
}