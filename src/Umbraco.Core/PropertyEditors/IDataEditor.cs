using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models;

namespace Umbraco.Cms.Core.PropertyEditors;

/// <summary>
///     Represents a data editor.
/// </summary>
/// <remarks>This is the base interface for parameter and property editors.</remarks>
public interface IDataEditor : IDiscoverable
{
    /// <summary>
    ///     Gets the alias of the editor.
    /// </summary>
    string Alias { get; }

    bool SupportsReadOnly => false;

    /// <summary>
    ///     Gets a value indicating whether the editor is deprecated.
    /// </summary>
    /// <remarks>Deprecated editors are supported but not proposed in the UI.</remarks>
    bool IsDeprecated { get; }

    /// <summary>
    ///     Gets the configuration for the value editor.
    /// </summary>
    IDictionary<string, object>? DefaultConfiguration { get; }

    /// <summary>
    ///     Gets the index value factory for the editor.
    /// </summary>
    IPropertyIndexValueFactory PropertyIndexValueFactory { get; }

    /// <summary>
    ///     Gets a value editor.
    /// </summary>
    IDataValueEditor GetValueEditor(); // TODO: should be configured?!

    /// <summary>
    ///     Gets a configured value editor.
    /// </summary>
    IDataValueEditor GetValueEditor(object? configurationObject);

    /// <summary>
    ///     Gets an editor to edit the value editor configuration.
    /// </summary>
    /// <remarks>
    ///     <para>Is expected to throw if the editor does not support being configured, e.g. for most parameter editors.</para>
    /// </remarks>
    IConfigurationEditor GetConfigurationEditor();

    /// <summary>
    ///     Determines if the value editor needs to perform <see cref="PublishPartialValueForCulture"/> for a given property type.
    /// </summary>
    bool ShouldPublishPartialValues(IPropertyType propertyType) => false;

    /// <summary>
    ///     Partially published an edited property value into the published property value for a given culture.
    /// </summary>
    /// <param name="editedValue">The edited property value.</param>
    /// <param name="publishedValue">The published property value.</param>
    /// <param name="culture">The culture (or null for invariant).</param>
    /// <returns>The result of the partial publishing operation.</returns>
    object? PublishPartialValueForCulture(object? editedValue, object? publishedValue, string? culture) => editedValue;
}
