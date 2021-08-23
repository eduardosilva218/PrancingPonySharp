﻿using System;

namespace PrancingPonySharp.Try
{
    public readonly struct Try<T, TE1, TE2> 
        where TE1 : Exception 
        where TE2 : Exception
    {
        private Func<T> Function { get; }

        public Try(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailureHandle(Func<TE1, T> case1, Func<TE2, T> case2, Func<Exception, T> caseDefault)
        {
            try
            {
                return Function();
            }
            catch (TE1 exception)
            {
                return case1(exception);
            }
            catch (TE2 exception)
            {
                return case2(exception);
            }
            catch (Exception exception)
            {
                return caseDefault(exception);
            }
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
        /// </summary>
        public void RunOrFailureHandle(Action<TE1> case1, Action<TE2> case2, Action<Exception> caseDefault)
        {
            try
            {
                Function();
            }
            catch (TE1 exception)
            {
                case1(exception);
            }
            catch (TE2 exception)
            {
                case2(exception);
            }
            catch (Exception exception)
            {
                caseDefault(exception);
            }
        }
    }
}