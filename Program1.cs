namespace HelloWorld
{

    internal class Program1
    {
        static async Task Main(string[] args)
        {
            Task firstTask=new Task(()=>{
                
                Thread.Sleep(1000);
                Console.WriteLine("Getting printed after 1 second");   

            });
            firstTask.Start();
            await firstTask;
            Console.WriteLine("This gets printed After task runs");
            

        }
    }
}