using System;
using NUnit.Framework;
using RestApiTesting;
using RestApiTesting.DTO;

namespace ApiTests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void GetListOfUsersTest()
        {
            var apiHelper = new ApiHelper("api/users?page=2");
            var restRequest = apiHelper.CreateGetRequest();
            var restResponse = apiHelper.ExecuteAndGetResponse(restRequest);
            ListOfUsersDTO listUsersObject = apiHelper.GetContent<ListOfUsersDTO>(restResponse);

            Assert.AreEqual("OK", restResponse.StatusDescription);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.AreEqual("michael.lawson@reqres.in", listUsersObject.data[0].email);
        }

        [Test]
        public void GetSingleUserTest()
        {
            var apiHelper = new ApiHelper("api/users/2");

            var restRequest = apiHelper.CreateGetRequest();
            var restResponse = apiHelper.ExecuteAndGetResponse(restRequest);
            var singleUserDataObject = apiHelper.GetContent<SingleUserDataDTO>(restResponse);

            Assert.AreEqual("OK", restResponse.StatusDescription);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.AreEqual("janet.weaver@reqres.in", singleUserDataObject.data.email);
            Assert.AreEqual("https://reqres.in/#support-heading", singleUserDataObject.support.url);
        }

        [Test]
        public void CreateUserTest()
        {
            var apiHelper = new ApiHelper("api/users");

            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                               }";
            var restRequest = apiHelper.CreatePostRequest(payload);
            var restResponse = apiHelper.ExecuteAndGetResponse(restRequest);
            var userObject = apiHelper.GetContent<CreateUsersDto>(restResponse);

            Assert.AreEqual("Created", restResponse.StatusDescription);
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Assert.AreEqual("morpheus", userObject.Name);
            Assert.AreEqual("leader", userObject.Job);
            Console.WriteLine($"Id : {userObject.Id} --- Created At : {userObject.CreatedAt}");
        }

        [Test]
        public void UpdateUserTest()
        {
            var apiHelper = new ApiHelper("api/users/2");

            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                               }";
            var restRequest = apiHelper.CreatePutRequest(payload);
            var restResponse = apiHelper.ExecuteAndGetResponse(restRequest);
            var userObject = apiHelper.GetContent<CreateUsersDto>(restResponse);

            Assert.AreEqual("OK", restResponse.StatusDescription);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.AreEqual("morpheus", userObject.Name);
            Assert.AreEqual("leader", userObject.Job);
            Console.WriteLine($"Id : {userObject.Id} --- Created At : {userObject.CreatedAt}");
        }

        [Test]
        public void DeleteUserTest()
        {
            var apiHelper = new ApiHelper("api/users/2");

            var restRequest = apiHelper.CreateDeleteRequest();
            var restResponse = apiHelper.ExecuteAndGetResponse(restRequest);

            Assert.AreEqual("No Content", restResponse.StatusDescription);
            Assert.AreEqual(204, (int)restResponse.StatusCode);
        }
    }
}