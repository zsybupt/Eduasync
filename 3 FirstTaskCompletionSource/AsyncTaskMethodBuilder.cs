
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    public interface INotifyCompletion
    {
        void OnCompleted(Action continuation);
    }
    public interface ICriticalNotifyCompletion
    {
        void UnsafeOnCompleted(Action continuation);
    }

    public interface IAsyncStateMachine
    {
        void MoveNext();
        void SetStateMachine(IAsyncStateMachine stateMachine);
    }

    public struct AsyncTaskMethodBuilder<T>
    {
        private TaskCompletionSource<T> tcs;

        public AsyncTaskMethodBuilder(TaskCompletionSource<T> tcs)
        {
            this.tcs = tcs;
        }
        public Task<T> Task => this.tcs.Task;

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter: INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.UnsafeOnCompleted(stateMachine.MoveNext);
        }
        public static AsyncTaskMethodBuilder<T> Create()
        {
            return new AsyncTaskMethodBuilder<T>(new TaskCompletionSource<T>());
        }
        public void SetException(Exception e)
        {
            Console.WriteLine("SetException called");
        }

        public void SetResult(T result)
        {
            this.tcs.SetResult(result);
            Console.WriteLine("SetResult called");
        }
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            Console.WriteLine("SetStateMachine called");

        }
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            Console.WriteLine("Start called");

            stateMachine.MoveNext();
        }
    }
}
