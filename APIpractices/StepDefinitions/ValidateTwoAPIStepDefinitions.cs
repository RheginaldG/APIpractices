using API_Practice.ClassModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Practice.StepDefinitions
{
    [Binding]
    public class ValidateTwoAPIStepDefinitions : BaseSteps
    {
        public ValidateTwoAPIStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"I open the user page of a specific user and copied their information from the reqres API")]
        public void GivenIOpenTheUserPageOfASpecificUserAndCopiedTheirInformationFromTheReqresAPI()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users/2", Method.GET);
            var response = client.Execute(request);
            _scenarioContext.Set(response, "open user page");
        }

        [When(@"I open the list of users page in the reqres API")]
        public void WhenIOpenTheListOfUsersPageInTheReqresAPI()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users?page=1", Method.GET);
            var response = client.Execute(request);
            _scenarioContext.Set(response, "open list of users");
        }

        [Then(@"I should be able to find my specific user on the list")]
        public void ThenIShouldBeAbleToFindMySpecificUserOnTheList()
        {
            var userResponse = _scenarioContext.Get<IRestResponse>("open user page");
            var userInfo = JsonConvert.DeserializeObject<Root>(userResponse.Content);
            var listResponse = _scenarioContext.Get<IRestResponse>("open list of users");
            //var userList = JsonConvert.DeserializeObject<userListInfo>(listResponse.Content);

            JObject listUsers = JObject.Parse(listResponse.Content);
            JToken parsedUser = listUsers.SelectToken("$.data");
            var userResult = parsedUser.Where(c => (string)c["first_name"] == "Janet").FirstOrDefault();
            var userValue = JsonConvert.DeserializeObject<Datum>(userResult.ToString());

            //var val = userList.first_name;

            Assert.AreEqual(userInfo.data.first_name, userValue.first_name, "The information is incorrect");


        }
    }
}
