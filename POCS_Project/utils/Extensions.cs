using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;

namespace POCS_Project.utils
{
    public static class Extensions
    {
        public static TEnum SearchEnumByDisplayName<TEnum>(this string displayName) where TEnum : struct, Enum
        {
            if(!typeof(TEnum).IsEnum)
                throw new ArgumentException($"O tipo '{typeof(TEnum)}' não é um enum.");

            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var enumMember = typeof(TEnum).GetField(enumValue.ToString());
                var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(enumMember, typeof(DisplayAttribute));

                if (displayAttribute != null && displayAttribute.Name.ToUpper() == displayName.ToUpper())
                    return enumValue;
            }

            throw new ArgumentException($"Não foi encontrado um valor de enum {typeof(TEnum)} com o nome de exibição '{displayName}'.");
        }
        public static string GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
        {
            var enumType = enumValue.GetType();
            var memberInfo = enumType.GetMember(enumValue.ToString());
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (displayAttribute != null && displayAttribute.Length > 0)
            {
                return displayAttribute[0].Name;
            }
            else
            {
                return enumValue.ToString(); // Retorna o nome padrão do enum se o atributo de exibição não estiver definido
            }
        }
        public static IList<string> GetEnumDisplayValues<T>() where T : Enum
        {
            var type = typeof(T);
            var displayValues = new List<string>();

            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    displayValues.Add(displayAttribute.Name);
                }
                else
                {
                    displayValues.Add(field.Name);
                }
            }

            return displayValues;
        }
        public static List<string> GetBitmapNames(this List<Bitmap> bitmaps)
        {
            var bitmapNames = new List<string>();
            var properties = typeof(Properties.Resources).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(Bitmap))
                    bitmapNames.Add(property.Name);
            }

            return bitmapNames;
        }
    }
}
