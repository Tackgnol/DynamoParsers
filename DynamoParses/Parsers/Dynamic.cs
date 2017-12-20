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
    public class Dynamic
    {
        private static Dynamic instance;

        private Dynamic() { }

        public static Dynamic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dynamic();
                }
                return instance;
            }
        }
        private ParameterStorage parameters = new ParameterStorage();
        private ButterflyParametersStorage butterflyParameters = new ButterflyParametersStorage();
        private OtherPreasureStorage otherPressures = new OtherPreasureStorage();
        private ContactTimeStorage contactTimes = new ContactTimeStorage();
        private PreassureMeasurementStorage preassureMeasurements = new PreassureMeasurementStorage();
        private ForceOverlayStorage forceOverlays = new ForceOverlayStorage();
        private AbstractStorage currentStorage = null;
        private HeaderStorage headers = new HeaderStorage();
        public List<PressureMeasurement> parsedPreassures = new List<PressureMeasurement>();
        public List<DynamicParameter> parsedParameters = new List<DynamicParameter>();
        public List<OtherPreassureMeasurement> parsedOtherPressures = new List<OtherPreassureMeasurement>();
        public List<ButterflyParameter> parsedButterflyParameters = new List<ButterflyParameter>();
        public List<ForceOverlay> parsedForceOverlays = new List<ForceOverlay>();
        private List<string> overlayCriteria = new List<string>(
                new string[] {
                    "heel",
                    "forefoot",
                    "midfoot",
                    "total"
                }
            );
        private string foot = "";
        private string type = "";
        private string measure = "";

        public void ParseFiles(List<string> directories, ref PatientStorage patients, ref List<Header> parsedHeaders)
        {


            foreach (string file in directories)
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
                }

                Header currentExperiment = headers.ParseElements(patients);
                parsedHeaders.Add(currentExperiment);
                parsedPreassures.AddRange(preassureMeasurements.ParseElements(currentExperiment));
                parsedParameters.AddRange(parameters.ParseElements(currentExperiment));
                parsedButterflyParameters.AddRange(butterflyParameters.ParseElements(currentExperiment));
                parsedOtherPressures.AddRange(otherPressures.ParseElements(currentExperiment));
                parsedForceOverlays.AddRange(forceOverlays.ParseElements(currentExperiment));
                //Export export = new Export(@"c:\temp\Data_Test_Final.xlsx");
                //export.DumpValues("Preassures", parsedPreassures);
                //export.DumpValues("DynamicParameters", parsedParameters);
                //export.DumpValues("ButterflyParameters", parsedButterflyParameters);
                //export.DumpValues("OtherPreassures", parsedOtherPressures);
                //export.DumpValues("ForceOverlays", parsedForceOverlays);
                //parsedPreassures.Clear();
                //parsedParameters.Clear();
                //parsedButterflyParameters.Clear();
                //parsedOtherPressures.Clear();
                //parsedForceOverlays.Clear();
                //export.Save();
                //export.Close();
                //export = null;

            }
        }

        private string _forceOverlayInfo(string foot, List<string> cryteriaList, string line, string oldValue)
        {
            foreach (var item in cryteriaList)
            {
                if (line.Contains(item))
                {
                    return foot + ", force overlay, " + item + ", ";
                }
            }
            return oldValue;
        }
        private AbstractStorage _setupStorage(string mainFlag, string line)
        {

            switch (mainFlag)
            {
                case "Header":
                    currentStorage = headers;
                    break;

                case "Left":
                    if (line == "Force,N	  X,mm	   Y,mm")
                    {
                        currentStorage = preassureMeasurements;
                        currentStorage.AdditionalInfo = "Left, ";
                        break;
                    }
                    if (line.Contains("force overlay"))
                    {
                        currentStorage = forceOverlays;
                        currentStorage.AdditionalInfo = "Left, force overlay, ";
                        break;
                    }
                    if (currentStorage.AdditionalInfo.Contains("force overlay"))
                    {
                        currentStorage.AdditionalInfo = _forceOverlayInfo("Left", overlayCriteria, line, currentStorage.AdditionalInfo);
                    }
                    break;
                case "Right":
                    if (line == "Force,N	  X,mm	   Y,mm")
                    {
                        currentStorage = preassureMeasurements;
                        currentStorage.AdditionalInfo = "Right, ";
                        break;
                    }
                    if (line.Contains("force overlay"))
                    {
                        currentStorage = forceOverlays;
                        currentStorage.AdditionalInfo = "Right, force overlay, ";
                        break;
                    }
                    if (currentStorage.AdditionalInfo.Contains("force overlay"))
                    {
                        currentStorage.AdditionalInfo = _forceOverlayInfo("Right", overlayCriteria, line, currentStorage.AdditionalInfo);
                    }
                    break;

                case "Butterfly":
                    if (line == "Force,N	  X,mm	   Y,mm")
                    {
                        currentStorage = preassureMeasurements;
                        currentStorage.AdditionalInfo = "Butterfly, ";
                        break;
                    }
                    if (line.Contains("force overlay"))
                    {
                        currentStorage = forceOverlays;
                        currentStorage.AdditionalInfo = "Butterfly, force overlay, ";
                        break;
                    }
                    if (currentStorage.AdditionalInfo.Contains("force overlay"))
                    {
                        currentStorage.AdditionalInfo = _forceOverlayInfo("Butterfly", overlayCriteria, line, currentStorage.AdditionalInfo);
                    }
                    break;
                case "Parameters":
                    currentStorage = parameters;
                    break;

                case "Butterfly Parameters":
                    currentStorage = butterflyParameters;
                    break;

                case "":

                    if (line.Contains("max pressure") && !line.Contains("Signal"))
                    {
                        foot = line.Split(' ')[0];
                        type = "max pressure";
                        currentStorage = otherPressures;
                    }
                    if (line.Contains("force") && !line.Contains("Signal"))
                    {
                        foot = line.Split(' ')[0];
                        type = "force";
                        currentStorage = otherPressures;
                    }
                    if (type == "max pressure" || type == "force")
                    {
                        if (line == "Time, %\t Value, \t SD, ")
                        {
                            measure = "Measurement 1";
                        }
                        if (line == "Time, %\t Value, ")
                        {
                            measure = "Measurement 2";
                        }
                    }
                    currentStorage.AdditionalInfo = foot + ", " + type + ", " + measure + ", ";
                    break;
                default:
                    currentStorage = null;
                    break;
            }

            return currentStorage;
        }
    }
}

