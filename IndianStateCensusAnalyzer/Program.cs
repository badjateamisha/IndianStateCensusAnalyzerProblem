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
string DelimiterIndianStateCensusDataFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\DelimiterIndiaStateCensusData.csv";
string csvPath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";
//censusAnalyser.ReadCsvFile();
string IndiaStateCodeCsvFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCode.csv";
string IndianStateCodeDataWrongFilePath = @"C:\Users\amisha\source\repos\Indian_State_Census_Analyzer_Problem\IndianStateCensus_Analyser\IndianStateCode.csv";
string IndianStateCodeDataWrongExtensionFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerTests\IndiaStateCode.txt";
string DelimeterIndiaStateCode = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzer_Problem\IndianStateCensus_Analyser\DelimeterIndiaStateCode.csv";


string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";

string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
string IndiaStateCodeHeaders2 = "srNo,state name,tin,stateCode";


while (true)
{
    Console.WriteLine("Please choose the option: \n1)UC1 - Check the number of records in CSV file\n2)UC1.2 - Given wrong file Path\n3)UC1.3 - Giving wrong text file as Input\n4)UC1.4-Throw exception if Delimeter is Wrong\n5)UC1.5-Throw exception if Wrong Headers are given\n6)UC2 Load India State code (Count Rows)\n7)UC2.2 Given wrong file Path(for Indian State code)\n8)UC2.3Throw exception if Extension is Wrong(for Indian State code)\n9)UC2.4-Throw exception if Delimeter is Wrong(for Indian State code)\n10)uc2.5-Throw exception if Wrong Headers are given(for Indian State code)");
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
        case 4:
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 5:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 6:
            Dictionary<string, CensusDTO> stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Console.WriteLine(stateRecord.Count);
            break;
        case 7:
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 8:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongExtensionFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 9:
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                stateRecord = a1.LoadCensusData(DelimeterIndiaStateCode, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 10:
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders2);
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
