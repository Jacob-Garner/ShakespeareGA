using System;
using System.Linq;
using System.Collections.Generic;

namespace ShakespeareGA.GAclasses
{
    public class GeneticAlgorithm
    {
        #region Properties

        private List<Individual> Population = new List<Individual>();
        private List<Individual> MatingPool = new List<Individual>();
        public Individual BestIndividual { get; private set; } = new Individual();
        public int Generation { get; private set; } = 0;
        private int HighestFitness = 0;

        private Random Random;

        #endregion

        #region Constructors

        //Initializes the GeneticAlgorithm with no properties set.
        public GeneticAlgorithm()
        {

        }

        //Initializes the GeneticAlgorithm with N amout of Individuals.
        public GeneticAlgorithm(int populationSize, string targetPhrase, 
            Random random, float mutationChance = 0.01f)
        {
            this.Random = random;
            this.Generation = 0;

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new Individual(targetPhrase, Random, mutationChance));
            }
        }

        #endregion

        #region Functions

        #region GA functions

        //Preforms the next time step in the evolution.
        public void EvolvePopulation()
        {
            UpdateHighestFitness();
            Selection();
            CrossoverAndMutation();
            UpdateBestIndividual();
            Generation++;
        }

        /*Selects Individuals from the population to produce the next generation.
        The higher the fitness of an Individual, the more likely it is to be chosen.*/
        private void Selection()
        {
            MatingPool.Clear();

            for (int i = 0; i < Population.Count; i++)
            {
                if (ShouldSelectIndividual(Population[i]))
                    MatingPool.Add(Population[i]);
                else
                {
                    int index = Random.Next(0, Population.Count);
                    MatingPool.Add(Population[index]);
                }
            }
        }

        /*Breeds the next generation from the Individuals in the mating pool.
        Mutation also happens in this function.*/
        private void CrossoverAndMutation()
        {
            List<Individual> newPopulation = new List<Individual>();

            for (int i = 0; i < Population.Count; i++)
            {
                Individual parent1 = ChooseParent();
                Individual parent2 = ChooseParent();
                Individual child = parent1.Crossover(parent2);
                child.Mutate();

                newPopulation.Add(child);
            }

            Population = newPopulation;
        }

        //Finds and records the best Individual of the generation.
        private void UpdateBestIndividual()
        {
            Population = Population.OrderByDescending(o => o.Fitness).ToList();
            BestIndividual = Population[0];
        }

        #endregion

        #region Helper functions

        //Selects an Individual from the breeding pool for mating.
        private Individual ChooseParent()
        {
            while (true)
            {
                int index = Random.Next(0, MatingPool.Count);

                if (ShouldSelectIndividual(MatingPool[index]))
                    return MatingPool[index];
            }
        }

        //Determines if the given Individual should be selected.
        private bool ShouldSelectIndividual(Individual individual)
        {
            float selectionChance = (float)individual.Fitness / HighestFitness;

            if (selectionChance > Random.NextDouble())
                return true;
            else
                return false;
        }

        //Gets the highest fitness of the generation.
        private void UpdateHighestFitness()
        {
            Population = Population.OrderByDescending(o => o.Fitness).ToList();
            HighestFitness = Population[0].Fitness;
        }

        #endregion

        #endregion
    }
}