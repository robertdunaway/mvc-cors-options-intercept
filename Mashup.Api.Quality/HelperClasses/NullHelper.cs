using System;
using System.Data;

// To get the above using statement to work I had to remove DNX Core 5.0 from the project.json.  
// It kept interfering despite the fact that 4.51 is what I want to use.
// "dnxcore50": { } is what I removed per this stack overflow
// http://stackoverflow.com/questions/30087232/how-to-switch-context-in-vs-net-2015
// Fixed problem instantly and now I can use System.Data again.  :)


namespace Helper.Library
{
    /// <summary>
    /// Helper class for when dealing with Null values.
    /// </summary>
    public static class NullHelper
    {
        /// <summary>
        /// Gets the date from a reader but if the value is null returns the MinValue of the DateTime class.
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static DateTime GetDateFromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                return reader.GetDateTime(index);
            }

            return DateTime.MinValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static decimal GetDecimalFromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                return reader.GetDecimal(index);
            }

            return 0m;
        }
        public static decimal GetDecimalFromString(string value, decimal returnIfInvalid)
        {
            decimal newDecimal;
            if (!Decimal.TryParse(value, out newDecimal))
            {
                newDecimal = returnIfInvalid;
            }

            return newDecimal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static Int16 GetInt16FromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                return reader.GetInt16(index);
            }

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static Int32 GetInt32FromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                return reader.GetInt32(index);
            }

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static Int64 GetInt64FromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            { return reader.GetInt64(index); }

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static string GetStringFromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                //return reader.GetString(index).TrimEnd();
                return reader[index].ToString();
            }

            return String.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader">Record that holds values for evaluation.</param>
        /// <param name="field">String name of the field to evaluate.</param>
        /// <returns></returns>
        public static float GetFloatFromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            { return reader.GetFloat(index); }

            return 0f;
        }

        public static char GetCharFromReader(IDataRecord reader, string field)
        {
            int index = reader.GetOrdinal(field);

            if (!reader.IsDBNull(index))
            {
                return Convert.ToChar(reader[index].ToString());
                // return reader.GetChar(index); - Specified Method not supported error
            }

            return char.MinValue;
        }

    }
}
