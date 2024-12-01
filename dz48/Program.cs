using System;
// Завдання 1 
/*class CreditCard
{
    public string CardNumber;
    public string CardHolderName;
    public string CVC;
    public string ExpiryDate;

    public CreditCard(string cardNumber, string cardHolderName, string cvc, string expiryDate)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        CVC = cvc;
        ExpiryDate = expiryDate;
    }

    public void PrintCardInfo()
    {
        Console.WriteLine("Credit card:");
        Console.WriteLine($"Card number: {CardNumber}");
        Console.WriteLine($"The owner: {CardHolderName}");
        Console.WriteLine($"CVC: {CVC}");
        Console.WriteLine($"Expiration date: {ExpiryDate}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the card number: ");
        string cardNumber = Console.ReadLine();

        Console.Write("Enter the owner's name: ");
        string cardHolderName = Console.ReadLine();

        Console.Write("Enter the CVC: ");
        string cvc = Console.ReadLine();

        Console.Write("Enter the expiration date: ");
        string expiryDate = Console.ReadLine();

        CreditCard card = new CreditCard(cardNumber, cardHolderName, cvc, expiryDate);

        card.PrintCardInfo();
    }
}*/

class CreditCard
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string CVC { get; set; }
    public decimal Balance { get; set; }

    public CreditCard(string cardNumber, string cardHolderName, string cvc, decimal balance)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        CVC = cvc;
        Balance = balance;
    }

    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        card.Balance += amount;
        return card;
    }

    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        card.Balance -= amount;
        return card;
    }

    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        return card1.CVC == card2.CVC;
    }

    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return card1.CVC != card2.CVC;
    }

    public override bool Equals(object obj)
    {
        if (obj is CreditCard)
        {
            CreditCard other = (CreditCard)obj;
            return this.CVC == other.CVC;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return CVC.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        CreditCard card1 = new CreditCard("1234 5678 9876 5432", "Ivan Ivanov", "126", 500);

        Console.WriteLine($"Card number: {card1.CardNumber}");
        Console.WriteLine($"Balance: {card1.Balance} грн");

        card1 += 200;
        Console.WriteLine("\nAfter depositing UAH 200:");
        Console.WriteLine($"Balance: {card1.Balance} UAH");

        card1 -= 100;
        Console.WriteLine("\nAfter withdrawing 100 UAH:");
        Console.WriteLine($"Balance: {card1.Balance} UAH");

        CreditCard card2 = new CreditCard("2345 6789 8765 4321", "Peter Petrov", "123", 300);
        Console.WriteLine("\nChecking for CVC code equality:");
        Console.WriteLine(card1 == card2 ? "CVC codes are the same" : "CVC codes are different");
    }
}
