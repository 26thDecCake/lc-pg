// using System.Diagnostics;
// using Humanizer;
// // See https://aka.ms/new-console-template for more information

// static void HumanizeQuantities()
// {
//   Console.WriteLine("case".ToQuantity(0));
//   Console.WriteLine("case".ToQuantity(1));
//   Console.WriteLine("case".ToQuantity(5));
// }

// static void HumanizeDates()
// {
//   Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
//   Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
//   Console.WriteLine(TimeSpan.FromDays(1).Humanize());
//   Console.WriteLine(TimeSpan.FromDays(16).Humanize());
// }

// Console.WriteLine("Quantities:");
// HumanizeQuantities();

// Console.WriteLine("\nDate/Time Manipulation:");
// HumanizeDates();

// int count = 0;
// // This line of code writes the message "The count is 0 and this may cause an exception." to the debug output only if the count variable is equal to 0.
// Debug.WriteLineIf(count == 0, "The count is 0 and this may cause an exception.");

// bool errorFlag = false;  
// Trace.WriteIf(errorFlag, "Error in AppendData procedure.");  
// Debug.WriteIf(errorFlag, "Transaction abandoned.");  
// Trace.Write("Invalid value for data request");

// IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("../test_dotnet");
// IEnumerable<string> listOfFiles = Directory.EnumerateFiles("../test_dotnet");
// IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("../test_dotnet", "*.txt", SearchOption.AllDirectories);

// foreach (var dir in listOfDirectories)
// {
//   Console.WriteLine(dir);
// }
// foreach (var file in listOfFiles)
// {
//   Console.WriteLine(file);
// }
// foreach (var file in allFilesInAllFolders)
// {
//   Console.WriteLine(file);
// }
// // Code for finding Special Directory MyDocuments, works for windows and linux. It targer the user's special document directory
// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

// // Automatically interpret path using respective OS's path character
// Console.WriteLine($"projects{Path.DirectorySeparatorChar}csharp");

// //Get information about a directory or a file by using the DirectoryInfo or FileInfo classes, respectively
// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);
// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");



class MainClass
{
  public int[] TwoSum(int[] nums, int target)
  {
    int[] resArray = new int[2];
    for (int i = 0; i < nums.Length; i++)
    {
      for (int j = i + 1; j < nums.Length; j++)
      {
        if (nums[i] + nums[j] == target)
        {
          resArray[0] = i;
          resArray[1] = j;
          return resArray;
        }
      }
    }

    return resArray;
  }

  public bool IsPalindromeInt(int x)
  {
    string temp = x.ToString();
    var reversed = new string(temp.ToCharArray().Reverse().ToArray());
    return temp == reversed;
  }

  public bool IsPalindromeStr(string s)
  {
    var cleanStr = s.ToLower().Where(x => char.IsLetterOrDigit(x));
    return cleanStr.Reverse().SequenceEqual(cleanStr);
  }

  public int RomanToInt(string s)
  {
    Dictionary<char, int> symbols = new Dictionary<char, int> {
      {'I', 1},
      {'V', 5},
      {'X', 10},
      {'L', 50},
      {'C', 100},
      {'D', 500},
      {'M', 1000}
    };

    int summ = 0;
    int previousNum = 0;

    for (int i = s.Length - 1; i >= 0; i--)
    {
      int currentNum = symbols[s[i]];

      if (currentNum < previousNum)
      {
        summ -= currentNum;
      }
      else
      {
        summ += currentNum;
      }
      previousNum = currentNum;
    }
    return summ;
  }

  public string LongestCommonPrefix(string[] strs)
  {
    string shortest = strs.OrderBy(o1 => o1.Length).First();

    for (int i = 0; i <= shortest.Length - 1; i++)
    {
      if (strs.Select(s => s[i]).Distinct().Count() > 1) return shortest[..i];
    }
    return shortest;
  }

  public bool IsValid(string s)
  {
    // Used to check the paired opening brackets of any found closing brackets in the iteration
    var setOfBrackets = new Dictionary<char, char> {
      { ')', '(' },
      { '}', '{' },
      { ']', '[' }
    };
    Stack<char> stck = new Stack<char>();

    for (int i = 0; i <= s.Length - 1; i++)
    {
      if (setOfBrackets.ContainsValue(s[i]))
      {
        stck.Push(s[i]);
      }
      else if (setOfBrackets.ContainsKey(s[i]))
      {
        if (stck.Count == 0 || stck.Pop() != setOfBrackets[s[i]])
        {
          return false;
        }
      }
    }
    return stck.Count == 0;
  }

  public int RemoveDuplicates(int[] nums)
  {
    int totalUnique = 1;
    for (int i = 1; i < nums.Length; i++)
    {
      if (nums[i] != nums[i - 1])
      {
        nums[totalUnique] = nums[i];
        totalUnique++;
      }
    }
    return totalUnique;
  }

  public int RemoveElement(int[] nums, int val)
  {
    int j = 0;
    for (int i = 0; i <= nums.Length - 1; i++)
    {
      if (nums[i] != val)
      {
        nums[j] = nums[i];
        j++;
      }
    }
    return j;
  }

  public int StrStr(string haystack, string needle)
  {
    for (int i = 0; i <= haystack.Length - needle.Length; i++)
    {
      if (haystack.Substring(i, needle.Length) == needle)
      {
        return i;
      }
    }
    return -1;
  }

  public int SearchInsert(int[] nums, int target)
  {
    int left = 0;
    int right = nums.Length - 1;
    int mid;

    while (left <= right)
    {
      //find midpoint of arrays, then floor it
      mid = (right + left) / 2;

      if (nums[mid] < target)
      {
        left = mid + 1;
      }
      else if (nums[mid] > target)
      {
        right = mid - 1;
      }
      else
      {
        return mid;
      }
    }
    return left;
  }

  public int LengthOfLastWord(string s)
  {
    s = s.TrimStart().TrimEnd();
    string[] words = s.Split(' ');
    return words[words.Length - 1].Length;
  }

  public int[] PlusOne(int[] digits)
  {
    for (int i = digits.Length - 1; i >= 0; i--)
    {
      if (digits[i] == 9)
      {
        digits[i] = 0;
      }
      else
      {
        digits[i]++;
        return digits;
      }
    }
    int[] toReturn = new int[digits.Length + 1];
    toReturn[0] = 1;
    return toReturn;
  }

  public int MySqrt(int x)
  {
    for (double i = 0; i <= x; i++)
    {
      if (i * i > x)
      {
        return Convert.ToInt32(i - 1);
      }
    }
    return x;
  }

  public int FirstFactorial(int num)
  {
    if (num == 0) return 1;
    for (int i = num - 1; i > 0; i--)
    {
      num = num * i;
    }

    return num;
  }

  /** Given an int num, return the sum of all numbers from 1 to num **/
  public int SimpleAdding(int num)
  {
    int sum = 0;

    for (int i = num; i > 0; i--)
    {
      sum += i;
    }
    return sum;
  }

  public bool Anagrams(string text1, string text2)
  {
    char[] text1Array = text1.ToLower().ToCharArray();
    char[] text2Array = text2.ToLower().ToCharArray();
    Array.Sort(text1Array);
    Array.Sort(text2Array);
    return text1Array.SequenceEqual(text2Array);
  }

  /** Merge Sorted Arrays **/
  public void Merge(int[] nums1, int m, int[] nums2, int n)
  {
    Array.Copy(nums2, 0, nums1, m, n);
    Array.Sort(nums1);
  }

  public int MajorityElement(int[] nums)
  {
    Dictionary<int, int> countOfNum = new Dictionary<int, int>();
    Array.Sort(nums);

    for (int i = 0; i <= nums.Length - 1; i++)
    {
      if (countOfNum.ContainsKey(nums[i]))
      {
        countOfNum[nums[i]]++;
      }
      else
      {
        countOfNum[nums[i]] = 1;
      }

      if (countOfNum[nums[i]] > (nums.Length / 2))
      {
        return nums[i];
      }
    }
    return -1;
  }



}