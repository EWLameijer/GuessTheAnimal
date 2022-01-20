namespace GuessTheConcept
{
    internal class ChoiceQuestion : Question
    {
        public string Question { get; init; }

        public Question YesAnswer { get; set; }

        public Question NoAnswer { get; set; }

    }
}
