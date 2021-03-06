﻿using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    interface INotifyCompletion { }
    interface ICriticalNotifyCompletion { }

    public interface IAsyncStateMachine
    {
        void MoveNext();
        void SetStateMachine(IAsyncStateMachine stateMachine);
    }

    public struct AsyncTaskMethodBuilder
    {
        public Task Task => null;

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
        {
        }
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
        {
        }
        public static AsyncTaskMethodBuilder Create()
        {
            return new AsyncTaskMethodBuilder();
        }
        public void SetException(Exception e)
        {
            Console.WriteLine("SetException called");
        }

        public void SetResult()
        {
            Console.WriteLine("SetResult called");
        }
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            Console.WriteLine("SetStateMachine called");

        }
        public void Start<TStateMachine>(ref TStateMachine stateMachine)
        // where TStateMachine : IAsyncStateMachine
        {

        }
    }
}
