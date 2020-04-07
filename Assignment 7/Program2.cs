using System;

namespace Moody8Ball
{
    class Program
    {
        // global random generator for all to use
        public static Random random = new Random();

        // mood states for our 8-Ball
        public enum STATES { NONE, DEFAULT, ANGRY, EMPATHETIC, SARCASTIC };

        static void Main(string[] args)
        {
            // keep track of the number of questions asked
            int questionCount = 0;

            // create an oracle object to provide answers
            Oracle oracle = new Oracle();

            // banner
            Console.WriteLine("========================================");
            Console.WriteLine("You got a question...you ask the 8-Ball.");
            Console.WriteLine("========================================\n");

            // main loop (exit on q)
            while (true)
            {

                // get the next question    
                Console.Write("\nYour question (q to quit): ");
                string input = Console.ReadLine();
                

                // strip leading/trailing whitespace
                input = input.Trim();

                // check for exit condition
                if (input == "q" || input == "Q")
                {
                    break;
                }

                // answer the question
                questionCount++;
                STATES next = oracle.update(questionCount, input);
                Console.WriteLine("8-Ball says: {0}", oracle.getAnswer());

                // change to a different oracle (state) if specified
                if (next != STATES.NONE)
                {
                    oracle = getOracle(next);
                }

            }

        }

        // helper method to create a new oracle object for the specified state
        private static Oracle getOracle(STATES next)
        {
            switch (next)
            {
                case STATES.ANGRY:
                    return new AngryOracle();
                case STATES.EMPATHETIC:
                    return new EmpatheticOracle();
                case STATES.SARCASTIC:
                    return new SarcasticOracle();
            }
            // default
            return new Oracle();
        }
    }

    // simple public-data class to hold text-type pairs for answers
    // each answer is classified as positive, negative or non-committal
    class Answer
    {
        public enum TYPE { POSITIVE, NEGATIVE, NONCOMMITTAL };

        public Answer(string t, TYPE type)
        {
            Text = t;
            Type = type;
        }

        public string Text;
        public TYPE Type;
    }

    // class to generate answers in a certain way
    class Oracle
    {
        // recognizes three types of input
        public enum INPUT_TYPE { QUESTION, STATEMENT, SHOUTING };
        // the answers for this default oracle
        protected static Answer[] ANSWERS = {
            new Answer("It is certain", Answer.TYPE.POSITIVE),
            new Answer("Without a doubt", Answer.TYPE.POSITIVE),
            new Answer("You may rely on it", Answer.TYPE.POSITIVE),
            new Answer("Signs point to yes", Answer.TYPE.POSITIVE),
            new Answer("As I see it, yes", Answer.TYPE.POSITIVE),
            new Answer("My reply is no", Answer.TYPE.NEGATIVE),
            new Answer("Don't count on it", Answer.TYPE.NEGATIVE),
            new Answer("Very doubtful", Answer.TYPE.NEGATIVE),
            new Answer("My sources say no", Answer.TYPE.NEGATIVE),
            new Answer("Outlook not so good", Answer.TYPE.NEGATIVE),
            new Answer("Reply hazy try again", Answer.TYPE.NONCOMMITTAL),
            new Answer("Ask again later", Answer.TYPE.NONCOMMITTAL),
            new Answer("Better not tell you now", Answer.TYPE.NONCOMMITTAL),
            new Answer("Concentrate and ask again", Answer.TYPE.NONCOMMITTAL),
            new Answer("Cannot predict now", Answer.TYPE.NONCOMMITTAL)
        };

        // update method takes the input and question number and sets the nextAnswer internally
        // it also returns what state the 8-ball should change to, if any (None for no change)
        protected string nextAnswer;
        protected int shoutCounter = 0;
        protected int statementCounter = 0;
        protected int questionCounter = 0;
        public string userInput;
        public virtual Program.STATES update(int question_number, string input)
        {

            // update answer based on input (default is purely random)
            if (inputType(input) == INPUT_TYPE.SHOUTING)
            {
                if (shoutCounter > 1)
                {
                    nextAnswer = "Now you've made me angry.";
                    return Program.STATES.ANGRY;
                }
                else
                {
                    nextAnswer = "Please stop shouting.";
                    shoutCounter++;
                }

            }
            else if (inputType(input) == INPUT_TYPE.QUESTION)
            {
                if (questionCounter == 3)
                {
                    nextAnswer = "You've me so happy!";
                    return Program.STATES.EMPATHETIC;
                }
                else
                {
                    shoutCounter--;
                    questionCounter++;
                    int selection = Moody8Ball.Program.random.Next(ANSWERS.Length);
                    nextAnswer = ANSWERS[selection].Text;
                }
            }
            else if (inputType(input) == INPUT_TYPE.STATEMENT)
            {
                if (statementCounter > 0)
                {
                    nextAnswer = "Sarcasm mode activated.";
                    return Program.STATES.SARCASTIC;
                }
                else
                {
                    statementCounter++;
                    nextAnswer = "That's not a question genius.";
                }
            }
            else
            {
                int selection = Moody8Ball.Program.random.Next(ANSWERS.Length);
                nextAnswer = ANSWERS[selection].Text;

            }

            // return next state (no transition)
            return Program.STATES.NONE;
        }

        // accessor to get the last stored answer
        public string getAnswer()
        {
            // return the answer set by update
            return nextAnswer;
        }

        // helper method to classify the type of input
        public INPUT_TYPE inputType(string input)
        {
            if (input[input.Length - 1] == '!')
                return INPUT_TYPE.SHOUTING;
            else if (input[input.Length - 1] == '?')
                return INPUT_TYPE.QUESTION;
            else
                return INPUT_TYPE.STATEMENT;
        }
    }
    class AngryOracle : Oracle
    {
        public override Program.STATES update(int question_number, string input)
        {
            nextAnswer = "REEEEEEEEEEEEEEEEE!!!";
            if (inputType(input) == INPUT_TYPE.QUESTION)
            {
                shoutCounter--;
            }
            if (shoutCounter < 1)
            {
                return Program.STATES.DEFAULT;
            }
            return Program.STATES.NONE;
        }
    }

    class SarcasticOracle : Oracle
    {
        public override Program.STATES update(int question_number, string input)
        {

            userInput = input;
            if (inputType(input) == INPUT_TYPE.STATEMENT)
            {
                nextAnswer = "Genius alert.";
            }
            else if (inputType(input) == INPUT_TYPE.QUESTION)
            {
                nextAnswer = "Example of a stupid question: " + userInput;
            }
            else if (inputType(input) == INPUT_TYPE.SHOUTING)
            {
                nextAnswer = "Okay! Okay! Jeez...";
                return Program.STATES.DEFAULT;
            }
            
            return Program.STATES.NONE;
        }
    }

    class EmpatheticOracle : Oracle
    {
        public override Program.STATES update(int question_number, string input)
        {
            if (inputType(input) == INPUT_TYPE.QUESTION)
            {
                int selection = Moody8Ball.Program.random.Next(ANSWERS.Length);
                nextAnswer = ANSWERS[selection].Text;
                var myType = ANSWERS[selection].Type; 
                
                if (myType == Answer.TYPE.POSITIVE)
                {
                    nextAnswer = "Isn't that great?!";
                }
                else if (myType == Answer.TYPE.NEGATIVE)
                {
                    nextAnswer = "I'm so sorry.";
                }
                else if (myType == Answer.TYPE.NONCOMMITTAL)
                    nextAnswer = "You're so great.";
            }
            else if (inputType(input) == INPUT_TYPE.SHOUTING)
            {
                if (shoutCounter > 1)
                    {
                    nextAnswer = "Now you've made me angry.";
                    return Program.STATES.ANGRY;
                    }
                else
                    {
                    nextAnswer = "Please stop shouting.";
                    shoutCounter++;
                    }
            }
            else if (inputType(input) == INPUT_TYPE.STATEMENT)
            {
                if (statementCounter > 0)
                {
                    nextAnswer = "Sarcasm mode activated.";
                    return Program.STATES.SARCASTIC;
                }
                else
                {
                    statementCounter++;
                    nextAnswer = "That's not a question genius.";
                }
            }
            return Program.STATES.NONE;
        }
    }
}