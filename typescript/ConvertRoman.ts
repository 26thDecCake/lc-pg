/**
 * Converts a Roman numeral string to an integer.
 *
 * This function takes a Roman numeral string as input and converts it into its corresponding integer value.
 * The conversion is based on the mapping of Roman numeral symbols to their integer values.
 * The function iterates through the characters of the input string and checks the relationship between the current character
 * and the next character in the string. If the value of the next character is greater than the value of the current character,
 * it means the current character is subtractive (e.g., IV, IX, XL, XC, CD, CM), so the value of the next character is subtracted
 * from the value of the current character. Otherwise, the value of the current character is added to the total value.
 *
 * @param {string} s - The Roman numeral string to convert.
 * @return {number} The integer value of the Roman numeral string.
 */

const keys = {
  I: 1,
  V: 5,
  X: 10,
  L: 50,
  C: 100,
  D: 500,
  M: 1000,
};

// const romanMapping: { [key: string]: number } = {
//   I: 1,
//   V: 5,
//   X: 10,
//   L: 50,
//   C: 100,
//   D: 500,
//   M: 1000,
// };

function romanToInt(s: string): number {
  let sum = 0;
  for (let i = 0; i < s.length; i++) {
    const current = keys[s[i]];
    const next = keys[s[i + 1]];

    if (current < next) {
      sum += next - current;
      i++;
    } else {
      sum += current;
    }
  }

  return sum;

  //   const stringList = s.split("");
  //   let romanInt = 0;
  //   let index = 0;
  //   while (index < stringList.length) {
  //     if (romanMapping[stringList[index]] < romanMapping[stringList[index + 1]]) {
  //       romanInt +=
  //         romanMapping[stringList[index + 1]] - romanMapping[stringList[index]];
  //       index++;
  //     } else {
  //       romanInt += romanMapping[stringList[index]];
  //     }
  //     index++;
  //   }
  //   return romanInt;
}
