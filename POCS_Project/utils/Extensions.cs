using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
