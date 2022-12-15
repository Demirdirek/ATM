# ATM
Basic ATM with the help of the Internet, what I did learn is using classes efficiently.

## Describing Codes

### cardHolder class
In this class my main focus was learning how to use ```class``` properly. For this I created a instances for every getter and setter but not using ```get: set:``` properties. 
```
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
```

### Main class
I will try my best to describe what I done here.

#### Menu
This lines of code mainly writes the openning screen. It is basic ```Console.WriteLine("");``` commands.
```
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
```

#### Depositing
This lines of codes mainly working as a depositer and gets the data from the ```Dictionary```.
```
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
```

#### Withdrawing
What I did here is I did find this codes in youtube that describes it best. 

Basicly ```currentUser.getBalance() < withdrawal``` statement, if the money we are trying to take larger than the our account balance, it basiccly doesnt allow it, how ever is we switch this with the else statement, it will allow us to take to money no mather what write there. 

In the ```else``` statement we are simply passing the if check and landing our money and it ```currentUser.getBalance() - withdrawal``` deletes money from our balance when we completed it. That simple. 
```
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
```

#### Showing Balance
It basically shows our balance. Too simple and lazy. ITS PERFECT! PERFECT! PERFECT!. I love every single nude peace of it. 
```
// Showing balance
void balance(cardHolder currentUser)
{
    Console.WriteLine("══════════════════════════════════════════════════════════");
    Console.WriteLine("Current Balance: " + currentUser.getBalance());
}
```

#### Users
Basic dictionary it gets date from the ```class cardHolder``` and writes it here, order is what i did write there. ```String cardNUM```, ```firstName```, ```lastName;```, ```int pin;```. Checks thoose values and sends to our program.
double balance;
```
List<cardHolder> cardHolders = new List<cardHolder>();

//card id, firstname, lastname, pin, balance
cardHolders.Add(new cardHolder("1111222233334444", "Admin", "Computer", 1111, 9999));
```

#### Entering the Card Numbers
Basicly checks the ```Dictonary``` card id input. It setted to be maximum lenght of 16 by this ```if (debitCardnum.ToString().Length == 16)``` statement.
```
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
```

#### Pin
Same as card number magic, gets the ```Dictionary``` data and checks if its correct or not. It setted to be maximum lenght of 16 by this ```if (userPin.ToString().Length == 4)``` statement.
```
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
```

#### User Interaction
After we successfully enter the program, this is the execution side of the program.
```
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
```
