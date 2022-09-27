using System;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[]? source, int digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(paramName: "Expected digit can not be more than nine.");
            }

            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException("Expected digit can not be less than zero.");
            }

            if (source == null)
            {
                throw new ArgumentNullException("Array can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array can not be empty.");
            }

            int[] result = Array.Empty<int>();

            foreach (int s in source)
            {
                if (HasDigit(s, digit))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = s;
                }
            }

            return result;
        }

        private static bool HasDigit(int val, int digit)
        {
            return val / 10 != 0 ? Math.Abs(val) % 10 == digit || HasDigit(val / 10, digit) : Math.Abs(val) == digit;
        }
    }
}
