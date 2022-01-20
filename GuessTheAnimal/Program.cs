namespace GuessTheAnimal
{
    public class Program
    {
        static void Main()
        {
            var startOfAnswer = 'n';
            do
            {
                // Verwelkom gebruiker
                Console.WriteLine("Hallo! Welkom bij dieren raden.");
                Console.WriteLine("Neem een dier in gedachten, ik probeer het te raden.");
                // Stel gebruiker vragen
                Question question = new KnownAnimal { Name = "koe" };
                Console.WriteLine(question.Question);
                var guessed = GetAnswerChar();
                if (guessed == 'j') Console.WriteLine("Ik heb gewonnen!");
                else
                {
                    if (question is KnownAnimal) Console.WriteLine("Ik geef het op!");
                    else
                    {
                        var realQuestion = (ChoiceQuestion)question;
                        if (guessed == 'j') question = realQuestion.YesAnswer;
                        else question = realQuestion.NoAnswer;
                    }
                    // scenario1 : ik ben bij een eindknoop (dier) en weet het niet 
                    // scenario2: ik ben bij een vraag met nog ja en nee en weet het niet.

                }
                // op basis van antwoord, stel nieuwe vraag
                // als je het hebt geraden, dank voor het spel
                // als je het NIET hebt geraden, vraag om een onderscheidende vraag

                // vraag of de gebruiker nog eens wil spelen
                Console.WriteLine("Wil je nog eens spelen?");
                // krijg antwoord van gebruiker
                startOfAnswer = GetAnswerChar();
            } while (startOfAnswer == 'j');
        }

        private static char GetAnswerChar()
        {
            var answer = Console.ReadLine();
            if (!string.IsNullOrEmpty(answer))
            {
                return answer.ToLower().First();
            }
            return 'n';
        }
    }


}
