using DynamoParses.Models;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DynamoParses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HeaderStorage headers = new HeaderStorage();
            ParameterStorage parameters = new ParameterStorage();
            ButterflyParametersStorage butterflyParameters = new ButterflyParametersStorage();
            OtherPreasureStorage otherPressures = new OtherPreasureStorage();
            ContactTimeStorage contactTimes = new ContactTimeStorage();
            PreassureMeasurementStorage preassureMeasurements = new PreassureMeasurementStorage();
            ForceOverlayStorage forceOverlays = new ForceOverlayStorage();
            PatientStorage patients = new PatientStorage();
            AbstractStorage currentStorage = null;
            List<Header> parsedHeaders = new List<Header>();
            List<PressureMeasurement> parsedPreassures = new List<PressureMeasurement>();
            List<Parameter> parsedParameters = new List<Parameter>();
            List<OtherPreassureMeasurement> parsedOtherPressures = new List<OtherPreassureMeasurement>();
            List<ButterflyParameter> parsedButterflyParameters = new List<ButterflyParameter>();
            List<ForceOverlay> parsedForceOverlays = new List<ForceOverlay>();

            List<string> directories = new List<string>(
                    new string[]
                    {
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, buty 1.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, b2.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, bb 1.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, bb 2.txt"
                    }
                );
            foreach (var file in directories)
            {


                string[] lines = System.IO.File.ReadAllLines(file);
                List<string> overlayCriteria = new List<string>(
                    new string[] {
                    "heel",
                    "forefoot",
                    "midfoot",
                    "total"
                    });
                string foot = "";
                string type = "";
                string measure = "";
                string mainFlag = "none";
                string additionalInfo = null;
                List<PressureMeasurement> preasures = new List<PressureMeasurement>();
                foreach (var line in lines)
                {
                    Match match = Regex.Match(line, @"\[([^)]*)\]");
                    if (match.Success)
                    {
                        mainFlag = match.Groups[1].Value;
                        continue;

                    }
                    switch (mainFlag)
                    {
                        case "Header":
                            currentStorage = headers;
                            break;

                        case "Left":
                            if (line == "Force,N	  X,mm	   Y,mm")
                            {
                                currentStorage = preassureMeasurements;
                                additionalInfo = "Left, ";
                                break;
                            }
                            if (line.Contains("force overlay"))
                            {
                                currentStorage = forceOverlays;
                                additionalInfo = "Left, force overlay, ";
                                break;
                            }
                            if (additionalInfo.Contains("force overlay"))
                            {
                                additionalInfo = _forceOverlayInfo("Left", overlayCriteria, line, additionalInfo);
                            }
                            break;
                        case "Right":
                            if (line == "Force,N	  X,mm	   Y,mm")
                            {
                                currentStorage = preassureMeasurements;
                                additionalInfo = "Right, ";
                                break;
                            }
                            if (line.Contains("force overlay"))
                            {
                                currentStorage = forceOverlays;
                                additionalInfo = "Right, force overlay, ";
                                break;
                            }
                            if (additionalInfo.Contains("force overlay"))
                            {
                                additionalInfo = _forceOverlayInfo("Right", overlayCriteria, line, additionalInfo);
                            }
                            break;

                        case "Butterfly":
                            if (line == "Force,N	  X,mm	   Y,mm")
                            {
                                currentStorage = preassureMeasurements;
                                additionalInfo = "Butterfly, ";
                                break;
                            }
                            if (line.Contains("force overlay"))
                            {
                                currentStorage = forceOverlays;
                                additionalInfo = "Butterfly, force overlay, ";
                                break;
                            }
                            if (additionalInfo.Contains("force overlay"))
                            {
                                additionalInfo = _forceOverlayInfo("Butterfly", overlayCriteria, line, additionalInfo);
                            }
                            break;
                        case "Parameters":
                            currentStorage = parameters;
                            break;

                        case "Butterfly Parameters":
                            currentStorage = butterflyParameters;
                            break;

                        case "":

                            // find Max Pressure  or force
                            // find "Time, %	 Value, 	 SD,"
                            // take to OtherPressureStorage - Type - Measurement 1 - Dowiedzieć się co to kurwa jest 
                            // find "Time, %	 Value," 
                            // take to to OtherPressureStorage - Type - Measurement 2 - Dowiedzieć się co to kurwa jest 
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
                            additionalInfo = foot + ", " + type + ", " + measure + ", ";
                            break;
                        default:
                            currentStorage = null;
                            additionalInfo = null;
                            break;
                    }

                    if (currentStorage != null)
                    {
                        currentStorage.AddElement(additionalInfo + line);
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
            Export export = new Export();
            export.DumpValues<Header>("Experiments", parsedHeaders);
            export.DumpValues<PressureMeasurement>("Preassures", parsedPreassures);
            export.DumpValues<Patient>("Patients", patients.AllPatients);
            export.DumpValues<Parameter>("Parameters", parsedParameters);
            export.DumpValues<ButterflyParameter>("ButterflyParameters", parsedButterflyParameters);
            export.DumpValues<OtherPreassureMeasurement>("OtherPreassures", parsedOtherPressures);
            export.DumpValues<ForceOverlay>("ForceOverlays", parsedForceOverlays);
            export.Save(@"c:\temp\Data_Test.xlsx");
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
    }
}
