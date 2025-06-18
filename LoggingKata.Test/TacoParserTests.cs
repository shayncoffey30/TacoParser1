using System;
using System.Collections.Generic;
using Xunit;


namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        private IEnumerable<object> expected;
        private object line;
        private object tacoParserInstance;


        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange -write the code we need in order to call the method we're testing
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLat(string line, double expected)
        {
            // Done: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange - write the code we need in order to call the method we're testing 
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }


        //Done: Create a test called ShouldParseLatitude

    }
}
