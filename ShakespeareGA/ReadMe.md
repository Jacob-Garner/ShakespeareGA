# ShakespeareGA:

### Version: 1.0.0.0

ShakespeareGA is a simple implementation of a genetic algorithm in C#.
The goal of this genetic algorithm is to evolve an individual to write 
the phrase "To be or not to be" from Shakespeare. Here are the defualt
settings of the application:
Phrase to be written: "To be or not to be"
Population size per generation: 500
Chance for an individual to mutate: 0.01%
The program averages 33.1 generations with these settings 
(average based on 10 runs).

For more info on genetic algorithms, see the [wikipedia](https://en.wikipedia.org/wiki/Genetic_algorithm) page on it.

## Modification guide:

You can change the settings of the genetic algorithm if you would like to
test different scenarios.

*To change the phrase to be written*
1. Open "Program.cs"
2. In "Main" find the line
   ```C#
   string targetPhrase = "To be or not to be";
   ```
3. Change the text inside the quotation marks to what ever you want.

*To change the population size*
1. Open "Program.cs"
2. In "Main" find the line
   ```C#
   int populationSize = 500;
   ```
3. Change the value to whatever you want. 
   (Values around 2000 and higher may cuase the program to slow down)

*To change the chance of mutation*
1. Open "Program.cs"
2. In "Main" find the line
   ```C#
   GeneticAlgorithm ShakespeareGA = 
       new GeneticAlgorithm(populationSize, targetPhrase, random);
   ```
3. After the "random" argument, add a comma and a space, followed by the value 
   you want to set the chance of mutation to.

# Change log:

08/07/2019 - First version finished.