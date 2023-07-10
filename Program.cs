using System.Runtime.CompilerServices;
using System.Text.Json;
using WriterReaderLib;

namespace Snake_With_ECS
{
    internal class Program
    {
        static Program()
        {
            r = new Random();
        }
        static public Random r { get; private set; }
        static void Main(string[] args)
        {
            Settings settings = JsonSerializer.Deserialize<Settings>(WRL.Read("Settings.json"));
            Render.Set(settings.Width, settings.Height);
            Console.WriteLine("Press Any Key To Start");
            Console.ReadKey(true);

            int Score = 0;
            bool IsGameAlive = true;
            Entity head;
            List<Entity> tail = new List<Entity>();
            List<Entity> apples = new List<Entity>();

            head = Entity.CreateHead();
            tail.Add(Entity.CreateTailSegment());
            tail.Add(Entity.CreateTailSegment());
            for (int i = 0; i < settings.ApplesCount; i++)
            {
                apples.Add(Entity.CreateApple());
            }

            System.MoveToRandom(apples);
            System.UpdateBuffer(head);
            System.UpdateBuffer(apples);
            Render.CreateBorder('\u2588');
            Render.RenderBuffer(0);

            while (IsGameAlive)
            {
                System.UpdateMovement(head, Input.Get());
                System.UpdateMovement(tail[0], Heap.Calc(tail[0].position, head.position));
                for (int i = 1; i < tail.Count; i++)
                {
                    System.UpdateMovement(tail[i], Heap.Calc(tail[i].position, tail[i - 1].position));
                }

                System.UpdatePosition(head);
                System.UpdatePosition(tail);

                IsGameAlive &= !System.CheckBorder(head);
                IsGameAlive &= !System.UpdateCollision(head, tail);
                foreach(Entity a in apples)
                {
                    if(!System.UpdateCollision(head, a))
                    {
                        continue;
                    }
                    tail.Add(Entity.CreateTailSegment());
                    System.MoveToRandom(a);
                    Score++;
                }

                System.UpdateBuffer(head);
                System.UpdateBuffer(tail);
                System.UpdateBuffer(apples);
                Render.CreateBorder('\u2588');

                Render.RenderBuffer(settings.TimeToReaction);
            }

            Console.Clear();
            Console.WriteLine($"Your Score is {Score} points!");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}