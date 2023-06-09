class Address
{
    private string number;

    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }

    public Address(string city, string street, int number)
    {
        City = city;
        Street = street;
        Number = number;
    }

    public Address(string city, string street, string number)
    {
        City = city;
        Street = street;
        this.number = number;
    }
}

