using API_Practice.ClassModels;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class ReqresPostTestStepDefinitions : BaseSteps
    { 
        public ReqresPostTestStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }       

        [Given(@"I want to connect to the reqres user create API")]
        public void GivenIWantToConnectToTheReqresUserCreateAPI()
        {
            // setting up test data
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users", Method.POST);

            var userDetails = new CreateUser
            {
                name = "Mike",
                job = "Tester"
            };
            var userCreate = Newtonsoft.Json.JsonConvert.SerializeObject(userDetails);
            request.AddJsonBody(userCreate);

            // execute
            var response = client.Execute(request);

            // Set the response data
            _scenarioContext.Set(response, "reqresPost"); //very important if you want to move around 
        }

        [When(@"I am connected the correct status code is shown")]
        public void WhenIAmConnectedTheCorrectStatusCodeIsShown()
        {

            var response = _scenarioContext.Get<IRestResponse>("reqresPost"); //runs the sceneario
            Assert.AreEqual(201, (int)response.StatusCode, "User Response Status does not match");
        }

        [Then(@"I input the name of the user and their role")]
        public void ThenIInputTheNameOfTheUserAndTheirRole()
        {
           

            var response = _scenarioContext.Get<IRestResponse>("reqresPost"); //how to call your move around
            var userInfo = JsonConvert.DeserializeObject<userInformation>(response.Content);
            

            Assert.AreEqual("Mike", userInfo.user_name);
            Assert.AreEqual("Tester", userInfo.job);
        }

    }
}
