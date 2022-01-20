namespace GuessTheConcept
{

    // knownconcept is eindklasse.

    internal class KnownConcept : Question
    {
        public string Name { get; init; }

        public string Question => $"Is het '{Name}'?";
    }
}