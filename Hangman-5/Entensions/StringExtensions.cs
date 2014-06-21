namespace Extensions
{
    using System;

    public static class StringExtensions
    {
        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ToEnum<T>(this string value)
        {
            return ToEnum<T>(value, false);
        }

        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <param name="ignorecase">Ignore the case of the string being parsed</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ToEnum<T>(this string value, bool ignorecase)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value");
            }

            value = value.Trim();

            if (value.Length == 0)
            {
                throw new ArgumentNullException("Must specify valid information for parsing in the string.", "value");
            }

            Type t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", "T");
            }

            return (T)Enum.Parse(t, value, ignorecase);
        }

        public static string GetValueOrEmpty(this string value)
        {
            return GetValueOrDefault(value, string.Empty);
        }

        public static string GetValueOrDefault(this string value, string defaultvalue)
        {
            if (value != null)
            {
                return value;
            }
             
            return defaultvalue;
        }

        /*private enum DummyEnum
        {
            one,
            two,
            three
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStringToDummyEnum()
        {
            "".ToEnum<DummyClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringToDummyEnum()
        {
            string nullstring = null;
            nullstring.ToEnum<DummyClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Type provided must be an Enum.")]
        public void StringToNonEnumType()
        {
            "dummystring".ToEnum<DummyClass>();
        }

        [TestMethod]
        public void StringToDummyEnum()
        {
            Assert.AreEqual(DummyEnum.one, "one".ToEnum<DummyEnum>());
        }

        [TestMethod]
        public void IgnoreCaseStringToDummyEnum()
        {
            Assert.AreEqual(DummyEnum.one, "one".ToEnum<DummyEnum>(true));
        }
        
        [TestMethod]
        public void NullStringToDefault()
        {
            string value = null;
            Assert.AreEqual("Test", value.GetValueOrDefault("Test"));
        }
         
        [TestMethod]
        public void NullStringToEmpty()
        {
            string value = null;
            Assert.AreEqual("", value.GetValueOrEmpty());
        }*/
    }
}
