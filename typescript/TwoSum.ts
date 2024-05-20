/**
 * Finds two numbers in the given array that add up to the target value.
 *
 * This function uses a Map data structure to efficiently find the two numbers. It iterates over the nums array,
 * calculating the difference between the target value and the current number. If the difference exists as a key
 * in the Map, it means that the target value can be achieved by subtracting the current number from the target value.
 * In this case, the function returns an array containing the indices of the two numbers that add up to the target value.
 * If no such pair is found, the function returns an empty array.
 *
 * @param {number[]} nums - The array of numbers to search in.
 * @param {number} target - The target sum value.
 * @return {number[]} An array containing the indices of the two numbers that add up to the target value. If no such pair is found, an empty array is returned.
 */
function twoSum(nums: number[], target: number): number[] {
  const map: Map<number, number> = new Map();
  for (let i = 0; i < nums.length; i++) {
    const seenNum = target - nums[i];
    if (map.has(seenNum)) {
      return [map.get(seenNum)!, i];
    }
    map.set(nums[i], i);
  }
  return [];

  // for (let i = 0; i < nums.length; i++) {
  //     for (let j = i + 1; j < nums.length; j++) {
  //         if(nums[i] + nums[j] === target) {
  //             return [i, j];
  //         }
  //     }
  // }
  // return [];
}
