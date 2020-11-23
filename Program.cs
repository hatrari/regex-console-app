using System;
using System.IO;
using System.Text.RegularExpressions;

namespace content
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] files = Directory.GetFiles("files");
      string pattern = @"[0-9]{2}:[0-9]{2}";
      Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
      foreach (string file in files)
      {
        int fileMin = 0;
        int fileSecond = 0;
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
          Match match = regex.Match(line);
          string[] minSecond = match.Groups[0].ToString().Split(":");
          fileMin += Int32.Parse(minSecond[0]);
          fileSecond += Int32.Parse(minSecond[1]);
        }
        fileMin += fileSecond / 60;
        fileSecond = fileSecond % 60;
        Console.WriteLine($"{lines[0]} => {fileMin}:{fileSecond}");
      }
    }
  }
}