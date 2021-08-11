﻿using System;

namespace PrancingPonySharp.Maybe
{
    public readonly struct Maybe<T>
    {
        private T Value { get; }

        public bool IsValue { get; }

        public bool IsNull => !IsValue;

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value, value != null);
        }

        private Maybe(T value, bool isValue)
        {
            Value = value;
            IsValue = isValue;
        }

        public TR Matches<TR>(Func<T, TR> a, Func<TR> or)
        {
            return IsValue ? a(Value) : or();
        }

        public void Matches(Action<T> a, Action or)
        {
            if (IsValue)
                a(Value);
            else
                or();
        }
    }
}