using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class MovingOnePageStepDefinitions : BaseSteps
    {
        public MovingOnePageStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"I open a reqres user api (.*)")]
        public void GivenIOpenAReqresUserApi(string pageNum)
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users?page="+pageNum, Method.GET);
            var response = client.Execute(request);
            _scenarioContext.Set(response, "open page");
        }

        [Then(@"I should get a correct status code")]
        public void ThenIShouldGetACorrectStatusCode()
        {
            var response = _scenarioContext.Get<IRestResponse>("open page");
            Assert.AreEqual(200, (int)response.StatusCode, "User Response Status does not match");
        }
    }
}
