﻿using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.HybridCache.Services;

namespace Umbraco.Cms.Infrastructure.HybridCache;

public class MediaCache : IPublishedMediaHybridCache
{
    private readonly IMediaCacheService _mediaCacheService;
    private readonly PublishedContentTypeCache _publishedContentTypeCache;

    public MediaCache(IMediaCacheService mediaCacheService, PublishedContentTypeCache publishedContentTypeCache)
    {
        _mediaCacheService = mediaCacheService;
        _publishedContentTypeCache = publishedContentTypeCache;
    }

    public async Task<IPublishedContent?> GetByIdAsync(int id) => await _mediaCacheService.GetByIdAsync(id);

    public async Task<IPublishedContent?> GetByKeyAsync(Guid key) => await _mediaCacheService.GetByKeyAsync(key);

    public async Task<bool> HasByIdAsync(int id) => await _mediaCacheService.HasContentByIdAsync(id);

    public IPublishedContent? GetById(bool preview, int contentId) => GetByIdAsync(contentId).GetAwaiter().GetResult();

    public IPublishedContent? GetById(bool preview, Guid contentId) =>
        GetByKeyAsync(contentId).GetAwaiter().GetResult();


    public IPublishedContent? GetById(int contentId) => GetByIdAsync(contentId).GetAwaiter().GetResult();

    public IPublishedContent? GetById(Guid contentId) => GetByKeyAsync(contentId).GetAwaiter().GetResult();

    public bool HasById(bool preview, int contentId) => HasByIdAsync(contentId).GetAwaiter().GetResult();

    public bool HasById(int contentId) => HasByIdAsync(contentId).GetAwaiter().GetResult();

    public IPublishedContentType? GetContentType(Guid key) => _publishedContentTypeCache.Get(PublishedItemType.Media, key);

    public IPublishedContentType GetContentType(int id) => _publishedContentTypeCache.Get(PublishedItemType.Media, id);

    public IPublishedContentType GetContentType(string alias) => _publishedContentTypeCache.Get(PublishedItemType.Media, alias);

    // FIXME - these need to be removed when removing nucache
    public IPublishedContent? GetById(bool preview, Udi contentId) => throw new NotImplementedException();

    public IPublishedContent? GetById(Udi contentId) => throw new NotImplementedException();

    public IEnumerable<IPublishedContent> GetAtRoot(bool preview, string? culture = null) => throw new NotImplementedException();

    public IEnumerable<IPublishedContent> GetAtRoot(string? culture = null) => throw new NotImplementedException();

    public bool HasContent(bool preview) => throw new NotImplementedException();

    public bool HasContent() => throw new NotImplementedException();


    public IEnumerable<IPublishedContent> GetByContentType(IPublishedContentType contentType) =>
        throw new NotImplementedException();
}
