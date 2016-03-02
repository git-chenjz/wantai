using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyFrameWork.Common;

namespace MyFrameWork.Mvc
{
    public class JQAjaxModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Type parameterType = bindingContext.ModelType;
            string prefix = bindingContext.ModelName;
            if (typeof(IEnumerable).IsAssignableFrom(parameterType))
            {
                var key = prefix + "[]";
                var valueResult = bindingContext.ValueProvider.GetValue(key);
                if (valueResult != null && !string.IsNullOrEmpty(valueResult.AttemptedValue))
                    bindingContext.ModelName = key;
                else
                {
                    valueResult = bindingContext.ValueProvider.GetValue(prefix);
                    ModelMetadata modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => null, parameterType);
                    if (modelMetadata.IsComplexType && valueResult != null && !string.IsNullOrEmpty(valueResult.AttemptedValue))
                    {
                        if (typeof(IDictionary).IsAssignableFrom(parameterType))
                            return valueResult.AttemptedValue.ToObject<IDictionary>();
                        if (typeof(ICollection).IsAssignableFrom(parameterType) && valueResult.RawValue.GetType() == parameterType)
                            return valueResult.ConvertTo(parameterType);
                    }
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
        bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }
    }
}
