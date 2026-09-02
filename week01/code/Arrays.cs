public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. We need to return an array of 'length' doubles.
        // 2. The first entry is 'number' itself (1st multiple), the second entry is
        //    'number' * 2, the third is 'number' * 3, and so on up to 'number' * length.
        // 3. So for a 0-based index i, the value at that index is number * (i + 1).
        // 4. Create a double[] of size 'length'.
        // 5. Loop from i = 0 to length - 1, setting array[i] = number * (i + 1).
        // 6. Return the filled array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Rotating right by 'amount' means the last 'amount' elements need to end up
        //    at the front of the list, and the remaining elements (the front part) shift
        //    right to come after them, keeping their relative order.
        // 2. Slice the list into two pieces using GetRange:
        //    - tail: the last 'amount' elements, starting at index (data.Count - amount)
        //    - front: everything before the tail, from index 0 for (data.Count - amount) elements
        // 3. Clear out the original list.
        // 4. Add the tail elements back first, then the front elements, so the list
        //    ends up as tail + front, which is the rotated result.
        // 5. Since we modified 'data' in place, there's nothing to return.

        List<int> tail = data.GetRange(data.Count - amount, amount);
        List<int> front = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(front);
    }
}
