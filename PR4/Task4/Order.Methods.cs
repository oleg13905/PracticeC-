partial class Order
{
    public Order(int i, string c, decimal s)
    {
        id = i;
        cust = c;
        sum = s;
    }

    public bool IsHighValue(decimal min)
    {
        return sum > min;
    }
}
