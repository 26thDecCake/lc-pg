/**
 * Removes duplicate numbers from the given array.
 *
 * This function iterates over the input array and removes any duplicate numbers.
 * It does this by comparing each element with the previous one. If the current
 * element is different from the previous one, it is considered a unique number
 * and is moved to the next available position in the array. The function returns
 * the final count of unique numbers.
 *
 * @param {number[]} nums - The array of numbers to remove duplicates from.
 * @return {number} The number of unique numbers in the array.
 */
function removeDuplicates(nums: number[]): number {
  let totalUniqueNumber = 1;

  for (let i = 1; i < nums.length; i++) {
    if (nums[i] !== nums[i - 1]) {
      nums[totalUniqueNumber] = nums[i];
      totalUniqueNumber++;
    }
  }

  return totalUniqueNumber;
}
