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

        public static Optional<T> Of(T value)
        {
            return new Optional<T>(value);
        }

        public static Optional<T> Empty()
        {
            return new Optional<T>(default);
        }

        public bool IsEmpty => EqualityComparer<T>.Default.Equals(_value, default);

        public T Default([NotNull] T @default)
        {
            return IsEmpty ? @default : _value;
        }

        public Optional<V> Select<V>(Func<T, V> selector)
        {
            return IsEmpty ? Optional<V>.Empty() : new Optional<V>(selector.Invoke(_value));
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