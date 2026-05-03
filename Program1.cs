namespace HelloWorld
{

    internal class Program1
    {
        static async Task Main(string[] args)
        {
            Task firstTask = new Task(() =>
            {

                Thread.Sleep(1000);
                Console.WriteLine("Getting printed after 1 second");

            });
            firstTask.Start();
             Task secondTask=ConsoleAfterDelayAsync("This gets printed after 2 seconds",2000);
            
            await firstTask;
            Console.WriteLine("This gets printed After task runs");

            Task thirdTask=ConsoleAfterDelayAsync("This gets printed after 1500 seconds",1500);
            
            await thirdTask;
            await secondTask;

            ConsoleAfterDelay("This gets printed after 3 seconds",3000);

           




        }
        static void ConsoleAfterDelay(string message, int delay)
        {
            Thread.Sleep(delay);
            Console.WriteLine(message);
        }

        static async Task ConsoleAfterDelayAsync(string message, int delay)
        {
           await Task.Delay(delay);
            Console.WriteLine(message);
        }
    }
}