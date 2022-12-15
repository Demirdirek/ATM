using System;
using System.ComponentModel;
using System.Linq.Expressions;

public class cardHolder
{
    String cardNUM, firstName, lastName;
    int pin;
    double balance;

    public cardHolder(string cardNUM, string firstName, string lastName, int pin, double balance)
    {
        this.cardNUM = cardNUM;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
    }

    public String getNum() { return cardNUM; }
    public void setNum(String newCardNum) { cardNUM = newCardNum; }

    public int getPin() { return pin; }
    public void setPin(int NewPin) { pin = NewPin; }

    public String getFirstName() { return firstName; }
    public void setFirstName(String newFirstName) { firstName = newFirstName; }

    public String getLastName() { return lastName; }
    public void setLastName(String newLastName) { lastName = newLastName; }

    public double getBalance() { return balance; }
    public void setBalance(double newBalance) { balance = newBalance; }



    public static void Main(String[] args)
    {
        // Menu
        void PrintOptions()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine("══════════════════════════════════════════════════════════");
        }

        // Depositing
        void deposit(cardHolder currentUser)
        {
            //should add try catch
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.Write("How much $ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine(deposit + " $ deposited to your bank!");
            Console.WriteLine("Your new balance is " + currentUser.getBalance());
            Console.WriteLine("══════════════════════════════════════════════════════════");
        }

        // Withdrawing
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.Write("How much you would like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if user have enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficent balance!");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you!");
            }
        }

        // Showing balance
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        //card id, firstname, lastname, pin, balance
        cardHolders.Add(new cardHolder("1111222233334444", "Admin", "Computer", 1111, 9999));

        //Enterences Menu, Promt User
        Console.WriteLine("══════════════════════════════════════════════════════════");
        Console.WriteLine("Welcome to Demirdirek ATM, your security isn't considered!");
        Console.Write("Plase insert you debit card: ");
        String debitCardnum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardnum = Console.ReadLine();
                //Check against our data base
                currentUser = cardHolders.FirstOrDefault(a => a.cardNUM == debitCardnum);
                if (debitCardnum.ToString().Length == 16)
                {
                    if (currentUser != null) { break; }
                    else { Console.Write("Card not recognized. Plase insert your debit card again: "); }
                }
                else { Console.WriteLine("Card No must be 16 digits."); }
            }
            catch { Console.WriteLine("Card not recognized. Plase insert you debit card again: "); }
        }

        //Entering pin
        Console.Write("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (userPin.ToString().Length == 4)
                {
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.Write("Incorrect pin. Please write your PIN again: "); }
                }
                else { Console.WriteLine("PIN must be 4 digits."); }
            }
            catch { Console.WriteLine("Incorrect pin, please try again."); }
        }

        Console.WriteLine("══════════════════════════════════════════════════════════");

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        do
        {
            PrintOptions();
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balance(currentUser);
                    break;
                case 4:
                    Environment.Exit(0);
                    Console.WriteLine("Thank you for choosing us!");
                    break;
                default:
                    Console.WriteLine("══════════════════════════════════════════════════════════");
                    Console.WriteLine("Please choose from list numbers.");
                    break;

            }
        } while (true);
    }
}