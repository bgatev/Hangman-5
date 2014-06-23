namespace Extensions
{
    using System;

    public static class ClassExtensions
    {
        /// <summary>
        /// Throws an exception if the object called upon is null.
        /// </summary>
        /// <typeparam name="T">The calling class</typeparam>
        /// <param name="obj">The This object</param>
        /// <param name="text">The text to be written on the ArgumentNullException: [text] not allowed to be null</param>
        public static void ThrowIfArgumentIsNull<T>(this T obj, string text) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(text + " not allowed to be null");
            }
        }

        /*
		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void ThrowIfArgumentIsNullOnString()
		{
			string sut = null;

			sut.ThrowIfArgumentIsNull("string");
		}

		[TestMethod]
		public void ThrowIfArgumentIsNotNullOnString()
		{
			string sut = "not null";

			sut.ThrowIfArgumentIsNull("string");
		}*/
    }
}
