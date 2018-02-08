using DynamoParses.Models;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamoParses.Parsers
{
    public class Static
    {
        public Static()
        {

        }
        private AbstractStorage currentStorage = null;
        private HeaderStorage headers = new HeaderStorage();
        private COPAveragedStorage COPAverages = new COPAveragedStorage();
        private COPTrackStorage COPTracks = new COPTrackStorage();
        private SideForceStorage sideForces = new SideForceStorage();
        private StaticParameterStorage parameters = new StaticParameterStorage();

        public void ParseFiles(string file, PatientStorage patients, ref List<StudyHeader> parsedHeaders, ref Export export, Dictionary<string, bool> launch)
        {
            headers.fileName = Path.GetFileNameWithoutExtension(file);
            using (var stream = File.OpenRead(file))
            using (var reader = new StreamReader(stream))
            {
                string line;
                string mainFlag = "none";
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = Regex.Match(line, @"\[([^)]*)\]");
                    if (match.Success)
                    {
                        mainFlag = match.Groups[1].Value;
                        continue;

                    }
                    currentStorage = _setupStorage(mainFlag, line);

                    if (currentStorage != null)
                    {
                        currentStorage.AddElement(currentStorage.AdditionalInfo + line);
                    }

                }

                StudyHeader currentExperiment = headers.ParseElements(patients);
                currentExperiment.TryParseFileNameArray();
                parsedHeaders.Add(currentExperiment);

                if (launch["COP Averages"])
                {
                    export.DumpValues("COPAverages", COPAverages.ParseElements(currentExperiment));
                }
                if (launch["COP Tracks"])
                {
                    export.DumpValues("COPTracks", COPTracks.ParseElements(currentExperiment));
                }
                if (launch["Side Forces"])
                {
                    export.DumpValues("SideForces", sideForces.ParseElements(currentExperiment));
                }
                if (launch["Parameters"])
                {
                    export.DumpValues("StaticParameters", parameters.ParseElements(currentExperiment));
                }


            }




        }
        //}
        private AbstractStorage _setupStorage(string mainFlag, string line)
        {

            switch (mainFlag)
            {
                case "Header":
                    currentStorage = headers;
                    break;

                case "COP averaged":
                    currentStorage = COPAverages;
                    break;
                case "COP, left track":
                    currentStorage = COPTracks;
                    currentStorage.AdditionalInfo = "Left, ";
                    break;
                case "COP, both track":
                    currentStorage = COPTracks;
                    currentStorage.AdditionalInfo = "Both, ";
                    break;

                case "":
                    if (line.Contains("Left forefoot"))
                    {
                        currentStorage = sideForces;
                        currentStorage.AdditionalInfo = "Left, Forefoot, ";
                    }
                    if (line.Contains("Left backfoot"))
                    {
                        currentStorage = sideForces;
                        currentStorage.AdditionalInfo = "Left, Backfoot, ";
                    }
                    if (line.Contains("Right forefoot"))
                    {
                        currentStorage = sideForces;
                        currentStorage.AdditionalInfo = "Right, Forefoot, ";
                    }
                    if (line.Contains("Right backfoot"))
                    {
                        currentStorage = sideForces;
                        currentStorage.AdditionalInfo = "Right, Backfoot, ";
                    }
                    if (line.Contains("Parameters"))
                    {
                        currentStorage = parameters;
                    }
                    break;

                default:
                    currentStorage = null;
                    break;
            }

            return currentStorage;
        }
    }
}

