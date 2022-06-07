using API_Practice.ClassModels;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class PutTableStepDefinitions : BaseSteps
    {
        public PutTableStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"I have set of (.*) I want to change their (.*) and (.*)")]
        public void GivenIHaveSetOfIWantToChangeTheirMaryAndPresident(int id, string name, string job)
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users/" + Convert.ToString(id), Method.PUT);
            var userDetails = new CreateUser
            {
                name = name,
                job = job
            };
            var userCreate = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails);
            request.AddJsonBody(userCreate);

            var response = client.Execute(request);
            _scenarioContext.Set(response, "edit details");
        }

        [When(@"the edit has been sent I should get a correct status code")]
        public void WhenTheEditHasBeenSentIShouldGetACorrectStatusCode()
        {
            var response = _scenarioContext.Get<IRestResponse>("edit details"); //runs the sceneario
            Assert.AreEqual(200, (int)response.StatusCode, "User Response Status does not match");
        }

        [Then(@"I should check if the edited (.*) and (.*) has been updated")]
        public void ThenIShouldCheckIfTheEditedMaryAndPresidentHasBeenUpdated(string name, string job)
        {
            var response = _scenarioContext.Get<IRestResponse>("edit details");
            var userInfo = JsonConvert.DeserializeObject<userInformation>(response.Content);
            Assert.AreEqual(name, userInfo.user_name, "name value does not match");
            Assert.AreEqual(job, userInfo.job, "job title does not match");

        }
    }
}
