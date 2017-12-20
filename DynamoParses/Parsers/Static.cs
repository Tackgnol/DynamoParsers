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
        private static Static instance;

        private Static() { }

        public static Static Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Static();
                }
                return instance;
            }
        }
        private AbstractStorage currentStorage = null;
        private HeaderStorage headers = new HeaderStorage();
        private COPAveragedStorage COPAverages = new COPAveragedStorage();
        private COPTrackStorage COPTracks = new COPTrackStorage();
        private SideForceStorage sideForces = new SideForceStorage();
        private StaticParameterStorage parameters = new StaticParameterStorage();

        public List<COPAveraged> parsedCOPAvereges = new List<COPAveraged>();
        public List<COPTrack> parsedCOPTracks = new List<COPTrack>();
        public List<SideForce> parsedSideForces = new List<SideForce>();
        public List<StaticParameter> parsedParameters = new List<StaticParameter>();

        public void ParseFiles(List<string> directories, ref PatientStorage patients, ref List<Header> parsedHeaders)
        {


            foreach (var file in directories)
            {

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

                    Header currentExperiment = headers.ParseElements(patients);
                    Export export = new Export(@"c:\temp\Data_Test_Final.xlsx");
                    parsedCOPAvereges.AddRange(COPAverages.ParseElements(currentExperiment));
                    parsedCOPTracks.AddRange(COPTracks.ParseElements(currentExperiment));
                    parsedSideForces.AddRange(sideForces.ParseElements(currentExperiment));
                    parsedParameters.AddRange(parameters.ParseElements(currentExperiment));
                    parsedHeaders.Add(currentExperiment);
                    //export.DumpValues("COPAverages", parsedCOPAvereges);
                    //export.DumpValues("COPTracks", parsedCOPTracks);
                    //export.DumpValues("SideForces", parsedSideForces);
                    //export.DumpValues("StaticParameters", parsedParameters);
                    //parsedCOPAvereges.Clear();
                    //parsedCOPTracks.Clear();
                    //parsedSideForces.Clear();
                    //parsedParameters.Clear();
                    //export.Save();
                    //export.Close();
                    //export = null;

                }




            }
        }
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

