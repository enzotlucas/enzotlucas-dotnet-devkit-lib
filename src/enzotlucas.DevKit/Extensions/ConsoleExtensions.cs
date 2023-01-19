namespace enzotlucas.DevKit.Extensions
{
    /// <summary>
    /// Extension class responsable for <see cref="Console"/> extension methods.
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// Write an red color message on <see cref="Console"/>.
        /// </summary>
        /// <param name="message">The specified error message.</param>
        public static void PrintError(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Write an white color message on <see cref="Console"/>.
        /// </summary>
        /// <param name="message">The custom message.</param>
        public static void PrintInformation(string message)
        {
            Print(message, ConsoleColor.White);
        }

        /// <summary>
        /// Write an green color message on <see cref="Console"/>.
        /// </summary>
        /// <param name="message">The success message.</param>
        public static void PrintSuccess(string message)
        {
            Print(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Write a object on the <see cref="Console"/> with a custom color.
        /// </summary>
        /// <param name="obj">The custom object to be printed.</param>
        /// <param name="color">The custom color.</param>
        public static void Print(object obj, ConsoleColor color)
        {
            Print(obj.ToString(), color);
        }

        /// <summary>
        /// Write a custom message with a custom color on <see cref="Console"/>.
        /// </summary>
        /// <param name="message">The custom message.</param>
        /// <param name="color">The custom color.</param>
        public static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
