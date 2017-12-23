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
        public Dynamic()
        {
        }
        private MaxForceStorage maxForces = new MaxForceStorage();
        private ParameterStorage parameters = new ParameterStorage();
        private ButterflyParametersStorage butterflyParameters = new ButterflyParametersStorage();
        private OtherPreasureStorage otherPressures = new OtherPreasureStorage();
        private ContactTimeStorage contactTimes = new ContactTimeStorage();
        private PreassureMeasurementStorage preassureMeasurements = new PreassureMeasurementStorage();
        private ForceOverlayStorage forceOverlays = new ForceOverlayStorage();
        private AbstractStorage currentStorage = null;
        private HeaderStorage headers = new HeaderStorage();
        private OtherDynamicParameterStorage otherParameters = new OtherDynamicParameterStorage();
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

        public void ParseFiles(string file, ref PatientStorage patients, ref List<Header> parsedHeaders, ref Export export, Dictionary<string, bool> launch)
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
            if (launch["Preassures"])
            {
                export.DumpValues("Preassures", preassureMeasurements.ParseElements(currentExperiment));
            }
            if (launch["Butterfly Parameters"])
            {
                export.DumpValues("ButterflyParameters", butterflyParameters.ParseElements(currentExperiment));
            }
            if (launch["Other Preassures"])
            {
                export.DumpValues("OtherPreassures", otherPressures.ParseElements(currentExperiment));
            }
            if (launch["Parameters"])
            {
                export.DumpValues("DynamicParameters", parameters.ParseElements(currentExperiment));
            }
            if (launch["Force Overlays"])
            {
                export.DumpValues("ForceOverlays", forceOverlays.ParseElements(currentExperiment));
            }
            if (launch["Max Forces"])
            {
                export.DumpValues("MaxForces", maxForces.ParseElements(currentExperiment));
            }
            if (launch["Other Parameters"])
            {
                export.DumpValues("OtherDynamicParameters", otherParameters.ParseElements(currentExperiment));
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
                    if (line.Contains("force") && !line.Contains("Signal") && !line.Contains("Max"))
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
                    if (Regex.IsMatch(line, @"(Max force \d)+"))
                    {
                        currentStorage = maxForces;
                    }

                    if (otherParameters.OtherParameterHeaders.ContainsKey(line))
                    {
                        currentStorage = otherParameters;
                        List<string> tempList = (otherParameters.OtherParameterHeaders[line]).Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        foot = tempList[0];
                        type = tempList[1];
                        measure = null;
                    }
                    if (line.Contains("Time change heel to forefoot"))
                    {
                        currentStorage = otherParameters;
                        foot = type = measure = null;
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

