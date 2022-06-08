using CsvHelper;
using CsvHelper.Configuration;
using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.POCO;
using System.Globalization;
using static IndianStateCensusAnalyzer.CensusAnalyser;

Console.WriteLine("Hello, Welcome to Indian State Census Analyser!");
CensusAnalyser censusAnalyser = new();
string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerTests\IndiaCensusTextFile.txt";
string IndianStateCensusDataWrongFilePath = @"C:\Users\amisha\source\repos\Indian_State_Census_Analyzer_Problem\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";
string csvPath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";
//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
while (true)
{
    Console.WriteLine("Please choose the option: \n1) Check the number of records in CSV file\n2) Given wrong file Path\n3) Giving wrong text file as Input");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Console.WriteLine(totalRecord.Count);
            break;
        case 2:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 3:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongExtensionFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        default:
            Console.WriteLine("Please choose Valid option!");
            break;

    }
}
