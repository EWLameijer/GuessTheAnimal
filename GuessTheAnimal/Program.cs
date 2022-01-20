namespace GuessTheConcept
{
    public class Program
    {
        private static Question s_startingQuestion = new KnownConcept { Name = "interface" };

        static void Main()
        {
            var startOfAnswer = 'n';
            do
            {
                // Verwelkom gebruiker
                Console.WriteLine("Hallo! Welkom bij C#-termen raden.");
                Console.WriteLine("Neem een C#-term in gedachten, ik probeer het te raden.");
                // Stel gebruiker vragen
                AskQuestions(s_startingQuestion, null, true);

                // vraag of de gebruiker nog eens wil spelen
                Console.WriteLine("Wil je nog eens spelen?");
                // krijg antwoord van gebruiker
                startOfAnswer = GetAnswerChar();
            } while (startOfAnswer == 'j');
        }

        private static Question AskQuestions(Question baseQuestion, ChoiceQuestion? parentQuestion, bool wasYes)
        {
            var question = baseQuestion;
            Console.WriteLine(question.Question);
            var guessed = GetAnswerChar();
            if (question is KnownConcept)
            {
                if (guessed == 'j')
                {

                    Console.WriteLine("Ik heb gewonnen!");
                }
                else
                {
                    var guessedConcept = (KnownConcept)baseQuestion;
                    Console.WriteLine("Ik geef het op!");
                    Console.WriteLine("Wat was het?");
                    var actualConcept = Console.ReadLine()?.ToLower();
                    var actualAnswer = new KnownConcept { Name = actualConcept! };
                    Console.WriteLine($"En wat is een vraag die voor '{actualConcept}' ja is, en voor '{guessedConcept.Name}' nee ?");
                    var discriminatingQuestion = Console.ReadLine();
                    var newQuestion = new ChoiceQuestion
                    {
                        Question = discriminatingQuestion!,
                        YesAnswer = actualAnswer,
                        NoAnswer = question
                    };
                    if (parentQuestion == null) s_startingQuestion = newQuestion;
                    else if (wasYes) parentQuestion.YesAnswer = newQuestion;
                    else parentQuestion.NoAnswer = newQuestion;




                }
            }
            else
            {
                // op basis van antwoord, stel nieuwe vraag
                Question newQuestion;
                var questionAsChoiceQuestion = (ChoiceQuestion)question;
                if (guessed == 'j') newQuestion = questionAsChoiceQuestion.YesAnswer;
                else newQuestion = questionAsChoiceQuestion.NoAnswer;
                AskQuestions(newQuestion, questionAsChoiceQuestion, guessed == 'j');
            }
            // scenario1 : ik ben bij een eindknoop (dier) en weet het niet 
            // scenario2: ik ben bij een vraag met nog ja en nee en weet het niet.



            return baseQuestion;
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
