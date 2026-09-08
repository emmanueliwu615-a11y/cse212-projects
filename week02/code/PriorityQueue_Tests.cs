using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a low-priority item first, then a higher-priority item added later (out of priority order).
    // Expected Result: The higher-priority item is still added to the back and correctly dequeued first,
    // proving Enqueue always appends to the back regardless of priority.
    // Defect(s) Found: None — Enqueue already adds to the back correctly. Test passes.
    public void TestPriorityQueue_EnqueueAddsToBackRegardlessOfPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue Low(1), High(5), Mid(3), then dequeue three times.
    // Expected Result: High, Mid, Low
    // Defect(s) Found: Dequeue's loop condition (index < _queue.Count - 1) skipped the last item in the
    // queue, and Dequeue never removed the returned item from the internal list, so items were re-read
    // on subsequent calls instead of being consumed.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Mid", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Mid", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(5), B(5), C(1) — two items tie for highest priority.
    // Expected Result: A, B, C (earlier tied item comes out first)
    // Defect(s) Found: Dequeue used >= instead of > when comparing priorities, so the later tied item (B)
    // overwrote the earlier one (A) as the "highest priority" match, breaking the FIFO tiebreak rule.
    public void TestPriorityQueue_TieBreaksFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None — the empty-queue check and exception message were already correct.
    public void TestPriorityQueue_EmptyThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item, then dequeue it.
    // Expected Result: The single item is returned, and the queue is empty afterward.
    // Defect(s) Found: None.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);

        Assert.AreEqual("Only", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items that all share the same priority.
    // Expected Result: They come back out in FIFO order: First, Second, Third.
    // Defect(s) Found: None — covered by the > vs >= fix already applied.
    public void TestPriorityQueue_AllSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}
