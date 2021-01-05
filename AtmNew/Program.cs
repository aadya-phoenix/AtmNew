using System;

namespace AtmNew
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account atm = new Account();
                Console.Clear();
                Console.WriteLine(" ------------------------");
                Console.WriteLine("|  ATM System            |");
                Console.WriteLine("|                        |");
                Console.WriteLine("| 1. Enter card number   |");
                var cardNumber = Console.ReadLine();
                
                Console.WriteLine(" ------------------------");

            if (!atm.ValidateCard(cardNumber))
            {
                Console.WriteLine("Invalid Card Number");
            }
            Console.WriteLine("Enter your pin");
            var pin = int.Parse(Console.ReadLine());

            if (!atm.ValidatePin(cardNumber, pin))
            {
                Console.WriteLine("Invalid Card Pin.");
            }

            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|      ATM Secure Menu       |");
            Console.WriteLine("|                            |");
            Console.WriteLine("| 1. Check Balance           |");
            Console.WriteLine("| 2. Withdraw Balance        |");
            Console.WriteLine("| 3. Change Pin              |");
            Console.WriteLine("| 4. Logout                  |");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine(" ---------------------------");


            switch (option)
            {
                case 1:

                    long Balance = atm.BalanceCh(cardNumber, pin);


                    Console.WriteLine("Current Balance is: " + Balance);

                    break;

                case 2:
                    long BalanceInRupees = atm.Withdraw(cardNumber, pin);

                    Console.WriteLine("Enter withdraw amount");

                    int withdraw = int.Parse(Console.ReadLine());

                    Console.WriteLine("Withdrawal request of " + withdraw + "  processed");
                    break;

                case 3:

                    if (!atm.ValidatePin(cardNumber, pin))

                        Console.WriteLine("Enter your old pin");

                    var p = Console.ReadLine();

                    Console.WriteLine("Enter your new pin");

                    var newPin = Console.ReadLine();

                    Console.WriteLine("Re-enter your new pin");

                    var cnp = Console.ReadLine();

                    if (cnp == newPin)
                    {
                        Console.WriteLine("Pin Successfully  changed");
                    }
                    else
                    {
                        Console.WriteLine("Please try again");
                    }

                    break;

                default:
                    Console.WriteLine("wrong choice");
                    break;
            
            }


        }
    }
}
