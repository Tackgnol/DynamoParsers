using DynamoParses.Models;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamoParses.Parsers
{
    public static class Dynamic
    {
        static ParameterStorage parameters = new ParameterStorage();
        static ButterflyParametersStorage butterflyParameters = new ButterflyParametersStorage();
        static OtherPreasureStorage otherPressures = new OtherPreasureStorage();
        static ContactTimeStorage contactTimes = new ContactTimeStorage();
        static PreassureMeasurementStorage preassureMeasurements = new PreassureMeasurementStorage();
        static ForceOverlayStorage forceOverlays = new ForceOverlayStorage();
        static AbstractStorage currentStorage = null;
        static HeaderStorage headers = new HeaderStorage();
        static List<PressureMeasurement> parsedPreassures = new List<PressureMeasurement>();
        static List<Parameter> parsedParameters = new List<Parameter>();
        static List<OtherPreassureMeasurement> parsedOtherPressures = new List<OtherPreassureMeasurement>();
        static List<ButterflyParameter> parsedButterflyParameters = new List<ButterflyParameter>();
        static List<ForceOverlay> parsedForceOverlays = new List<ForceOverlay>();
        static List<string> overlayCriteria = new List<string>(
            new string[] {
                    "heel",
                    "forefoot",
                    "midfoot",
                    "total"
            });
        static string foot = "";
        static string type = "";
        static string measure = "";


        public static void ParseFiles(List<string> directories, ref PatientStorage patients, ref List<Header> parsedHeaders, ref Export export)
        {


            foreach (var file in directories)
            {

                string[] lines = System.IO.File.ReadAllLines(file);

                string mainFlag = "none";

                foreach (var line in lines)
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
                parsedHeaders.Add(currentExperiment);
                parsedPreassures.AddRange(preassureMeasurements.ParseElements(currentExperiment));
                parsedParameters.AddRange(parameters.ParseElements(currentExperiment));
                parsedButterflyParameters.AddRange(butterflyParameters.ParseElements(currentExperiment));
                parsedOtherPressures.AddRange(otherPressures.ParseElements(currentExperiment));
                parsedForceOverlays.AddRange(forceOverlays.ParseElements(currentExperiment));
            }
           
            export.DumpValues<PressureMeasurement>("Preassures", parsedPreassures);
            export.DumpValues<Parameter>("Parameters", parsedParameters);
            export.DumpValues<ButterflyParameter>("ButterflyParameters", parsedButterflyParameters);
            export.DumpValues<OtherPreassureMeasurement>("OtherPreassures", parsedOtherPressures);
            export.DumpValues<ForceOverlay>("ForceOverlays", parsedForceOverlays);

        }
        private static string _forceOverlayInfo(string foot, List<string> cryteriaList, string line, string oldValue)
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
        private static AbstractStorage _setupStorage(string mainFlag, string line)
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

