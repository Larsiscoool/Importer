internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string[] lines = File.ReadAllLines(@"C:\Users\larsb\Source\Importer\Overganger.txt");

        Console.WriteLine("Contents of WriteLines2.txt = ");

        List<Intersection> intersections = new();

        var id = 0;

        foreach (string line in lines)
        {   
            var route = line.Substring(11, 4);
            Console.WriteLine($"route:{route}");
            
            var journey = line.Substring(22, 4);
            Console.WriteLine($"journey:{journey}");

            var stoparea = line.Substring(34, 8);
            Console.WriteLine($"stoparea:{stoparea}");

            var to_route = line.Substring(90, 4);
            Console.WriteLine($"to route:{to_route}");
            
            var to_journey = line.Substring(103, 4);
            Console.WriteLine($"to journey:{to_journey}");

            var to_stoparea = line.Substring(118, 8);
            Console.WriteLine($"to stoparea:{to_stoparea}");

            intersections.Add(new Intersection(){
                Id = id,
                StaySeated = true,
                Guaranteed = true,
                FromLineId = Convert.ToInt32(route),
                ToLineId = Convert.ToInt32(to_route),
                FromJourneyId = Convert.ToInt32(journey),
                ToJourneyId = Convert.ToInt32(to_journey),
                FromPointId = Convert.ToInt32(stoparea),
                ToPointId = Convert.ToInt32(to_stoparea)
            });
            id++;
        }
        string jsonString = System.Text.Json.JsonSerializer.Serialize(intersections);
        Console.WriteLine(jsonString);
        Console.WriteLine("\"id\": \"430\",\"RouteSetId\": 430,\"ServiceJourneyInterchanges\":\""  + jsonString+"}");
    }
}
class Intersection
{
    public int Id { get; set; }
    public bool StaySeated { get; set; }
    public bool Guaranteed { get; set; }
    public int FromLineId { get; set; }
    public int ToLineId { get; set; }
    public int FromJourneyId { get; set; }
    public int ToJourneyId { get; set; }
    public int FromPointId { get; set; }
    public int ToPointId { get; set; }
}
    /*{
      "Id": 74,
      "StaySeated": true,
      "Guaranteed": true,
      "FromLineId": 5560,
      "ToLineId": 5560,
      "FromJourneyId": 1001,
      "ToJourneyId": 2002,
      "FromPointId": 11354742,
      "ToPointId": 11354742
    },*/