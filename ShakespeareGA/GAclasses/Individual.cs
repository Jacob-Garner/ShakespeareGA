using System;

namespace ShakespeareGA.GAclasses
{
    public class Individual
    {
        #region Properties

        public char[] Genes { get; private set; }
        public int Fitness { get; private set; } = 0;
        public string WrittenPhrase { get; private set; } = "";
        private float MutationChance;

        private Random Random;

        private readonly string GenePool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .,?!";
        private string TargetPhrase;

        #endregion

        #region Constructors

        //Initializes the Individual with no properties set.
        public Individual()
        {

        }

        /*Initializes the Individual with N amout of genes, and random initializes
        those genes if "shouldInitGenes" is true.*/
        public Individual(string targetPhrase, Random random,
            float mutationChance, bool shouldInitGenes = true)
        {
            this.TargetPhrase = targetPhrase;
            this.Genes = new char[targetPhrase.Length];
            this.MutationChance = mutationChance;
            this.Random = random;

            if (shouldInitGenes)
            {
                for (int i = 0; i < Genes.Length; i++)
                    this.Genes[i] = GetRandomGene();
            }

            this.WrittenPhrase = new string(Genes);
            CalculateFitness();
        }

        #endregion

        #region Functions

        //Mates (breeds) the Individual with another given Individual.
        public Individual Crossover(Individual otherParent)
        {
            Individual child = new Individual(this.TargetPhrase, this.Random, this.MutationChance, false);

            for (int i = 0; i < child.Genes.Length; i++)
            {
                child.Genes[i] = Random.NextDouble() > 0.5 ? this.Genes[i] : otherParent.Genes[i];
            }

            child.WrittenPhrase = new string(child.Genes);
            child.CalculateFitness();
            return child;
        }

        //Randomly mutates the Individual.
        public void Mutate()
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (MutationChance > Random.NextDouble())
                    Genes[i] = GetRandomGene();
            }

            WrittenPhrase = new string(Genes);
            CalculateFitness();
        }

        //Calculates the fitness of the Individual.
        public void CalculateFitness()
        {
            Fitness = 0;

            for (int i = 0; i < Genes.Length; i++)
            {
                if (Genes[i] == TargetPhrase[i])
                    Fitness++;
            }
        }

        //Returns a random gene.
        private char GetRandomGene()
        {
            int index = Random.Next(0, GenePool.Length);
            return GenePool[index];
        }

        #endregion
    }
}