using System;
using System.Reflection;
using System.ComponentModel;

namespace PresidentAtDate
{
    class EnumUtil
    {
        /// <summary>
        /// Get the Description of the enumeration
        /// </summary>
        /// <param name="e">Enumeration type</param>
        /// <returns>The description string</returns>
        public static String GetEnumDescription(Enum e)
        {
            try
            {
                FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

                DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (enumAttributes.Length > 0)
                {
                    return enumAttributes[0].Description;
                }

                return e.ToString();
            }
            catch
            {
                throw new Exception("EnumUtil:GetEnumDescription : Could not find description for given enum.");
            }
        }

        /// <summary>
        /// Retrieve the enumeration associated with the given description value
        /// </summary>
        /// <param name="enumType">The enumeration type</param>
        /// <param name="desc"> The description string to look for</param>
        /// <returns>The enum with the given description</returns>
        public static Enum GetEnumFromDescription(Type enumType, String desc)
        {
            try
            {
                Array enumArray = Enum.GetValues(enumType);
                String foundDesc = String.Empty;
                foreach (Enum e in enumArray)
                {
                    FieldInfo fieldInfo = e.GetType().GetField(e.ToString());
                    DescriptionAttribute[] enumAttributes =
                        (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (enumAttributes.Length > 0)
                    {
                        foundDesc = enumAttributes[0].Description;
                    }
                    else
                    {
                        foundDesc = e.ToString();
                    }
                    if (desc.Equals(foundDesc))
                    {
                        return e;
                    }
                }

                // no enum found with the given enum type and description string attribute
                return null;
            }
            catch
            {
                throw new Exception("EnumUtil:GetEnumFromDescription : Could not find enum for given description.");
            }
        }
    }
}
