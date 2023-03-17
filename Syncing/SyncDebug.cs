using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            var tasks = new List<Task>();
            Parallel.ForEach(items, async i =>
            {
                var task = Task.Run(() => i);
                tasks.Add(task);
                var r = await task.ConfigureAwait(false);
                bag.Add(r);
            });
            // Need to wait on the tasks to finish, but it's late and I can't remember how... I'm missing something
            Task.WhenAll(tasks).Wait();
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            //var dictLock = new object();
            int numThreads = 3;
            var threads = Enumerable.Range(0, numThreads)
                .Select(i => new Thread(() => {
                    for (int j = itemsToInitialize.Count / numThreads * i; j < itemsToInitialize.Count / numThreads * (i + 1); j++)  // actually split the items over the threads. Cheating?
                    {
                        //lock (dictLock) // Kind of defeats the purpose of the multiple threads
                        //{
                        concurrentDictionary.AddOrUpdate(itemsToInitialize[j], getItem, (_, s) => s);
                        //}
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}