using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Models.ItemModels.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace TheInjectables.Feature.PaaSPort.DXF.Providers.Azure.Converters.DataAccess.ValueAccessors
{
    public class PropertyValueAccessorConverter : ValueAccessorConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{729AEFFB-B5BD-4CD4-958F-E25B50948AC8}");

        public PropertyValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }

        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }

            var propertyName = GetStringValue(source, PropertyValueAccessorItemModel.PropertyName);
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            //unless a reader or writer is explicitly set use the property value
            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new PropertyValueReader(propertyName);
            }
            if (accessor.ValueWriter == null)
            {
                accessor.ValueWriter = new PropertyValueWriter(propertyName);
            }
            return accessor;
        }
    }
}