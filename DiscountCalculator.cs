public interface IDiscountStrategy {
    double CalculateDiscount(double amount);
}

public class RegularDiscount : IDiscountStrategy {
    public double CalculateDiscount(double amount) {
        return amount;
    }
}

public class SilverDiscount : IDiscountStrategy {
    public double CalculateDiscount(double amount) {
        return amount * 0.9; // 10% скидка
    }
}

public class GoldDiscount : IDiscountStrategy {
    public double CalculateDiscount(double amount) {
        return amount * 0.8; // 20% скидка
    }
}

public class DiscountCalculator {
    private readonly Dictionary<CustomerType, IDiscountStrategy> strategies;

    public DiscountCalculator() {
        strategies = new Dictionary<CustomerType, IDiscountStrategy> {
            { CustomerType.Regular, new RegularDiscount() },
            { CustomerType.Silver, new SilverDiscount() },
            { CustomerType.Gold, new GoldDiscount() }
        };
    }

    public double CalculateDiscount(CustomerType customerType, double amount) {
        if (strategies.TryGetValue(customerType, out var strategy)) {
            return strategy.CalculateDiscount(amount);
        }
        throw new ArgumentException("Неизвестный тип клиента");
    }
}

