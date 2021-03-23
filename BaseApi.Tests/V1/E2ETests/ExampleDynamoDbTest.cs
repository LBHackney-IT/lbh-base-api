using AutoFixture;
using BaseApi;
using BaseApi.Tests;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

//namespace BaseApi.Tests.V1.E2ETests
//{
// For guidance on writing integration tests see the wiki page https://github.com/LBHackney-IT/lbh-base-api/wiki/Writing-Integration-Tests
// Example integration tests using DynamoDb

//public class ExampleDynamoDbTest : DynamoDbIntegrationTests<Startup>
//{
//    private readonly Fixture _fixture = new Fixture();

//    /// <summary>
//    /// Method to construct a test entity that can be used in a test
//    /// </summary>
//    /// <param name="entity"></param>
//    /// <returns></returns>
//    private Entity ConstructTestEntity()
//    {
//        var entity = _fixture.Create<Entity>();
//        entity.CreatedAt = DateTime.UtcNow;
//        return entity;
//    }

//    /// <summary>
//    /// Method to add an entity instance to the database so that it can be used in a test.
//    /// Also adds the corresponding action to remove the upserted data from the database when the test is done.
//    /// </summary>
//    /// <param name="entity"></param>
//    /// <returns></returns>
//    private async Task SetupTestData(Entity entity)
//    {
//        await DynamoDbContext.SaveAsync(entity.ToDatabase()).ConfigureAwait(false);
//        CleanupActions.Add(async () => await DynamoDbContext.DeleteAsync<DatabaseEntity>(entity.Id).ConfigureAwait(false));
//    }

//    [Test]
//    public async Task GetEntityByIdNotFoundReturns404()
//    {
//        int id = 123456789;
//        //TODO: Update uri route to match the APIs endpoint
//        var uri = new Uri($"api/v1/notes/{id}", UriKind.Relative);
//        var response = await Client.GetAsync(uri).ConfigureAwait(false);

//        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
//    }

//    [Test]
//    public async Task GetNoteBydIdFoundReturnsResponse()
//    {
//        var entity = ConstructTestEntity();
//        await SetupTestData(entity).ConfigureAwait(false);

//        //TODO: Update uri route to match the APIs endpoint
//        var uri = new Uri($"api/v1/notes/{entity.Id}", UriKind.Relative);
//        var response = await Client.GetAsync(uri).ConfigureAwait(false);

//        response.StatusCode.Should().Be(HttpStatusCode.OK);

//        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//        var apiEntity = JsonConvert.DeserializeObject<Entity>(responseContent);

//        apiEntity.Should().BeEquivalentTo(entity, (x) => x.Excluding(y => y.CreatedAt));
//        apiEntity.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1000);
//    }
//}
//}
