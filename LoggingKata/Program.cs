using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        private static ITrackable locB;
        private static GeoCoordinate corB;
        private static double distance;
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            string[] lines = File.ReadAllLines(csvPath);
            //if (lines.Length == 0)
            {
                logger.LogError("file has no input");

            }

            if (lines.Length == 1)
            {
                logger.LogWarning("file only has one line of input");

            }



            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // Done: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other.

            // Done: Create a `double` variable to store the distance

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distant = 0;


            // Done: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;

            // NESTED LOOPS SECTION----------------------------


            for (int i = 0; i < locations.Length; i++)
            {
                // Do a loop for your locations to grab each location as the origin (perhaps: 'locA')
                var locA = locations[i];

                //  Create a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // Now do another loop on the locations with the scope of your first loop, so you can grab the "destination" loca
                for (int j = 0; j < locations.Length; j++)
                {
                    // Create a new Coordinate with your locB's lat and long

                    // Now, compare the two using '.GetDistanceTo()', which returns a double

                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distant = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;

                    }
                }


                // Now, compare the two using '.GetDistanceTo()', which returns a double

                // If the distance is greater than the currently saved distance, update the distance and the two 'ITrackable' vari

            }

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart");

        }
    }
}