namespace Tests.Processing
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NativeCode.Core.Processing;

    using Tests.Testables;

    [TestClass]
    public class WhenProcessingConcurrentTasks
    {
        [TestMethod]
        public void ShouldThrottleTaskExecution()
        {
            // Arrange
            var factory = new QueueProcessorFactory(new CollectionFactory());
            var processor = factory.CreateConcurrentQueueProcessor<string>(QueueProcessorAsync, 1);

            // Act
            processor.Enqueue("1");
            processor.Enqueue("2");
            processor.Enqueue("3");
            processor.Enqueue("4");
            processor.Enqueue("5");

            // Assert
            Assert.AreEqual(1, processor.Running);
        }

        private static async Task<string> QueueProcessorAsync(string value)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);

                return value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}