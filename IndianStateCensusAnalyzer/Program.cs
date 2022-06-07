using CsvHelper;
using CsvHelper.Configuration;
using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.POCO;
using System.Globalization;
using static IndianStateCensusAnalyzer.CensusAnalyser;

Console.WriteLine("Hello, Welcome to Indian State Census Analyser!");
CensusAnalyser censusAnalyser = new();
string csvPath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";
//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
Console.WriteLine("Total record="+ totalRecord.Count);
