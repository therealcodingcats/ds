using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ds
{
    public class Optional<T>
    {
        private readonly T _value;

        private Optional(T value)
        {
            _value = value;
        }

        public static Optional<ST> Of<ST>(ST value)
        {
            return new Optional<ST>(value);
        }

        public static Optional<ST> Empty<ST>()
        {
            return new Optional<ST>(default);
        }

        public bool IsEmpty => EqualityComparer<T>.Default.Equals(_value, default);

        public T Default([NotNull] T @default)
        {
            return IsEmpty ? @default : _value;
        }

        public Optional<V> Select<V>(Func<T, V> selector)
        {
            return IsEmpty ? Empty<V>() : new Optional<V>(selector.Invoke(_value));
        }
        
        public V Select<V>(Func<T, V> selector, V @default)
        {
            return Select(selector).Default(@default);
        }
        
        public void Action(Action<T> action)
        {
            if (!IsEmpty) action.Invoke(_value);
        }
    }
}