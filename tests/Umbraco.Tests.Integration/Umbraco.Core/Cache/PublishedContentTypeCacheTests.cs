﻿using NUnit.Framework;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentTypeEditing;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Services.ContentTypeEditing;
using Umbraco.Cms.Tests.Common.Builders;
using Umbraco.Cms.Tests.Common.Testing;
using Umbraco.Cms.Tests.Integration.Testing;

namespace Umbraco.Cms.Tests.Integration.Umbraco.Core.Cache;

[TestFixture]
[UmbracoTest(Database = UmbracoTestOptions.Database.NewSchemaPerTest)]
public class PublishedContentTypeCacheTests : UmbracoIntegrationTest
{
    // Integration tests på om IPublishedCOntentTypeCache bliver opdateret CRUD

    // Create a ContentTypeEdtingBuilder
    protected ContentTypeCreateModel ContentType { get; private set; }


    // Inspiration: https://github.com/umbraco/Umbraco-CMS/pull/16938/commits/e45fa106840d7b88ed5ea095c29571e24275e925
    protected override void CustomTestSetup(IUmbracoBuilder builder) => builder.AddUmbracoHybridCache();

    private IPublishedContentCache PublishedContentCache => GetRequiredService<IPublishedContentCache>();
    private IPublishedContentTypeCache PublishedContentTypeCache => GetRequiredService<IPublishedContentTypeCache>();

    private IContentTypeEditingService ContentTypeEditingService => GetRequiredService<IContentTypeEditingService>();


    [Test]
    public async Task Can_Get_Draft_Content_By_Id()
    {
        //Act
        ContentTypeEditingBuilder contentTypeBuilder = new ContentTypeEditingBuilder();
        // contentTypeBuilder.createBasicContentType();
        //ContentTypeEditingService

        //var textPage = await PublishedContentTypeCache.Get(TextpageId, true);

        // var newContentType = ContentTypeBuilder.CreateBasicContentType();
        // newContentType.Key = ContentType.Key;
        // newContentType.Id = ContentType.Id;
        // newContentType.Alias = ContentType.Alias;
        // newContentType.DefaultTemplateId = ContentType.DefaultTemplateId;
        // ContentTypeService.Save(newContentType);

        // Assert
        //var newTextPage = await PublishedContentHybridCache.GetByIdAsync(TextpageId, true);
       // Assert.IsNull(newTextPage.Value("title"));
    }
    //
    // [Test]
    // public async Task Can_Get_Draft_Content_By_Key()
    // {
    //     // Act
    //     var textPage = await PublishedContentHybridCache.GetByIdAsync(Textpage.Key.Value, true);
    //
    //     var newContentType = ContentTypeBuilder.CreateBasicContentType();
    //     newContentType.Key = ContentType.Key;
    //     newContentType.Id = ContentType.Id;
    //     newContentType.Alias = ContentType.Alias;
    //     newContentType.DefaultTemplateId = ContentType.DefaultTemplateId;
    //     ContentTypeService.Save(newContentType);
    //
    //     //Assert
    //     var newTextPage = await PublishedContentHybridCache.GetByIdAsync(Textpage.Key.Value, true);
    //     Assert.IsNull(newTextPage.Value("title"));
    // }


     [SetUp]
    public new void Setup() => CreateTestData();

    protected async void CreateTestData()
    {
        ContentType =
            ContentTypeEditingBuilder.CreateBasicContentType("umbTextpage", "Textpage");

        var contentTypeResult = await ContentTypeEditingService.CreateAsync(ContentType, Constants.Security.SuperUserKey);
        Assert.IsTrue(contentTypeResult.Success);

    }
}
