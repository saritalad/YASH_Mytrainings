using System;

using System.Threading;

using System.Threading.Tasks;
namespace CountDownExample1
{
    public class WorkerNode

    {

        private readonly CountdownEvent completionSignal;

        public WorkerNode(CountdownEvent completionSignal)

        {

            this.completionSignal = completionSignal;

        }

        public async Task ProcessTasksAsync()

        {

            // Simulate processing tasks

            await Task.Delay(TimeSpan.FromSeconds(Random.Shared.Next(1, 5)));

            // Signal completion

            completionSignal.Signal();

        }

    }

    class Program

    {

        static async Task Main()

        {

            int numberOfWorkerNodes = 5;

            CountdownEvent completionSignal = new CountdownEvent(numberOfWorkerNodes);

            // Create worker nodes

            List<WorkerNode> workerNodes = new List<WorkerNode>();

            for (int i = 0; i < numberOfWorkerNodes; i++)

            {

                workerNodes.Add(new WorkerNode(completionSignal));

            }

            // Start worker nodes

            List<Task> tasks = new List<Task>();

            foreach (WorkerNode workerNode in workerNodes)

            {

                tasks.Add(workerNode.ProcessTasksAsync());

            }

            // Wait for all worker nodes to complete

            await completionSignal.WaitAsync();

            // Trigger global operation

            Console.WriteLine("All worker nodes have completed. Triggering global operation...");

        }

    }
}