using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoParses.Parsers;
using System.IO;
using System.Text.RegularExpressions;

namespace DynamoParses.UI.ViewModels
{
    public enum ParseType
    {
        Unknown= 0,
        Static = 1,
        Dynamic = 2
    }

    static class DynamoLabels
    {
        public static List<string> _staticLabels = new List<string>(new[] {
            "[Average Force Distribution]",
            "[COP averaged]",
            "[COP, left track]",
            "[COP, right track]",
            "[COP, both track]"
        });
        public static List<string> _dynamicLabels = new List<string>(new[] {
            "[Butterfly Parameters]",
            "[Average EMG]",
            "[Parameters]",
            "[Average]",
            "[Maximum]"
        });

    }

    class DynamoFile
    {

        public string Directory { get; set; }
        public ParseType Parser { get; set; } 

        public DynamoFile(string directory)
        {
            Directory = directory;
            Parser = 0;
        }
        public string[] ReturnItem()
        {
            return new[] {"X", Directory, Parser.ToString() };
        }

        public void GetType()
        {

            // first easy pass
            if (Directory.Contains("dynamika"))
            {
                Parser = (ParseType)2;
                return;
            }
            if (Directory.Contains("chod"))
            {
                Parser = (ParseType)2;
                return;
            }
            if (Directory.Contains("statyka"))
            {
                Parser = (ParseType)1;
                return;
            }
            Regex pattern = new Regex(@"\[([^)]*)\]");
            var bracketText = from line in File.ReadAllLines(Directory)
                              let matches = pattern.Matches(line)
                              where matches.Count > 0
                              select line;


            if (bracketText.Intersect(DynamoLabels._dynamicLabels).Any())
            {
                Parser = (ParseType)2;
                return;
            }
            if (bracketText.Intersect(DynamoLabels._staticLabels).Any())
            {
                Parser = (ParseType)1;
                return;
            }
        }
    }
}
