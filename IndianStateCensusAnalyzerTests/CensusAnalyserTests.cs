using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        string csvPath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";

        string IndianStateCensusDataWrongFilePath = @"C:\Users\amisha\source\repos\Indian_State_Census_Analyzer_Problem\IndianStateCensus_Analyser\IndianStateCensusData.csv";
        string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerTests\IndiaCensusTextFile.txt";
        string DelimiterIndianStateCensusDataFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\DelimiterIndiaStateCensusData.csv";

        string IndiaStateCodeCsvFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\IndiaStateCode.csv";
        string IndianStateCodeDataWrongFilePath = @"C:\Users\amisha\source\repos\Indian_State_Census_Analyzer_Problem\IndianStateCensus_Analyser\IndianStateCode.csv";
        string IndianStateCodeDataWrongExtensionFilePath = @"C:\Users\amisha\source\repos\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerTests\IndiaStateCode.txt";

        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";
        
        string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string IndiaStateCodeHeaders2 = "srNo,state name,tin,stateCode";



        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
        [Test]
        public void GivenIndiaStateCodeFile_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndiaStateCodeFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndiaStateCode_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongExtensionFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
    }
}