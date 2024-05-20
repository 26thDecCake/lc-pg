/**
 * Finds the longest common prefix among an array of strings.
 *
 * It sorts the array of strings in ascending order.
 * It then compares the first and last strings in the sorted array.
 * It checks each character of the first and last string from the start until it finds a character that is different or reaches the end of the strings.
 * It returns the substring of the first string from the start to the index of the last different character. This is the longest common prefix.
 * For example, if the input is ["apple", "app", "application"], the function will return "app".
 *
 * @param {string[]} strs - The array of strings to search for the common prefix.
 * @return {string} The longest common prefix among the input strings.
 */
function longestCommonPrefix(strs: string[]): string {
  strs.sort();

  let first = strs[0];
  let last = strs[strs.length - 1];
  let i = 0;

  while (i < first.length && i < last.length && first[i] === last[i]) i++;

  return first.substring(0, i);

  // let commonPrefix: string = ""
  // if (strs.length === 0 || strs[0].length === 0) return commonPrefix;

  // for (let i: number = 0; i < strs[0].length; i++) {
  //   let currentChar: string = strs[0][i]
  //   for (let j: number = 0; j < strs.length; j++) {
  //     if (currentChar !== strs[j][i]) {
  //         return commonPrefix;
  //     }
  //   }
  //   commonPrefix += currentChar;
  // }

  // return commonPrefix
}
