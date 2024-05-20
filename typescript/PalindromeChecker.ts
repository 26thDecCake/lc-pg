/**
 * Determines whether a given number is a palindrome.
 *
 * This function checks whether a given number is a palindrome by reversing the number and comparing it with the original number.
 * It works by repeatedly extracting the last digit of the number and appending it to a reversed number.
 * This process continues until the input number becomes zero.
 * The function then returns true if the original number is equal to the reversed number, indicating that it is a palindrome.
 * Otherwise, it returns false.
 *
 * @param {number} x - The number to check.
 * @return {boolean} True if the number is a palindrome, false otherwise.
 */
function isPalindrome(x: number): boolean {
  let reversed = 0;
  let input = x;
  while (input > 0) {
    const lastDigit = input % 10;
    reversed = reversed * 10 + lastDigit;
    input = Math.floor(input / 10);
  }

  // if ( x < 0) return false;
  // if (x % 10 === 0 && x !== 0) return false;
  // const str = x+'';
  // const reversed = str.split('').reverse().join('');

  return x === reversed;
}
