namespace IntegrationTestsDemo.Api.IntegrationTests;

[CollectionDefinition("Shared test collection")]
public class SharedTestCollection : ICollectionFixture<IntTestsWebApplicationFactory>
{
}
