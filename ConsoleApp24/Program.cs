using System;

class PhysicalBody
{
    protected double massGrams;
    protected double velocity;

    public PhysicalBody(double massGrams, double velocity)
    {
        this.massGrams = massGrams;
        this.velocity = velocity;
    }

    public virtual string GetInfo()
    {
        return $"Маса тіла: {massGrams} г, Швидкість: {velocity} м/с";
    }

    public virtual string ProcessData()
    {
        double massKg = massGrams / 1000;
        double energy = 0.5 * massKg * velocity * velocity;
        return $"Кінетична енергія: {energy:F2} Дж";
    }
}

// Клас-нащадок
class FallingBody : PhysicalBody
{
    private double height; // додаткове поле

    public FallingBody(double massGrams, double velocity, double height)
        : base(massGrams, velocity)
    {
        this.height = height;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Висота: {height} м";
    }

    // Новий метод обробки — потенційна енергія
    public override string ProcessData()
    {
        double massKg = massGrams / 1000;
        double potentialEnergy = massKg * 9.81 * height;
        return $"Потенціальна енергія: {potentialEnergy:F2} Дж";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть масу тіла (в грамах): ");
        double m = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть швидкість тіла (в м/с): ");
        double v = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть висоту падіння тіла (в метрах): ");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- Об'єкт класу PhysicalBody ---");
        PhysicalBody body = new PhysicalBody(m, v);
        Console.WriteLine(body.GetInfo());
        Console.WriteLine(body.ProcessData());

        Console.WriteLine("\n--- Об'єкт класу FallingBody ---");
        FallingBody fallingBody = new FallingBody(m, v, h);
        Console.WriteLine(fallingBody.GetInfo());
        Console.WriteLine(fallingBody.ProcessData());
    }
}
