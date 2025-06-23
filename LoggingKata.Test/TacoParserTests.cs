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
        [InlineData("30.39371,-87.68332,Taco Bell Fole...", 30.39371)]
        [InlineData("34.8831,-84.293899,Taco Bell Blue Ridg...", 34.8831)]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn...", 32.571331)]
        

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

        
   

        //Done: Create a test called ShouldParseLongitude
        public void ShouldParseLong(string line, double expected)
        {
            //Arrange - write the code we need in order to call the method we're testing 
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        
        
        
        
        
        
        }
    }
}
