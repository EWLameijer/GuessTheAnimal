namespace GuessTheAnimal
{

    // knownanimal is eindklasse.

    internal class KnownAnimal : Question
    {
        public string Name { get; init; }

        public string Question => $"Is het een {Name}?";
    }
}