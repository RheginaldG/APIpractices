using API_Practice.ClassModels;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class PostTableStepDefinitions : BaseSteps
    {
        public PostTableStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"I enter (.*) and (.*) on reqres api")]
        public void GivenIEnterMikeAndQAOnReqresApi(string name, string job)
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users", Method.POST);

            var userDetails = new CreateUser { 
                name = name, 
                job = job 
            };

            var userCreate = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails);
            request.AddJsonBody(userCreate);

            var response = client.Execute(request);
            _scenarioContext.Set(response, "reqresPost");
        }

        [When(@"the information is sent should give me the correct status code")]
        public void WhenTheInformationIsSentShouldGiveMeTheCorrectStatusCode()
        {
            var response = _scenarioContext.Get<IRestResponse>("reqresPost"); //runs the sceneario
            Assert.AreEqual(201, (int)response.StatusCode, "User Response Status does not match");
        }

        [Then(@"I will check if the correct (.*) and (.*) was sent over")]
        public void ThenIWillCheckIfTheCorrectMikeAndQAWasSentOver(string name, string job)
        {
            var response = _scenarioContext.Get<IRestResponse>("reqresPost");
            var userInfo = JsonConvert.DeserializeObject<userInformation>(response.Content);
            Assert.AreEqual(name, userInfo.user_name,"name value does not match");
            Assert.AreEqual(job, userInfo.job, "job title does not match");
        }













    }
}
