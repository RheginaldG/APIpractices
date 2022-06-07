using API_Practice.ClassModels;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class CheckAddressStepDefinitions : BaseSteps
    {
        public CheckAddressStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"I connect to the zippostam api")]
        public void GivenIConnectToTheZippostamApi()
        {
            // setting up test data
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("/nz/1010", Method.GET);

            // execute
            var response = client.Execute(request);

            // Set the response data
            _scenarioContext.Set(response, "zipCodeResponse");
        }

        [When(@"I am connected I should get a correct status code")]
        public void WhenIAmConnectedIShouldGetACorrectStatusCode()
        {
            var response = _scenarioContext.Get<IRestResponse>("zipCodeResponse");
            Assert.AreEqual(200, (int)response.StatusCode, "Zipcode Response Status does not match");

        }

        [Then(@"I should get a correct information on my request")]
        public void ThenIShouldGetACorrectInformationOnMyRequest()
        {
            var response = _scenarioContext.Get<IRestResponse>("zipCodeResponse");
            var localInfo = JsonConvert.DeserializeObject<LocationResponse>(response.Content);
            
            /*Assert.IsTrue((bool)response.Content.Contains("1010"), "request does not contain the specified value");*/ //not the best choice of code 

            Assert.AreEqual("1010", localInfo.PostCode); 
            Assert.AreEqual("New Zealand", localInfo.Country);
            Assert.AreEqual("NZ", localInfo.CountryAbbreviation);



        }

    }
}
