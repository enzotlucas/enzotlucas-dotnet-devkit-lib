namespace enzotlucas.DevKit.Extensions
{
    /// <summary>
    /// Extension class responsable for <see cref="Console"/> extension methods.
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void PrintError(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void PrintInformation(string message)
        {
            Print(message, ConsoleColor.White);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void PrintSuccess(string message)
        {
            Print(message, ConsoleColor.Green);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="color"></param>
        public static void Print(object obj, ConsoleColor color)
        {
            Print(obj.ToString(), color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
